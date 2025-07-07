using System;
using System.Collections.Generic;
using System.Linq;
using NodaTime;

namespace HL7;

public sealed record Message {
    public IReadOnlyList<Segment> Segments { get; init; }
    public string HL7RawMessage { get; init; }
    public string Version { get; init; }
    public Instant? MessageDateTime { get; init; }
    public string MessageType { get; init; }
    public string MessageControlId { get; init; }
    public string ProcessingId { get; init; }
    public HL7Encoding Encoding { get; init; }

    private static readonly string[] SegmentDelimiters = ["\r\n", "\n\r", "\r", "\n"];

    private record MetaData(
        string Version,
        string MessageType,
        string MessageControlId,
        string ProcessingId,
        Instant? MessageDateTime
    );

    private Message(IReadOnlyList<Segment> Segments, string hl7RawMessage, string Version, string MessageType,
        string MessageControlId, string ProcessingId, HL7Encoding Encoding, Instant? messageDateTime) {
        this.Segments = Segments;
        HL7RawMessage = hl7RawMessage;
        this.Version = Version;
        this.MessageType = MessageType;
        this.MessageControlId = MessageControlId;
        this.ProcessingId = ProcessingId;
        this.Encoding = Encoding;
        this.MessageDateTime = messageDateTime;
    }

    private Message(IReadOnlyList<Segment> Segments, string hl7RawMessage, HL7Encoding Encoding, MetaData meta)
        : this(Segments, hl7RawMessage, meta.Version, meta.MessageType, meta.MessageControlId, meta.ProcessingId, Encoding, meta.MessageDateTime) { }

    public static Message Parse(string rawMessage) {
        try {
            var hL7Message = getMessage(rawMessage);
            var firstSegment = getFirstSegment(hL7Message);
            var (mshSegment, encoding) = Segment.ParseMSH(firstSegment);

            var rawSegments = hL7Message
                .Split(SegmentDelimiters, StringSplitOptions.RemoveEmptyEntries)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Skip(1);
            var segments = new List<Segment> { mshSegment };
            segments.AddRange(rawSegments.Select((t, i) => Segment.Parse(encoding, t, i + 1)));

            var meta = getMetaData(mshSegment, encoding);

            return new Message(segments.AsReadOnly(), hL7Message, encoding, meta);
        } catch (Exception? ex) {
            throw new HL7Exception("Failed to validate the message with error - " + ex.Message, HL7Exception.ParsingError, ex);
        }

        static string getMessage(string rawMessage) {
            var start = 0;
            var end = rawMessage.Length;

            var vtIndex = rawMessage.IndexOf('\x0B');
            if (vtIndex >= 0) start = vtIndex + 1;

            var fsIndex = rawMessage.IndexOf('\x1C', start);
            if (fsIndex >= 0) end = fsIndex;

            var cleaned = rawMessage[start..end];

            if (string.IsNullOrEmpty(cleaned)) throw new HL7Exception("No Message Found", HL7Exception.BadMessage);
            if (cleaned.Length < 20) throw new HL7Exception($"Message Length too short: {cleaned.Length} chars.", HL7Exception.BadMessage);

            return cleaned;
        }

        static string getFirstSegment(string hl7Message) {
            var firstSegmentEnd = -1;
            foreach (var d in SegmentDelimiters) {
                var idx = hl7Message.IndexOf(d, StringComparison.Ordinal);
                if (idx >= 0 && (firstSegmentEnd == -1 || idx < firstSegmentEnd)) {
                    firstSegmentEnd = idx;
                }
            }
            if (firstSegmentEnd <= 0) throw new HL7Exception("Missing MSH segment.", HL7Exception.BadMessage);
            return hl7Message[..firstSegmentEnd];
        }
    }

    private static MetaData getMetaData(Segment mshSegment, HL7Encoding encoding) {
        if (mshSegment.Name != "MSH") throw new HL7Exception("First segment is not MSH", HL7Exception.BadMessage);
        if (mshSegment.Fields.Count < 11) throw new HL7Exception("MSH segment doesn't contain all the required fields", HL7Exception.BadMessage);

        string version;
        string messageStructure = "";
        Instant? messageDateTime = null;

        if (mshSegment.Fields.Count >= 12)
            version = encoding.Decode(mshSegment.Fields[11].Value.Split(encoding.ComponentDelimiter)[0]);
        else
            throw new HL7Exception("HL7 version not found in the MSH segment", HL7Exception.RequiredFieldMissing);

        try {
            var msh9 = encoding.Decode(mshSegment.Fields[8].Value);
            if (!string.IsNullOrEmpty(msh9)) {
                var msh9Comps = msh9.Split(encoding.ComponentDelimiter);
                if (msh9Comps.Length >= 3) messageStructure = msh9Comps[2];
                else if (msh9Comps.Length > 0 && msh9Comps[0].Equals("ACK", StringComparison.Ordinal)) messageStructure = "ACK";
                else if (msh9Comps.Length == 2) messageStructure = msh9Comps[0] + "_" + msh9Comps[1];
                else throw new HL7Exception("Message Type & Trigger Event value not found in message", HL7Exception.UnsupportedMessageType);
            }
        } catch (IndexOutOfRangeException? e) {
            throw new HL7Exception("Can't find message structure (MSH.9.3) - " + e.Message, HL7Exception.UnsupportedMessageType, e);
        }

        var messageControlId = encoding.Decode(mshSegment.Fields[9].Value);
        var processingId = encoding.Decode(mshSegment.Fields[10].Value);

        // Parse MSH-7 (Date/Time of Message) if present
        try {
            if (mshSegment.Fields.Count > 6) {
                var msh7Raw = encoding.Decode(mshSegment.Fields[6].Value);
                if (!string.IsNullOrWhiteSpace(msh7Raw)) messageDateTime = Hl7DateParser.ParseInstant(msh7Raw);
            }
        } catch {
            // If parsing fails, leave messageDateTime as null (optionally log or handle as needed)
        }

        return new MetaData(version, messageStructure, messageControlId, processingId, messageDateTime);
    }

    public string SerializeMessage() {
        try {
            return string.Join(Encoding.SegmentDelimiter, Segments.Select(s => s.Serialize(Encoding)));
        } catch (Exception? ex) {
            throw new HL7Exception("Failed to serialize the message with error - " + ex.Message,
                HL7Exception.SerializationError, ex);
        }
    }

    public bool Equals(Message? other) {
        if (ReferenceEquals(this, other)) return true;
        if (other is null) return false;
        if (Segments.Count != other.Segments.Count) return false;

        var diff = Segments.Where((t, i) => !t.Equals(other.Segments[i]));
        return !diff.Any();
    }

    public override int GetHashCode() => Segments.Aggregate(17, (current, segment) => current * 31 + segment.GetHashCode());
}
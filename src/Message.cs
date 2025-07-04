using System;
using System.Collections.Generic;
using System.Linq;
using NodaTime;

namespace HL7;

public sealed record Message {
    public IReadOnlyList<Segment> Segments { get; init; }
    public string HL7Message { get; init; }
    public string Version { get; init; }
    public Instant? MessageDateTime { get; init; }
    public string MessageStructure { get; init; }
    public string MessageControlId { get; init; }
    public string ProcessingId { get; init; }
    public HL7Encoding Encoding { get; init; }

    private static readonly string[] SegmentDelimiters = ["\r\n", "\n\r", "\r", "\n"];

    private record MetaData(
        string Version,
        string MessageStructure,
        string MessageControlId,
        string ProcessingId,
        Instant? MessageDateTime
    );

    private Message(IReadOnlyList<Segment> Segments, string hl7Message, string Version, string MessageStructure,
        string MessageControlId, string ProcessingId, HL7Encoding Encoding, Instant? messageDateTime) {
        this.Segments = Segments;
        HL7Message = hl7Message;
        this.Version = Version;
        this.MessageStructure = MessageStructure;
        this.MessageControlId = MessageControlId;
        this.ProcessingId = ProcessingId;
        this.Encoding = Encoding;
        this.MessageDateTime = messageDateTime;
    }

    private Message(IReadOnlyList<Segment> Segments, string hl7Message, HL7Encoding Encoding, MetaData meta)
        : this(Segments, hl7Message, meta.Version, meta.MessageStructure, meta.MessageControlId, meta.ProcessingId, Encoding, meta.MessageDateTime) {
    }

    public static Message Parse(string hL7Message) {
        try {
            if (string.IsNullOrEmpty(hL7Message)) throw new HL7Exception("No Message Found", HL7Exception.BadMessage);
            if (hL7Message.Length < 20) throw new HL7Exception($"Message Length too short: {hL7Message.Length} chars.", HL7Exception.BadMessage);
            if (!hL7Message.StartsWith("MSH", StringComparison.Ordinal)) throw new HL7Exception("MSH segment not found at the beginning of the message", HL7Exception.BadMessage);

            var encoding = HL7Encoding.FromMessage(hL7Message);
            var segments = hL7Message
                .Split(SegmentDelimiters, StringSplitOptions.RemoveEmptyEntries)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select((rawSegment, idx) => Segment.Parse(encoding, rawSegment, idx))
                .ToArray();
            if (segments.Length == 0) throw new HL7Exception("No segments found in message", HL7Exception.BadMessage);

            var mshSegment = segments.First();
            var meta = getMetaData(mshSegment, encoding);

            return new Message(segments.AsReadOnly(), hL7Message, encoding, meta);
        } catch (Exception? ex) {
            throw new HL7Exception("Failed to validate the message with error - " + ex.Message, HL7Exception.ParsingError, ex);
        }
    }

    private static MetaData getMetaData(Segment mshSegment, HL7Encoding encoding) {
        if (mshSegment.Name != "MSH") throw new HL7Exception("First segment is not MSH", HL7Exception.BadMessage);
        if (mshSegment.Fields.Count < 11)
            throw new HL7Exception("MSH segment doesn't contain all the required fields", HL7Exception.BadMessage);

        string version;
        string messageStructure;
        string messageControlId;
        string processingId;
        Instant? messageDateTime = null;

        if (mshSegment.Fields.Count >= 12)
            version = encoding.Decode(mshSegment.Fields[11].Value.Split(encoding.ComponentDelimiter)[0]);
        else
            throw new HL7Exception("HL7 version not found in the MSH segment", HL7Exception.RequiredFieldMissing);

        try {
            var msh9 = encoding.Decode(mshSegment.Fields[8].Value);
            if (string.IsNullOrEmpty(msh9)) throw new HL7Exception("MSH.9 not available", HL7Exception.UnsupportedMessageType);

            var msh9Comps = msh9.Split(encoding.ComponentDelimiter);
            if (msh9Comps.Length >= 3) messageStructure = msh9Comps[2];
            else if (msh9Comps.Length > 0 && msh9Comps[0].Equals("ACK", StringComparison.Ordinal)) messageStructure = "ACK";
            else if (msh9Comps.Length == 2) messageStructure = msh9Comps[0] + "_" + msh9Comps[1];
            else throw new HL7Exception("Message Type & Trigger Event value not found in message", HL7Exception.UnsupportedMessageType);
        } catch (IndexOutOfRangeException? e) {
            throw new HL7Exception("Can't find message structure (MSH.9.3) - " + e.Message, HL7Exception.UnsupportedMessageType, e);
        }

        try {
            messageControlId = encoding.Decode(mshSegment.Fields[9].Value);
            if (string.IsNullOrEmpty(messageControlId))
                throw new HL7Exception("MSH.10 - Message Control ID not found", HL7Exception.RequiredFieldMissing);
        } catch (Exception? ex) {
            throw new HL7Exception("Error occured while accessing MSH.10 - " + ex.Message,
                HL7Exception.RequiredFieldMissing, ex);
        }

        try {
            processingId = encoding.Decode(mshSegment.Fields[10].Value);
            if (string.IsNullOrEmpty(processingId))
                throw new HL7Exception("MSH.11 - Processing ID not found", HL7Exception.RequiredFieldMissing);
        } catch (Exception? ex) {
            throw new HL7Exception("Error occured while accessing MSH.11 - " + ex.Message,
                HL7Exception.RequiredFieldMissing, ex);
        }

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
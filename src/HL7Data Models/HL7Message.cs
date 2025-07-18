using System;
using System.Collections.Generic;
using System.Linq;

namespace HL7;

public record Hl7Message : Hl7DataType{
    private readonly List<Hl7Segment> allSegments = [];

    public MSH MSH => allSegments.OfType<MSH>().Single();

    private Hl7Message() { }

    public void AddHl7Segment(Hl7Segment segment) => allSegments.Add(segment);

    public ICollection<Hl7Segment> AllSegments => allSegments.AsReadOnly();

    public ICollection<T> GetHl7Segments<T>() where T : Hl7Segment => allSegments.OfType<T>().ToArray();

    public static Hl7Message Create(string rawMessageString) {
        var msg = new Hl7Message();
        msg.loadHL7Message(rawMessageString);
        return msg;
    }

    public static bool TryCreate(string rawMessageString, out Hl7Message? result) {
        try {
            var msg = new Hl7Message();
            msg.loadHL7Message(rawMessageString);
            result = msg;
            return true;
        } catch (Exception) {
            result = null;
            return false;
        }

    }

    private void loadHL7Message(string rawMessageString) {
        var message = Message.Parse(rawMessageString);
        AddHl7Segment(new MSH(message.MshSegment));
        foreach (var rawSegment in message.Segments.Where(s => s.Name != "MSH")) {
            AddHl7Segment(Hl7DataLoader.CreateHl7Segment(rawSegment));
        }
    }

    public string Serialize() => Serialize(MSH.Encoding, Hl7Structure.Hl7Message);

    public override string Serialize(Hl7Encoding encoding, Hl7Structure? sourceStructure = null) {
        try {
            return string.Join(encoding.SegmentDelimiter, AllSegments.Select(seg => seg.Serialize(encoding, Hl7Structure.Hl7Segment)));

        } catch (Exception? ex) {
            throw new Hl7Exception("Failed to serialize the message with error - " + ex.Message, Hl7Exception.SerializationError, ex);
        }
    }
}
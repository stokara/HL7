using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace HL7;

public class HL7Message {
    public IImmutableDictionary<Type, IImmutableList<IHl7Segment>> HL7Records { get; private set; } = null!;
    public MSH MSH => (MSH)HL7Records[typeof(MSH)].Single();
    private readonly Dictionary<Type, List<IHl7Segment>> dict = new();

    private HL7Message() { }

    public ICollection<T> GetRecords<T>() where T : IHl7Segment {
        return HL7Records.TryGetValue(typeof(T), out var records) ? records.Cast<T>().ToArray() : [];
    }

    public static HL7Message? Create(string hl7Message) {
        var msg = new HL7Message();
        return msg.loadHL7Message(hl7Message) ? msg : null;
    }

    public static bool TryCreate(string hl7Message, out HL7Message? result) {
        var msg = new HL7Message();
        if (msg.loadHL7Message(hl7Message)) {
            result = msg;
            return true;
        }

        result = null;
        return false;
    }

    private bool loadHL7Message(string hl7Message) {
        var message = Message.Parse(hl7Message);
        var msh = new MSH(message.Segments[0]);
        dict.Add(typeof(MSH), [msh]);
        foreach (var segment in message.Segments.Where(s => s.Name != "MSH")) {
            var hl7Segment = Hl7DataLoader.Create(segment);
            var list = ensureTypeIsInDictionary(hl7Segment);
            list.Add(hl7Segment);
        }

        HL7Records = dict.ToImmutableDictionary(kvp => kvp.Key, IImmutableList<IHl7Segment> (kvp) => kvp.Value.ToImmutableList());
        return true;

        List<IHl7Segment> ensureTypeIsInDictionary(IHl7Segment segment) {
            var type = segment.GetType();
            return dict.TryGetValue(type, out var list)
                ? list
                : dict[type] = [];
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace HL7;

public class HL7Message {
    public IImmutableDictionary<Type, IImmutableList<IHL7Data>> HL7Records { get; private set; } = null!;
    public MSH MSH => (MSH)HL7Records[typeof(MSH)].Single();
    private readonly Dictionary<Type, List<IHL7Data>> dict = new();

    private HL7Message() { }

    public ICollection<T> GetRecords<T>() where T : IHL7Data {
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
        var msh = new MSH(message);
        dict.Add(typeof(MSH), [msh]);
        foreach (var segment in message.Segments.Where(s => s.Name != "MSH")) {
            var hl7Data = HL7DataLoader.Create(segment);
            var list = ensureTypeIsInDictionary(hl7Data);
            list.Add(hl7Data);
        }

        HL7Records = dict.ToImmutableDictionary(kvp => kvp.Key, IImmutableList<IHL7Data> (kvp) => kvp.Value.ToImmutableList());
        return true;

        List<IHL7Data> ensureTypeIsInDictionary(IHL7Data hl7Data) {
            var type = hl7Data.GetType();
            return dict.TryGetValue(type, out var list)
                ? list
                : dict[type] = [];
        }
    }
}
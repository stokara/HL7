using System;
using System.Collections.Generic;
using System.Linq;

namespace HL7;

public class HL7Message {
    public Dictionary<Type, List<IHL7Data>> HL7Records { get; } = new();

    public bool LoadHL7Message(string hl7Message) {
        try {
            var message = Message.Parse(hl7Message);
            var msh = new MSH(message);
            HL7Records.Add(typeof(MSH), [msh]);
            foreach (var segment in message.Segments.Where(s => s.Name != "MSH")) {
                var hl7Data = HL7DataLoader.Create(segment);
                var list = ensureTypeIsInDictionary(hl7Data);
                list.Add(hl7Data);
            }
            return true;
        } catch {
            return false;
        }

        List<IHL7Data> ensureTypeIsInDictionary(IHL7Data hl7Data) {
            var type = hl7Data.GetType();
            return HL7Records.TryGetValue(type, out var list)
                ? list 
                : HL7Records[type] = [];
        }
    }
}
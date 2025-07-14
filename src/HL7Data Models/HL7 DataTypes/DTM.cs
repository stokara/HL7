using System.Collections.Generic;
using HL7;
using NodaTime;

public sealed record DTM : Hl7DataType {
    public Instant? DateTime { get; }

    public DTM(IReadOnlyList<string> components) {
        DateTime = components.GetInstant(1);
    }

    public override string Serialize(Hl7Encoding encoding) => SerializePropertyValue(DateTime, encoding);
}
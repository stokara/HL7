using HL7;
using NodaTime;
using System.Collections.Generic;

public sealed record DT : Hl7DataType {
    public Instant? Date { get; }

    public DT(IReadOnlyList<string> components) {
        Date = components.GetInstant(1);
    }

    public override string Serialize(Hl7Encoding encoding) => SerializePropertyValue(Date, encoding);
}
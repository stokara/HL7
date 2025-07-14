using System.Collections.Generic;
using HL7;
using NodaTime;

public sealed record TM : Hl7DataType {
    public Instant? Time { get; }

    public TM(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Time = components.GetInstant(1);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        SerializePropertyValue(Time, encoding);
}
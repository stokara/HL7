using System.Collections.Generic;
using HL7;

public sealed record NM : Hl7DataType {
    public decimal? Value { get; }

    public NM(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Value = components.GetDecimal(1);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        SerializePropertyValue(Value, encoding);
}
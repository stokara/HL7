using System.Collections.Generic;
using HL7;

public sealed record SI : Hl7DataType {
    public int? Value { get; }

    public SI(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Value = components.GetInt(1);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        SerializePropertyValue(Value, encoding);
}
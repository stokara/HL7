using System.Collections.Generic;
using HL7;

public sealed record SNM : Hl7DataType {
    public string? Value { get; }

    public SNM(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Value = components.GetString(1);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        SerializePropertyValue(Value, encoding);
}
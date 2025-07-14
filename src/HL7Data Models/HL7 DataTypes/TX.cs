using System.Collections.Generic;
using HL7;

public sealed record TX : Hl7DataType {
    public string? TextData { get; }

    public TX(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        TextData = components.GetString(1);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        SerializePropertyValue(TextData, encoding);
}
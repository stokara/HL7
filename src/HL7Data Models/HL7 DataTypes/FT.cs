using System.Collections.Generic;
using HL7;

public sealed record FT : Hl7DataType {
    public string? FormattedTextData { get; }

    public FT(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        FormattedTextData = components.GetString(1);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        SerializePropertyValue(FormattedTextData, encoding);
}
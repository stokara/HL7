using HL7;
using System.Collections.Generic;

public sealed record ST : Hl7DataType {
    public string? StringData { get; }

    public ST(IReadOnlyList<string> components) {
        StringData = components.GetString(1);
    }

    public override string Serialize(Hl7Encoding encoding) => SerializePropertyValue(StringData, encoding);
    
}
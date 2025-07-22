namespace HL7;

public abstract record HL7String : Hl7SimpleType {
    public string? Value { get; init; }
    protected HL7String(string? value) {
        this.Value = value;
        StringValue = value;
    }
}
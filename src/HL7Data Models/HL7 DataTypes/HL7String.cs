namespace HL7;

public abstract record HL7String : Hl7SimpleType {
    public string? Value { get; init; }
    protected HL7String(string? value, Hl7Structure structure = Hl7Structure.Hl7Component) : base(structure) {
        this.Value = value;
        StringValue = value;
    }
}
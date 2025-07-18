namespace HL7;

public abstract record Hl7Decimal : Hl7SimpleType {
    public decimal? Value { get; init; }

    protected Hl7Decimal(string? val, Hl7Structure structure = Hl7Structure.Hl7Component) : base(structure) {
        if (val is not null) {
            Value = decimal.Parse(val);
            StringValue = val;
        }
    }

    protected Hl7Decimal(decimal? value, Hl7Structure structure = Hl7Structure.Hl7Component) : base(structure) {
        Value = value;
        if (value.HasValue) StringValue = value.Value.ToString("G");
    }
}
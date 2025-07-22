namespace HL7;

public abstract record Hl7Decimal : Hl7SimpleType {
    public decimal? Value { get; init; }

    protected Hl7Decimal(string? val) {
        if (val is not null) {
            Value = decimal.Parse(val);
            StringValue = val;
        }
    }

    protected Hl7Decimal(decimal? value) {
        Value = value;
        if (value.HasValue) StringValue = value.Value.ToString("G");
    }
}
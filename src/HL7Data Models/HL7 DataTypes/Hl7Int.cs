namespace HL7;

public abstract record Hl7Int : Hl7SimpleType {
    public int? Value { get; init; }

    protected Hl7Int(string? val) : this(string.IsNullOrWhiteSpace(val) ? null : int.Parse(val)) {
        StringValue = val;
    }

    protected Hl7Int(int? Value)  {
        this.Value = Value;
        if (Value is not null) StringValue = Value.ToString();
    }
    


}
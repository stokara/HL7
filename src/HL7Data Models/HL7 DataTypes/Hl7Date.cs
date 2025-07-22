using NodaTime;

namespace HL7;

public abstract record Hl7Date : Hl7SimpleType {
    public Instant? Value { get; init; }
    protected string Format { get; set; } = "yyyyMMdd";

    protected Hl7Date(string? val) : this(Hl7DateParser.ParseInstant(val)) {
        StringValue = val;
        if (val is not null) Format = Hl7DateParser.GetFormat(val);
    }

    protected Hl7Date(Instant? value)  {
        Value = value;
        if (value.HasValue) StringValue = value.Value.ToDateTimeUtc().ToString(Format);
    }
}
using NodaTime;

namespace HL7;

public abstract record Hl7Date : Hl7SimpleType {
    public Instant? Value { get; init; }
    protected string Format { get; set; } = "yyyyMMdd";

    protected Hl7Date(string? val, Hl7Structure structure = Hl7Structure.Hl7Component) : this(Hl7DateParser.ParseInstant(val), structure) {
        StringValue = val;
        Format = Hl7DateParser.GetFormat(val);
    }

    protected Hl7Date(Instant? value, Hl7Structure structure = Hl7Structure.Hl7Component) : base(structure) {
        Value = value;
        if (value.HasValue) StringValue = value.Value.ToDateTimeUtc().ToString(Format);
    }
}
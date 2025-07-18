namespace HL7;

public sealed record NM(decimal? Value) : Hl7Decimal(Value) { }
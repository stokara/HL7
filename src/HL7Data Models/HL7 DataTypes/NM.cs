namespace HL7;

public sealed record NM(string? Value) : HL7String(Value) { }
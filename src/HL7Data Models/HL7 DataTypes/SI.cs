namespace HL7;

public sealed record SI(string? IntValue) : Hl7Int(IntValue);

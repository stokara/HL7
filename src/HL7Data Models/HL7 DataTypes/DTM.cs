namespace HL7;

public sealed record DTM : Hl7Date {
    public DTM(string? dateTimeString) : base(dateTimeString) { }
}
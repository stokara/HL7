using System.IO;

public sealed record PID {
    public string SetId { get; init; }
    public string PatientId { get; init; }
    public string PatientIdentifierList { get; init; }
    public string PatientName { get; init; }
    public string DateOfBirth { get; init; }
    public string Sex { get; init; }
    public string Address { get; init; }
    public string PhoneNumber { get; init; }
    public string MaritalStatus { get; init; }
    public string SSN { get; init; }

    private PID() { }

    public static PID Load(Segment segment) {
        if (segment.Name != "PID") throw new InvalidDataException($"Invalid Segment - Primary Insurance Data is in IN1 Segment, this is {segment.Name}");

        return new PID {
            SetId = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty,
            PatientId = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty,
            PatientIdentifierList = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty,
            PatientName = segment.Fields.Count > 5 ? segment.Fields[5].Value : string.Empty,
            DateOfBirth = segment.Fields.Count > 7 ? segment.Fields[7].Value : string.Empty,
            Sex = segment.Fields.Count > 8 ? segment.Fields[8].Value : string.Empty,
            Address = segment.Fields.Count > 11 ? segment.Fields[11].Value : string.Empty,
            PhoneNumber = segment.Fields.Count > 13 ? segment.Fields[13].Value : string.Empty,
            MaritalStatus = segment.Fields.Count > 16 ? segment.Fields[16].Value : string.Empty,
            SSN = segment.Fields.Count > 19 ? segment.Fields[19].Value : string.Empty,
        };
}
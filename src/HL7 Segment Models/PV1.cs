using System.IO;

public sealed record PV1 {
    public string SetId { get; init; }
    public string PatientClass { get; init; }
    public string AssignedPatientLocation { get; init; }
    public string AttendingDoctor { get; init; }
    public string VisitNumber { get; init; }

    private PV1() { }

    public static PV1 Load(Segment segment) {
        if (segment.Name != "PV1") throw new InvalidDataException($"Invalid Segment - PV1 data is in PV1 Segment, this is {segment.Name}");

        return new PV1 {
            SetId = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty,
            PatientClass = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty,
            AssignedPatientLocation = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty,
            AttendingDoctor = segment.Fields.Count > 7 ? segment.Fields[7].Value : string.Empty,
            VisitNumber = segment.Fields.Count > 19 ? segment.Fields[19].Value : string.Empty
        };
    }
}
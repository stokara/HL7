public sealed record PV1 : HL7Data {
    public override string Name => nameof(PV1);
    public string SetId { get; private set; }
    public string PatientClass { get; private set; }
    public string AssignedPatientLocation { get; private set; }
    public string AttendingDoctor { get; private set; }
    public string VisitNumber { get; private set; }

    private PV1(Segment segment) : base(segment) {
        SetId = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty;
        PatientClass = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;
        AssignedPatientLocation = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty;
        AttendingDoctor = segment.Fields.Count > 7 ? segment.Fields[7].Value : string.Empty;
        VisitNumber = segment.Fields.Count > 19 ? segment.Fields[19].Value : string.Empty;
    }

    static PV1() {
        SegmentLoader.Register("PV1", segment => new PV1(segment));
    }
}
namespace HL7;

public sealed record PID : HL7Data<PID> {
    public string SetId { get; private set; }
    public string PatientId { get; private set; }
    public string PatientIdentifierList { get; private set; }
    public string PatientName { get; private set; }
    public string DateOfBirth { get; private set; }
    public string Sex { get; private set; }
    public string Address { get; private set; }
    public string PhoneNumber { get; private set; }
    public string MaritalStatus { get; private set; }
    public string SSN { get; private set; }

    public PID(Segment segment) : base(segment) {
        SetId = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty;
        PatientId = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;
        PatientIdentifierList = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty;
        PatientName = segment.Fields.Count > 5 ? segment.Fields[5].Value : string.Empty;
        DateOfBirth = segment.Fields.Count > 7 ? segment.Fields[7].Value : string.Empty;
        Sex = segment.Fields.Count > 8 ? segment.Fields[8].Value : string.Empty;
        Address = segment.Fields.Count > 11 ? segment.Fields[11].Value : string.Empty;
        PhoneNumber = segment.Fields.Count > 13 ? segment.Fields[13].Value : string.Empty;
        MaritalStatus = segment.Fields.Count > 16 ? segment.Fields[16].Value : string.Empty;
        SSN = segment.Fields.Count > 19 ? segment.Fields[19].Value : string.Empty;
    }
}
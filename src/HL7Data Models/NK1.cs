namespace HL7;

/// <summary>
///     NK1 - Next of Kin / Associated Parties (HL7 v2.3.1)
/// </summary>
public sealed record NK1 : HL7Data<NK1> {
    public string SetID { get; }
    public string Name { get; }
    public string Relationship { get; }
    public string Address { get; }
    public string PhoneNumber { get; }
    public string BusinessPhoneNumber { get; }
    public string ContactRole { get; }
    public string StartDate { get; }
    public string EndDate { get; }
    public string NextOfKinAssociatedPartiesJobTitle { get; }
    public string NextOfKinAssociatedPartiesJobCodeClass { get; }
    public string NextOfKinAssociatedPartiesEmployeeNumber { get; }
    public string OrganizationName { get; }

    public NK1(Segment segment) : base(segment) {
        SetID = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty;
        Name = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;
        Relationship = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty;
        Address = segment.Fields.Count > 4 ? segment.Fields[4].Value : string.Empty;
        PhoneNumber = segment.Fields.Count > 5 ? segment.Fields[5].Value : string.Empty;
        BusinessPhoneNumber = segment.Fields.Count > 6 ? segment.Fields[6].Value : string.Empty;
        ContactRole = segment.Fields.Count > 7 ? segment.Fields[7].Value : string.Empty;
        StartDate = segment.Fields.Count > 8 ? segment.Fields[8].Value : string.Empty;
        EndDate = segment.Fields.Count > 9 ? segment.Fields[9].Value : string.Empty;
        NextOfKinAssociatedPartiesJobTitle = segment.Fields.Count > 10 ? segment.Fields[10].Value : string.Empty;
        NextOfKinAssociatedPartiesJobCodeClass = segment.Fields.Count > 11 ? segment.Fields[11].Value : string.Empty;
        NextOfKinAssociatedPartiesEmployeeNumber = segment.Fields.Count > 12 ? segment.Fields[12].Value : string.Empty;
        OrganizationName = segment.Fields.Count > 13 ? segment.Fields[13].Value : string.Empty;
    }
}
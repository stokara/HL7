namespace HL7;

/// <summary>
///     STF - Staff Identification Segment (HL7 v2.3.1)
/// </summary>
public sealed record STF : HL7Data<STF> {
    public string PrimaryKeyValueSTF { get; }
    public string StaffIdCode { get; }
    public string StaffName { get; }
    public string StaffType { get; }
    public string AdministrativeSex { get; }
    public string DateTimeOfBirth { get; }
    public string ActiveInactiveFlag { get; }
    public string Department { get; }
    public string Service { get; }
    public string Phone { get; }
    public string OfficeHomeAddressBirthplace { get; }
    public string InstitutionActivationDate { get; }
    public string InstitutionInactivationDate { get; }
    public string BackupPersonId { get; }
    public string EmailAddress { get; }
    public string PreferredMethodOfContact { get; }

    public STF(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        PrimaryKeyValueSTF = cnt > 1 ? fields[1].Value : string.Empty;
        StaffIdCode = cnt > 2 ? fields[2].Value : string.Empty;
        StaffName = cnt > 3 ? fields[3].Value : string.Empty;
        StaffType = cnt > 4 ? fields[4].Value : string.Empty;
        AdministrativeSex = cnt > 5 ? fields[5].Value : string.Empty;
        DateTimeOfBirth = cnt > 6 ? fields[6].Value : string.Empty;
        ActiveInactiveFlag = cnt > 7 ? fields[7].Value : string.Empty;
        Department = cnt > 8 ? fields[8].Value : string.Empty;
        Service = cnt > 9 ? fields[9].Value : string.Empty;
        Phone = cnt > 10 ? fields[10].Value : string.Empty;
        OfficeHomeAddressBirthplace = cnt > 11 ? fields[11].Value : string.Empty;
        InstitutionActivationDate = cnt > 12 ? fields[12].Value : string.Empty;
        InstitutionInactivationDate = cnt > 13 ? fields[13].Value : string.Empty;
        BackupPersonId = cnt > 14 ? fields[14].Value : string.Empty;
        EmailAddress = cnt > 15 ? fields[15].Value : string.Empty;
        PreferredMethodOfContact = cnt > 16 ? fields[16].Value : string.Empty;
    }
}
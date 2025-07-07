namespace HL7;

/// <summary>
///     GT1 - Guarantor Segment (HL7 v2.3.1)
/// </summary>
public sealed record GT1 : HL7Data<GT1> {
    public string SetId { get; }
    public string GuarantorNumber { get; }
    public string GuarantorName { get; }
    public string GuarantorSpouseName { get; }
    public string GuarantorAddress { get; }
    public string GuarantorPhoneNumberHome { get; }
    public string GuarantorPhoneNumberBusiness { get; }
    public string GuarantorDateOfBirth { get; }
    public string GuarantorSex { get; }
    public string GuarantorType { get; }
    public string GuarantorRelationship { get; }
    public string GuarantorSSN { get; }
    public string GuarantorDateBegin { get; }
    public string GuarantorDateEnd { get; }
    public string GuarantorPriority { get; }
    public string GuarantorEmployerName { get; }
    public string GuarantorEmployerAddress { get; }
    public string GuarantorEmployerPhoneNumber { get; }
    public string GuarantorEmployeeIdNumber { get; }
    public string GuarantorEmploymentStatus { get; }
    public string GuarantorOrganizationName { get; }

    public GT1(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        SetId = cnt > 1 ? fields[1].Value : string.Empty;
        GuarantorNumber = cnt > 2 ? fields[2].Value : string.Empty;
        GuarantorName = cnt > 3 ? fields[3].Value : string.Empty;
        GuarantorSpouseName = cnt > 4 ? fields[4].Value : string.Empty;
        GuarantorAddress = cnt > 5 ? fields[5].Value : string.Empty;
        GuarantorPhoneNumberHome = cnt > 6 ? fields[6].Value : string.Empty;
        GuarantorPhoneNumberBusiness = cnt > 7 ? fields[7].Value : string.Empty;
        GuarantorDateOfBirth = cnt > 8 ? fields[8].Value : string.Empty;
        GuarantorSex = cnt > 9 ? fields[9].Value : string.Empty;
        GuarantorType = cnt > 10 ? fields[10].Value : string.Empty;
        GuarantorRelationship = cnt > 11 ? fields[11].Value : string.Empty;
        GuarantorSSN = cnt > 12 ? fields[12].Value : string.Empty;
        GuarantorDateBegin = cnt > 13 ? fields[13].Value : string.Empty;
        GuarantorDateEnd = cnt > 14 ? fields[14].Value : string.Empty;
        GuarantorPriority = cnt > 15 ? fields[15].Value : string.Empty;
        GuarantorEmployerName = cnt > 16 ? fields[16].Value : string.Empty;
        GuarantorEmployerAddress = cnt > 17 ? fields[17].Value : string.Empty;
        GuarantorEmployerPhoneNumber = cnt > 18 ? fields[18].Value : string.Empty;
        GuarantorEmployeeIdNumber = cnt > 19 ? fields[19].Value : string.Empty;
        GuarantorEmploymentStatus = cnt > 20 ? fields[20].Value : string.Empty;
        GuarantorOrganizationName = cnt > 21 ? fields[21].Value : string.Empty;
    }
}
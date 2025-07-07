namespace HL7;

/// <summary>
///     IN3 - Insurance Additional Information, Certification Segment (HL7 v2.3.1)
/// </summary>
public sealed record IN3 : HL7Data<IN3> {
    public string SetId { get; }
    public string CertificationNumber { get; }
    public string CertifiedBy { get; }
    public string CertificationRequired { get; }
    public string Penalty { get; }
    public string CertificationDateTime { get; }
    public string CertificationModifyDateTime { get; }
    public string Operator { get; }
    public string CertificationBeginDate { get; }
    public string CertificationEndDate { get; }
    public string Days { get; }
    public string NonConcurCodeDescription { get; }
    public string NonConcurEffectiveDateTime { get; }
    public string PhysicianReviewer { get; }
    public string CertificationContact { get; }
    public string CertificationContactPhoneNumber { get; }
    public string AppealReason { get; }
    public string CertificationAgency { get; }
    public string CertificationAgencyPhoneNumber { get; }
    public string PreCertificationRequirement { get; }
    public string CaseManager { get; }
    public string SecondOpinionDate { get; }
    public string SecondOpinionStatus { get; }
    public string SecondOpinionDocumentationReceived { get; }
    public string SecondOpinionPhysician { get; }

    public IN3(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        SetId = cnt > 1 ? fields[1].Value : string.Empty;
        CertificationNumber = cnt > 2 ? fields[2].Value : string.Empty;
        CertifiedBy = cnt > 3 ? fields[3].Value : string.Empty;
        CertificationRequired = cnt > 4 ? fields[4].Value : string.Empty;
        Penalty = cnt > 5 ? fields[5].Value : string.Empty;
        CertificationDateTime = cnt > 6 ? fields[6].Value : string.Empty;
        CertificationModifyDateTime = cnt > 7 ? fields[7].Value : string.Empty;
        Operator = cnt > 8 ? fields[8].Value : string.Empty;
        CertificationBeginDate = cnt > 9 ? fields[9].Value : string.Empty;
        CertificationEndDate = cnt > 10 ? fields[10].Value : string.Empty;
        Days = cnt > 11 ? fields[11].Value : string.Empty;
        NonConcurCodeDescription = cnt > 12 ? fields[12].Value : string.Empty;
        NonConcurEffectiveDateTime = cnt > 13 ? fields[13].Value : string.Empty;
        PhysicianReviewer = cnt > 14 ? fields[14].Value : string.Empty;
        CertificationContact = cnt > 15 ? fields[15].Value : string.Empty;
        CertificationContactPhoneNumber = cnt > 16 ? fields[16].Value : string.Empty;
        AppealReason = cnt > 17 ? fields[17].Value : string.Empty;
        CertificationAgency = cnt > 18 ? fields[18].Value : string.Empty;
        CertificationAgencyPhoneNumber = cnt > 19 ? fields[19].Value : string.Empty;
        PreCertificationRequirement = cnt > 20 ? fields[20].Value : string.Empty;
        CaseManager = cnt > 21 ? fields[21].Value : string.Empty;
        SecondOpinionDate = cnt > 22 ? fields[22].Value : string.Empty;
        SecondOpinionStatus = cnt > 23 ? fields[23].Value : string.Empty;
        SecondOpinionDocumentationReceived = cnt > 24 ? fields[24].Value : string.Empty;
        SecondOpinionPhysician = cnt > 25 ? fields[25].Value : string.Empty;
    }
}
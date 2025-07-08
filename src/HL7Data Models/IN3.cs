using NodaTime;

namespace HL7;

/// <summary>
///     IN3 - Insurance Additional Information, Certification Segment (HL7 v2.3.1)
/// </summary>
public sealed record IN3 : HL7Data<IN3> {
    public string SetId { get; }
    public string CertificationNumber { get; }
    public HL7Property<PersonName> CertifiedBy { get; }
    public string CertificationRequired { get; }
    public string Penalty { get; }
    public Instant? CertificationDateTime { get; }
    public Instant? CertificationModifyDateTime { get; }
    public string Operator { get; }
    public Instant? CertificationBeginDate { get; }
    public Instant? CertificationEndDate { get; }
    public int? Days { get; }
    public string NonConcurCodeDescription { get; }
    public Instant? NonConcurEffectiveDateTime { get; }
    public HL7Property<PersonName> PhysicianReviewer { get; }
    public string CertificationContact { get; }
    public HL7Property<Phone> CertificationContactPhoneNumber { get; }
    public string AppealReason { get; }
    public string CertificationAgency { get; }
    public HL7Property<Phone> CertificationAgencyPhoneNumber { get; }
    public string PreCertificationRequirement { get; }
    public string CaseManager { get; }
    public Instant? SecondOpinionDate { get; }
    public string SecondOpinionStatus { get; }
    public string SecondOpinionDocumentationReceived { get; }
    public HL7Property<PersonName> SecondOpinionPhysician { get; }

    public IN3(Segment segment) : base(segment) {
        SetId = segment.GetFieldString(1);
        CertificationNumber = segment.GetFieldString(2);
        CertifiedBy = PersonName.CreateHL7Property(segment, 3);
        CertificationRequired = segment.GetFieldString(4);
        Penalty = segment.GetFieldString(5);
        CertificationDateTime = segment.GetFieldInstant(6);
        CertificationModifyDateTime = segment.GetFieldInstant(7);
        Operator = segment.GetFieldString(8);
        CertificationBeginDate = segment.GetFieldInstant(9);
        CertificationEndDate = segment.GetFieldInstant(10);
        Days = segment.GetFieldInt(11);
        NonConcurCodeDescription = segment.GetFieldString(12);
        NonConcurEffectiveDateTime = segment.GetFieldInstant(13);
        PhysicianReviewer = PersonName.CreateHL7Property(segment, 14);
        CertificationContact = segment.GetFieldString(15);
        CertificationContactPhoneNumber = Phone.CreateHL7Property(segment, 16);
        AppealReason = segment.GetFieldString(17);
        CertificationAgency = segment.GetFieldString(18);
        CertificationAgencyPhoneNumber = Phone.CreateHL7Property(segment, 19);
        PreCertificationRequirement = segment.GetFieldString(20);
        CaseManager = segment.GetFieldString(21);
        SecondOpinionDate = segment.GetFieldInstant(22);
        SecondOpinionStatus = segment.GetFieldString(23);
        SecondOpinionDocumentationReceived = segment.GetFieldString(24);
        SecondOpinionPhysician = PersonName.CreateHL7Property(segment, 25);
    }
}
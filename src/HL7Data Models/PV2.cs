using NodaTime;

namespace HL7;

/// <summary>
///     PV2 - Patient Visit - Additional Information (HL7 v2.3.1)
/// </summary>
public sealed record PV2 : HL7Data<PV2> {
    public HL7Property<CodedElement> PriorPendingLocation { get; }
    public HL7Property<CodedElement> AccommodationCode { get; }
    public HL7Property<CodedElement> AdmitReason { get; }
    public HL7Property<CodedElement> TransferReason { get; }
    public string PatientValuables { get; }
    public string PatientValuablesLocation { get; }
    public string VisitUserCode { get; }
    public Instant? ExpectedAdmitDateTime { get; }
    public Instant? ExpectedDischargeDateTime { get; }
    public int? EstimatedLengthOfInpatientStay { get; }
    public int? ActualLengthOfInpatientStay { get; }
    public string VisitDescription { get; }
    public HL7Property<EntityIdentifier> ReferralSourceCode { get; }
    public Instant? PreviousServiceDate { get; }
    public string EmploymentIllnessRelatedIndicator { get; }
    public string PurgeStatusCode { get; }
    public Instant? PurgeStatusDate { get; }
    public string SpecialProgramCode { get; }
    public string RetentionIndicator { get; }
    public int? ExpectedNumberOfInsurancePlans { get; }
    public string VisitPublicityCode { get; }
    public string VisitProtectionIndicator { get; }
    public HL7Property<CodedElement> ClinicOrganizationName { get; }
    public string PatientStatusCode { get; }
    public string VisitPriorityCode { get; }
    public Instant? PreviousTreatmentDate { get; }
    public string ExpectedDischargeDisposition { get; }
    public Instant? SignatureOnFileDate { get; }
    public Instant? FirstSimilarIllnessDate { get; }
    public HL7Property<CodedElement> PatientChargeAdjustmentCode { get; }
    public HL7Property<CodedElement> RecurringServiceCode { get; }
    public HL7Property<CodedElement> BillingMediaCode { get; }
    public Instant? ExpectedSurgeryDateTime { get; }
    public string MilitaryPartnershipCode { get; }
    public string MilitaryNonAvailabilityCode { get; }
    public string NewbornBabyIndicator { get; }
    public string BabyDetainedIndicator { get; }

    public PV2(Segment segment) : base(segment) {
        PriorPendingLocation = CodedElement.CreateHL7Property(segment, 1);
        AccommodationCode = CodedElement.CreateHL7Property(segment, 2);
        AdmitReason = CodedElement.CreateHL7Property(segment, 3);
        TransferReason = CodedElement.CreateHL7Property(segment, 4);
        PatientValuables = segment.GetFieldString(5);
        PatientValuablesLocation = segment.GetFieldString(6);
        VisitUserCode = segment.GetFieldString(7);
        ExpectedAdmitDateTime = segment.GetFieldInstant(8);
        ExpectedDischargeDateTime = segment.GetFieldInstant(9);
        EstimatedLengthOfInpatientStay = segment.GetFieldInt(10);
        ActualLengthOfInpatientStay = segment.GetFieldInt(11);
        VisitDescription = segment.GetFieldString(12);
        ReferralSourceCode = EntityIdentifier.CreateHL7Property(segment, 13);
        PreviousServiceDate = segment.GetFieldInstant(14);
        EmploymentIllnessRelatedIndicator = segment.GetFieldString(15);
        PurgeStatusCode = segment.GetFieldString(16);
        PurgeStatusDate = segment.GetFieldInstant(17);
        SpecialProgramCode = segment.GetFieldString(18);
        RetentionIndicator = segment.GetFieldString(19);
        ExpectedNumberOfInsurancePlans = segment.GetFieldInt(20);
        VisitPublicityCode = segment.GetFieldString(21);
        VisitProtectionIndicator = segment.GetFieldString(22);
        ClinicOrganizationName = CodedElement.CreateHL7Property(segment, 23);
        PatientStatusCode = segment.GetFieldString(24);
        VisitPriorityCode = segment.GetFieldString(25);
        PreviousTreatmentDate = segment.GetFieldInstant(26);
        ExpectedDischargeDisposition = segment.GetFieldString(27);
        SignatureOnFileDate = segment.GetFieldInstant(28);
        FirstSimilarIllnessDate = segment.GetFieldInstant(29);
        PatientChargeAdjustmentCode = CodedElement.CreateHL7Property(segment, 30);
        RecurringServiceCode = CodedElement.CreateHL7Property(segment, 31);
        BillingMediaCode = CodedElement.CreateHL7Property(segment, 32);
        ExpectedSurgeryDateTime = segment.GetFieldInstant(33);
        MilitaryPartnershipCode = segment.GetFieldString(34);
        MilitaryNonAvailabilityCode = segment.GetFieldString(35);
        NewbornBabyIndicator = segment.GetFieldString(36);
        BabyDetainedIndicator = segment.GetFieldString(37);
    }
}
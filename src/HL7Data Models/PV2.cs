namespace HL7;

/// <summary>
///     PV2 - Patient Visit - Additional Information (HL7 v2.3.1)
/// </summary>
public sealed record PV2 : HL7Data<PV2> {
    public string PriorPendingLocation { get; }
    public string AccommodationCode { get; }
    public string AdmitReason { get; }
    public string TransferReason { get; }
    public string PatientValuables { get; }
    public string PatientValuablesLocation { get; }
    public string VisitUserCode { get; }
    public string ExpectedAdmitDateTime { get; }
    public string ExpectedDischargeDateTime { get; }
    public string EstimatedLengthOfInpatientStay { get; }
    public string ActualLengthOfInpatientStay { get; }
    public string VisitDescription { get; }
    public string ReferralSourceCode { get; }
    public string PreviousServiceDate { get; }
    public string EmploymentIllnessRelatedIndicator { get; }
    public string PurgeStatusCode { get; }
    public string PurgeStatusDate { get; }
    public string SpecialProgramCode { get; }
    public string RetentionIndicator { get; }
    public string ExpectedNumberOfInsurancePlans { get; }
    public string VisitPublicityCode { get; }
    public string VisitProtectionIndicator { get; }
    public string ClinicOrganizationName { get; }
    public string PatientStatusCode { get; }
    public string VisitPriorityCode { get; }
    public string PreviousTreatmentDate { get; }
    public string ExpectedDischargeDisposition { get; }
    public string SignatureOnFileDate { get; }
    public string FirstSimilarIllnessDate { get; }
    public string PatientChargeAdjustmentCode { get; }
    public string RecurringServiceCode { get; }
    public string BillingMediaCode { get; }
    public string ExpectedSurgeryDateTime { get; }
    public string MilitaryPartnershipCode { get; }
    public string MilitaryNonAvailabilityCode { get; }
    public string NewbornBabyIndicator { get; }
    public string BabyDetainedIndicator { get; }

    public PV2(Segment segment) : base(segment) {
        var cnt = segment.Fields.Count;
        PriorPendingLocation = cnt > 1 ? segment.Fields[1].Value : string.Empty;
        AccommodationCode = cnt > 2 ? segment.Fields[2].Value : string.Empty;
        AdmitReason = cnt > 3 ? segment.Fields[3].Value : string.Empty;
        TransferReason = cnt > 4 ? segment.Fields[4].Value : string.Empty;
        PatientValuables = cnt > 5 ? segment.Fields[5].Value : string.Empty;
        PatientValuablesLocation = cnt > 6 ? segment.Fields[6].Value : string.Empty;
        VisitUserCode = cnt > 7 ? segment.Fields[7].Value : string.Empty;
        ExpectedAdmitDateTime = cnt > 8 ? segment.Fields[8].Value : string.Empty;
        ExpectedDischargeDateTime = cnt > 9 ? segment.Fields[9].Value : string.Empty;
        EstimatedLengthOfInpatientStay = cnt > 10 ? segment.Fields[10].Value : string.Empty;
        ActualLengthOfInpatientStay = cnt > 11 ? segment.Fields[11].Value : string.Empty;
        VisitDescription = cnt > 12 ? segment.Fields[12].Value : string.Empty;
        ReferralSourceCode = cnt > 13 ? segment.Fields[13].Value : string.Empty;
        PreviousServiceDate = cnt > 14 ? segment.Fields[14].Value : string.Empty;
        EmploymentIllnessRelatedIndicator = cnt > 15 ? segment.Fields[15].Value : string.Empty;
        PurgeStatusCode = cnt > 16 ? segment.Fields[16].Value : string.Empty;
        PurgeStatusDate = cnt > 17 ? segment.Fields[17].Value : string.Empty;
        SpecialProgramCode = cnt > 18 ? segment.Fields[18].Value : string.Empty;
        RetentionIndicator = cnt > 19 ? segment.Fields[19].Value : string.Empty;
        ExpectedNumberOfInsurancePlans = cnt > 20 ? segment.Fields[20].Value : string.Empty;
        VisitPublicityCode = cnt > 21 ? segment.Fields[21].Value : string.Empty;
        VisitProtectionIndicator = cnt > 22 ? segment.Fields[22].Value : string.Empty;
        ClinicOrganizationName = cnt > 23 ? segment.Fields[23].Value : string.Empty;
        PatientStatusCode = cnt > 24 ? segment.Fields[24].Value : string.Empty;
        VisitPriorityCode = cnt > 25 ? segment.Fields[25].Value : string.Empty;
        PreviousTreatmentDate = cnt > 26 ? segment.Fields[26].Value : string.Empty;
        ExpectedDischargeDisposition = cnt > 27 ? segment.Fields[27].Value : string.Empty;
        SignatureOnFileDate = cnt > 28 ? segment.Fields[28].Value : string.Empty;
        FirstSimilarIllnessDate = cnt > 29 ? segment.Fields[29].Value : string.Empty;
        PatientChargeAdjustmentCode = cnt > 30 ? segment.Fields[30].Value : string.Empty;
        RecurringServiceCode = cnt > 31 ? segment.Fields[31].Value : string.Empty;
        BillingMediaCode = cnt > 32 ? segment.Fields[32].Value : string.Empty;
        ExpectedSurgeryDateTime = cnt > 33 ? segment.Fields[33].Value : string.Empty;
        MilitaryPartnershipCode = cnt > 34 ? segment.Fields[34].Value : string.Empty;
        MilitaryNonAvailabilityCode = cnt > 35 ? segment.Fields[35].Value : string.Empty;
        NewbornBabyIndicator = cnt > 36 ? segment.Fields[36].Value : string.Empty;
        BabyDetainedIndicator = cnt > 37 ? segment.Fields[37].Value : string.Empty;
    }
}
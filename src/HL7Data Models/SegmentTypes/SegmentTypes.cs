using System.Collections.Generic;

namespace HL7;

public sealed record ABS : Hl7Segment {
    public XCN? DischargeCareProvider { get; }
    public CWE? TransferMedicalServiceCode { get; }
    public CWE? SeverityofIllnessCode { get; }
    public DTM? DateTimeofAttestation { get; }
    public XCN? AttestedBy { get; }
    public CWE? TriageCode { get; }
    public DTM? AbstractCompletionDateTime { get; }
    public XCN? AbstractedBy { get; }
    public CWE? CaseCategoryCode { get; }
    public ID? CaesarianSectionIndicator { get; }
    public CWE? GestationCategoryCode { get; }
    public NM? GestationPeriodWeeks { get; }
    public CWE? NewbornCode { get; }
    public ID? StillbornIndicator { get; }

    public ABS(Segment segment) : base(typeof(ABS), segment) {
        this.DischargeCareProvider = segment.GetField<XCN>(1);
        this.TransferMedicalServiceCode = segment.GetField<CWE>(2);
        this.SeverityofIllnessCode = segment.GetField<CWE>(3);
        this.DateTimeofAttestation = segment.GetField<DTM>(4);
        this.AttestedBy = segment.GetField<XCN>(5);
        this.TriageCode = segment.GetField<CWE>(6);
        this.AbstractCompletionDateTime = segment.GetField<DTM>(7);
        this.AbstractedBy = segment.GetField<XCN>(8);
        this.CaseCategoryCode = segment.GetField<CWE>(9);
        this.CaesarianSectionIndicator = segment.GetField<ID>(10);
        this.GestationCategoryCode = segment.GetField<CWE>(11);
        this.GestationPeriodWeeks = segment.GetField<NM>(12);
        this.NewbornCode = segment.GetField<CWE>(13);
        this.StillbornIndicator = segment.GetField<ID>(14);
    }
}

public sealed record ACC : Hl7Segment {
    public DTM? AccidentDateTime { get; }
    public CWE? AccidentCode { get; }
    public ST? AccidentLocation { get; }
    public CWE? AutoAccidentState { get; }
    public ID? AccidentJobRelatedIndicator { get; }
    public ID? AccidentDeathIndicator { get; }
    public XCN? EnteredBy { get; }
    public ST? AccidentDescription { get; }
    public ST? BroughtInBy { get; }
    public ID? PoliceNotifiedIndicator { get; }
    public XAD? AccidentAddress { get; }
    public NM? Degreeofpatientliability { get; }
    public ICollection<EI>? AccidentIdentifier { get; }

    public ACC(Segment segment) : base(typeof(ACC), segment) {
        this.AccidentDateTime = segment.GetField<DTM>(1);
        this.AccidentCode = segment.GetField<CWE>(2);
        this.AccidentLocation = segment.GetField<ST>(3);
        this.AutoAccidentState = segment.GetField<CWE>(4);
        this.AccidentJobRelatedIndicator = segment.GetField<ID>(5);
        this.AccidentDeathIndicator = segment.GetField<ID>(6);
        this.EnteredBy = segment.GetField<XCN>(7);
        this.AccidentDescription = segment.GetField<ST>(8);
        this.BroughtInBy = segment.GetField<ST>(9);
        this.PoliceNotifiedIndicator = segment.GetField<ID>(10);
        this.AccidentAddress = segment.GetField<XAD>(11);
        this.Degreeofpatientliability = segment.GetField<NM>(12);
        this.AccidentIdentifier = segment.GetRepField<EI>(13);
    }
}

public sealed record ADD : Hl7Segment {
    public ST? AddendumContinuationPointer { get; }

    public ADD(Segment segment) : base(typeof(ADD), segment) {
        this.AddendumContinuationPointer = segment.GetField<ST>(1);
    }
}

public sealed record ADJ : Hl7Segment {
    public EI ProviderAdjustmentNumber { get; }
    public EI PayerAdjustmentNumber { get; }
    public SI AdjustmentSequenceNumber { get; }
    public CWE AdjustmentCategory { get; }
    public CP? AdjustmentAmount { get; }
    public CQ? AdjustmentQuantity { get; }
    public CWE? AdjustmentReasonPA { get; }
    public ST? AdjustmentDescription { get; }
    public NM? OriginalValue { get; }
    public NM? SubstituteValue { get; }
    public CWE? AdjustmentAction { get; }
    public EI? ProviderAdjustmentNumberCrossReference { get; }
    public EI? ProviderProductServiceLineItemNumberCrossReference { get; }
    public DTM AdjustmentDate { get; }
    public XON? ResponsibleOrganization { get; }

    public ADJ(Segment segment) : base(typeof(ADJ), segment) {
        this.ProviderAdjustmentNumber = segment.GetRequiredField<EI>(1);
        this.PayerAdjustmentNumber = segment.GetRequiredField<EI>(2);
        this.AdjustmentSequenceNumber = segment.GetRequiredField<SI>(3);
        this.AdjustmentCategory = segment.GetRequiredField<CWE>(4);
        this.AdjustmentAmount = segment.GetField<CP>(5);
        this.AdjustmentQuantity = segment.GetField<CQ>(6);
        this.AdjustmentReasonPA = segment.GetField<CWE>(7);
        this.AdjustmentDescription = segment.GetField<ST>(8);
        this.OriginalValue = segment.GetField<NM>(9);
        this.SubstituteValue = segment.GetField<NM>(10);
        this.AdjustmentAction = segment.GetField<CWE>(11);
        this.ProviderAdjustmentNumberCrossReference = segment.GetField<EI>(12);
        this.ProviderProductServiceLineItemNumberCrossReference = segment.GetField<EI>(13);
        this.AdjustmentDate = segment.GetRequiredField<DTM>(14);
        this.ResponsibleOrganization = segment.GetField<XON>(15);
    }
}

public sealed record AFF : Hl7Segment {
    public SI SetIDAFF { get; }
    public XON ProfessionalOrganization { get; }
    public XAD? ProfessionalOrganizationAddress { get; }
    public ICollection<DR>? ProfessionalOrganizationAffiliationDateRange { get; }
    public ST? ProfessionalAffiliationAdditionalInformation { get; }

    public AFF(Segment segment) : base(typeof(AFF), segment) {
        this.SetIDAFF = segment.GetRequiredField<SI>(1);
        this.ProfessionalOrganization = segment.GetRequiredField<XON>(2);
        this.ProfessionalOrganizationAddress = segment.GetField<XAD>(3);
        this.ProfessionalOrganizationAffiliationDateRange = segment.GetRepField<DR>(4);
        this.ProfessionalAffiliationAdditionalInformation = segment.GetField<ST>(5);
    }
}

public sealed record AIG : Hl7Segment {
    public SI SetIDAIG { get; }
    public ID? SegmentActionCode { get; }
    public CWE? ResourceID { get; }
    public CWE ResourceType { get; }
    public ICollection<CWE>? ResourceGroup { get; }
    public NM? ResourceQuantity { get; }
    public CNE? ResourceQuantityUnits { get; }
    public DTM? StartDateTime { get; }
    public NM? StartDateTimeOffset { get; }
    public CNE? StartDateTimeOffsetUnits { get; }
    public NM? Duration { get; }
    public CNE? DurationUnits { get; }
    public CWE? AllowSubstitutionCode { get; }
    public CWE? FillerStatusCode { get; }

    public AIG(Segment segment) : base(typeof(AIG), segment) {
        this.SetIDAIG = segment.GetRequiredField<SI>(1);
        this.SegmentActionCode = segment.GetField<ID>(2);
        this.ResourceID = segment.GetField<CWE>(3);
        this.ResourceType = segment.GetRequiredField<CWE>(4);
        this.ResourceGroup = segment.GetRepField<CWE>(5);
        this.ResourceQuantity = segment.GetField<NM>(6);
        this.ResourceQuantityUnits = segment.GetField<CNE>(7);
        this.StartDateTime = segment.GetField<DTM>(8);
        this.StartDateTimeOffset = segment.GetField<NM>(9);
        this.StartDateTimeOffsetUnits = segment.GetField<CNE>(10);
        this.Duration = segment.GetField<NM>(11);
        this.DurationUnits = segment.GetField<CNE>(12);
        this.AllowSubstitutionCode = segment.GetField<CWE>(13);
        this.FillerStatusCode = segment.GetField<CWE>(14);
    }
}

public sealed record AIL : Hl7Segment {
    public SI SetIDAIL { get; }
    public ID? SegmentActionCode { get; }
    public PL? LocationResourceID { get; }
    public CWE? LocationTypeAIL { get; }
    public CWE? LocationGroup { get; }
    public DTM? StartDateTime { get; }
    public NM? StartDateTimeOffset { get; }
    public CNE? StartDateTimeOffsetUnits { get; }
    public NM? Duration { get; }
    public CNE? DurationUnits { get; }
    public CWE? AllowSubstitutionCode { get; }
    public CWE? FillerStatusCode { get; }

    public AIL(Segment segment) : base(typeof(AIL), segment) {
        this.SetIDAIL = segment.GetRequiredField<SI>(1);
        this.SegmentActionCode = segment.GetField<ID>(2);
        this.LocationResourceID = segment.GetField<PL>(3);
        this.LocationTypeAIL = segment.GetField<CWE>(4);
        this.LocationGroup = segment.GetField<CWE>(5);
        this.StartDateTime = segment.GetField<DTM>(6);
        this.StartDateTimeOffset = segment.GetField<NM>(7);
        this.StartDateTimeOffsetUnits = segment.GetField<CNE>(8);
        this.Duration = segment.GetField<NM>(9);
        this.DurationUnits = segment.GetField<CNE>(10);
        this.AllowSubstitutionCode = segment.GetField<CWE>(11);
        this.FillerStatusCode = segment.GetField<CWE>(12);
    }
}

public sealed record AIP : Hl7Segment {
    public SI SetIDAIP { get; }
    public ID? SegmentActionCode { get; }
    public XCN? PersonnelResourceID { get; }
    public CWE? ResourceType { get; }
    public CWE? ResourceGroup { get; }
    public DTM? StartDateTime { get; }
    public NM? StartDateTimeOffset { get; }
    public CNE? StartDateTimeOffsetUnits { get; }
    public NM? Duration { get; }
    public CNE? DurationUnits { get; }
    public CWE? AllowSubstitutionCode { get; }
    public CWE? FillerStatusCode { get; }

    public AIP(Segment segment) : base(typeof(AIP), segment) {
        this.SetIDAIP = segment.GetRequiredField<SI>(1);
        this.SegmentActionCode = segment.GetField<ID>(2);
        this.PersonnelResourceID = segment.GetField<XCN>(3);
        this.ResourceType = segment.GetField<CWE>(4);
        this.ResourceGroup = segment.GetField<CWE>(5);
        this.StartDateTime = segment.GetField<DTM>(6);
        this.StartDateTimeOffset = segment.GetField<NM>(7);
        this.StartDateTimeOffsetUnits = segment.GetField<CNE>(8);
        this.Duration = segment.GetField<NM>(9);
        this.DurationUnits = segment.GetField<CNE>(10);
        this.AllowSubstitutionCode = segment.GetField<CWE>(11);
        this.FillerStatusCode = segment.GetField<CWE>(12);
    }
}

public sealed record AIS : Hl7Segment {
    public SI SetIDAIS { get; }
    public ID? SegmentActionCode { get; }
    public CWE UniversalServiceIdentifier { get; }
    public DTM? StartDateTime { get; }
    public NM? StartDateTimeOffset { get; }
    public CNE? StartDateTimeOffsetUnits { get; }
    public NM? Duration { get; }
    public CNE? DurationUnits { get; }
    public CWE? AllowSubstitutionCode { get; }
    public CWE? FillerStatusCode { get; }
    public ICollection<CWE>? PlacerSupplementalServiceInformation { get; }
    public ICollection<CWE>? FillerSupplementalServiceInformation { get; }

    public AIS(Segment segment) : base(typeof(AIS), segment) {
        this.SetIDAIS = segment.GetRequiredField<SI>(1);
        this.SegmentActionCode = segment.GetField<ID>(2);
        this.UniversalServiceIdentifier = segment.GetRequiredField<CWE>(3);
        this.StartDateTime = segment.GetField<DTM>(4);
        this.StartDateTimeOffset = segment.GetField<NM>(5);
        this.StartDateTimeOffsetUnits = segment.GetField<CNE>(6);
        this.Duration = segment.GetField<NM>(7);
        this.DurationUnits = segment.GetField<CNE>(8);
        this.AllowSubstitutionCode = segment.GetField<CWE>(9);
        this.FillerStatusCode = segment.GetField<CWE>(10);
        this.PlacerSupplementalServiceInformation = segment.GetRepField<CWE>(11);
        this.FillerSupplementalServiceInformation = segment.GetRepField<CWE>(12);
    }
}

public sealed record AL1 : Hl7Segment {
    public SI SetIDAL1 { get; }
    public CWE? AllergenTypeCode { get; }
    public CWE? AllergenCodeMnemonicDescription { get; }
    public CWE? AllergySeverityCode { get; }
    public ICollection<ST>? AllergyReactionCode { get; }
    public ST? IdentificationDate { get; }

    public AL1(Segment segment) : base(typeof(AL1), segment) {
        this.SetIDAL1 = segment.GetRequiredField<SI>(1);
        this.AllergenTypeCode = segment.GetField<CWE>(2);
        this.AllergenCodeMnemonicDescription = segment.GetField<CWE>(3);
        this.AllergySeverityCode = segment.GetField<CWE>(4);
        this.AllergyReactionCode = segment.GetRepField<ST>(5);
        this.IdentificationDate = segment.GetField<ST>(6);
    }
}

public sealed record APR : Hl7Segment {
    public ICollection<SCV>? TimeSelectionCriteria { get; }
    public ICollection<SCV>? ResourceSelectionCriteria { get; }
    public ICollection<SCV>? LocationSelectionCriteria { get; }
    public NM? SlotSpacingCriteria { get; }
    public ICollection<SCV>? FillerOverrideCriteria { get; }

    public APR(Segment segment) : base(typeof(APR), segment) {
        this.TimeSelectionCriteria = segment.GetRepField<SCV>(1);
        this.ResourceSelectionCriteria = segment.GetRepField<SCV>(2);
        this.LocationSelectionCriteria = segment.GetRepField<SCV>(3);
        this.SlotSpacingCriteria = segment.GetField<NM>(4);
        this.FillerOverrideCriteria = segment.GetRepField<SCV>(5);
    }
}

public sealed record ARQ : Hl7Segment {
    public EI PlacerAppointmentID { get; }
    public EI? FillerAppointmentID { get; }
    public NM? OccurrenceNumber { get; }
    public EI? PlacerOrderGroupNumber { get; }
    public CWE? ScheduleID { get; }
    public CWE? RequestEventReason { get; }
    public CWE? AppointmentReason { get; }
    public CWE? AppointmentType { get; }
    public NM? AppointmentDuration { get; }
    public CNE? AppointmentDurationUnits { get; }
    public ICollection<DR>? RequestedStartDateTimeRange { get; }
    public ST? PriorityARQ { get; }
    public RI? RepeatingInterval { get; }
    public ST? RepeatingIntervalDuration { get; }
    public ICollection<XCN> PlacerContactPerson { get; }
    public ICollection<XTN>? PlacerContactPhoneNumber { get; }
    public ICollection<XAD>? PlacerContactAddress { get; }
    public PL? PlacerContactLocation { get; }
    public ICollection<XCN> EnteredByPerson { get; }
    public ICollection<XTN>? EnteredByPhoneNumber { get; }
    public PL? EnteredByLocation { get; }
    public EI? ParentPlacerAppointmentID { get; }
    public EI? ParentFillerAppointmentID { get; }
    public EI? PlacerOrderNumber { get; }
    public EI? FillerOrderNumber { get; }
    public EIP? AlternatePlacerOrderGroupNumber { get; }

    public ARQ(Segment segment) : base(typeof(ARQ), segment) {
        this.PlacerAppointmentID = segment.GetRequiredField<EI>(1);
        this.FillerAppointmentID = segment.GetField<EI>(2);
        this.OccurrenceNumber = segment.GetField<NM>(3);
        this.PlacerOrderGroupNumber = segment.GetField<EI>(4);
        this.ScheduleID = segment.GetField<CWE>(5);
        this.RequestEventReason = segment.GetField<CWE>(6);
        this.AppointmentReason = segment.GetField<CWE>(7);
        this.AppointmentType = segment.GetField<CWE>(8);
        this.AppointmentDuration = segment.GetField<NM>(9);
        this.AppointmentDurationUnits = segment.GetField<CNE>(10);
        this.RequestedStartDateTimeRange = segment.GetRepField<DR>(11);
        this.PriorityARQ = segment.GetField<ST>(12);
        this.RepeatingInterval = segment.GetField<RI>(13);
        this.RepeatingIntervalDuration = segment.GetField<ST>(14);
        this.PlacerContactPerson = segment.GetRequiredRepField<XCN>(15);
        this.PlacerContactPhoneNumber = segment.GetRepField<XTN>(16);
        this.PlacerContactAddress = segment.GetRepField<XAD>(17);
        this.PlacerContactLocation = segment.GetField<PL>(18);
        this.EnteredByPerson = segment.GetRequiredRepField<XCN>(19);
        this.EnteredByPhoneNumber = segment.GetRepField<XTN>(20);
        this.EnteredByLocation = segment.GetField<PL>(21);
        this.ParentPlacerAppointmentID = segment.GetField<EI>(22);
        this.ParentFillerAppointmentID = segment.GetField<EI>(23);
        this.PlacerOrderNumber = segment.GetField<EI>(24);
        this.FillerOrderNumber = segment.GetField<EI>(25);
        this.AlternatePlacerOrderGroupNumber = segment.GetField<EIP>(26);
    }
}

public sealed record ARV : Hl7Segment {
    public SI? SetID { get; }
    public CNE AccessRestrictionActionCode { get; }
    public CWE AccessRestrictionValue { get; }
    public ICollection<CWE>? AccessRestrictionReason { get; }
    public ICollection<ST>? SpecialAccessRestrictionInstructions { get; }
    public DR? AccessRestrictionDateRange { get; }
    public CWE SecurityClassificationTag { get; }
    public ICollection<CWE>? SecurityHandlingInstructions { get; }
    public ICollection<ERL>? AccessRestrictionMessageLocation { get; }
    public EI? AccessRestrictionInstanceIdentifier { get; }

    public ARV(Segment segment) : base(typeof(ARV), segment) {
        this.SetID = segment.GetField<SI>(1);
        this.AccessRestrictionActionCode = segment.GetRequiredField<CNE>(2);
        this.AccessRestrictionValue = segment.GetRequiredField<CWE>(3);
        this.AccessRestrictionReason = segment.GetRepField<CWE>(4);
        this.SpecialAccessRestrictionInstructions = segment.GetRepField<ST>(5);
        this.AccessRestrictionDateRange = segment.GetField<DR>(6);
        this.SecurityClassificationTag = segment.GetRequiredField<CWE>(7);
        this.SecurityHandlingInstructions = segment.GetRepField<CWE>(8);
        this.AccessRestrictionMessageLocation = segment.GetRepField<ERL>(9);
        this.AccessRestrictionInstanceIdentifier = segment.GetField<EI>(10);
    }
}

public sealed record AUT : Hl7Segment {
    public CWE? AuthorizingPayorPlanID { get; }
    public CWE AuthorizingPayorCompanyID { get; }
    public ST? AuthorizingPayorCompanyName { get; }
    public DTM? AuthorizationEffectiveDate { get; }
    public DTM? AuthorizationExpirationDate { get; }
    public EI? AuthorizationIdentifier { get; }
    public CP? ReimbursementLimit { get; }
    public CQ? RequestedNumberofTreatments { get; }
    public CQ? AuthorizedNumberofTreatments { get; }
    public DTM? ProcessDate { get; }
    public ICollection<CWE>? RequestedDisciplines { get; }
    public ICollection<CWE>? AuthorizedDisciplines { get; }
    public CWE AuthorizationReferralType { get; }
    public CWE? ApprovalStatus { get; }
    public DTM? PlannedTreatmentStopDate { get; }
    public CWE? ClinicalService { get; }
    public ST? ReasonText { get; }
    public CQ? NumberofAuthorizedTreatmentsUnits { get; }
    public CQ? NumberofUsedTreatmentsUnits { get; }
    public CQ? NumberofScheduleTreatmentsUnits { get; }
    public CWE? EncounterType { get; }
    public MO? RemainingBenefitAmount { get; }
    public XON? AuthorizedProvider { get; }
    public XCN? AuthorizedHealthProfessional { get; }
    public ST? SourceText { get; }
    public DTM? SourceDate { get; }
    public XTN? SourcePhone { get; }
    public ST? Comment { get; }
    public ID? ActionCode { get; }

    public AUT(Segment segment) : base(typeof(AUT), segment) {
        this.AuthorizingPayorPlanID = segment.GetField<CWE>(1);
        this.AuthorizingPayorCompanyID = segment.GetRequiredField<CWE>(2);
        this.AuthorizingPayorCompanyName = segment.GetField<ST>(3);
        this.AuthorizationEffectiveDate = segment.GetField<DTM>(4);
        this.AuthorizationExpirationDate = segment.GetField<DTM>(5);
        this.AuthorizationIdentifier = segment.GetField<EI>(6);
        this.ReimbursementLimit = segment.GetField<CP>(7);
        this.RequestedNumberofTreatments = segment.GetField<CQ>(8);
        this.AuthorizedNumberofTreatments = segment.GetField<CQ>(9);
        this.ProcessDate = segment.GetField<DTM>(10);
        this.RequestedDisciplines = segment.GetRepField<CWE>(11);
        this.AuthorizedDisciplines = segment.GetRepField<CWE>(12);
        this.AuthorizationReferralType = segment.GetRequiredField<CWE>(13);
        this.ApprovalStatus = segment.GetField<CWE>(14);
        this.PlannedTreatmentStopDate = segment.GetField<DTM>(15);
        this.ClinicalService = segment.GetField<CWE>(16);
        this.ReasonText = segment.GetField<ST>(17);
        this.NumberofAuthorizedTreatmentsUnits = segment.GetField<CQ>(18);
        this.NumberofUsedTreatmentsUnits = segment.GetField<CQ>(19);
        this.NumberofScheduleTreatmentsUnits = segment.GetField<CQ>(20);
        this.EncounterType = segment.GetField<CWE>(21);
        this.RemainingBenefitAmount = segment.GetField<MO>(22);
        this.AuthorizedProvider = segment.GetField<XON>(23);
        this.AuthorizedHealthProfessional = segment.GetField<XCN>(24);
        this.SourceText = segment.GetField<ST>(25);
        this.SourceDate = segment.GetField<DTM>(26);
        this.SourcePhone = segment.GetField<XTN>(27);
        this.Comment = segment.GetField<ST>(28);
        this.ActionCode = segment.GetField<ID>(29);
    }
}

public sealed record BHS : Hl7Segment {
    public ST BatchFieldSeparator { get; }
    public ST BatchEncodingCharacters { get; }
    public HD? BatchSendingApplication { get; }
    public HD? BatchSendingFacility { get; }
    public HD? BatchReceivingApplication { get; }
    public HD? BatchReceivingFacility { get; }
    public DTM? BatchCreationDateTime { get; }
    public ST? BatchSecurity { get; }
    public ST? BatchNameIDType { get; }
    public ST? BatchComment { get; }
    public ST? BatchControlID { get; }
    public ST? ReferenceBatchControlID { get; }
    public HD? BatchSendingNetworkAddress { get; }
    public HD? BatchReceivingNetworkAddress { get; }
    public CWE? SecurityClassificationTag { get; }
    public CWE? SecurityHandlingInstructions { get; }
    public ST? SpecialAccessRestrictionInstructions { get; }

    public BHS(Segment segment) : base(typeof(BHS), segment) {
        this.BatchFieldSeparator = segment.GetRequiredField<ST>(1);
        this.BatchEncodingCharacters = segment.GetRequiredField<ST>(2);
        this.BatchSendingApplication = segment.GetField<HD>(3);
        this.BatchSendingFacility = segment.GetField<HD>(4);
        this.BatchReceivingApplication = segment.GetField<HD>(5);
        this.BatchReceivingFacility = segment.GetField<HD>(6);
        this.BatchCreationDateTime = segment.GetField<DTM>(7);
        this.BatchSecurity = segment.GetField<ST>(8);
        this.BatchNameIDType = segment.GetField<ST>(9);
        this.BatchComment = segment.GetField<ST>(10);
        this.BatchControlID = segment.GetField<ST>(11);
        this.ReferenceBatchControlID = segment.GetField<ST>(12);
        this.BatchSendingNetworkAddress = segment.GetField<HD>(13);
        this.BatchReceivingNetworkAddress = segment.GetField<HD>(14);
        this.SecurityClassificationTag = segment.GetField<CWE>(15);
        this.SecurityHandlingInstructions = segment.GetField<CWE>(16);
        this.SpecialAccessRestrictionInstructions = segment.GetField<ST>(17);
    }
}

public sealed record BLC : Hl7Segment {
    public CWE? BloodProductCode { get; }
    public CQ? BloodAmount { get; }

    public BLC(Segment segment) : base(typeof(BLC), segment) {
        this.BloodProductCode = segment.GetField<CWE>(1);
        this.BloodAmount = segment.GetField<CQ>(2);
    }
}

public sealed record BLG : Hl7Segment {
    public CCD? WhentoCharge { get; }
    public ID? ChargeType { get; }
    public CX? AccountID { get; }
    public CWE? ChargeTypeReason { get; }

    public BLG(Segment segment) : base(typeof(BLG), segment) {
        this.WhentoCharge = segment.GetField<CCD>(1);
        this.ChargeType = segment.GetField<ID>(2);
        this.AccountID = segment.GetField<CX>(3);
        this.ChargeTypeReason = segment.GetField<CWE>(4);
    }
}

public sealed record BPO : Hl7Segment {
    public SI SetIDBPO { get; }
    public CWE BPUniversalServiceIdentifier { get; }
    public ICollection<CWE>? BPProcessingRequirements { get; }
    public NM BPQuantity { get; }
    public NM? BPAmount { get; }
    public CWE? BPUnits { get; }
    public DTM? BPIntendedUseDateTime { get; }
    public PL? BPIntendedDispenseFromLocation { get; }
    public XAD? BPIntendedDispenseFromAddress { get; }
    public DTM? BPRequestedDispenseDateTime { get; }
    public PL? BPRequestedDispenseToLocation { get; }
    public XAD? BPRequestedDispenseToAddress { get; }
    public ICollection<CWE>? BPIndicationforUse { get; }
    public ID? BPInformedConsentIndicator { get; }

    public BPO(Segment segment) : base(typeof(BPO), segment) {
        this.SetIDBPO = segment.GetRequiredField<SI>(1);
        this.BPUniversalServiceIdentifier = segment.GetRequiredField<CWE>(2);
        this.BPProcessingRequirements = segment.GetRepField<CWE>(3);
        this.BPQuantity = segment.GetRequiredField<NM>(4);
        this.BPAmount = segment.GetField<NM>(5);
        this.BPUnits = segment.GetField<CWE>(6);
        this.BPIntendedUseDateTime = segment.GetField<DTM>(7);
        this.BPIntendedDispenseFromLocation = segment.GetField<PL>(8);
        this.BPIntendedDispenseFromAddress = segment.GetField<XAD>(9);
        this.BPRequestedDispenseDateTime = segment.GetField<DTM>(10);
        this.BPRequestedDispenseToLocation = segment.GetField<PL>(11);
        this.BPRequestedDispenseToAddress = segment.GetField<XAD>(12);
        this.BPIndicationforUse = segment.GetRepField<CWE>(13);
        this.BPInformedConsentIndicator = segment.GetField<ID>(14);
    }
}

public sealed record BPX : Hl7Segment {
    public SI SetIDBPX { get; }
    public CWE BPDispenseStatus { get; }
    public ID BPStatus { get; }
    public DTM BPDateTimeofStatus { get; }
    public EI? BCDonationID { get; }
    public CNE? BCComponent { get; }
    public CNE? BCDonationTypeIntendedUse { get; }
    public CWE? CPCommercialProduct { get; }
    public XON? CPManufacturer { get; }
    public EI? CPLotNumber { get; }
    public CNE? BPBloodGroup { get; }
    public ICollection<CNE>? BCSpecialTesting { get; }
    public DTM? BPExpirationDateTime { get; }
    public NM BPQuantity { get; }
    public NM? BPAmount { get; }
    public CWE? BPUnits { get; }
    public EI? BPUniqueID { get; }
    public PL? BPActualDispensedToLocation { get; }
    public XAD? BPActualDispensedToAddress { get; }
    public XCN? BPDispensedtoReceiver { get; }
    public XCN? BPDispensingIndividual { get; }
    public ID? ActionCode { get; }

    public BPX(Segment segment) : base(typeof(BPX), segment) {
        this.SetIDBPX = segment.GetRequiredField<SI>(1);
        this.BPDispenseStatus = segment.GetRequiredField<CWE>(2);
        this.BPStatus = segment.GetRequiredField<ID>(3);
        this.BPDateTimeofStatus = segment.GetRequiredField<DTM>(4);
        this.BCDonationID = segment.GetField<EI>(5);
        this.BCComponent = segment.GetField<CNE>(6);
        this.BCDonationTypeIntendedUse = segment.GetField<CNE>(7);
        this.CPCommercialProduct = segment.GetField<CWE>(8);
        this.CPManufacturer = segment.GetField<XON>(9);
        this.CPLotNumber = segment.GetField<EI>(10);
        this.BPBloodGroup = segment.GetField<CNE>(11);
        this.BCSpecialTesting = segment.GetRepField<CNE>(12);
        this.BPExpirationDateTime = segment.GetField<DTM>(13);
        this.BPQuantity = segment.GetRequiredField<NM>(14);
        this.BPAmount = segment.GetField<NM>(15);
        this.BPUnits = segment.GetField<CWE>(16);
        this.BPUniqueID = segment.GetField<EI>(17);
        this.BPActualDispensedToLocation = segment.GetField<PL>(18);
        this.BPActualDispensedToAddress = segment.GetField<XAD>(19);
        this.BPDispensedtoReceiver = segment.GetField<XCN>(20);
        this.BPDispensingIndividual = segment.GetField<XCN>(21);
        this.ActionCode = segment.GetField<ID>(22);
    }
}

public sealed record BTS : Hl7Segment {
    public ST? BatchMessageCount { get; }
    public ST? BatchComment { get; }
    public ICollection<NM>? BatchTotals { get; }

    public BTS(Segment segment) : base(typeof(BTS), segment) {
        this.BatchMessageCount = segment.GetField<ST>(1);
        this.BatchComment = segment.GetField<ST>(2);
        this.BatchTotals = segment.GetRepField<NM>(3);
    }
}

public sealed record BTX : Hl7Segment {
    public SI SetIDBTX { get; }
    public EI? BCDonationID { get; }
    public CNE? BCComponent { get; }
    public CNE? BCBloodGroup { get; }
    public CWE? CPCommercialProduct { get; }
    public XON? CPManufacturer { get; }
    public EI? CPLotNumber { get; }
    public NM BPQuantity { get; }
    public NM? BPAmount { get; }
    public CWE? BPUnits { get; }
    public CWE BPTransfusionDispositionStatus { get; }
    public ID BPMessageStatus { get; }
    public DTM BPDateTimeofStatus { get; }
    public XCN? BPTransfusionAdministrator { get; }
    public XCN? BPTransfusionVerifier { get; }
    public DTM? BPTransfusionStartDateTimeofStatus { get; }
    public DTM? BPTransfusionEndDateTimeofStatus { get; }
    public ICollection<CWE>? BPAdverseReactionType { get; }
    public CWE? BPTransfusionInterruptedReason { get; }
    public EI? BPUniqueID { get; }
    public ID? ActionCode { get; }

    public BTX(Segment segment) : base(typeof(BTX), segment) {
        this.SetIDBTX = segment.GetRequiredField<SI>(1);
        this.BCDonationID = segment.GetField<EI>(2);
        this.BCComponent = segment.GetField<CNE>(3);
        this.BCBloodGroup = segment.GetField<CNE>(4);
        this.CPCommercialProduct = segment.GetField<CWE>(5);
        this.CPManufacturer = segment.GetField<XON>(6);
        this.CPLotNumber = segment.GetField<EI>(7);
        this.BPQuantity = segment.GetRequiredField<NM>(8);
        this.BPAmount = segment.GetField<NM>(9);
        this.BPUnits = segment.GetField<CWE>(10);
        this.BPTransfusionDispositionStatus = segment.GetRequiredField<CWE>(11);
        this.BPMessageStatus = segment.GetRequiredField<ID>(12);
        this.BPDateTimeofStatus = segment.GetRequiredField<DTM>(13);
        this.BPTransfusionAdministrator = segment.GetField<XCN>(14);
        this.BPTransfusionVerifier = segment.GetField<XCN>(15);
        this.BPTransfusionStartDateTimeofStatus = segment.GetField<DTM>(16);
        this.BPTransfusionEndDateTimeofStatus = segment.GetField<DTM>(17);
        this.BPAdverseReactionType = segment.GetRepField<CWE>(18);
        this.BPTransfusionInterruptedReason = segment.GetField<CWE>(19);
        this.BPUniqueID = segment.GetField<EI>(20);
        this.ActionCode = segment.GetField<ID>(21);
    }
}

public sealed record BUI : Hl7Segment {
    public SI? SetIDBUI { get; }
    public EI BloodUnitIdentifier { get; }
    public CWE BloodUnitType { get; }
    public NM BloodUnitWeight { get; }
    public CNE WeightUnits { get; }
    public NM BloodUnitVolume { get; }
    public CNE VolumeUnits { get; }
    public ST ContainerCatalogNumber { get; }
    public ST ContainerLotNumber { get; }
    public XON ContainerManufacturer { get; }
    public NR TransportTemperature { get; }
    public ICollection<CNE> TransportTemperatureUnits { get; }
    public ID? ActionCode { get; }

    public BUI(Segment segment) : base(typeof(BUI), segment) {
        this.SetIDBUI = segment.GetField<SI>(1);
        this.BloodUnitIdentifier = segment.GetRequiredField<EI>(2);
        this.BloodUnitType = segment.GetRequiredField<CWE>(3);
        this.BloodUnitWeight = segment.GetRequiredField<NM>(4);
        this.WeightUnits = segment.GetRequiredField<CNE>(5);
        this.BloodUnitVolume = segment.GetRequiredField<NM>(6);
        this.VolumeUnits = segment.GetRequiredField<CNE>(7);
        this.ContainerCatalogNumber = segment.GetRequiredField<ST>(8);
        this.ContainerLotNumber = segment.GetRequiredField<ST>(9);
        this.ContainerManufacturer = segment.GetRequiredField<XON>(10);
        this.TransportTemperature = segment.GetRequiredField<NR>(11);
        this.TransportTemperatureUnits = segment.GetRequiredRepField<CNE>(12);
        this.ActionCode = segment.GetField<ID>(13);
    }
}

public sealed record CDM : Hl7Segment {
    public CWE PrimaryKeyValueCDM { get; }
    public ICollection<CWE>? ChargeCodeAlias { get; }
    public ST ChargeDescriptionShort { get; }
    public ST? ChargeDescriptionLong { get; }
    public CWE? DescriptionOverrideIndicator { get; }
    public ICollection<CWE>? ExplodingCharges { get; }
    public ICollection<CNE>? ProcedureCode { get; }
    public ID? ActiveInactiveFlag { get; }
    public ICollection<CWE>? InventoryNumber { get; }
    public NM? ResourceLoad { get; }
    public ICollection<CX>? ContractNumber { get; }
    public ICollection<XON>? ContractOrganization { get; }
    public ID? RoomFeeIndicator { get; }

    public CDM(Segment segment) : base(typeof(CDM), segment) {
        this.PrimaryKeyValueCDM = segment.GetRequiredField<CWE>(1);
        this.ChargeCodeAlias = segment.GetRepField<CWE>(2);
        this.ChargeDescriptionShort = segment.GetRequiredField<ST>(3);
        this.ChargeDescriptionLong = segment.GetField<ST>(4);
        this.DescriptionOverrideIndicator = segment.GetField<CWE>(5);
        this.ExplodingCharges = segment.GetRepField<CWE>(6);
        this.ProcedureCode = segment.GetRepField<CNE>(7);
        this.ActiveInactiveFlag = segment.GetField<ID>(8);
        this.InventoryNumber = segment.GetRepField<CWE>(9);
        this.ResourceLoad = segment.GetField<NM>(10);
        this.ContractNumber = segment.GetRepField<CX>(11);
        this.ContractOrganization = segment.GetRepField<XON>(12);
        this.RoomFeeIndicator = segment.GetField<ID>(13);
    }
}

public sealed record CDO : Hl7Segment {
    public SI? SetIDCDO { get; }
    public ID? ActionCode { get; }
    public CQ? CumulativeDosageLimit { get; }
    public CQ? CumulativeDosageLimitTimeInterval { get; }

    public CDO(Segment segment) : base(typeof(CDO), segment) {
        this.SetIDCDO = segment.GetField<SI>(1);
        this.ActionCode = segment.GetField<ID>(2);
        this.CumulativeDosageLimit = segment.GetField<CQ>(3);
        this.CumulativeDosageLimitTimeInterval = segment.GetField<CQ>(4);
    }
}

public sealed record CER : Hl7Segment {
    public SI SetIDCER { get; }
    public ST? SerialNumber { get; }
    public ST? Version { get; }
    public XON? GrantingAuthority { get; }
    public XCN? IssuingAuthority { get; }
    public ED? Signature { get; }
    public ID? GrantingCountry { get; }
    public CWE? GrantingStateProvince { get; }
    public CWE? GrantingCountyParish { get; }
    public CWE? CertificateType { get; }
    public CWE? CertificateDomain { get; }
    public EI? SubjectID { get; }
    public ST SubjectName { get; }
    public ICollection<CWE>? SubjectDirectoryAttributeExtension { get; }
    public CWE? SubjectPublicKeyInfo { get; }
    public CWE? AuthorityKeyIdentifier { get; }
    public ID? BasicConstraint { get; }
    public ICollection<CWE>? CRLDistributionPoint { get; }
    public ID? JurisdictionCountry { get; }
    public CWE? JurisdictionStateProvince { get; }
    public CWE? JurisdictionCountyParish { get; }
    public ICollection<CWE>? JurisdictionBreadth { get; }
    public DTM? GrantingDate { get; }
    public DTM? IssuingDate { get; }
    public DTM? ActivationDate { get; }
    public DTM? InactivationDate { get; }
    public DTM? ExpirationDate { get; }
    public DTM? RenewalDate { get; }
    public DTM? RevocationDate { get; }
    public CWE? RevocationReasonCode { get; }
    public CWE? CertificateStatusCode { get; }

    public CER(Segment segment) : base(typeof(CER), segment) {
        this.SetIDCER = segment.GetRequiredField<SI>(1);
        this.SerialNumber = segment.GetField<ST>(2);
        this.Version = segment.GetField<ST>(3);
        this.GrantingAuthority = segment.GetField<XON>(4);
        this.IssuingAuthority = segment.GetField<XCN>(5);
        this.Signature = segment.GetField<ED>(6);
        this.GrantingCountry = segment.GetField<ID>(7);
        this.GrantingStateProvince = segment.GetField<CWE>(8);
        this.GrantingCountyParish = segment.GetField<CWE>(9);
        this.CertificateType = segment.GetField<CWE>(10);
        this.CertificateDomain = segment.GetField<CWE>(11);
        this.SubjectID = segment.GetField<EI>(12);
        this.SubjectName = segment.GetRequiredField<ST>(13);
        this.SubjectDirectoryAttributeExtension = segment.GetRepField<CWE>(14);
        this.SubjectPublicKeyInfo = segment.GetField<CWE>(15);
        this.AuthorityKeyIdentifier = segment.GetField<CWE>(16);
        this.BasicConstraint = segment.GetField<ID>(17);
        this.CRLDistributionPoint = segment.GetRepField<CWE>(18);
        this.JurisdictionCountry = segment.GetField<ID>(19);
        this.JurisdictionStateProvince = segment.GetField<CWE>(20);
        this.JurisdictionCountyParish = segment.GetField<CWE>(21);
        this.JurisdictionBreadth = segment.GetRepField<CWE>(22);
        this.GrantingDate = segment.GetField<DTM>(23);
        this.IssuingDate = segment.GetField<DTM>(24);
        this.ActivationDate = segment.GetField<DTM>(25);
        this.InactivationDate = segment.GetField<DTM>(26);
        this.ExpirationDate = segment.GetField<DTM>(27);
        this.RenewalDate = segment.GetField<DTM>(28);
        this.RevocationDate = segment.GetField<DTM>(29);
        this.RevocationReasonCode = segment.GetField<CWE>(30);
        this.CertificateStatusCode = segment.GetField<CWE>(31);
    }
}

public sealed record CM0 : Hl7Segment {
    public SI? SetIDCM0 { get; }
    public EI SponsorStudyID { get; }
    public EI? AlternateStudyID { get; }
    public ST TitleofStudy { get; }
    public ICollection<XCN>? ChairmanofStudy { get; }
    public DT? LastIRBApprovalDate { get; }
    public NM? TotalAccrualtoDate { get; }
    public DT? LastAccrualDate { get; }
    public ICollection<XCN>? ContactforStudy { get; }
    public XTN? ContactsTelephoneNumber { get; }
    public ICollection<XAD>? ContactsAddress { get; }

    public CM0(Segment segment) : base(typeof(CM0), segment) {
        this.SetIDCM0 = segment.GetField<SI>(1);
        this.SponsorStudyID = segment.GetRequiredField<EI>(2);
        this.AlternateStudyID = segment.GetField<EI>(3);
        this.TitleofStudy = segment.GetRequiredField<ST>(4);
        this.ChairmanofStudy = segment.GetRepField<XCN>(5);
        this.LastIRBApprovalDate = segment.GetField<DT>(6);
        this.TotalAccrualtoDate = segment.GetField<NM>(7);
        this.LastAccrualDate = segment.GetField<DT>(8);
        this.ContactforStudy = segment.GetRepField<XCN>(9);
        this.ContactsTelephoneNumber = segment.GetField<XTN>(10);
        this.ContactsAddress = segment.GetRepField<XAD>(11);
    }
}

public sealed record CM1 : Hl7Segment {
    public SI SetIDCM1 { get; }
    public CWE StudyPhaseIdentifier { get; }
    public ST DescriptionofStudyPhase { get; }

    public CM1(Segment segment) : base(typeof(CM1), segment) {
        this.SetIDCM1 = segment.GetRequiredField<SI>(1);
        this.StudyPhaseIdentifier = segment.GetRequiredField<CWE>(2);
        this.DescriptionofStudyPhase = segment.GetRequiredField<ST>(3);
    }
}

public sealed record CM2 : Hl7Segment {
    public SI? SetIDCM2 { get; }
    public CWE ScheduledTimePoint { get; }
    public ST? DescriptionofTimePoint { get; }
    public CWE EventsScheduledThisTimePoint { get; }

    public CM2(Segment segment) : base(typeof(CM2), segment) {
        this.SetIDCM2 = segment.GetField<SI>(1);
        this.ScheduledTimePoint = segment.GetRequiredField<CWE>(2);
        this.DescriptionofTimePoint = segment.GetField<ST>(3);
        this.EventsScheduledThisTimePoint = segment.GetRequiredField<CWE>(4);
    }
}

public sealed record CNS : Hl7Segment {
    public NM? StartingNotificationReferenceNumber { get; }
    public NM? EndingNotificationReferenceNumber { get; }
    public DTM? StartingNotificationDateTime { get; }
    public DTM? EndingNotificationDateTime { get; }
    public CWE? StartingNotificationCode { get; }
    public CWE? EndingNotificationCode { get; }

    public CNS(Segment segment) : base(typeof(CNS), segment) {
        this.StartingNotificationReferenceNumber = segment.GetField<NM>(1);
        this.EndingNotificationReferenceNumber = segment.GetField<NM>(2);
        this.StartingNotificationDateTime = segment.GetField<DTM>(3);
        this.EndingNotificationDateTime = segment.GetField<DTM>(4);
        this.StartingNotificationCode = segment.GetField<CWE>(5);
        this.EndingNotificationCode = segment.GetField<CWE>(6);
    }
}

public sealed record CSP : Hl7Segment {
    public CWE StudyPhaseIdentifier { get; }
    public DTM DatetimeStudyPhaseBegan { get; }
    public DTM? DatetimeStudyPhaseEnded { get; }
    public CWE? StudyPhaseEvaluability { get; }

    public CSP(Segment segment) : base(typeof(CSP), segment) {
        this.StudyPhaseIdentifier = segment.GetRequiredField<CWE>(1);
        this.DatetimeStudyPhaseBegan = segment.GetRequiredField<DTM>(2);
        this.DatetimeStudyPhaseEnded = segment.GetField<DTM>(3);
        this.StudyPhaseEvaluability = segment.GetField<CWE>(4);
    }
}

public sealed record CSR : Hl7Segment {
    public EI SponsorStudyID { get; }
    public EI? AlternateStudyID { get; }
    public CWE? InstitutionRegisteringthePatient { get; }
    public CX SponsorPatientID { get; }
    public CX? AlternatePatientIDCSR { get; }
    public DTM DateTimeofPatientStudyRegistration { get; }
    public ICollection<XCN>? PersonPerformingStudyRegistration { get; }
    public ICollection<XCN> StudyAuthorizingProvider { get; }
    public DTM? DateTimePatientStudyConsentSigned { get; }
    public CWE? PatientStudyEligibilityStatus { get; }
    public DTM? StudyRandomizationDatetime { get; }
    public CWE? RandomizedStudyArm { get; }
    public CWE? StratumforStudyRandomization { get; }
    public CWE? PatientEvaluabilityStatus { get; }
    public DTM? DateTimeEndedStudy { get; }
    public CWE? ReasonEndedStudy { get; }
    public ID? ActionCode { get; }

    public CSR(Segment segment) : base(typeof(CSR), segment) {
        this.SponsorStudyID = segment.GetRequiredField<EI>(1);
        this.AlternateStudyID = segment.GetField<EI>(2);
        this.InstitutionRegisteringthePatient = segment.GetField<CWE>(3);
        this.SponsorPatientID = segment.GetRequiredField<CX>(4);
        this.AlternatePatientIDCSR = segment.GetField<CX>(5);
        this.DateTimeofPatientStudyRegistration = segment.GetRequiredField<DTM>(6);
        this.PersonPerformingStudyRegistration = segment.GetRepField<XCN>(7);
        this.StudyAuthorizingProvider = segment.GetRequiredRepField<XCN>(8);
        this.DateTimePatientStudyConsentSigned = segment.GetField<DTM>(9);
        this.PatientStudyEligibilityStatus = segment.GetField<CWE>(10);
        this.StudyRandomizationDatetime = segment.GetField<DTM>(11);
        this.RandomizedStudyArm = segment.GetField<CWE>(12);
        this.StratumforStudyRandomization = segment.GetField<CWE>(13);
        this.PatientEvaluabilityStatus = segment.GetField<CWE>(14);
        this.DateTimeEndedStudy = segment.GetField<DTM>(15);
        this.ReasonEndedStudy = segment.GetField<CWE>(16);
        this.ActionCode = segment.GetField<ID>(17);
    }
}

public sealed record CSS : Hl7Segment {
    public CWE StudyScheduledTimePoint { get; }
    public DTM? StudyScheduledPatientTimePoint { get; }
    public CWE? StudyQualityControlCodes { get; }

    public CSS(Segment segment) : base(typeof(CSS), segment) {
        this.StudyScheduledTimePoint = segment.GetRequiredField<CWE>(1);
        this.StudyScheduledPatientTimePoint = segment.GetField<DTM>(2);
        this.StudyQualityControlCodes = segment.GetField<CWE>(3);
    }
}

public sealed record CTD : Hl7Segment {
    public ICollection<CWE> ContactRole { get; }
    public ICollection<XPN>? ContactName { get; }
    public ICollection<XAD>? ContactAddress { get; }
    public PL? ContactLocation { get; }
    public ICollection<XTN>? ContactCommunicationInformation { get; }
    public CWE? PreferredMethodofContact { get; }
    public ICollection<PLN>? ContactIdentifiers { get; }

    public CTD(Segment segment) : base(typeof(CTD), segment) {
        this.ContactRole = segment.GetRequiredRepField<CWE>(1);
        this.ContactName = segment.GetRepField<XPN>(2);
        this.ContactAddress = segment.GetRepField<XAD>(3);
        this.ContactLocation = segment.GetField<PL>(4);
        this.ContactCommunicationInformation = segment.GetRepField<XTN>(5);
        this.PreferredMethodofContact = segment.GetField<CWE>(6);
        this.ContactIdentifiers = segment.GetRepField<PLN>(7);
    }
}

public sealed record CTI : Hl7Segment {
    public EI SponsorStudyID { get; }
    public CWE? StudyPhaseIdentifier { get; }
    public CWE? StudyScheduledTimePoint { get; }
    public ID? ActionCode { get; }

    public CTI(Segment segment) : base(typeof(CTI), segment) {
        this.SponsorStudyID = segment.GetRequiredField<EI>(1);
        this.StudyPhaseIdentifier = segment.GetField<CWE>(2);
        this.StudyScheduledTimePoint = segment.GetField<CWE>(3);
        this.ActionCode = segment.GetField<ID>(4);
    }
}

public sealed record CTR : Hl7Segment {
    public EI ContractIdentifier { get; }
    public ST? ContractDescription { get; }
    public CWE? ContractStatus { get; }
    public DTM EffectiveDate { get; }
    public DTM ExpirationDate { get; }
    public XPN? ContractOwnerName { get; }
    public XPN? ContractOriginatorName { get; }
    public CWE SupplierType { get; }
    public CWE? ContractType { get; }
    public CNE? FreeOnBoardFreightTerms { get; }
    public DTM? PriceProtectionDate { get; }
    public CNE? FixedPriceContractIndicator { get; }
    public XON? GroupPurchasingOrganization { get; }
    public MOP? MaximumMarkup { get; }
    public MOP? ActualMarkup { get; }
    public XON? Corporation { get; }
    public XON? ParentofCorporation { get; }
    public CWE? PricingTierLevel { get; }
    public ST? ContractPriority { get; }
    public CWE? ClassofTrade { get; }
    public EI? AssociatedContractID { get; }

    public CTR(Segment segment) : base(typeof(CTR), segment) {
        this.ContractIdentifier = segment.GetRequiredField<EI>(1);
        this.ContractDescription = segment.GetField<ST>(2);
        this.ContractStatus = segment.GetField<CWE>(3);
        this.EffectiveDate = segment.GetRequiredField<DTM>(4);
        this.ExpirationDate = segment.GetRequiredField<DTM>(5);
        this.ContractOwnerName = segment.GetField<XPN>(6);
        this.ContractOriginatorName = segment.GetField<XPN>(7);
        this.SupplierType = segment.GetRequiredField<CWE>(8);
        this.ContractType = segment.GetField<CWE>(9);
        this.FreeOnBoardFreightTerms = segment.GetField<CNE>(10);
        this.PriceProtectionDate = segment.GetField<DTM>(11);
        this.FixedPriceContractIndicator = segment.GetField<CNE>(12);
        this.GroupPurchasingOrganization = segment.GetField<XON>(13);
        this.MaximumMarkup = segment.GetField<MOP>(14);
        this.ActualMarkup = segment.GetField<MOP>(15);
        this.Corporation = segment.GetField<XON>(16);
        this.ParentofCorporation = segment.GetField<XON>(17);
        this.PricingTierLevel = segment.GetField<CWE>(18);
        this.ContractPriority = segment.GetField<ST>(19);
        this.ClassofTrade = segment.GetField<CWE>(20);
        this.AssociatedContractID = segment.GetField<EI>(21);
    }
}

public sealed record DB1 : Hl7Segment {
    public SI SetIDDB1 { get; }
    public CWE? DisabledPersonCode { get; }
    public ICollection<CX>? DisabledPersonIdentifier { get; }
    public ID? DisabilityIndicator { get; }
    public DT? DisabilityStartDate { get; }
    public DT? DisabilityEndDate { get; }
    public DT? DisabilityReturntoWorkDate { get; }
    public DT? DisabilityUnabletoWorkDate { get; }

    public DB1(Segment segment) : base(typeof(DB1), segment) {
        this.SetIDDB1 = segment.GetRequiredField<SI>(1);
        this.DisabledPersonCode = segment.GetField<CWE>(2);
        this.DisabledPersonIdentifier = segment.GetRepField<CX>(3);
        this.DisabilityIndicator = segment.GetField<ID>(4);
        this.DisabilityStartDate = segment.GetField<DT>(5);
        this.DisabilityEndDate = segment.GetField<DT>(6);
        this.DisabilityReturntoWorkDate = segment.GetField<DT>(7);
        this.DisabilityUnabletoWorkDate = segment.GetField<DT>(8);
    }
}

public sealed record DEV : Hl7Segment {
    public ID ActionCode { get; }
    public EI? UniqueDeviceIdentifier { get; }
    public CNE? DeviceType { get; }
    public ICollection<CNE>? DeviceStatus { get; }
    public XON? ManufacturerDistributor { get; }
    public ST? BrandName { get; }
    public ST? ModelIdentifier { get; }
    public ST? CatalogueIdentifier { get; }
    public EI? UDIDeviceIdentifier { get; }
    public ST? DeviceLotNumber { get; }
    public ST? DeviceSerialNumber { get; }
    public DTM? DeviceManufactureDate { get; }
    public DTM? DeviceExpiryDate { get; }
    public ICollection<CWE>? SafetyCharacteristics { get; }
    public EI? DeviceDonationIdentification { get; }
    public ST? SoftwareVersionNumber { get; }
    public CNE? ImplantationStatus { get; }

    public DEV(Segment segment) : base(typeof(DEV), segment) {
        this.ActionCode = segment.GetRequiredField<ID>(1);
        this.UniqueDeviceIdentifier = segment.GetField<EI>(2);
        this.DeviceType = segment.GetField<CNE>(3);
        this.DeviceStatus = segment.GetRepField<CNE>(4);
        this.ManufacturerDistributor = segment.GetField<XON>(5);
        this.BrandName = segment.GetField<ST>(6);
        this.ModelIdentifier = segment.GetField<ST>(7);
        this.CatalogueIdentifier = segment.GetField<ST>(8);
        this.UDIDeviceIdentifier = segment.GetField<EI>(9);
        this.DeviceLotNumber = segment.GetField<ST>(10);
        this.DeviceSerialNumber = segment.GetField<ST>(11);
        this.DeviceManufactureDate = segment.GetField<DTM>(12);
        this.DeviceExpiryDate = segment.GetField<DTM>(13);
        this.SafetyCharacteristics = segment.GetRepField<CWE>(14);
        this.DeviceDonationIdentification = segment.GetField<EI>(15);
        this.SoftwareVersionNumber = segment.GetField<ST>(16);
        this.ImplantationStatus = segment.GetField<CNE>(17);
    }
}

public sealed record DG1 : Hl7Segment {
    public SI SetIDDG1 { get; }
    public ST? DiagnosisCodingMethod { get; }
    public CWE DiagnosisCodeDG1 { get; }
    public ST? DiagnosisDescription { get; }
    public DTM? DiagnosisDateTime { get; }
    public CWE DiagnosisType { get; }
    public CNE? MajorDiagnosticCategory { get; }
    public CNE? DiagnosticRelatedGroup { get; }
    public ID? DRGApprovalIndicator { get; }
    public CWE? DRGGrouperReviewCode { get; }
    public CWE? OutlierType { get; }
    public NM? OutlierDays { get; }
    public CP? OutlierCost { get; }
    public ST? GrouperVersionAndType { get; }
    public NM? DiagnosisPriority { get; }
    public ICollection<XCN>? DiagnosingClinician { get; }
    public CWE? DiagnosisClassification { get; }
    public ID? ConfidentialIndicator { get; }
    public DTM? AttestationDateTime { get; }
    public EI? DiagnosisIdentifier { get; }
    public ID? DiagnosisActionCode { get; }
    public EI? ParentDiagnosis { get; }
    public CWE? DRGCCLValueCode { get; }
    public ID? DRGGroupingUsage { get; }
    public CWE? DRGDiagnosisDeterminationStatus { get; }
    public CWE? PresentOnAdmission { get; }

    public DG1(Segment segment) : base(typeof(DG1), segment) {
        this.SetIDDG1 = segment.GetRequiredField<SI>(1);
        this.DiagnosisCodingMethod = segment.GetField<ST>(2);
        this.DiagnosisCodeDG1 = segment.GetRequiredField<CWE>(3);
        this.DiagnosisDescription = segment.GetField<ST>(4);
        this.DiagnosisDateTime = segment.GetField<DTM>(5);
        this.DiagnosisType = segment.GetRequiredField<CWE>(6);
        this.MajorDiagnosticCategory = segment.GetField<CNE>(7);
        this.DiagnosticRelatedGroup = segment.GetField<CNE>(8);
        this.DRGApprovalIndicator = segment.GetField<ID>(9);
        this.DRGGrouperReviewCode = segment.GetField<CWE>(10);
        this.OutlierType = segment.GetField<CWE>(11);
        this.OutlierDays = segment.GetField<NM>(12);
        this.OutlierCost = segment.GetField<CP>(13);
        this.GrouperVersionAndType = segment.GetField<ST>(14);
        this.DiagnosisPriority = segment.GetField<NM>(15);
        this.DiagnosingClinician = segment.GetRepField<XCN>(16);
        this.DiagnosisClassification = segment.GetField<CWE>(17);
        this.ConfidentialIndicator = segment.GetField<ID>(18);
        this.AttestationDateTime = segment.GetField<DTM>(19);
        this.DiagnosisIdentifier = segment.GetField<EI>(20);
        this.DiagnosisActionCode = segment.GetField<ID>(21);
        this.ParentDiagnosis = segment.GetField<EI>(22);
        this.DRGCCLValueCode = segment.GetField<CWE>(23);
        this.DRGGroupingUsage = segment.GetField<ID>(24);
        this.DRGDiagnosisDeterminationStatus = segment.GetField<CWE>(25);
        this.PresentOnAdmission = segment.GetField<CWE>(26);
    }
}

public sealed record DMI : Hl7Segment {
    public CNE? DiagnosticRelatedGroup { get; }
    public CNE? MajorDiagnosticCategory { get; }
    public NR? LowerandUpperTrimPoints { get; }
    public NM? AverageLengthofStay { get; }
    public NM? RelativeWeight { get; }

    public DMI(Segment segment) : base(typeof(DMI), segment) {
        this.DiagnosticRelatedGroup = segment.GetField<CNE>(1);
        this.MajorDiagnosticCategory = segment.GetField<CNE>(2);
        this.LowerandUpperTrimPoints = segment.GetField<NR>(3);
        this.AverageLengthofStay = segment.GetField<NM>(4);
        this.RelativeWeight = segment.GetField<NM>(5);
    }
}

public sealed record DON : Hl7Segment {
    public EI? DonationIdentificationNumberDIN { get; }
    public CNE? DonationType { get; }
    public DTM PhlebotomyStartDateTime { get; }
    public DTM PhlebotomyEndDateTime { get; }
    public NM DonationDuration { get; }
    public CNE DonationDurationUnits { get; }
    public ICollection<CNE> IntendedProcedureType { get; }
    public ICollection<CNE> ActualProcedureType { get; }
    public ID DonorEligibilityFlag { get; }
    public ICollection<CNE> DonorEligibilityProcedureType { get; }
    public DTM DonorEligibilityDate { get; }
    public CNE ProcessInterruption { get; }
    public CNE ProcessInterruptionReason { get; }
    public ICollection<CNE> PhlebotomyIssue { get; }
    public ID IntendedRecipientBloodRelative { get; }
    public XPN IntendedRecipientName { get; }
    public DTM IntendedRecipientDOB { get; }
    public XON IntendedRecipientFacility { get; }
    public DTM IntendedRecipientProcedureDate { get; }
    public XPN IntendedRecipientOrderingProvider { get; }
    public CNE PhlebotomyStatus { get; }
    public CNE ArmStick { get; }
    public XPN BleedStartPhlebotomist { get; }
    public XPN BleedEndPhlebotomist { get; }
    public ST AphaeresisTypeMachine { get; }
    public ST AphaeresisMachineSerialNumber { get; }
    public ID DonorReaction { get; }
    public XPN FinalReviewStaffID { get; }
    public DTM FinalReviewDateTime { get; }
    public NM NumberofTubesCollected { get; }
    public ICollection<EI> DonationSampleIdentifier { get; }
    public XCN DonationAcceptStaff { get; }
    public ICollection<XCN> DonationMaterialReviewStaff { get; }
    public ID? ActionCode { get; }

    public DON(Segment segment) : base(typeof(DON), segment) {
        this.DonationIdentificationNumberDIN = segment.GetField<EI>(1);
        this.DonationType = segment.GetField<CNE>(2);
        this.PhlebotomyStartDateTime = segment.GetRequiredField<DTM>(3);
        this.PhlebotomyEndDateTime = segment.GetRequiredField<DTM>(4);
        this.DonationDuration = segment.GetRequiredField<NM>(5);
        this.DonationDurationUnits = segment.GetRequiredField<CNE>(6);
        this.IntendedProcedureType = segment.GetRequiredRepField<CNE>(7);
        this.ActualProcedureType = segment.GetRequiredRepField<CNE>(8);
        this.DonorEligibilityFlag = segment.GetRequiredField<ID>(9);
        this.DonorEligibilityProcedureType = segment.GetRequiredRepField<CNE>(10);
        this.DonorEligibilityDate = segment.GetRequiredField<DTM>(11);
        this.ProcessInterruption = segment.GetRequiredField<CNE>(12);
        this.ProcessInterruptionReason = segment.GetRequiredField<CNE>(13);
        this.PhlebotomyIssue = segment.GetRequiredRepField<CNE>(14);
        this.IntendedRecipientBloodRelative = segment.GetRequiredField<ID>(15);
        this.IntendedRecipientName = segment.GetRequiredField<XPN>(16);
        this.IntendedRecipientDOB = segment.GetRequiredField<DTM>(17);
        this.IntendedRecipientFacility = segment.GetRequiredField<XON>(18);
        this.IntendedRecipientProcedureDate = segment.GetRequiredField<DTM>(19);
        this.IntendedRecipientOrderingProvider = segment.GetRequiredField<XPN>(20);
        this.PhlebotomyStatus = segment.GetRequiredField<CNE>(21);
        this.ArmStick = segment.GetRequiredField<CNE>(22);
        this.BleedStartPhlebotomist = segment.GetRequiredField<XPN>(23);
        this.BleedEndPhlebotomist = segment.GetRequiredField<XPN>(24);
        this.AphaeresisTypeMachine = segment.GetRequiredField<ST>(25);
        this.AphaeresisMachineSerialNumber = segment.GetRequiredField<ST>(26);
        this.DonorReaction = segment.GetRequiredField<ID>(27);
        this.FinalReviewStaffID = segment.GetRequiredField<XPN>(28);
        this.FinalReviewDateTime = segment.GetRequiredField<DTM>(29);
        this.NumberofTubesCollected = segment.GetRequiredField<NM>(30);
        this.DonationSampleIdentifier = segment.GetRequiredRepField<EI>(31);
        this.DonationAcceptStaff = segment.GetRequiredField<XCN>(32);
        this.DonationMaterialReviewStaff = segment.GetRequiredRepField<XCN>(33);
        this.ActionCode = segment.GetField<ID>(34);
    }
}

public sealed record DPS : Hl7Segment {
    public CWE DiagnosisCodeMCP { get; }
    public ICollection<CWE> ProcedureCode { get; }
    public DTM? EffectiveDateTime { get; }
    public DTM? ExpirationDateTime { get; }
    public CNE? TypeofLimitation { get; }

    public DPS(Segment segment) : base(typeof(DPS), segment) {
        this.DiagnosisCodeMCP = segment.GetRequiredField<CWE>(1);
        this.ProcedureCode = segment.GetRequiredRepField<CWE>(2);
        this.EffectiveDateTime = segment.GetField<DTM>(3);
        this.ExpirationDateTime = segment.GetField<DTM>(4);
        this.TypeofLimitation = segment.GetField<CNE>(5);
    }
}

public sealed record DRG : Hl7Segment {
    public CNE? DiagnosticRelatedGroup { get; }
    public DTM? DRGAssignedDateTime { get; }
    public ID? DRGApprovalIndicator { get; }
    public CWE? DRGGrouperReviewCode { get; }
    public CWE? OutlierType { get; }
    public NM? OutlierDays { get; }
    public CP? OutlierCost { get; }
    public CWE? DRGPayor { get; }
    public CP? OutlierReimbursement { get; }
    public ID? ConfidentialIndicator { get; }
    public CWE? DRGTransferType { get; }
    public XPN? NameofCoder { get; }
    public CWE? GrouperStatus { get; }
    public CWE? PCCLValueCode { get; }
    public NM? EffectiveWeight { get; }
    public MO? MonetaryAmount { get; }
    public CWE? StatusPatient { get; }
    public ST? GrouperSoftwareName { get; }
    public ST? GrouperSoftwareVersion { get; }
    public CWE? StatusFinancialCalculation { get; }
    public MO? RelativeDiscountSurcharge { get; }
    public MO? BasicCharge { get; }
    public MO? TotalCharge { get; }
    public MO? DiscountSurcharge { get; }
    public NM? CalculatedDays { get; }
    public CWE? StatusGender { get; }
    public CWE? StatusAge { get; }
    public CWE? StatusLengthofStay { get; }
    public CWE? StatusSameDayFlag { get; }
    public CWE? StatusSeparationMode { get; }
    public CWE? StatusWeightatBirth { get; }
    public CWE? StatusRespirationMinutes { get; }
    public CWE? StatusAdmission { get; }

    public DRG(Segment segment) : base(typeof(DRG), segment) {
        this.DiagnosticRelatedGroup = segment.GetField<CNE>(1);
        this.DRGAssignedDateTime = segment.GetField<DTM>(2);
        this.DRGApprovalIndicator = segment.GetField<ID>(3);
        this.DRGGrouperReviewCode = segment.GetField<CWE>(4);
        this.OutlierType = segment.GetField<CWE>(5);
        this.OutlierDays = segment.GetField<NM>(6);
        this.OutlierCost = segment.GetField<CP>(7);
        this.DRGPayor = segment.GetField<CWE>(8);
        this.OutlierReimbursement = segment.GetField<CP>(9);
        this.ConfidentialIndicator = segment.GetField<ID>(10);
        this.DRGTransferType = segment.GetField<CWE>(11);
        this.NameofCoder = segment.GetField<XPN>(12);
        this.GrouperStatus = segment.GetField<CWE>(13);
        this.PCCLValueCode = segment.GetField<CWE>(14);
        this.EffectiveWeight = segment.GetField<NM>(15);
        this.MonetaryAmount = segment.GetField<MO>(16);
        this.StatusPatient = segment.GetField<CWE>(17);
        this.GrouperSoftwareName = segment.GetField<ST>(18);
        this.GrouperSoftwareVersion = segment.GetField<ST>(19);
        this.StatusFinancialCalculation = segment.GetField<CWE>(20);
        this.RelativeDiscountSurcharge = segment.GetField<MO>(21);
        this.BasicCharge = segment.GetField<MO>(22);
        this.TotalCharge = segment.GetField<MO>(23);
        this.DiscountSurcharge = segment.GetField<MO>(24);
        this.CalculatedDays = segment.GetField<NM>(25);
        this.StatusGender = segment.GetField<CWE>(26);
        this.StatusAge = segment.GetField<CWE>(27);
        this.StatusLengthofStay = segment.GetField<CWE>(28);
        this.StatusSameDayFlag = segment.GetField<CWE>(29);
        this.StatusSeparationMode = segment.GetField<CWE>(30);
        this.StatusWeightatBirth = segment.GetField<CWE>(31);
        this.StatusRespirationMinutes = segment.GetField<CWE>(32);
        this.StatusAdmission = segment.GetField<CWE>(33);
    }
}

public sealed record DSC : Hl7Segment {
    public ST? ContinuationPointer { get; }
    public ID? ContinuationStyle { get; }

    public DSC(Segment segment) : base(typeof(DSC), segment) {
        this.ContinuationPointer = segment.GetField<ST>(1);
        this.ContinuationStyle = segment.GetField<ID>(2);
    }
}

public sealed record DSP : Hl7Segment {
    public SI? SetIDDSP { get; }
    public SI? DisplayLevel { get; }
    public TX DataLine { get; }
    public ST? LogicalBreakPoint { get; }
    public TX? ResultID { get; }

    public DSP(Segment segment) : base(typeof(DSP), segment) {
        this.SetIDDSP = segment.GetField<SI>(1);
        this.DisplayLevel = segment.GetField<SI>(2);
        this.DataLine = segment.GetRequiredField<TX>(3);
        this.LogicalBreakPoint = segment.GetField<ST>(4);
        this.ResultID = segment.GetField<TX>(5);
    }
}

public sealed record DST : Hl7Segment {
    public CWE Destination { get; }
    public ICollection<CWE>? Route { get; }

    public DST(Segment segment) : base(typeof(DST), segment) {
        this.Destination = segment.GetRequiredField<CWE>(1);
        this.Route = segment.GetRepField<CWE>(2);
    }
}

public sealed record ECD : Hl7Segment {
    public NM ReferenceCommandNumber { get; }
    public CWE RemoteControlCommand { get; }
    public ID? ResponseRequired { get; }
    public ST? RequestedCompletionTime { get; }
    public ICollection<TX>? Parameters { get; }

    public ECD(Segment segment) : base(typeof(ECD), segment) {
        this.ReferenceCommandNumber = segment.GetRequiredField<NM>(1);
        this.RemoteControlCommand = segment.GetRequiredField<CWE>(2);
        this.ResponseRequired = segment.GetField<ID>(3);
        this.RequestedCompletionTime = segment.GetField<ST>(4);
        this.Parameters = segment.GetRepField<TX>(5);
    }
}

public sealed record ECR : Hl7Segment {
    public CWE CommandResponse { get; }
    public DTM DateTimeCompleted { get; }
    public ICollection<TX>? CommandResponseParameters { get; }

    public ECR(Segment segment) : base(typeof(ECR), segment) {
        this.CommandResponse = segment.GetRequiredField<CWE>(1);
        this.DateTimeCompleted = segment.GetRequiredField<DTM>(2);
        this.CommandResponseParameters = segment.GetRepField<TX>(3);
    }
}

public sealed record EDU : Hl7Segment {
    public SI SetIDEDU { get; }
    public CWE? AcademicDegree { get; }
    public DR? AcademicDegreeProgramDateRange { get; }
    public DR? AcademicDegreeProgramParticipationDateRange { get; }
    public DT? AcademicDegreeGrantedDate { get; }
    public XON? School { get; }
    public CWE? SchoolTypeCode { get; }
    public XAD? SchoolAddress { get; }
    public ICollection<CWE>? MajorFieldofStudy { get; }

    public EDU(Segment segment) : base(typeof(EDU), segment) {
        this.SetIDEDU = segment.GetRequiredField<SI>(1);
        this.AcademicDegree = segment.GetField<CWE>(2);
        this.AcademicDegreeProgramDateRange = segment.GetField<DR>(3);
        this.AcademicDegreeProgramParticipationDateRange = segment.GetField<DR>(4);
        this.AcademicDegreeGrantedDate = segment.GetField<DT>(5);
        this.School = segment.GetField<XON>(6);
        this.SchoolTypeCode = segment.GetField<CWE>(7);
        this.SchoolAddress = segment.GetField<XAD>(8);
        this.MajorFieldofStudy = segment.GetRepField<CWE>(9);
    }
}

public sealed record EQP : Hl7Segment {
    public CWE Eventtype { get; }
    public ST? FileName { get; }
    public DTM StartDateTime { get; }
    public DTM? EndDateTime { get; }
    public FT TransactionData { get; }

    public EQP(Segment segment) : base(typeof(EQP), segment) {
        this.Eventtype = segment.GetRequiredField<CWE>(1);
        this.FileName = segment.GetField<ST>(2);
        this.StartDateTime = segment.GetRequiredField<DTM>(3);
        this.EndDateTime = segment.GetField<DTM>(4);
        this.TransactionData = segment.GetRequiredField<FT>(5);
    }
}

public sealed record EQU : Hl7Segment {
    public ICollection<EI> EquipmentInstanceIdentifier { get; }
    public DTM EventDateTime { get; }
    public CWE? EquipmentState { get; }
    public CWE? LocalRemoteControlState { get; }
    public CWE? AlertLevel { get; }
    public DTM? Expecteddatetimeofthenextstatuschange { get; }

    public EQU(Segment segment) : base(typeof(EQU), segment) {
        this.EquipmentInstanceIdentifier = segment.GetRequiredRepField<EI>(1);
        this.EventDateTime = segment.GetRequiredField<DTM>(2);
        this.EquipmentState = segment.GetField<CWE>(3);
        this.LocalRemoteControlState = segment.GetField<CWE>(4);
        this.AlertLevel = segment.GetField<CWE>(5);
        this.Expecteddatetimeofthenextstatuschange = segment.GetField<DTM>(6);
    }
}

public sealed record ERR : Hl7Segment {
    public ST? ErrorCodeandLocation { get; }
    public ICollection<ERL>? ErrorLocation { get; }
    public CWE HL7ErrorCode { get; }
    public ID Severity { get; }
    public CWE? ApplicationErrorCode { get; }
    public ST? ApplicationErrorParameter { get; }
    public TX? DiagnosticInformation { get; }
    public TX? UserMessage { get; }
    public ICollection<CWE>? InformPersonIndicator { get; }
    public CWE? OverrideType { get; }
    public ICollection<CWE>? OverrideReasonCode { get; }
    public ICollection<XTN>? HelpDeskContactPoint { get; }

    public ERR(Segment segment) : base(typeof(ERR), segment) {
        this.ErrorCodeandLocation = segment.GetField<ST>(1);
        this.ErrorLocation = segment.GetRepField<ERL>(2);
        this.HL7ErrorCode = segment.GetRequiredField<CWE>(3);
        this.Severity = segment.GetRequiredField<ID>(4);
        this.ApplicationErrorCode = segment.GetField<CWE>(5);
        this.ApplicationErrorParameter = segment.GetField<ST>(6);
        this.DiagnosticInformation = segment.GetField<TX>(7);
        this.UserMessage = segment.GetField<TX>(8);
        this.InformPersonIndicator = segment.GetRepField<CWE>(9);
        this.OverrideType = segment.GetField<CWE>(10);
        this.OverrideReasonCode = segment.GetRepField<CWE>(11);
        this.HelpDeskContactPoint = segment.GetRepField<XTN>(12);
    }
}

public sealed record EVN : Hl7Segment {
    public ST? EventTypeCode { get; }
    public DTM RecordedDateTime { get; }
    public DTM? DateTimePlannedEvent { get; }
    public CWE? EventReasonCode { get; }
    public ICollection<XCN>? OperatorID { get; }
    public DTM? EventOccurred { get; }
    public HD? EventFacility { get; }

    public EVN(Segment segment) : base(typeof(EVN), segment) {
        this.EventTypeCode = segment.GetField<ST>(1);
        this.RecordedDateTime = segment.GetRequiredField<DTM>(2);
        this.DateTimePlannedEvent = segment.GetField<DTM>(3);
        this.EventReasonCode = segment.GetField<CWE>(4);
        this.OperatorID = segment.GetRepField<XCN>(5);
        this.EventOccurred = segment.GetField<DTM>(6);
        this.EventFacility = segment.GetField<HD>(7);
    }
}

public sealed record FAC : Hl7Segment {
    public EI FacilityIDFAC { get; }
    public ID? FacilityType { get; }
    public ICollection<XAD> FacilityAddress { get; }
    public XTN FacilityTelecommunication { get; }
    public ICollection<XCN>? ContactPerson { get; }
    public ICollection<ST>? ContactTitle { get; }
    public ICollection<XAD>? ContactAddress { get; }
    public ICollection<XTN>? ContactTelecommunication { get; }
    public ICollection<XCN> SignatureAuthority { get; }
    public ST? SignatureAuthorityTitle { get; }
    public ICollection<XAD>? SignatureAuthorityAddress { get; }
    public XTN? SignatureAuthorityTelecommunication { get; }

    public FAC(Segment segment) : base(typeof(FAC), segment) {
        this.FacilityIDFAC = segment.GetRequiredField<EI>(1);
        this.FacilityType = segment.GetField<ID>(2);
        this.FacilityAddress = segment.GetRequiredRepField<XAD>(3);
        this.FacilityTelecommunication = segment.GetRequiredField<XTN>(4);
        this.ContactPerson = segment.GetRepField<XCN>(5);
        this.ContactTitle = segment.GetRepField<ST>(6);
        this.ContactAddress = segment.GetRepField<XAD>(7);
        this.ContactTelecommunication = segment.GetRepField<XTN>(8);
        this.SignatureAuthority = segment.GetRequiredRepField<XCN>(9);
        this.SignatureAuthorityTitle = segment.GetField<ST>(10);
        this.SignatureAuthorityAddress = segment.GetRepField<XAD>(11);
        this.SignatureAuthorityTelecommunication = segment.GetField<XTN>(12);
    }
}

public sealed record FHS : Hl7Segment {
    public ST FileFieldSeparator { get; }
    public ST FileEncodingCharacters { get; }
    public HD? FileSendingApplication { get; }
    public HD? FileSendingFacility { get; }
    public HD? FileReceivingApplication { get; }
    public HD? FileReceivingFacility { get; }
    public DTM? FileCreationDateTime { get; }
    public ST? FileSecurity { get; }
    public ST? FileNameID { get; }
    public ST? FileHeaderComment { get; }
    public ST? FileControlID { get; }
    public ST? ReferenceFileControlID { get; }
    public HD? FileSendingNetworkAddress { get; }
    public HD? FileReceivingNetworkAddress { get; }
    public CWE? SecurityClassificationTag { get; }
    public CWE? SecurityHandlingInstructions { get; }
    public ST? SpecialAccessRestrictionInstructions { get; }

    public FHS(Segment segment) : base(typeof(FHS), segment) {
        this.FileFieldSeparator = segment.GetRequiredField<ST>(1);
        this.FileEncodingCharacters = segment.GetRequiredField<ST>(2);
        this.FileSendingApplication = segment.GetField<HD>(3);
        this.FileSendingFacility = segment.GetField<HD>(4);
        this.FileReceivingApplication = segment.GetField<HD>(5);
        this.FileReceivingFacility = segment.GetField<HD>(6);
        this.FileCreationDateTime = segment.GetField<DTM>(7);
        this.FileSecurity = segment.GetField<ST>(8);
        this.FileNameID = segment.GetField<ST>(9);
        this.FileHeaderComment = segment.GetField<ST>(10);
        this.FileControlID = segment.GetField<ST>(11);
        this.ReferenceFileControlID = segment.GetField<ST>(12);
        this.FileSendingNetworkAddress = segment.GetField<HD>(13);
        this.FileReceivingNetworkAddress = segment.GetField<HD>(14);
        this.SecurityClassificationTag = segment.GetField<CWE>(15);
        this.SecurityHandlingInstructions = segment.GetField<CWE>(16);
        this.SpecialAccessRestrictionInstructions = segment.GetField<ST>(17);
    }
}

public sealed record FT1 : Hl7Segment {
    public SI? SetIDFT1 { get; }
    public CX? TransactionID { get; }
    public ST? TransactionBatchID { get; }
    public DR TransactionDate { get; }
    public DTM? TransactionPostingDate { get; }
    public CWE TransactionType { get; }
    public CWE TransactionCode { get; }
    public ST? TransactionDescription { get; }
    public ST? TransactionDescriptionAlt { get; }
    public NM? TransactionQuantity { get; }
    public CP? TransactionAmountExtended { get; }
    public CP? TransactionAmountUnit { get; }
    public CWE? DepartmentCode { get; }
    public CWE? HealthPlanID { get; }
    public CP? InsuranceAmount { get; }
    public PL? AssignedPatientLocation { get; }
    public CWE? FeeSchedule { get; }
    public CWE? PatientType { get; }
    public ICollection<CWE>? DiagnosisCodeFT1 { get; }
    public ICollection<XCN>? PerformedByCode { get; }
    public ICollection<XCN>? OrderedByCode { get; }
    public CP? UnitCost { get; }
    public EI? FillerOrderNumber { get; }
    public ICollection<XCN>? EnteredByCode { get; }
    public CNE? ProcedureCode { get; }
    public ICollection<CNE>? ProcedureCodeModifier { get; }
    public CWE? AdvancedBeneficiaryNoticeCode { get; }
    public CWE? MedicallyNecessaryDuplicateProcedureReason { get; }
    public CWE? NDCCode { get; }
    public CX? PaymentReferenceID { get; }
    public ICollection<SI>? TransactionReferenceKey { get; }
    public ICollection<XON>? PerformingFacility { get; }
    public XON? OrderingFacility { get; }
    public CWE? ItemNumber { get; }
    public ST? ModelNumber { get; }
    public ICollection<CWE>? SpecialProcessingCode { get; }
    public CWE? ClinicCode { get; }
    public CX? ReferralNumber { get; }
    public CX? AuthorizationNumber { get; }
    public CWE? ServiceProviderTaxonomyCode { get; }
    public CWE? RevenueCode { get; }
    public ST? PrescriptionNumber { get; }
    public CQ? NDCQtyandUOM { get; }
    public CWE? DMECertificateofMedicalNecessityTransmissionCode { get; }
    public CWE? DMECertificationTypeCode { get; }
    public NM? DMEDurationValue { get; }
    public DT? DMECertificationRevisionDate { get; }
    public DT? DMEInitialCertificationDate { get; }
    public DT? DMELastCertificationDate { get; }
    public NM? DMELengthofMedicalNecessityDays { get; }
    public MO? DMERentalPrice { get; }
    public MO? DMEPurchasePrice { get; }
    public CWE? DMEFrequencyCode { get; }
    public ID? DMECertificationConditionIndicator { get; }
    public CWE? DMEConditionIndicatorCode { get; }
    public CWE? ServiceReasonCode { get; }

    public FT1(Segment segment) : base(typeof(FT1), segment) {
        this.SetIDFT1 = segment.GetField<SI>(1);
        this.TransactionID = segment.GetField<CX>(2);
        this.TransactionBatchID = segment.GetField<ST>(3);
        this.TransactionDate = segment.GetRequiredField<DR>(4);
        this.TransactionPostingDate = segment.GetField<DTM>(5);
        this.TransactionType = segment.GetRequiredField<CWE>(6);
        this.TransactionCode = segment.GetRequiredField<CWE>(7);
        this.TransactionDescription = segment.GetField<ST>(8);
        this.TransactionDescriptionAlt = segment.GetField<ST>(9);
        this.TransactionQuantity = segment.GetField<NM>(10);
        this.TransactionAmountExtended = segment.GetField<CP>(11);
        this.TransactionAmountUnit = segment.GetField<CP>(12);
        this.DepartmentCode = segment.GetField<CWE>(13);
        this.HealthPlanID = segment.GetField<CWE>(14);
        this.InsuranceAmount = segment.GetField<CP>(15);
        this.AssignedPatientLocation = segment.GetField<PL>(16);
        this.FeeSchedule = segment.GetField<CWE>(17);
        this.PatientType = segment.GetField<CWE>(18);
        this.DiagnosisCodeFT1 = segment.GetRepField<CWE>(19);
        this.PerformedByCode = segment.GetRepField<XCN>(20);
        this.OrderedByCode = segment.GetRepField<XCN>(21);
        this.UnitCost = segment.GetField<CP>(22);
        this.FillerOrderNumber = segment.GetField<EI>(23);
        this.EnteredByCode = segment.GetRepField<XCN>(24);
        this.ProcedureCode = segment.GetField<CNE>(25);
        this.ProcedureCodeModifier = segment.GetRepField<CNE>(26);
        this.AdvancedBeneficiaryNoticeCode = segment.GetField<CWE>(27);
        this.MedicallyNecessaryDuplicateProcedureReason = segment.GetField<CWE>(28);
        this.NDCCode = segment.GetField<CWE>(29);
        this.PaymentReferenceID = segment.GetField<CX>(30);
        this.TransactionReferenceKey = segment.GetRepField<SI>(31);
        this.PerformingFacility = segment.GetRepField<XON>(32);
        this.OrderingFacility = segment.GetField<XON>(33);
        this.ItemNumber = segment.GetField<CWE>(34);
        this.ModelNumber = segment.GetField<ST>(35);
        this.SpecialProcessingCode = segment.GetRepField<CWE>(36);
        this.ClinicCode = segment.GetField<CWE>(37);
        this.ReferralNumber = segment.GetField<CX>(38);
        this.AuthorizationNumber = segment.GetField<CX>(39);
        this.ServiceProviderTaxonomyCode = segment.GetField<CWE>(40);
        this.RevenueCode = segment.GetField<CWE>(41);
        this.PrescriptionNumber = segment.GetField<ST>(42);
        this.NDCQtyandUOM = segment.GetField<CQ>(43);
        this.DMECertificateofMedicalNecessityTransmissionCode = segment.GetField<CWE>(44);
        this.DMECertificationTypeCode = segment.GetField<CWE>(45);
        this.DMEDurationValue = segment.GetField<NM>(46);
        this.DMECertificationRevisionDate = segment.GetField<DT>(47);
        this.DMEInitialCertificationDate = segment.GetField<DT>(48);
        this.DMELastCertificationDate = segment.GetField<DT>(49);
        this.DMELengthofMedicalNecessityDays = segment.GetField<NM>(50);
        this.DMERentalPrice = segment.GetField<MO>(51);
        this.DMEPurchasePrice = segment.GetField<MO>(52);
        this.DMEFrequencyCode = segment.GetField<CWE>(53);
        this.DMECertificationConditionIndicator = segment.GetField<ID>(54);
        this.DMEConditionIndicatorCode = segment.GetField<CWE>(55);
        this.ServiceReasonCode = segment.GetField<CWE>(56);
    }
}

public sealed record FTS : Hl7Segment {
    public NM? FileBatchCount { get; }
    public ST? FileTrailerComment { get; }

    public FTS(Segment segment) : base(typeof(FTS), segment) {
        this.FileBatchCount = segment.GetField<NM>(1);
        this.FileTrailerComment = segment.GetField<ST>(2);
    }
}

public sealed record GOL : Hl7Segment {
    public ID ActionCode { get; }
    public DTM ActionDateTime { get; }
    public CWE GoalID { get; }
    public EI GoalInstanceID { get; }
    public EI? EpisodeofCareID { get; }
    public NM? GoalListPriority { get; }
    public DTM? GoalEstablishedDateTime { get; }
    public DTM? ExpectedGoalAchieveDateTime { get; }
    public CWE? GoalClassification { get; }
    public CWE? GoalManagementDiscipline { get; }
    public CWE? CurrentGoalReviewStatus { get; }
    public DTM? CurrentGoalReviewDateTime { get; }
    public DTM? NextGoalReviewDateTime { get; }
    public DTM? PreviousGoalReviewDateTime { get; }
    public ST? GoalReviewInterval { get; }
    public CWE? GoalEvaluation { get; }
    public ICollection<ST>? GoalEvaluationComment { get; }
    public CWE? GoalLifeCycleStatus { get; }
    public DTM? GoalLifeCycleStatusDateTime { get; }
    public ICollection<CWE>? GoalTargetType { get; }
    public ICollection<XPN>? GoalTargetName { get; }
    public CNE? MoodCode { get; }

    public GOL(Segment segment) : base(typeof(GOL), segment) {
        this.ActionCode = segment.GetRequiredField<ID>(1);
        this.ActionDateTime = segment.GetRequiredField<DTM>(2);
        this.GoalID = segment.GetRequiredField<CWE>(3);
        this.GoalInstanceID = segment.GetRequiredField<EI>(4);
        this.EpisodeofCareID = segment.GetField<EI>(5);
        this.GoalListPriority = segment.GetField<NM>(6);
        this.GoalEstablishedDateTime = segment.GetField<DTM>(7);
        this.ExpectedGoalAchieveDateTime = segment.GetField<DTM>(8);
        this.GoalClassification = segment.GetField<CWE>(9);
        this.GoalManagementDiscipline = segment.GetField<CWE>(10);
        this.CurrentGoalReviewStatus = segment.GetField<CWE>(11);
        this.CurrentGoalReviewDateTime = segment.GetField<DTM>(12);
        this.NextGoalReviewDateTime = segment.GetField<DTM>(13);
        this.PreviousGoalReviewDateTime = segment.GetField<DTM>(14);
        this.GoalReviewInterval = segment.GetField<ST>(15);
        this.GoalEvaluation = segment.GetField<CWE>(16);
        this.GoalEvaluationComment = segment.GetRepField<ST>(17);
        this.GoalLifeCycleStatus = segment.GetField<CWE>(18);
        this.GoalLifeCycleStatusDateTime = segment.GetField<DTM>(19);
        this.GoalTargetType = segment.GetRepField<CWE>(20);
        this.GoalTargetName = segment.GetRepField<XPN>(21);
        this.MoodCode = segment.GetField<CNE>(22);
    }
}

public sealed record GP1 : Hl7Segment {
    public CWE TypeofBillCode { get; }
    public ICollection<CWE>? RevenueCode { get; }
    public CWE? OverallClaimDispositionCode { get; }
    public ICollection<CWE>? OCEEditsperVisitCode { get; }
    public CP? OutlierCost { get; }

    public GP1(Segment segment) : base(typeof(GP1), segment) {
        this.TypeofBillCode = segment.GetRequiredField<CWE>(1);
        this.RevenueCode = segment.GetRepField<CWE>(2);
        this.OverallClaimDispositionCode = segment.GetField<CWE>(3);
        this.OCEEditsperVisitCode = segment.GetRepField<CWE>(4);
        this.OutlierCost = segment.GetField<CP>(5);
    }
}

public sealed record GP2 : Hl7Segment {
    public CWE? RevenueCode { get; }
    public NM? NumberofServiceUnits { get; }
    public CP? Charge { get; }
    public CWE? ReimbursementActionCode { get; }
    public CWE? DenialorRejectionCode { get; }
    public ICollection<CWE>? OCEEditCode { get; }
    public CWE? AmbulatoryPaymentClassificationCode { get; }
    public ICollection<CWE>? ModifierEditCode { get; }
    public CWE? PaymentAdjustmentCode { get; }
    public CWE? PackagingStatusCode { get; }
    public CP? ExpectedCMSPaymentAmount { get; }
    public CWE? ReimbursementTypeCode { get; }
    public CP? CoPayAmount { get; }
    public NM? PayRateperServiceUnit { get; }

    public GP2(Segment segment) : base(typeof(GP2), segment) {
        this.RevenueCode = segment.GetField<CWE>(1);
        this.NumberofServiceUnits = segment.GetField<NM>(2);
        this.Charge = segment.GetField<CP>(3);
        this.ReimbursementActionCode = segment.GetField<CWE>(4);
        this.DenialorRejectionCode = segment.GetField<CWE>(5);
        this.OCEEditCode = segment.GetRepField<CWE>(6);
        this.AmbulatoryPaymentClassificationCode = segment.GetField<CWE>(7);
        this.ModifierEditCode = segment.GetRepField<CWE>(8);
        this.PaymentAdjustmentCode = segment.GetField<CWE>(9);
        this.PackagingStatusCode = segment.GetField<CWE>(10);
        this.ExpectedCMSPaymentAmount = segment.GetField<CP>(11);
        this.ReimbursementTypeCode = segment.GetField<CWE>(12);
        this.CoPayAmount = segment.GetField<CP>(13);
        this.PayRateperServiceUnit = segment.GetField<NM>(14);
    }
}

public sealed record GT1 : Hl7Segment {
    public SI SetIDGT1 { get; }
    public ICollection<CX>? GuarantorNumber { get; }
    public ICollection<XPN> GuarantorName { get; }
    public ICollection<XPN>? GuarantorSpouseName { get; }
    public ICollection<XAD>? GuarantorAddress { get; }
    public ICollection<XTN>? GuarantorPhNumHome { get; }
    public ICollection<XTN>? GuarantorPhNumBusiness { get; }
    public DTM? GuarantorDateTimeOfBirth { get; }
    public CWE? GuarantorAdministrativeSex { get; }
    public CWE? GuarantorType { get; }
    public CWE? GuarantorRelationship { get; }
    public ST? GuarantorSSN { get; }
    public DT? GuarantorDateBegin { get; }
    public DT? GuarantorDateEnd { get; }
    public NM? GuarantorPriority { get; }
    public ICollection<XPN>? GuarantorEmployerName { get; }
    public ICollection<XAD>? GuarantorEmployerAddress { get; }
    public ICollection<XTN>? GuarantorEmployerPhoneNumber { get; }
    public ICollection<CX>? GuarantorEmployeeIDNumber { get; }
    public CWE? GuarantorEmploymentStatus { get; }
    public ICollection<XON>? GuarantorOrganizationName { get; }
    public ID? GuarantorBillingHoldFlag { get; }
    public CWE? GuarantorCreditRatingCode { get; }
    public DTM? GuarantorDeathDateAndTime { get; }
    public ID? GuarantorDeathFlag { get; }
    public CWE? GuarantorChargeAdjustmentCode { get; }
    public CP? GuarantorHouseholdAnnualIncome { get; }
    public NM? GuarantorHouseholdSize { get; }
    public ICollection<CX>? GuarantorEmployerIDNumber { get; }
    public CWE? GuarantorMaritalStatusCode { get; }
    public DT? GuarantorHireEffectiveDate { get; }
    public DT? EmploymentStopDate { get; }
    public CWE? LivingDependency { get; }
    public ICollection<CWE>? AmbulatoryStatus { get; }
    public ICollection<CWE>? Citizenship { get; }
    public CWE? PrimaryLanguage { get; }
    public CWE? LivingArrangement { get; }
    public CWE? PublicityCode { get; }
    public ID? ProtectionIndicator { get; }
    public CWE? StudentIndicator { get; }
    public CWE? Religion { get; }
    public ICollection<XPN>? MothersMaidenName { get; }
    public CWE? Nationality { get; }
    public ICollection<CWE>? EthnicGroup { get; }
    public ICollection<XPN>? ContactPersonsName { get; }
    public ICollection<XTN>? ContactPersonsTelephoneNumber { get; }
    public CWE? ContactReason { get; }
    public CWE? ContactRelationship { get; }
    public ST? JobTitle { get; }
    public JCC? JobCodeClass { get; }
    public ICollection<XON>? GuarantorEmployersOrganizationName { get; }
    public CWE? Handicap { get; }
    public CWE? JobStatus { get; }
    public FC? GuarantorFinancialClass { get; }
    public ICollection<CWE>? GuarantorRace { get; }
    public ST? GuarantorBirthPlace { get; }
    public CWE? VIPIndicator { get; }

    public GT1(Segment segment) : base(typeof(GT1), segment) {
        this.SetIDGT1 = segment.GetRequiredField<SI>(1);
        this.GuarantorNumber = segment.GetRepField<CX>(2);
        this.GuarantorName = segment.GetRequiredRepField<XPN>(3);
        this.GuarantorSpouseName = segment.GetRepField<XPN>(4);
        this.GuarantorAddress = segment.GetRepField<XAD>(5);
        this.GuarantorPhNumHome = segment.GetRepField<XTN>(6);
        this.GuarantorPhNumBusiness = segment.GetRepField<XTN>(7);
        this.GuarantorDateTimeOfBirth = segment.GetField<DTM>(8);
        this.GuarantorAdministrativeSex = segment.GetField<CWE>(9);
        this.GuarantorType = segment.GetField<CWE>(10);
        this.GuarantorRelationship = segment.GetField<CWE>(11);
        this.GuarantorSSN = segment.GetField<ST>(12);
        this.GuarantorDateBegin = segment.GetField<DT>(13);
        this.GuarantorDateEnd = segment.GetField<DT>(14);
        this.GuarantorPriority = segment.GetField<NM>(15);
        this.GuarantorEmployerName = segment.GetRepField<XPN>(16);
        this.GuarantorEmployerAddress = segment.GetRepField<XAD>(17);
        this.GuarantorEmployerPhoneNumber = segment.GetRepField<XTN>(18);
        this.GuarantorEmployeeIDNumber = segment.GetRepField<CX>(19);
        this.GuarantorEmploymentStatus = segment.GetField<CWE>(20);
        this.GuarantorOrganizationName = segment.GetRepField<XON>(21);
        this.GuarantorBillingHoldFlag = segment.GetField<ID>(22);
        this.GuarantorCreditRatingCode = segment.GetField<CWE>(23);
        this.GuarantorDeathDateAndTime = segment.GetField<DTM>(24);
        this.GuarantorDeathFlag = segment.GetField<ID>(25);
        this.GuarantorChargeAdjustmentCode = segment.GetField<CWE>(26);
        this.GuarantorHouseholdAnnualIncome = segment.GetField<CP>(27);
        this.GuarantorHouseholdSize = segment.GetField<NM>(28);
        this.GuarantorEmployerIDNumber = segment.GetRepField<CX>(29);
        this.GuarantorMaritalStatusCode = segment.GetField<CWE>(30);
        this.GuarantorHireEffectiveDate = segment.GetField<DT>(31);
        this.EmploymentStopDate = segment.GetField<DT>(32);
        this.LivingDependency = segment.GetField<CWE>(33);
        this.AmbulatoryStatus = segment.GetRepField<CWE>(34);
        this.Citizenship = segment.GetRepField<CWE>(35);
        this.PrimaryLanguage = segment.GetField<CWE>(36);
        this.LivingArrangement = segment.GetField<CWE>(37);
        this.PublicityCode = segment.GetField<CWE>(38);
        this.ProtectionIndicator = segment.GetField<ID>(39);
        this.StudentIndicator = segment.GetField<CWE>(40);
        this.Religion = segment.GetField<CWE>(41);
        this.MothersMaidenName = segment.GetRepField<XPN>(42);
        this.Nationality = segment.GetField<CWE>(43);
        this.EthnicGroup = segment.GetRepField<CWE>(44);
        this.ContactPersonsName = segment.GetRepField<XPN>(45);
        this.ContactPersonsTelephoneNumber = segment.GetRepField<XTN>(46);
        this.ContactReason = segment.GetField<CWE>(47);
        this.ContactRelationship = segment.GetField<CWE>(48);
        this.JobTitle = segment.GetField<ST>(49);
        this.JobCodeClass = segment.GetField<JCC>(50);
        this.GuarantorEmployersOrganizationName = segment.GetRepField<XON>(51);
        this.Handicap = segment.GetField<CWE>(52);
        this.JobStatus = segment.GetField<CWE>(53);
        this.GuarantorFinancialClass = segment.GetField<FC>(54);
        this.GuarantorRace = segment.GetRepField<CWE>(55);
        this.GuarantorBirthPlace = segment.GetField<ST>(56);
        this.VIPIndicator = segment.GetField<CWE>(57);
    }
}

public sealed record HXX : Hl7Segment {

    public HXX(Segment segment) : base(typeof(HXX), segment) {
    }
}

public sealed record IAM : Hl7Segment {
    public SI SetIDIAM { get; }
    public CWE? AllergenTypeCode { get; }
    public CWE AllergenCodeMnemonicDescription { get; }
    public CWE? AllergySeverityCode { get; }
    public ICollection<ST>? AllergyReactionCode { get; }
    public CNE AllergyActionCode { get; }
    public EI? AllergyUniqueIdentifier { get; }
    public ST? ActionReason { get; }
    public CWE? SensitivitytoCausativeAgentCode { get; }
    public CWE? AllergenGroupCodeMnemonicDescription { get; }
    public DT? OnsetDate { get; }
    public ST? OnsetDateText { get; }
    public DTM? ReportedDateTime { get; }
    public XPN? ReportedBy { get; }
    public CWE? RelationshiptoPatientCode { get; }
    public CWE? AlertDeviceCode { get; }
    public CWE? AllergyClinicalStatusCode { get; }
    public XCN? StatusedbyPerson { get; }
    public XON? StatusedbyOrganization { get; }
    public DTM? StatusedatDateTime { get; }
    public XCN? InactivatedbyPerson { get; }
    public DTM? InactivatedDateTime { get; }
    public XCN? InitiallyRecordedbyPerson { get; }
    public DTM? InitiallyRecordedDateTime { get; }
    public XCN? ModifiedbyPerson { get; }
    public DTM? ModifiedDateTime { get; }
    public CWE? ClinicianIdentifiedAllergenCode { get; }
    public XON? InitiallyRecordedbyOrganization { get; }
    public XON? ModifiedbyOrganization { get; }
    public XON? InactivatedbyOrganization { get; }

    public IAM(Segment segment) : base(typeof(IAM), segment) {
        this.SetIDIAM = segment.GetRequiredField<SI>(1);
        this.AllergenTypeCode = segment.GetField<CWE>(2);
        this.AllergenCodeMnemonicDescription = segment.GetRequiredField<CWE>(3);
        this.AllergySeverityCode = segment.GetField<CWE>(4);
        this.AllergyReactionCode = segment.GetRepField<ST>(5);
        this.AllergyActionCode = segment.GetRequiredField<CNE>(6);
        this.AllergyUniqueIdentifier = segment.GetField<EI>(7);
        this.ActionReason = segment.GetField<ST>(8);
        this.SensitivitytoCausativeAgentCode = segment.GetField<CWE>(9);
        this.AllergenGroupCodeMnemonicDescription = segment.GetField<CWE>(10);
        this.OnsetDate = segment.GetField<DT>(11);
        this.OnsetDateText = segment.GetField<ST>(12);
        this.ReportedDateTime = segment.GetField<DTM>(13);
        this.ReportedBy = segment.GetField<XPN>(14);
        this.RelationshiptoPatientCode = segment.GetField<CWE>(15);
        this.AlertDeviceCode = segment.GetField<CWE>(16);
        this.AllergyClinicalStatusCode = segment.GetField<CWE>(17);
        this.StatusedbyPerson = segment.GetField<XCN>(18);
        this.StatusedbyOrganization = segment.GetField<XON>(19);
        this.StatusedatDateTime = segment.GetField<DTM>(20);
        this.InactivatedbyPerson = segment.GetField<XCN>(21);
        this.InactivatedDateTime = segment.GetField<DTM>(22);
        this.InitiallyRecordedbyPerson = segment.GetField<XCN>(23);
        this.InitiallyRecordedDateTime = segment.GetField<DTM>(24);
        this.ModifiedbyPerson = segment.GetField<XCN>(25);
        this.ModifiedDateTime = segment.GetField<DTM>(26);
        this.ClinicianIdentifiedAllergenCode = segment.GetField<CWE>(27);
        this.InitiallyRecordedbyOrganization = segment.GetField<XON>(28);
        this.ModifiedbyOrganization = segment.GetField<XON>(29);
        this.InactivatedbyOrganization = segment.GetField<XON>(30);
    }
}

public sealed record IAR : Hl7Segment {
    public CWE AllergyReactionCode { get; }
    public CWE AllergySeverityCode { get; }
    public CWE? SensitivitytoCausativeAgentCode { get; }
    public ST? Management { get; }

    public IAR(Segment segment) : base(typeof(IAR), segment) {
        this.AllergyReactionCode = segment.GetRequiredField<CWE>(1);
        this.AllergySeverityCode = segment.GetRequiredField<CWE>(2);
        this.SensitivitytoCausativeAgentCode = segment.GetField<CWE>(3);
        this.Management = segment.GetField<ST>(4);
    }
}

public sealed record IIM : Hl7Segment {
    public CWE PrimaryKeyValueIIM { get; }
    public CWE ServiceItemCode { get; }
    public ST? InventoryLotNumber { get; }
    public DTM? InventoryExpirationDate { get; }
    public CWE? InventoryManufacturerName { get; }
    public CWE? InventoryLocation { get; }
    public DTM? InventoryReceivedDate { get; }
    public NM? InventoryReceivedQuantity { get; }
    public CWE? InventoryReceivedQuantityUnit { get; }
    public MO? InventoryReceivedItemCost { get; }
    public DTM? InventoryOnHandDate { get; }
    public NM? InventoryOnHandQuantity { get; }
    public CWE? InventoryOnHandQuantityUnit { get; }
    public CNE? ProcedureCode { get; }
    public ICollection<CNE>? ProcedureCodeModifier { get; }

    public IIM(Segment segment) : base(typeof(IIM), segment) {
        this.PrimaryKeyValueIIM = segment.GetRequiredField<CWE>(1);
        this.ServiceItemCode = segment.GetRequiredField<CWE>(2);
        this.InventoryLotNumber = segment.GetField<ST>(3);
        this.InventoryExpirationDate = segment.GetField<DTM>(4);
        this.InventoryManufacturerName = segment.GetField<CWE>(5);
        this.InventoryLocation = segment.GetField<CWE>(6);
        this.InventoryReceivedDate = segment.GetField<DTM>(7);
        this.InventoryReceivedQuantity = segment.GetField<NM>(8);
        this.InventoryReceivedQuantityUnit = segment.GetField<CWE>(9);
        this.InventoryReceivedItemCost = segment.GetField<MO>(10);
        this.InventoryOnHandDate = segment.GetField<DTM>(11);
        this.InventoryOnHandQuantity = segment.GetField<NM>(12);
        this.InventoryOnHandQuantityUnit = segment.GetField<CWE>(13);
        this.ProcedureCode = segment.GetField<CNE>(14);
        this.ProcedureCodeModifier = segment.GetRepField<CNE>(15);
    }
}

public sealed record ILT : Hl7Segment {
    public SI SetIdILT { get; }
    public ST InventoryLotNumber { get; }
    public DTM? InventoryExpirationDate { get; }
    public DTM? InventoryReceivedDate { get; }
    public NM? InventoryReceivedQuantity { get; }
    public CWE? InventoryReceivedQuantityUnit { get; }
    public MO? InventoryReceivedItemCost { get; }
    public DTM? InventoryOnHandDate { get; }
    public NM? InventoryOnHandQuantity { get; }
    public CWE? InventoryOnHandQuantityUnit { get; }

    public ILT(Segment segment) : base(typeof(ILT), segment) {
        this.SetIdILT = segment.GetRequiredField<SI>(1);
        this.InventoryLotNumber = segment.GetRequiredField<ST>(2);
        this.InventoryExpirationDate = segment.GetField<DTM>(3);
        this.InventoryReceivedDate = segment.GetField<DTM>(4);
        this.InventoryReceivedQuantity = segment.GetField<NM>(5);
        this.InventoryReceivedQuantityUnit = segment.GetField<CWE>(6);
        this.InventoryReceivedItemCost = segment.GetField<MO>(7);
        this.InventoryOnHandDate = segment.GetField<DTM>(8);
        this.InventoryOnHandQuantity = segment.GetField<NM>(9);
        this.InventoryOnHandQuantityUnit = segment.GetField<CWE>(10);
    }
}

public sealed record IN1 : Hl7Segment {
    public SI SetIDIN1 { get; }
    public CWE HealthPlanID { get; }
    public ICollection<CX> InsuranceCompanyID { get; }
    public ICollection<XON>? InsuranceCompanyName { get; }
    public ICollection<XAD>? InsuranceCompanyAddress { get; }
    public ICollection<XPN>? InsuranceCoContactPerson { get; }
    public ICollection<XTN>? InsuranceCoPhoneNumber { get; }
    public ST? GroupNumber { get; }
    public ICollection<XON>? GroupName { get; }
    public ICollection<CX>? InsuredsGroupEmpID { get; }
    public ICollection<XON>? InsuredsGroupEmpName { get; }
    public DT? PlanEffectiveDate { get; }
    public DT? PlanExpirationDate { get; }
    public AUI? AuthorizationInformation { get; }
    public CWE? PlanType { get; }
    public ICollection<XPN>? NameOfInsured { get; }
    public CWE? InsuredsRelationshipToPatient { get; }
    public DTM? InsuredsDateOfBirth { get; }
    public ICollection<XAD>? InsuredsAddress { get; }
    public CWE? AssignmentOfBenefits { get; }
    public CWE? CoordinationOfBenefits { get; }
    public ST? CoordOfBenPriority { get; }
    public ID? NoticeOfAdmissionFlag { get; }
    public DT? NoticeOfAdmissionDate { get; }
    public ID? ReportOfEligibilityFlag { get; }
    public DT? ReportOfEligibilityDate { get; }
    public CWE? ReleaseInformationCode { get; }
    public ST? PreAdmitCert { get; }
    public DTM? VerificationDateTime { get; }
    public ICollection<XCN>? VerificationBy { get; }
    public CWE? TypeOfAgreementCode { get; }
    public CWE? BillingStatus { get; }
    public NM? LifetimeReserveDays { get; }
    public NM? DelayBeforeLRDay { get; }
    public CWE? CompanyPlanCode { get; }
    public ST? PolicyNumber { get; }
    public CP? PolicyDeductible { get; }
    public ST? PolicyLimitAmount { get; }
    public NM? PolicyLimitDays { get; }
    public ST? RoomRateSemiPrivate { get; }
    public ST? RoomRatePrivate { get; }
    public CWE? InsuredsEmploymentStatus { get; }
    public CWE? InsuredsAdministrativeSex { get; }
    public ICollection<XAD>? InsuredsEmployersAddress { get; }
    public ST? VerificationStatus { get; }
    public CWE? PriorInsurancePlanID { get; }
    public CWE? CoverageType { get; }
    public CWE? Handicap { get; }
    public ICollection<CX>? InsuredsIDNumber { get; }
    public CWE? SignatureCode { get; }
    public DT? SignatureCodeDate { get; }
    public ST? InsuredsBirthPlace { get; }
    public CWE? VIPIndicator { get; }
    public ICollection<CX>? ExternalHealthPlanIdentifiers { get; }
    public ID? InsuranceActionCode { get; }

    public IN1(Segment segment) : base(typeof(IN1), segment) {
        this.SetIDIN1 = segment.GetRequiredField<SI>(1);
        this.HealthPlanID = segment.GetRequiredField<CWE>(2);
        this.InsuranceCompanyID = segment.GetRequiredRepField<CX>(3);
        this.InsuranceCompanyName = segment.GetRepField<XON>(4);
        this.InsuranceCompanyAddress = segment.GetRepField<XAD>(5);
        this.InsuranceCoContactPerson = segment.GetRepField<XPN>(6);
        this.InsuranceCoPhoneNumber = segment.GetRepField<XTN>(7);
        this.GroupNumber = segment.GetField<ST>(8);
        this.GroupName = segment.GetRepField<XON>(9);
        this.InsuredsGroupEmpID = segment.GetRepField<CX>(10);
        this.InsuredsGroupEmpName = segment.GetRepField<XON>(11);
        this.PlanEffectiveDate = segment.GetField<DT>(12);
        this.PlanExpirationDate = segment.GetField<DT>(13);
        this.AuthorizationInformation = segment.GetField<AUI>(14);
        this.PlanType = segment.GetField<CWE>(15);
        this.NameOfInsured = segment.GetRepField<XPN>(16);
        this.InsuredsRelationshipToPatient = segment.GetField<CWE>(17);
        this.InsuredsDateOfBirth = segment.GetField<DTM>(18);
        this.InsuredsAddress = segment.GetRepField<XAD>(19);
        this.AssignmentOfBenefits = segment.GetField<CWE>(20);
        this.CoordinationOfBenefits = segment.GetField<CWE>(21);
        this.CoordOfBenPriority = segment.GetField<ST>(22);
        this.NoticeOfAdmissionFlag = segment.GetField<ID>(23);
        this.NoticeOfAdmissionDate = segment.GetField<DT>(24);
        this.ReportOfEligibilityFlag = segment.GetField<ID>(25);
        this.ReportOfEligibilityDate = segment.GetField<DT>(26);
        this.ReleaseInformationCode = segment.GetField<CWE>(27);
        this.PreAdmitCert = segment.GetField<ST>(28);
        this.VerificationDateTime = segment.GetField<DTM>(29);
        this.VerificationBy = segment.GetRepField<XCN>(30);
        this.TypeOfAgreementCode = segment.GetField<CWE>(31);
        this.BillingStatus = segment.GetField<CWE>(32);
        this.LifetimeReserveDays = segment.GetField<NM>(33);
        this.DelayBeforeLRDay = segment.GetField<NM>(34);
        this.CompanyPlanCode = segment.GetField<CWE>(35);
        this.PolicyNumber = segment.GetField<ST>(36);
        this.PolicyDeductible = segment.GetField<CP>(37);
        this.PolicyLimitAmount = segment.GetField<ST>(38);
        this.PolicyLimitDays = segment.GetField<NM>(39);
        this.RoomRateSemiPrivate = segment.GetField<ST>(40);
        this.RoomRatePrivate = segment.GetField<ST>(41);
        this.InsuredsEmploymentStatus = segment.GetField<CWE>(42);
        this.InsuredsAdministrativeSex = segment.GetField<CWE>(43);
        this.InsuredsEmployersAddress = segment.GetRepField<XAD>(44);
        this.VerificationStatus = segment.GetField<ST>(45);
        this.PriorInsurancePlanID = segment.GetField<CWE>(46);
        this.CoverageType = segment.GetField<CWE>(47);
        this.Handicap = segment.GetField<CWE>(48);
        this.InsuredsIDNumber = segment.GetRepField<CX>(49);
        this.SignatureCode = segment.GetField<CWE>(50);
        this.SignatureCodeDate = segment.GetField<DT>(51);
        this.InsuredsBirthPlace = segment.GetField<ST>(52);
        this.VIPIndicator = segment.GetField<CWE>(53);
        this.ExternalHealthPlanIdentifiers = segment.GetRepField<CX>(54);
        this.InsuranceActionCode = segment.GetField<ID>(55);
    }
}

public sealed record IN2 : Hl7Segment {
    public ICollection<CX>? InsuredsEmployeeID { get; }
    public ST? InsuredsSocialSecurityNumber { get; }
    public ICollection<XCN>? InsuredsEmployersNameandID { get; }
    public CWE? EmployerInformationData { get; }
    public ICollection<CWE>? MailClaimParty { get; }
    public ST? MedicareHealthInsCardNumber { get; }
    public ICollection<XPN>? MedicaidCaseName { get; }
    public ST? MedicaidCaseNumber { get; }
    public ICollection<XPN>? MilitarySponsorName { get; }
    public ST? MilitaryIDNumber { get; }
    public CWE? DependentOfMilitaryRecipient { get; }
    public ST? MilitaryOrganization { get; }
    public ST? MilitaryStation { get; }
    public CWE? MilitaryService { get; }
    public CWE? MilitaryRankGrade { get; }
    public CWE? MilitaryStatus { get; }
    public DT? MilitaryRetireDate { get; }
    public ID? MilitaryNonAvailCertOnFile { get; }
    public ID? BabyCoverage { get; }
    public ID? CombineBabyBill { get; }
    public ST? BloodDeductible { get; }
    public ICollection<XPN>? SpecialCoverageApprovalName { get; }
    public ST? SpecialCoverageApprovalTitle { get; }
    public ICollection<CWE>? NonCoveredInsuranceCode { get; }
    public ICollection<CX>? PayorID { get; }
    public ICollection<CX>? PayorSubscriberID { get; }
    public CWE? EligibilitySource { get; }
    public ICollection<RMC>? RoomCoverageTypeAmount { get; }
    public ICollection<PTA>? PolicyTypeAmount { get; }
    public DDI? DailyDeductible { get; }
    public CWE? LivingDependency { get; }
    public ICollection<CWE>? AmbulatoryStatus { get; }
    public ICollection<CWE>? Citizenship { get; }
    public CWE? PrimaryLanguage { get; }
    public CWE? LivingArrangement { get; }
    public CWE? PublicityCode { get; }
    public ID? ProtectionIndicator { get; }
    public CWE? StudentIndicator { get; }
    public CWE? Religion { get; }
    public ICollection<XPN>? MothersMaidenName { get; }
    public CWE? Nationality { get; }
    public ICollection<CWE>? EthnicGroup { get; }
    public ICollection<CWE>? MaritalStatus { get; }
    public DT? InsuredsEmploymentStartDate { get; }
    public DT? EmploymentStopDate { get; }
    public ST? JobTitle { get; }
    public JCC? JobCodeClass { get; }
    public CWE? JobStatus { get; }
    public ICollection<XPN>? EmployerContactPersonName { get; }
    public ICollection<XTN>? EmployerContactPersonPhoneNumber { get; }
    public CWE? EmployerContactReason { get; }
    public ICollection<XPN>? InsuredsContactPersonsName { get; }
    public ICollection<XTN>? InsuredsContactPersonPhoneNumber { get; }
    public ICollection<CWE>? InsuredsContactPersonReason { get; }
    public DT? RelationshiptothePatientStartDate { get; }
    public ICollection<DT>? RelationshiptothePatientStopDate { get; }
    public CWE? InsuranceCoContactReason { get; }
    public ICollection<XTN>? InsuranceCoContactPhoneNumber { get; }
    public CWE? PolicyScope { get; }
    public CWE? PolicySource { get; }
    public CX? PatientMemberNumber { get; }
    public CWE? GuarantorsRelationshiptoInsured { get; }
    public ICollection<XTN>? InsuredsPhoneNumberHome { get; }
    public ICollection<XTN>? InsuredsEmployerPhoneNumber { get; }
    public CWE? MilitaryHandicappedProgram { get; }
    public ID? SuspendFlag { get; }
    public ID? CopayLimitFlag { get; }
    public ID? StoplossLimitFlag { get; }
    public ICollection<XON>? InsuredOrganizationNameandID { get; }
    public ICollection<XON>? InsuredEmployerOrganizationNameandID { get; }
    public ICollection<CWE>? Race { get; }
    public CWE? PatientsRelationshiptoInsured { get; }
    public CP? CoPayAmount { get; }

    public IN2(Segment segment) : base(typeof(IN2), segment) {
        this.InsuredsEmployeeID = segment.GetRepField<CX>(1);
        this.InsuredsSocialSecurityNumber = segment.GetField<ST>(2);
        this.InsuredsEmployersNameandID = segment.GetRepField<XCN>(3);
        this.EmployerInformationData = segment.GetField<CWE>(4);
        this.MailClaimParty = segment.GetRepField<CWE>(5);
        this.MedicareHealthInsCardNumber = segment.GetField<ST>(6);
        this.MedicaidCaseName = segment.GetRepField<XPN>(7);
        this.MedicaidCaseNumber = segment.GetField<ST>(8);
        this.MilitarySponsorName = segment.GetRepField<XPN>(9);
        this.MilitaryIDNumber = segment.GetField<ST>(10);
        this.DependentOfMilitaryRecipient = segment.GetField<CWE>(11);
        this.MilitaryOrganization = segment.GetField<ST>(12);
        this.MilitaryStation = segment.GetField<ST>(13);
        this.MilitaryService = segment.GetField<CWE>(14);
        this.MilitaryRankGrade = segment.GetField<CWE>(15);
        this.MilitaryStatus = segment.GetField<CWE>(16);
        this.MilitaryRetireDate = segment.GetField<DT>(17);
        this.MilitaryNonAvailCertOnFile = segment.GetField<ID>(18);
        this.BabyCoverage = segment.GetField<ID>(19);
        this.CombineBabyBill = segment.GetField<ID>(20);
        this.BloodDeductible = segment.GetField<ST>(21);
        this.SpecialCoverageApprovalName = segment.GetRepField<XPN>(22);
        this.SpecialCoverageApprovalTitle = segment.GetField<ST>(23);
        this.NonCoveredInsuranceCode = segment.GetRepField<CWE>(24);
        this.PayorID = segment.GetRepField<CX>(25);
        this.PayorSubscriberID = segment.GetRepField<CX>(26);
        this.EligibilitySource = segment.GetField<CWE>(27);
        this.RoomCoverageTypeAmount = segment.GetRepField<RMC>(28);
        this.PolicyTypeAmount = segment.GetRepField<PTA>(29);
        this.DailyDeductible = segment.GetField<DDI>(30);
        this.LivingDependency = segment.GetField<CWE>(31);
        this.AmbulatoryStatus = segment.GetRepField<CWE>(32);
        this.Citizenship = segment.GetRepField<CWE>(33);
        this.PrimaryLanguage = segment.GetField<CWE>(34);
        this.LivingArrangement = segment.GetField<CWE>(35);
        this.PublicityCode = segment.GetField<CWE>(36);
        this.ProtectionIndicator = segment.GetField<ID>(37);
        this.StudentIndicator = segment.GetField<CWE>(38);
        this.Religion = segment.GetField<CWE>(39);
        this.MothersMaidenName = segment.GetRepField<XPN>(40);
        this.Nationality = segment.GetField<CWE>(41);
        this.EthnicGroup = segment.GetRepField<CWE>(42);
        this.MaritalStatus = segment.GetRepField<CWE>(43);
        this.InsuredsEmploymentStartDate = segment.GetField<DT>(44);
        this.EmploymentStopDate = segment.GetField<DT>(45);
        this.JobTitle = segment.GetField<ST>(46);
        this.JobCodeClass = segment.GetField<JCC>(47);
        this.JobStatus = segment.GetField<CWE>(48);
        this.EmployerContactPersonName = segment.GetRepField<XPN>(49);
        this.EmployerContactPersonPhoneNumber = segment.GetRepField<XTN>(50);
        this.EmployerContactReason = segment.GetField<CWE>(51);
        this.InsuredsContactPersonsName = segment.GetRepField<XPN>(52);
        this.InsuredsContactPersonPhoneNumber = segment.GetRepField<XTN>(53);
        this.InsuredsContactPersonReason = segment.GetRepField<CWE>(54);
        this.RelationshiptothePatientStartDate = segment.GetField<DT>(55);
        this.RelationshiptothePatientStopDate = segment.GetRepField<DT>(56);
        this.InsuranceCoContactReason = segment.GetField<CWE>(57);
        this.InsuranceCoContactPhoneNumber = segment.GetRepField<XTN>(58);
        this.PolicyScope = segment.GetField<CWE>(59);
        this.PolicySource = segment.GetField<CWE>(60);
        this.PatientMemberNumber = segment.GetField<CX>(61);
        this.GuarantorsRelationshiptoInsured = segment.GetField<CWE>(62);
        this.InsuredsPhoneNumberHome = segment.GetRepField<XTN>(63);
        this.InsuredsEmployerPhoneNumber = segment.GetRepField<XTN>(64);
        this.MilitaryHandicappedProgram = segment.GetField<CWE>(65);
        this.SuspendFlag = segment.GetField<ID>(66);
        this.CopayLimitFlag = segment.GetField<ID>(67);
        this.StoplossLimitFlag = segment.GetField<ID>(68);
        this.InsuredOrganizationNameandID = segment.GetRepField<XON>(69);
        this.InsuredEmployerOrganizationNameandID = segment.GetRepField<XON>(70);
        this.Race = segment.GetRepField<CWE>(71);
        this.PatientsRelationshiptoInsured = segment.GetField<CWE>(72);
        this.CoPayAmount = segment.GetField<CP>(73);
    }
}

public sealed record IN3 : Hl7Segment {
    public SI SetIDIN3 { get; }
    public CX? CertificationNumber { get; }
    public ICollection<XCN>? CertifiedBy { get; }
    public ID? CertificationRequired { get; }
    public MOP? Penalty { get; }
    public DTM? CertificationDateTime { get; }
    public DTM? CertificationModifyDateTime { get; }
    public ICollection<XCN>? Operator { get; }
    public DT? CertificationBeginDate { get; }
    public DT? CertificationEndDate { get; }
    public DTN? Days { get; }
    public CWE? NonConcurCodeDescription { get; }
    public DTM? NonConcurEffectiveDateTime { get; }
    public ICollection<XCN>? PhysicianReviewer { get; }
    public ST? CertificationContact { get; }
    public ICollection<XTN>? CertificationContactPhoneNumber { get; }
    public CWE? AppealReason { get; }
    public CWE? CertificationAgency { get; }
    public ICollection<XTN>? CertificationAgencyPhoneNumber { get; }
    public ICollection<ICD>? PreCertificationRequirement { get; }
    public ST? CaseManager { get; }
    public DT? SecondOpinionDate { get; }
    public CWE? SecondOpinionStatus { get; }
    public ICollection<CWE>? SecondOpinionDocumentationReceived { get; }
    public ICollection<XCN>? SecondOpinionPhysician { get; }
    public CWE? CertificationType { get; }
    public CWE? CertificationCategory { get; }
    public DTM? OnlineVerificationDateTime { get; }
    public CWE? OnlineVerificationResult { get; }
    public CWE? OnlineVerificationResultErrorCode { get; }
    public ST? OnlineVerificationResultCheckDigit { get; }

    public IN3(Segment segment) : base(typeof(IN3), segment) {
        this.SetIDIN3 = segment.GetRequiredField<SI>(1);
        this.CertificationNumber = segment.GetField<CX>(2);
        this.CertifiedBy = segment.GetRepField<XCN>(3);
        this.CertificationRequired = segment.GetField<ID>(4);
        this.Penalty = segment.GetField<MOP>(5);
        this.CertificationDateTime = segment.GetField<DTM>(6);
        this.CertificationModifyDateTime = segment.GetField<DTM>(7);
        this.Operator = segment.GetRepField<XCN>(8);
        this.CertificationBeginDate = segment.GetField<DT>(9);
        this.CertificationEndDate = segment.GetField<DT>(10);
        this.Days = segment.GetField<DTN>(11);
        this.NonConcurCodeDescription = segment.GetField<CWE>(12);
        this.NonConcurEffectiveDateTime = segment.GetField<DTM>(13);
        this.PhysicianReviewer = segment.GetRepField<XCN>(14);
        this.CertificationContact = segment.GetField<ST>(15);
        this.CertificationContactPhoneNumber = segment.GetRepField<XTN>(16);
        this.AppealReason = segment.GetField<CWE>(17);
        this.CertificationAgency = segment.GetField<CWE>(18);
        this.CertificationAgencyPhoneNumber = segment.GetRepField<XTN>(19);
        this.PreCertificationRequirement = segment.GetRepField<ICD>(20);
        this.CaseManager = segment.GetField<ST>(21);
        this.SecondOpinionDate = segment.GetField<DT>(22);
        this.SecondOpinionStatus = segment.GetField<CWE>(23);
        this.SecondOpinionDocumentationReceived = segment.GetRepField<CWE>(24);
        this.SecondOpinionPhysician = segment.GetRepField<XCN>(25);
        this.CertificationType = segment.GetField<CWE>(26);
        this.CertificationCategory = segment.GetField<CWE>(27);
        this.OnlineVerificationDateTime = segment.GetField<DTM>(28);
        this.OnlineVerificationResult = segment.GetField<CWE>(29);
        this.OnlineVerificationResultErrorCode = segment.GetField<CWE>(30);
        this.OnlineVerificationResultCheckDigit = segment.GetField<ST>(31);
    }
}

public sealed record INV : Hl7Segment {
    public CWE? SubstanceIdentifier { get; }
    public CWE? SubstanceStatus { get; }
    public CWE? SubstanceType { get; }
    public CWE? InventoryContainerIdentifier { get; }
    public CWE? ContainerCarrierIdentifier { get; }
    public CWE? PositiononCarrier { get; }
    public NM? InitialQuantity { get; }
    public NM? CurrentQuantity { get; }
    public NM? AvailableQuantity { get; }
    public NM? ConsumptionQuantity { get; }
    public CWE? QuantityUnits { get; }
    public DTM? ExpirationDateTime { get; }
    public DTM? FirstUsedDateTime { get; }
    public ST? OnBoardStabilityDuration { get; }
    public ICollection<CWE>? TestFluidIdentifiers { get; }
    public ST? ManufacturerLotNumber { get; }
    public CWE? ManufacturerIdentifier { get; }
    public CWE? SupplierIdentifier { get; }
    public CQ? OnBoardStabilityTime { get; }
    public CQ? TargetValue { get; }
    public CWE? EquipmentStateIndicatorTypeCode { get; }
    public CQ? EquipmentStateIndicatorValue { get; }

    public INV(Segment segment) : base(typeof(INV), segment) {
        this.SubstanceIdentifier = segment.GetField<CWE>(1);
        this.SubstanceStatus = segment.GetField<CWE>(2);
        this.SubstanceType = segment.GetField<CWE>(3);
        this.InventoryContainerIdentifier = segment.GetField<CWE>(4);
        this.ContainerCarrierIdentifier = segment.GetField<CWE>(5);
        this.PositiononCarrier = segment.GetField<CWE>(6);
        this.InitialQuantity = segment.GetField<NM>(7);
        this.CurrentQuantity = segment.GetField<NM>(8);
        this.AvailableQuantity = segment.GetField<NM>(9);
        this.ConsumptionQuantity = segment.GetField<NM>(10);
        this.QuantityUnits = segment.GetField<CWE>(11);
        this.ExpirationDateTime = segment.GetField<DTM>(12);
        this.FirstUsedDateTime = segment.GetField<DTM>(13);
        this.OnBoardStabilityDuration = segment.GetField<ST>(14);
        this.TestFluidIdentifiers = segment.GetRepField<CWE>(15);
        this.ManufacturerLotNumber = segment.GetField<ST>(16);
        this.ManufacturerIdentifier = segment.GetField<CWE>(17);
        this.SupplierIdentifier = segment.GetField<CWE>(18);
        this.OnBoardStabilityTime = segment.GetField<CQ>(19);
        this.TargetValue = segment.GetField<CQ>(20);
        this.EquipmentStateIndicatorTypeCode = segment.GetField<CWE>(21);
        this.EquipmentStateIndicatorValue = segment.GetField<CQ>(22);
    }
}

public sealed record IPC : Hl7Segment {
    public EI AccessionIdentifier { get; }
    public EI RequestedProcedureID { get; }
    public EI StudyInstanceUID { get; }
    public EI ScheduledProcedureStepID { get; }
    public CWE? Modality { get; }
    public ICollection<CWE>? ProtocolCode { get; }
    public EI? ScheduledStationName { get; }
    public ICollection<CWE>? ScheduledProcedureStepLocation { get; }
    public ST? ScheduledStationAETitle { get; }
    public ID? ActionCode { get; }

    public IPC(Segment segment) : base(typeof(IPC), segment) {
        this.AccessionIdentifier = segment.GetRequiredField<EI>(1);
        this.RequestedProcedureID = segment.GetRequiredField<EI>(2);
        this.StudyInstanceUID = segment.GetRequiredField<EI>(3);
        this.ScheduledProcedureStepID = segment.GetRequiredField<EI>(4);
        this.Modality = segment.GetField<CWE>(5);
        this.ProtocolCode = segment.GetRepField<CWE>(6);
        this.ScheduledStationName = segment.GetField<EI>(7);
        this.ScheduledProcedureStepLocation = segment.GetRepField<CWE>(8);
        this.ScheduledStationAETitle = segment.GetField<ST>(9);
        this.ActionCode = segment.GetField<ID>(10);
    }
}

public sealed record IPR : Hl7Segment {
    public EI IPRIdentifier { get; }
    public EI ProviderCrossReferenceIdentifier { get; }
    public EI PayerCrossReferenceIdentifier { get; }
    public CWE IPRStatus { get; }
    public DTM IPRDateTime { get; }
    public CP? AdjudicatedPaidAmount { get; }
    public DTM? ExpectedPaymentDateTime { get; }
    public ST IPRChecksum { get; }

    public IPR(Segment segment) : base(typeof(IPR), segment) {
        this.IPRIdentifier = segment.GetRequiredField<EI>(1);
        this.ProviderCrossReferenceIdentifier = segment.GetRequiredField<EI>(2);
        this.PayerCrossReferenceIdentifier = segment.GetRequiredField<EI>(3);
        this.IPRStatus = segment.GetRequiredField<CWE>(4);
        this.IPRDateTime = segment.GetRequiredField<DTM>(5);
        this.AdjudicatedPaidAmount = segment.GetField<CP>(6);
        this.ExpectedPaymentDateTime = segment.GetField<DTM>(7);
        this.IPRChecksum = segment.GetRequiredField<ST>(8);
    }
}

public sealed record ISD : Hl7Segment {
    public NM ReferenceInteractionNumber { get; }
    public CWE? InteractionTypeIdentifier { get; }
    public CWE InteractionActiveState { get; }

    public ISD(Segment segment) : base(typeof(ISD), segment) {
        this.ReferenceInteractionNumber = segment.GetRequiredField<NM>(1);
        this.InteractionTypeIdentifier = segment.GetField<CWE>(2);
        this.InteractionActiveState = segment.GetRequiredField<CWE>(3);
    }
}

public sealed record ITM : Hl7Segment {
    public EI ItemIdentifier { get; }
    public ST? ItemDescription { get; }
    public CWE? ItemStatus { get; }
    public CWE? ItemType { get; }
    public CWE? ItemCategory { get; }
    public CNE? SubjecttoExpirationIndicator { get; }
    public EI? ManufacturerIdentifier { get; }
    public ST? ManufacturerName { get; }
    public ST? ManufacturerCatalogNumber { get; }
    public CWE? ManufacturerLabelerIdentificationCode { get; }
    public CNE? PatientChargeableIndicator { get; }
    public CWE? TransactionCode { get; }
    public CP? TransactionAmountUnit { get; }
    public CNE? StockedItemIndicator { get; }
    public CWE? SupplyRiskCodes { get; }
    public ICollection<XON>? ApprovingRegulatoryAgency { get; }
    public CNE? LatexIndicator { get; }
    public ICollection<CWE>? RulingAct { get; }
    public CWE? ItemNaturalAccountCode { get; }
    public NM? ApprovedToBuyQuantity { get; }
    public MO? ApprovedToBuyPrice { get; }
    public CNE? TaxableItemIndicator { get; }
    public CNE? FreightChargeIndicator { get; }
    public CNE? ItemSetIndicator { get; }
    public EI? ItemSetIdentifier { get; }
    public CNE? TrackDepartmentUsageIndicator { get; }
    public CNE? ProcedureCode { get; }
    public ICollection<CNE>? ProcedureCodeModifier { get; }
    public CWE? SpecialHandlingCode { get; }
    public CNE? HazardousIndicator { get; }
    public CNE? SterileIndicator { get; }
    public EI? MaterialDataSafetySheetNumber { get; }
    public CWE? UnitedNationsStandardProductsandServicesCode { get; }
    public DR? ContractDate { get; }
    public XPN? ManufacturerContactName { get; }
    public XTN? ManufacturerContactInformation { get; }
    public ST? ClassofTrade { get; }
    public ID? FieldLevelEventCode { get; }

    public ITM(Segment segment) : base(typeof(ITM), segment) {
        this.ItemIdentifier = segment.GetRequiredField<EI>(1);
        this.ItemDescription = segment.GetField<ST>(2);
        this.ItemStatus = segment.GetField<CWE>(3);
        this.ItemType = segment.GetField<CWE>(4);
        this.ItemCategory = segment.GetField<CWE>(5);
        this.SubjecttoExpirationIndicator = segment.GetField<CNE>(6);
        this.ManufacturerIdentifier = segment.GetField<EI>(7);
        this.ManufacturerName = segment.GetField<ST>(8);
        this.ManufacturerCatalogNumber = segment.GetField<ST>(9);
        this.ManufacturerLabelerIdentificationCode = segment.GetField<CWE>(10);
        this.PatientChargeableIndicator = segment.GetField<CNE>(11);
        this.TransactionCode = segment.GetField<CWE>(12);
        this.TransactionAmountUnit = segment.GetField<CP>(13);
        this.StockedItemIndicator = segment.GetField<CNE>(14);
        this.SupplyRiskCodes = segment.GetField<CWE>(15);
        this.ApprovingRegulatoryAgency = segment.GetRepField<XON>(16);
        this.LatexIndicator = segment.GetField<CNE>(17);
        this.RulingAct = segment.GetRepField<CWE>(18);
        this.ItemNaturalAccountCode = segment.GetField<CWE>(19);
        this.ApprovedToBuyQuantity = segment.GetField<NM>(20);
        this.ApprovedToBuyPrice = segment.GetField<MO>(21);
        this.TaxableItemIndicator = segment.GetField<CNE>(22);
        this.FreightChargeIndicator = segment.GetField<CNE>(23);
        this.ItemSetIndicator = segment.GetField<CNE>(24);
        this.ItemSetIdentifier = segment.GetField<EI>(25);
        this.TrackDepartmentUsageIndicator = segment.GetField<CNE>(26);
        this.ProcedureCode = segment.GetField<CNE>(27);
        this.ProcedureCodeModifier = segment.GetRepField<CNE>(28);
        this.SpecialHandlingCode = segment.GetField<CWE>(29);
        this.HazardousIndicator = segment.GetField<CNE>(30);
        this.SterileIndicator = segment.GetField<CNE>(31);
        this.MaterialDataSafetySheetNumber = segment.GetField<EI>(32);
        this.UnitedNationsStandardProductsandServicesCode = segment.GetField<CWE>(33);
        this.ContractDate = segment.GetField<DR>(34);
        this.ManufacturerContactName = segment.GetField<XPN>(35);
        this.ManufacturerContactInformation = segment.GetField<XTN>(36);
        this.ClassofTrade = segment.GetField<ST>(37);
        this.FieldLevelEventCode = segment.GetField<ID>(38);
    }
}

public sealed record IVC : Hl7Segment {
    public EI ProviderInvoiceNumber { get; }
    public EI? PayerInvoiceNumber { get; }
    public EI? ContractAgreementNumber { get; }
    public CWE InvoiceControl { get; }
    public CWE InvoiceReason { get; }
    public CWE InvoiceType { get; }
    public DTM InvoiceDateTime { get; }
    public CP InvoiceAmount { get; }
    public ST? PaymentTerms { get; }
    public XON ProviderOrganization { get; }
    public XON PayerOrganization { get; }
    public XCN? Attention { get; }
    public ID? LastInvoiceIndicator { get; }
    public DTM? InvoiceBookingPeriod { get; }
    public ST? Origin { get; }
    public CP? InvoiceFixedAmount { get; }
    public CP? SpecialCosts { get; }
    public CP? AmountforDoctorsTreatment { get; }
    public XCN? ResponsiblePhysician { get; }
    public CX? CostCenter { get; }
    public CP? InvoicePrepaidAmount { get; }
    public CP? TotalInvoiceAmountwithoutPrepaidAmount { get; }
    public CP? TotalAmountofVAT { get; }
    public ICollection<NM>? VATRatesapplied { get; }
    public CWE BenefitGroup { get; }
    public ST? ProviderTaxID { get; }
    public ST? PayerTaxID { get; }
    public CWE? ProviderTaxStatus { get; }
    public CWE? PayerTaxStatus { get; }
    public ST? SalesTaxID { get; }

    public IVC(Segment segment) : base(typeof(IVC), segment) {
        this.ProviderInvoiceNumber = segment.GetRequiredField<EI>(1);
        this.PayerInvoiceNumber = segment.GetField<EI>(2);
        this.ContractAgreementNumber = segment.GetField<EI>(3);
        this.InvoiceControl = segment.GetRequiredField<CWE>(4);
        this.InvoiceReason = segment.GetRequiredField<CWE>(5);
        this.InvoiceType = segment.GetRequiredField<CWE>(6);
        this.InvoiceDateTime = segment.GetRequiredField<DTM>(7);
        this.InvoiceAmount = segment.GetRequiredField<CP>(8);
        this.PaymentTerms = segment.GetField<ST>(9);
        this.ProviderOrganization = segment.GetRequiredField<XON>(10);
        this.PayerOrganization = segment.GetRequiredField<XON>(11);
        this.Attention = segment.GetField<XCN>(12);
        this.LastInvoiceIndicator = segment.GetField<ID>(13);
        this.InvoiceBookingPeriod = segment.GetField<DTM>(14);
        this.Origin = segment.GetField<ST>(15);
        this.InvoiceFixedAmount = segment.GetField<CP>(16);
        this.SpecialCosts = segment.GetField<CP>(17);
        this.AmountforDoctorsTreatment = segment.GetField<CP>(18);
        this.ResponsiblePhysician = segment.GetField<XCN>(19);
        this.CostCenter = segment.GetField<CX>(20);
        this.InvoicePrepaidAmount = segment.GetField<CP>(21);
        this.TotalInvoiceAmountwithoutPrepaidAmount = segment.GetField<CP>(22);
        this.TotalAmountofVAT = segment.GetField<CP>(23);
        this.VATRatesapplied = segment.GetRepField<NM>(24);
        this.BenefitGroup = segment.GetRequiredField<CWE>(25);
        this.ProviderTaxID = segment.GetField<ST>(26);
        this.PayerTaxID = segment.GetField<ST>(27);
        this.ProviderTaxStatus = segment.GetField<CWE>(28);
        this.PayerTaxStatus = segment.GetField<CWE>(29);
        this.SalesTaxID = segment.GetField<ST>(30);
    }
}

public sealed record IVT : Hl7Segment {
    public SI SetIdIVT { get; }
    public EI InventoryLocationIdentifier { get; }
    public ST? InventoryLocationName { get; }
    public EI? SourceLocationIdentifier { get; }
    public ST? SourceLocationName { get; }
    public CWE? ItemStatus { get; }
    public ICollection<EI>? BinLocationIdentifier { get; }
    public CWE? OrderPackaging { get; }
    public CWE? IssuePackaging { get; }
    public EI? DefaultInventoryAssetAccount { get; }
    public CNE? PatientChargeableIndicator { get; }
    public CWE? TransactionCode { get; }
    public CP? TransactionAmountUnit { get; }
    public CWE? ItemImportanceCode { get; }
    public CNE? StockedItemIndicator { get; }
    public CNE? ConsignmentItemIndicator { get; }
    public CNE? ReusableItemIndicator { get; }
    public CP? ReusableCost { get; }
    public ICollection<EI>? SubstituteItemIdentifier { get; }
    public EI? LatexFreeSubstituteItemIdentifier { get; }
    public CWE? RecommendedReorderTheory { get; }
    public NM? RecommendedSafetyStockDays { get; }
    public NM? RecommendedMaximumDaysInventory { get; }
    public NM? RecommendedOrderPoint { get; }
    public NM? RecommendedOrderAmount { get; }
    public CNE? OperatingRoomParLevelIndicator { get; }

    public IVT(Segment segment) : base(typeof(IVT), segment) {
        this.SetIdIVT = segment.GetRequiredField<SI>(1);
        this.InventoryLocationIdentifier = segment.GetRequiredField<EI>(2);
        this.InventoryLocationName = segment.GetField<ST>(3);
        this.SourceLocationIdentifier = segment.GetField<EI>(4);
        this.SourceLocationName = segment.GetField<ST>(5);
        this.ItemStatus = segment.GetField<CWE>(6);
        this.BinLocationIdentifier = segment.GetRepField<EI>(7);
        this.OrderPackaging = segment.GetField<CWE>(8);
        this.IssuePackaging = segment.GetField<CWE>(9);
        this.DefaultInventoryAssetAccount = segment.GetField<EI>(10);
        this.PatientChargeableIndicator = segment.GetField<CNE>(11);
        this.TransactionCode = segment.GetField<CWE>(12);
        this.TransactionAmountUnit = segment.GetField<CP>(13);
        this.ItemImportanceCode = segment.GetField<CWE>(14);
        this.StockedItemIndicator = segment.GetField<CNE>(15);
        this.ConsignmentItemIndicator = segment.GetField<CNE>(16);
        this.ReusableItemIndicator = segment.GetField<CNE>(17);
        this.ReusableCost = segment.GetField<CP>(18);
        this.SubstituteItemIdentifier = segment.GetRepField<EI>(19);
        this.LatexFreeSubstituteItemIdentifier = segment.GetField<EI>(20);
        this.RecommendedReorderTheory = segment.GetField<CWE>(21);
        this.RecommendedSafetyStockDays = segment.GetField<NM>(22);
        this.RecommendedMaximumDaysInventory = segment.GetField<NM>(23);
        this.RecommendedOrderPoint = segment.GetField<NM>(24);
        this.RecommendedOrderAmount = segment.GetField<NM>(25);
        this.OperatingRoomParLevelIndicator = segment.GetField<CNE>(26);
    }
}

public sealed record LAN : Hl7Segment {
    public SI SetIDLAN { get; }
    public CWE LanguageCode { get; }
    public ICollection<CWE>? LanguageAbilityCode { get; }
    public CWE? LanguageProficiencyCode { get; }

    public LAN(Segment segment) : base(typeof(LAN), segment) {
        this.SetIDLAN = segment.GetRequiredField<SI>(1);
        this.LanguageCode = segment.GetRequiredField<CWE>(2);
        this.LanguageAbilityCode = segment.GetRepField<CWE>(3);
        this.LanguageProficiencyCode = segment.GetField<CWE>(4);
    }
}

public sealed record LCC : Hl7Segment {
    public PL PrimaryKeyValueLCC { get; }
    public CWE LocationDepartment { get; }
    public ICollection<CWE>? AccommodationType { get; }
    public ICollection<CWE> ChargeCode { get; }

    public LCC(Segment segment) : base(typeof(LCC), segment) {
        this.PrimaryKeyValueLCC = segment.GetRequiredField<PL>(1);
        this.LocationDepartment = segment.GetRequiredField<CWE>(2);
        this.AccommodationType = segment.GetRepField<CWE>(3);
        this.ChargeCode = segment.GetRequiredRepField<CWE>(4);
    }
}

public sealed record LCH : Hl7Segment {
    public PL PrimaryKeyValueLCH { get; }
    public ID? SegmentActionCode { get; }
    public EI? SegmentUniqueKey { get; }
    public CWE LocationCharacteristicID { get; }
    public CWE LocationCharacteristicValueLCH { get; }

    public LCH(Segment segment) : base(typeof(LCH), segment) {
        this.PrimaryKeyValueLCH = segment.GetRequiredField<PL>(1);
        this.SegmentActionCode = segment.GetField<ID>(2);
        this.SegmentUniqueKey = segment.GetField<EI>(3);
        this.LocationCharacteristicID = segment.GetRequiredField<CWE>(4);
        this.LocationCharacteristicValueLCH = segment.GetRequiredField<CWE>(5);
    }
}

public sealed record LDP : Hl7Segment {
    public PL PrimaryKeyValueLDP { get; }
    public CWE LocationDepartment { get; }
    public ICollection<CWE>? LocationService { get; }
    public ICollection<CWE>? SpecialtyType { get; }
    public ICollection<CWE>? ValidPatientClasses { get; }
    public ID? ActiveInactiveFlag { get; }
    public DTM? ActivationDateLDP { get; }
    public DTM? InactivationDateLDP { get; }
    public ST? InactivatedReason { get; }
    public ICollection<VH>? VisitingHours { get; }
    public XTN? ContactPhone { get; }
    public CWE? LocationCostCenter { get; }

    public LDP(Segment segment) : base(typeof(LDP), segment) {
        this.PrimaryKeyValueLDP = segment.GetRequiredField<PL>(1);
        this.LocationDepartment = segment.GetRequiredField<CWE>(2);
        this.LocationService = segment.GetRepField<CWE>(3);
        this.SpecialtyType = segment.GetRepField<CWE>(4);
        this.ValidPatientClasses = segment.GetRepField<CWE>(5);
        this.ActiveInactiveFlag = segment.GetField<ID>(6);
        this.ActivationDateLDP = segment.GetField<DTM>(7);
        this.InactivationDateLDP = segment.GetField<DTM>(8);
        this.InactivatedReason = segment.GetField<ST>(9);
        this.VisitingHours = segment.GetRepField<VH>(10);
        this.ContactPhone = segment.GetField<XTN>(11);
        this.LocationCostCenter = segment.GetField<CWE>(12);
    }
}

public sealed record LOC : Hl7Segment {
    public PL PrimaryKeyValueLOC { get; }
    public ST? LocationDescription { get; }
    public ICollection<CWE> LocationTypeLOC { get; }
    public ICollection<XON>? OrganizationNameLOC { get; }
    public ICollection<XAD>? LocationAddress { get; }
    public ICollection<XTN>? LocationPhone { get; }
    public ICollection<CWE>? LicenseNumber { get; }
    public ICollection<CWE>? LocationEquipment { get; }
    public CWE? LocationServiceCode { get; }

    public LOC(Segment segment) : base(typeof(LOC), segment) {
        this.PrimaryKeyValueLOC = segment.GetRequiredField<PL>(1);
        this.LocationDescription = segment.GetField<ST>(2);
        this.LocationTypeLOC = segment.GetRequiredRepField<CWE>(3);
        this.OrganizationNameLOC = segment.GetRepField<XON>(4);
        this.LocationAddress = segment.GetRepField<XAD>(5);
        this.LocationPhone = segment.GetRepField<XTN>(6);
        this.LicenseNumber = segment.GetRepField<CWE>(7);
        this.LocationEquipment = segment.GetRepField<CWE>(8);
        this.LocationServiceCode = segment.GetField<CWE>(9);
    }
}

public sealed record LRL : Hl7Segment {
    public PL PrimaryKeyValueLRL { get; }
    public ID? SegmentActionCode { get; }
    public EI? SegmentUniqueKey { get; }
    public CWE LocationRelationshipID { get; }
    public XON? OrganizationalLocationRelationshipValue { get; }
    public PL? PatientLocationRelationshipValue { get; }

    public LRL(Segment segment) : base(typeof(LRL), segment) {
        this.PrimaryKeyValueLRL = segment.GetRequiredField<PL>(1);
        this.SegmentActionCode = segment.GetField<ID>(2);
        this.SegmentUniqueKey = segment.GetField<EI>(3);
        this.LocationRelationshipID = segment.GetRequiredField<CWE>(4);
        this.OrganizationalLocationRelationshipValue = segment.GetField<XON>(5);
        this.PatientLocationRelationshipValue = segment.GetField<PL>(6);
    }
}

public sealed record MCP : Hl7Segment {
    public SI SetIDMCP { get; }
    public CWE ProducersServiceTestObservationID { get; }
    public MO? UniversalServicePriceRangeLowValue { get; }
    public MO? UniversalServicePriceRangeHighValue { get; }
    public ST? ReasonforUniversalServiceCostRange { get; }

    public MCP(Segment segment) : base(typeof(MCP), segment) {
        this.SetIDMCP = segment.GetRequiredField<SI>(1);
        this.ProducersServiceTestObservationID = segment.GetRequiredField<CWE>(2);
        this.UniversalServicePriceRangeLowValue = segment.GetField<MO>(3);
        this.UniversalServicePriceRangeHighValue = segment.GetField<MO>(4);
        this.ReasonforUniversalServiceCostRange = segment.GetField<ST>(5);
    }
}

public sealed record MFA : Hl7Segment {
    public ID RecordLevelEventCode { get; }
    public ST? MFNControlID { get; }
    public DTM? EventCompletionDateTime { get; }
    public CWE MFNRecordLevelErrorReturn { get; }
    public ICollection<ST> PrimaryKeyValueMFA { get; }
    public ICollection<ID> PrimaryKeyValueTypeMFA { get; }

    public MFA(Segment segment) : base(typeof(MFA), segment) {
        this.RecordLevelEventCode = segment.GetRequiredField<ID>(1);
        this.MFNControlID = segment.GetField<ST>(2);
        this.EventCompletionDateTime = segment.GetField<DTM>(3);
        this.MFNRecordLevelErrorReturn = segment.GetRequiredField<CWE>(4);
        this.PrimaryKeyValueMFA = segment.GetRequiredRepField<ST>(5);
        this.PrimaryKeyValueTypeMFA = segment.GetRequiredRepField<ID>(6);
    }
}

public sealed record MFE : Hl7Segment {
    public ID RecordLevelEventCode { get; }
    public ST? MFNControlID { get; }
    public DTM? EffectiveDateTime { get; }
    public ICollection<ST> PrimaryKeyValueMFE { get; }
    public ICollection<ID> PrimaryKeyValueType { get; }
    public DTM? EnteredDateTime { get; }
    public XCN? EnteredBy { get; }

    public MFE(Segment segment) : base(typeof(MFE), segment) {
        this.RecordLevelEventCode = segment.GetRequiredField<ID>(1);
        this.MFNControlID = segment.GetField<ST>(2);
        this.EffectiveDateTime = segment.GetField<DTM>(3);
        this.PrimaryKeyValueMFE = segment.GetRequiredRepField<ST>(4);
        this.PrimaryKeyValueType = segment.GetRequiredRepField<ID>(5);
        this.EnteredDateTime = segment.GetField<DTM>(6);
        this.EnteredBy = segment.GetField<XCN>(7);
    }
}

public sealed record MFI : Hl7Segment {
    public CWE MasterFileIdentifier { get; }
    public ICollection<HD>? MasterFileApplicationIdentifier { get; }
    public ID FileLevelEventCode { get; }
    public DTM? EnteredDateTime { get; }
    public DTM? EffectiveDateTime { get; }
    public ID ResponseLevelCode { get; }

    public MFI(Segment segment) : base(typeof(MFI), segment) {
        this.MasterFileIdentifier = segment.GetRequiredField<CWE>(1);
        this.MasterFileApplicationIdentifier = segment.GetRepField<HD>(2);
        this.FileLevelEventCode = segment.GetRequiredField<ID>(3);
        this.EnteredDateTime = segment.GetField<DTM>(4);
        this.EffectiveDateTime = segment.GetField<DTM>(5);
        this.ResponseLevelCode = segment.GetRequiredField<ID>(6);
    }
}

public sealed record MRG : Hl7Segment {
    public ICollection<CX> PriorPatientIdentifierList { get; }
    public ST? PriorAlternatePatientID { get; }
    public CX? PriorPatientAccountNumber { get; }
    public ST? PriorPatientID { get; }
    public CX? PriorVisitNumber { get; }
    public ICollection<CX>? PriorAlternateVisitID { get; }
    public ICollection<XPN>? PriorPatientName { get; }

    public MRG(Segment segment) : base(typeof(MRG), segment) {
        this.PriorPatientIdentifierList = segment.GetRequiredRepField<CX>(1);
        this.PriorAlternatePatientID = segment.GetField<ST>(2);
        this.PriorPatientAccountNumber = segment.GetField<CX>(3);
        this.PriorPatientID = segment.GetField<ST>(4);
        this.PriorVisitNumber = segment.GetField<CX>(5);
        this.PriorAlternateVisitID = segment.GetRepField<CX>(6);
        this.PriorPatientName = segment.GetRepField<XPN>(7);
    }
}

public sealed record MSA : Hl7Segment {
    public ID AcknowledgmentCode { get; }
    public ST MessageControlID { get; }
    public ST? TextMessage { get; }
    public NM? ExpectedSequenceNumber { get; }
    public ST? DelayedAcknowledgmentType { get; }
    public ST? ErrorCondition { get; }
    public NM? MessageWaitingNumber { get; }
    public ID? MessageWaitingPriority { get; }

    public MSA(Segment segment) : base(typeof(MSA), segment) {
        this.AcknowledgmentCode = segment.GetRequiredField<ID>(1);
        this.MessageControlID = segment.GetRequiredField<ST>(2);
        this.TextMessage = segment.GetField<ST>(3);
        this.ExpectedSequenceNumber = segment.GetField<NM>(4);
        this.DelayedAcknowledgmentType = segment.GetField<ST>(5);
        this.ErrorCondition = segment.GetField<ST>(6);
        this.MessageWaitingNumber = segment.GetField<NM>(7);
        this.MessageWaitingPriority = segment.GetField<ID>(8);
    }
}

public sealed record NCK : Hl7Segment {
    public DTM SystemDateTime { get; }

    public NCK(Segment segment) : base(typeof(NCK), segment) {
        this.SystemDateTime = segment.GetRequiredField<DTM>(1);
    }
}

public sealed record NDS : Hl7Segment {
    public NM NotificationReferenceNumber { get; }
    public DTM NotificationDateTime { get; }
    public CWE NotificationAlertSeverity { get; }
    public CWE NotificationCode { get; }

    public NDS(Segment segment) : base(typeof(NDS), segment) {
        this.NotificationReferenceNumber = segment.GetRequiredField<NM>(1);
        this.NotificationDateTime = segment.GetRequiredField<DTM>(2);
        this.NotificationAlertSeverity = segment.GetRequiredField<CWE>(3);
        this.NotificationCode = segment.GetRequiredField<CWE>(4);
    }
}

public sealed record NK1 : Hl7Segment {
    public SI SetIDNK1 { get; }
    public ICollection<XPN>? Name { get; }
    public CWE? Relationship { get; }
    public ICollection<XAD>? Address { get; }
    public XTN? PhoneNumber { get; }
    public XTN? BusinessPhoneNumber { get; }
    public CWE? ContactRole { get; }
    public DT? StartDate { get; }
    public DT? EndDate { get; }
    public ST? NextofKinAssociatedPartiesJobTitle { get; }
    public JCC? NextofKinAssociatedPartiesJobCodeClass { get; }
    public CX? NextofKinAssociatedPartiesEmployeeNumber { get; }
    public ICollection<XON>? OrganizationNameNK1 { get; }
    public CWE? MaritalStatus { get; }
    public CWE? AdministrativeSex { get; }
    public DTM? DateTimeofBirth { get; }
    public ICollection<CWE>? LivingDependency { get; }
    public ICollection<CWE>? AmbulatoryStatus { get; }
    public ICollection<CWE>? Citizenship { get; }
    public CWE? PrimaryLanguage { get; }
    public CWE? LivingArrangement { get; }
    public CWE? PublicityCode { get; }
    public ID? ProtectionIndicator { get; }
    public CWE? StudentIndicator { get; }
    public CWE? Religion { get; }
    public ICollection<XPN>? MothersMaidenName { get; }
    public CWE? Nationality { get; }
    public ICollection<CWE>? EthnicGroup { get; }
    public ICollection<CWE>? ContactReason { get; }
    public ICollection<XPN>? ContactPersonsName { get; }
    public XTN? ContactPersonsTelephoneNumber { get; }
    public ICollection<XAD>? ContactPersonsAddress { get; }
    public ICollection<CX>? NextofKinAssociatedPartysIdentifiers { get; }
    public CWE? JobStatus { get; }
    public ICollection<CWE>? Race { get; }
    public CWE? Handicap { get; }
    public ST? ContactPersonSocialSecurityNumber { get; }
    public ST? NextofKinBirthPlace { get; }
    public CWE? VIPIndicator { get; }
    public XTN? NextofKinTelecommunicationInformation { get; }
    public XTN? ContactPersonsTelecommunicationInformation { get; }

    public NK1(Segment segment) : base(typeof(NK1), segment) {
        this.SetIDNK1 = segment.GetRequiredField<SI>(1);
        this.Name = segment.GetRepField<XPN>(2);
        this.Relationship = segment.GetField<CWE>(3);
        this.Address = segment.GetRepField<XAD>(4);
        this.PhoneNumber = segment.GetField<XTN>(5);
        this.BusinessPhoneNumber = segment.GetField<XTN>(6);
        this.ContactRole = segment.GetField<CWE>(7);
        this.StartDate = segment.GetField<DT>(8);
        this.EndDate = segment.GetField<DT>(9);
        this.NextofKinAssociatedPartiesJobTitle = segment.GetField<ST>(10);
        this.NextofKinAssociatedPartiesJobCodeClass = segment.GetField<JCC>(11);
        this.NextofKinAssociatedPartiesEmployeeNumber = segment.GetField<CX>(12);
        this.OrganizationNameNK1 = segment.GetRepField<XON>(13);
        this.MaritalStatus = segment.GetField<CWE>(14);
        this.AdministrativeSex = segment.GetField<CWE>(15);
        this.DateTimeofBirth = segment.GetField<DTM>(16);
        this.LivingDependency = segment.GetRepField<CWE>(17);
        this.AmbulatoryStatus = segment.GetRepField<CWE>(18);
        this.Citizenship = segment.GetRepField<CWE>(19);
        this.PrimaryLanguage = segment.GetField<CWE>(20);
        this.LivingArrangement = segment.GetField<CWE>(21);
        this.PublicityCode = segment.GetField<CWE>(22);
        this.ProtectionIndicator = segment.GetField<ID>(23);
        this.StudentIndicator = segment.GetField<CWE>(24);
        this.Religion = segment.GetField<CWE>(25);
        this.MothersMaidenName = segment.GetRepField<XPN>(26);
        this.Nationality = segment.GetField<CWE>(27);
        this.EthnicGroup = segment.GetRepField<CWE>(28);
        this.ContactReason = segment.GetRepField<CWE>(29);
        this.ContactPersonsName = segment.GetRepField<XPN>(30);
        this.ContactPersonsTelephoneNumber = segment.GetField<XTN>(31);
        this.ContactPersonsAddress = segment.GetRepField<XAD>(32);
        this.NextofKinAssociatedPartysIdentifiers = segment.GetRepField<CX>(33);
        this.JobStatus = segment.GetField<CWE>(34);
        this.Race = segment.GetRepField<CWE>(35);
        this.Handicap = segment.GetField<CWE>(36);
        this.ContactPersonSocialSecurityNumber = segment.GetField<ST>(37);
        this.NextofKinBirthPlace = segment.GetField<ST>(38);
        this.VIPIndicator = segment.GetField<CWE>(39);
        this.NextofKinTelecommunicationInformation = segment.GetField<XTN>(40);
        this.ContactPersonsTelecommunicationInformation = segment.GetField<XTN>(41);
    }
}

public sealed record NPU : Hl7Segment {
    public PL BedLocation { get; }
    public CWE? BedStatus { get; }

    public NPU(Segment segment) : base(typeof(NPU), segment) {
        this.BedLocation = segment.GetRequiredField<PL>(1);
        this.BedStatus = segment.GetField<CWE>(2);
    }
}

public sealed record NSC : Hl7Segment {
    public CWE ApplicationChangeType { get; }
    public ST? CurrentCPU { get; }
    public ST? CurrentFileserver { get; }
    public HD? CurrentApplication { get; }
    public HD? CurrentFacility { get; }
    public ST? NewCPU { get; }
    public ST? NewFileserver { get; }
    public HD? NewApplication { get; }
    public HD? NewFacility { get; }

    public NSC(Segment segment) : base(typeof(NSC), segment) {
        this.ApplicationChangeType = segment.GetRequiredField<CWE>(1);
        this.CurrentCPU = segment.GetField<ST>(2);
        this.CurrentFileserver = segment.GetField<ST>(3);
        this.CurrentApplication = segment.GetField<HD>(4);
        this.CurrentFacility = segment.GetField<HD>(5);
        this.NewCPU = segment.GetField<ST>(6);
        this.NewFileserver = segment.GetField<ST>(7);
        this.NewApplication = segment.GetField<HD>(8);
        this.NewFacility = segment.GetField<HD>(9);
    }
}

public sealed record NST : Hl7Segment {
    public ID StatisticsAvailable { get; }
    public ST? SourceIdentifier { get; }
    public ID? SourceType { get; }
    public DTM? StatisticsStart { get; }
    public DTM? StatisticsEnd { get; }
    public NM? ReceiveCharacterCount { get; }
    public NM? SendCharacterCount { get; }
    public NM? MessagesReceived { get; }
    public NM? MessagesSent { get; }
    public NM? ChecksumErrorsReceived { get; }
    public NM? LengthErrorsReceived { get; }
    public NM? OtherErrorsReceived { get; }
    public NM? ConnectTimeouts { get; }
    public NM? ReceiveTimeouts { get; }
    public NM? ApplicationcontrollevelErrors { get; }

    public NST(Segment segment) : base(typeof(NST), segment) {
        this.StatisticsAvailable = segment.GetRequiredField<ID>(1);
        this.SourceIdentifier = segment.GetField<ST>(2);
        this.SourceType = segment.GetField<ID>(3);
        this.StatisticsStart = segment.GetField<DTM>(4);
        this.StatisticsEnd = segment.GetField<DTM>(5);
        this.ReceiveCharacterCount = segment.GetField<NM>(6);
        this.SendCharacterCount = segment.GetField<NM>(7);
        this.MessagesReceived = segment.GetField<NM>(8);
        this.MessagesSent = segment.GetField<NM>(9);
        this.ChecksumErrorsReceived = segment.GetField<NM>(10);
        this.LengthErrorsReceived = segment.GetField<NM>(11);
        this.OtherErrorsReceived = segment.GetField<NM>(12);
        this.ConnectTimeouts = segment.GetField<NM>(13);
        this.ReceiveTimeouts = segment.GetField<NM>(14);
        this.ApplicationcontrollevelErrors = segment.GetField<NM>(15);
    }
}

public sealed record NTE : Hl7Segment {
    public SI? SetIDNTE { get; }
    public ID? SourceofComment { get; }
    public FT? Comment { get; }
    public CWE? CommentType { get; }
    public XCN? EnteredBy { get; }
    public DTM? EnteredDateTime { get; }
    public DTM? EffectiveStartDate { get; }
    public DTM? ExpirationDate { get; }
    public ICollection<CWE>? CodedComment { get; }

    public NTE(Segment segment) : base(typeof(NTE), segment) {
        this.SetIDNTE = segment.GetField<SI>(1);
        this.SourceofComment = segment.GetField<ID>(2);
        this.Comment = segment.GetField<FT>(3);
        this.CommentType = segment.GetField<CWE>(4);
        this.EnteredBy = segment.GetField<XCN>(5);
        this.EnteredDateTime = segment.GetField<DTM>(6);
        this.EffectiveStartDate = segment.GetField<DTM>(7);
        this.ExpirationDate = segment.GetField<DTM>(8);
        this.CodedComment = segment.GetRepField<CWE>(9);
    }
}

public sealed record OBR : Hl7Segment {
    public SI? SetIDOBR { get; }
    public EI? PlacerOrderNumber { get; }
    public EI? FillerOrderNumber { get; }
    public CWE UniversalServiceIdentifier { get; }
    public ST? Priority { get; }
    public ST? RequestedDateTime { get; }
    public DTM? ObservationDateTime { get; }
    public DTM? ObservationEndDateTime { get; }
    public CQ? CollectionVolume { get; }
    public ICollection<XCN>? CollectorIdentifier { get; }
    public ID? SpecimenActionCode { get; }
    public CWE? DangerCode { get; }
    public ICollection<CWE>? RelevantClinicalInformation { get; }
    public DTM? SpecimenReceivedDateTime { get; }
    public ST? SpecimenSource { get; }
    public ST? OrderingProvider { get; }
    public XTN? OrderCallbackPhoneNumber { get; }
    public ST? PlacerField1 { get; }
    public ST? PlacerField2 { get; }
    public ST? FillerField1 { get; }
    public ST? FillerField2 { get; }
    public DTM? ResultsRptStatusChngDateTime { get; }
    public MOC? ChargetoPractice { get; }
    public ID? DiagnosticServSectID { get; }
    public ID? ResultStatus { get; }
    public PRL? ParentResult { get; }
    public ST? QuantityTiming { get; }
    public ST? ResultCopiesTo { get; }
    public EIP? ParentResultsObservationIdentifier { get; }
    public ID? TransportationMode { get; }
    public ICollection<CWE>? ReasonforStudy { get; }
    public ST? PrincipalResultInterpreter { get; }
    public ST? AssistantResultInterpreter { get; }
    public ST? Technician { get; }
    public ST? Transcriptionist { get; }
    public DTM? ScheduledDateTime { get; }
    public NM? NumberofSampleContainers { get; }
    public ICollection<CWE>? TransportLogisticsofCollectedSample { get; }
    public ICollection<CWE>? CollectorsComment { get; }
    public CWE? TransportArrangementResponsibility { get; }
    public ID? TransportArranged { get; }
    public ID? EscortRequired { get; }
    public ICollection<CWE>? PlannedPatientTransportComment { get; }
    public CNE? ProcedureCode { get; }
    public ICollection<CNE>? ProcedureCodeModifier { get; }
    public ICollection<CWE>? PlacerSupplementalServiceInformation { get; }
    public ICollection<CWE>? FillerSupplementalServiceInformation { get; }
    public CWE? MedicallyNecessaryDuplicateProcedureReason { get; }
    public CWE? ResultHandling { get; }
    public ST? ParentUniversalServiceIdentifier { get; }
    public EI? ObservationGroupID { get; }
    public EI? ParentObservationGroupID { get; }
    public ICollection<CX>? AlternatePlacerOrderNumber { get; }
    public ICollection<EIP>? ParentOrder { get; }
    public ID? ActionCode { get; }

    public OBR(Segment segment) : base(typeof(OBR), segment) {
        this.SetIDOBR = segment.GetField<SI>(1);
        this.PlacerOrderNumber = segment.GetField<EI>(2);
        this.FillerOrderNumber = segment.GetField<EI>(3);
        this.UniversalServiceIdentifier = segment.GetRequiredField<CWE>(4);
        this.Priority = segment.GetField<ST>(5);
        this.RequestedDateTime = segment.GetField<ST>(6);
        this.ObservationDateTime = segment.GetField<DTM>(7);
        this.ObservationEndDateTime = segment.GetField<DTM>(8);
        this.CollectionVolume = segment.GetField<CQ>(9);
        this.CollectorIdentifier = segment.GetRepField<XCN>(10);
        this.SpecimenActionCode = segment.GetField<ID>(11);
        this.DangerCode = segment.GetField<CWE>(12);
        this.RelevantClinicalInformation = segment.GetRepField<CWE>(13);
        this.SpecimenReceivedDateTime = segment.GetField<DTM>(14);
        this.SpecimenSource = segment.GetField<ST>(15);
        this.OrderingProvider = segment.GetField<ST>(16);
        this.OrderCallbackPhoneNumber = segment.GetField<XTN>(17);
        this.PlacerField1 = segment.GetField<ST>(18);
        this.PlacerField2 = segment.GetField<ST>(19);
        this.FillerField1 = segment.GetField<ST>(20);
        this.FillerField2 = segment.GetField<ST>(21);
        this.ResultsRptStatusChngDateTime = segment.GetField<DTM>(22);
        this.ChargetoPractice = segment.GetField<MOC>(23);
        this.DiagnosticServSectID = segment.GetField<ID>(24);
        this.ResultStatus = segment.GetField<ID>(25);
        this.ParentResult = segment.GetField<PRL>(26);
        this.QuantityTiming = segment.GetField<ST>(27);
        this.ResultCopiesTo = segment.GetField<ST>(28);
        this.ParentResultsObservationIdentifier = segment.GetField<EIP>(29);
        this.TransportationMode = segment.GetField<ID>(30);
        this.ReasonforStudy = segment.GetRepField<CWE>(31);
        this.PrincipalResultInterpreter = segment.GetField<ST>(32);
        this.AssistantResultInterpreter = segment.GetField<ST>(33);
        this.Technician = segment.GetField<ST>(34);
        this.Transcriptionist = segment.GetField<ST>(35);
        this.ScheduledDateTime = segment.GetField<DTM>(36);
        this.NumberofSampleContainers = segment.GetField<NM>(37);
        this.TransportLogisticsofCollectedSample = segment.GetRepField<CWE>(38);
        this.CollectorsComment = segment.GetRepField<CWE>(39);
        this.TransportArrangementResponsibility = segment.GetField<CWE>(40);
        this.TransportArranged = segment.GetField<ID>(41);
        this.EscortRequired = segment.GetField<ID>(42);
        this.PlannedPatientTransportComment = segment.GetRepField<CWE>(43);
        this.ProcedureCode = segment.GetField<CNE>(44);
        this.ProcedureCodeModifier = segment.GetRepField<CNE>(45);
        this.PlacerSupplementalServiceInformation = segment.GetRepField<CWE>(46);
        this.FillerSupplementalServiceInformation = segment.GetRepField<CWE>(47);
        this.MedicallyNecessaryDuplicateProcedureReason = segment.GetField<CWE>(48);
        this.ResultHandling = segment.GetField<CWE>(49);
        this.ParentUniversalServiceIdentifier = segment.GetField<ST>(50);
        this.ObservationGroupID = segment.GetField<EI>(51);
        this.ParentObservationGroupID = segment.GetField<EI>(52);
        this.AlternatePlacerOrderNumber = segment.GetRepField<CX>(53);
        this.ParentOrder = segment.GetRepField<EIP>(54);
        this.ActionCode = segment.GetField<ID>(55);
    }
}

public sealed record OBX : Hl7Segment {
    public SI? SetIDOBX { get; }
    public ID? ValueType { get; }
    public CWE ObservationIdentifier { get; }
    public OG? ObservationSubID { get; }
    public ST? ObservationValue { get; }
    public CWE? Units { get; }
    public ST? ReferenceRange { get; }
    public ICollection<CWE>? InterpretationCodes { get; }
    public NM? Probability { get; }
    public ICollection<ID>? NatureofAbnormalTest { get; }
    public ID ObservationResultStatus { get; }
    public DTM? EffectiveDateofReferenceRange { get; }
    public ST? UserDefinedAccessChecks { get; }
    public DTM? DateTimeoftheObservation { get; }
    public CWE? ProducersID { get; }
    public ICollection<XCN>? ResponsibleObserver { get; }
    public ICollection<CWE>? ObservationMethod { get; }
    public ICollection<EI>? EquipmentInstanceIdentifier { get; }
    public DTM? DateTimeoftheAnalysis { get; }
    public ICollection<CWE>? ObservationSite { get; }
    public EI? ObservationInstanceIdentifier { get; }
    public CNE? MoodCode { get; }
    public XON? PerformingOrganizationName { get; }
    public XAD? PerformingOrganizationAddress { get; }
    public XCN? PerformingOrganizationMedicalDirector { get; }
    public ID? PatientResultsReleaseCategory { get; }
    public CWE? RootCause { get; }
    public ICollection<CWE>? LocalProcessControl { get; }
    public ID? ObservationType { get; }
    public ID? ObservationSubType { get; }
    public ID? ActionCode { get; }
    public CWE? ObservationValueAbsentReason { get; }
    public ICollection<EIP>? ObservationRelatedSpecimenIdentifier { get; }

    public OBX(Segment segment) : base(typeof(OBX), segment) {
        this.SetIDOBX = segment.GetField<SI>(1);
        this.ValueType = segment.GetField<ID>(2);
        this.ObservationIdentifier = segment.GetRequiredField<CWE>(3);
        this.ObservationSubID = segment.GetField<OG>(4);
        this.ObservationValue = segment.GetField<ST>(5);
        this.Units = segment.GetField<CWE>(6);
        this.ReferenceRange = segment.GetField<ST>(7);
        this.InterpretationCodes = segment.GetRepField<CWE>(8);
        this.Probability = segment.GetField<NM>(9);
        this.NatureofAbnormalTest = segment.GetRepField<ID>(10);
        this.ObservationResultStatus = segment.GetRequiredField<ID>(11);
        this.EffectiveDateofReferenceRange = segment.GetField<DTM>(12);
        this.UserDefinedAccessChecks = segment.GetField<ST>(13);
        this.DateTimeoftheObservation = segment.GetField<DTM>(14);
        this.ProducersID = segment.GetField<CWE>(15);
        this.ResponsibleObserver = segment.GetRepField<XCN>(16);
        this.ObservationMethod = segment.GetRepField<CWE>(17);
        this.EquipmentInstanceIdentifier = segment.GetRepField<EI>(18);
        this.DateTimeoftheAnalysis = segment.GetField<DTM>(19);
        this.ObservationSite = segment.GetRepField<CWE>(20);
        this.ObservationInstanceIdentifier = segment.GetField<EI>(21);
        this.MoodCode = segment.GetField<CNE>(22);
        this.PerformingOrganizationName = segment.GetField<XON>(23);
        this.PerformingOrganizationAddress = segment.GetField<XAD>(24);
        this.PerformingOrganizationMedicalDirector = segment.GetField<XCN>(25);
        this.PatientResultsReleaseCategory = segment.GetField<ID>(26);
        this.RootCause = segment.GetField<CWE>(27);
        this.LocalProcessControl = segment.GetRepField<CWE>(28);
        this.ObservationType = segment.GetField<ID>(29);
        this.ObservationSubType = segment.GetField<ID>(30);
        this.ActionCode = segment.GetField<ID>(31);
        this.ObservationValueAbsentReason = segment.GetField<CWE>(32);
        this.ObservationRelatedSpecimenIdentifier = segment.GetRepField<EIP>(33);
    }
}

public sealed record ODS : Hl7Segment {
    public ID Type { get; }
    public CWE? ServicePeriod { get; }
    public CWE DietSupplementorPreferenceCode { get; }
    public ST? TextInstruction { get; }

    public ODS(Segment segment) : base(typeof(ODS), segment) {
        this.Type = segment.GetRequiredField<ID>(1);
        this.ServicePeriod = segment.GetField<CWE>(2);
        this.DietSupplementorPreferenceCode = segment.GetRequiredField<CWE>(3);
        this.TextInstruction = segment.GetField<ST>(4);
    }
}

public sealed record ODT : Hl7Segment {
    public CWE TrayType { get; }
    public CWE? ServicePeriod { get; }
    public ST? TextInstruction { get; }

    public ODT(Segment segment) : base(typeof(ODT), segment) {
        this.TrayType = segment.GetRequiredField<CWE>(1);
        this.ServicePeriod = segment.GetField<CWE>(2);
        this.TextInstruction = segment.GetField<ST>(3);
    }
}

public sealed record OH1 : Hl7Segment {
    public SI SetID { get; }
    public ID? ActionCode { get; }
    public CWE EmploymentStatus { get; }
    public DT? EmploymentStatusStartDate { get; }
    public DT? EmploymentStatusEndDate { get; }
    public DT EnteredDate { get; }
    public EI? EmploymentStatusUniqueIdentifier { get; }

    public OH1(Segment segment) : base(typeof(OH1), segment) {
        this.SetID = segment.GetRequiredField<SI>(1);
        this.ActionCode = segment.GetField<ID>(2);
        this.EmploymentStatus = segment.GetRequiredField<CWE>(3);
        this.EmploymentStatusStartDate = segment.GetField<DT>(4);
        this.EmploymentStatusEndDate = segment.GetField<DT>(5);
        this.EnteredDate = segment.GetRequiredField<DT>(6);
        this.EmploymentStatusUniqueIdentifier = segment.GetField<EI>(7);
    }
}

public sealed record OH2 : Hl7Segment {
    public SI SetID { get; }
    public ID? ActionCode { get; }
    public DT? EnteredDate { get; }
    public CWE Occupation { get; }
    public CWE Industry { get; }
    public CWE? WorkClassification { get; }
    public DT? JobStartDate { get; }
    public DT? JobEndDate { get; }
    public CWE? WorkSchedule { get; }
    public NM? AverageHoursworkedperDay { get; }
    public NM? AverageDaysWorkedperWeek { get; }
    public XON? EmployerOrganization { get; }
    public ICollection<XAD>? EmployerAddress { get; }
    public CWE? SupervisoryLevel { get; }
    public ICollection<ST>? JobDuties { get; }
    public ICollection<FT>? OccupationalHazards { get; }
    public EI? JobUniqueIdentifier { get; }
    public CWE? CurrentJobIndicator { get; }

    public OH2(Segment segment) : base(typeof(OH2), segment) {
        this.SetID = segment.GetRequiredField<SI>(1);
        this.ActionCode = segment.GetField<ID>(2);
        this.EnteredDate = segment.GetField<DT>(3);
        this.Occupation = segment.GetRequiredField<CWE>(4);
        this.Industry = segment.GetRequiredField<CWE>(5);
        this.WorkClassification = segment.GetField<CWE>(6);
        this.JobStartDate = segment.GetField<DT>(7);
        this.JobEndDate = segment.GetField<DT>(8);
        this.WorkSchedule = segment.GetField<CWE>(9);
        this.AverageHoursworkedperDay = segment.GetField<NM>(10);
        this.AverageDaysWorkedperWeek = segment.GetField<NM>(11);
        this.EmployerOrganization = segment.GetField<XON>(12);
        this.EmployerAddress = segment.GetRepField<XAD>(13);
        this.SupervisoryLevel = segment.GetField<CWE>(14);
        this.JobDuties = segment.GetRepField<ST>(15);
        this.OccupationalHazards = segment.GetRepField<FT>(16);
        this.JobUniqueIdentifier = segment.GetField<EI>(17);
        this.CurrentJobIndicator = segment.GetField<CWE>(18);
    }
}

public sealed record OH3 : Hl7Segment {
    public SI SetID { get; }
    public ID? ActionCode { get; }
    public CWE Occupation { get; }
    public CWE Industry { get; }
    public NM? UsualOccupationDurationyears { get; }
    public DT? Startyear { get; }
    public DT? EnteredDate { get; }
    public EI? WorkUniqueIdentifier { get; }

    public OH3(Segment segment) : base(typeof(OH3), segment) {
        this.SetID = segment.GetRequiredField<SI>(1);
        this.ActionCode = segment.GetField<ID>(2);
        this.Occupation = segment.GetRequiredField<CWE>(3);
        this.Industry = segment.GetRequiredField<CWE>(4);
        this.UsualOccupationDurationyears = segment.GetField<NM>(5);
        this.Startyear = segment.GetField<DT>(6);
        this.EnteredDate = segment.GetField<DT>(7);
        this.WorkUniqueIdentifier = segment.GetField<EI>(8);
    }
}

public sealed record OH4 : Hl7Segment {
    public SI SetID { get; }
    public ID? ActionCode { get; }
    public DT CombatZoneStartDate { get; }
    public DT? CombatZoneEndDate { get; }
    public DT? EnteredDate { get; }
    public EI? CombatZoneUniqueIdentifier { get; }

    public OH4(Segment segment) : base(typeof(OH4), segment) {
        this.SetID = segment.GetRequiredField<SI>(1);
        this.ActionCode = segment.GetField<ID>(2);
        this.CombatZoneStartDate = segment.GetRequiredField<DT>(3);
        this.CombatZoneEndDate = segment.GetField<DT>(4);
        this.EnteredDate = segment.GetField<DT>(5);
        this.CombatZoneUniqueIdentifier = segment.GetField<EI>(6);
    }
}

public sealed record OM1 : Hl7Segment {
    public NM SequenceNumberTestObservationMasterFile { get; }
    public CWE ProducersServiceTestObservationID { get; }
    public ICollection<ID>? PermittedDataTypes { get; }
    public ID SpecimenRequired { get; }
    public CWE ProducerID { get; }
    public TX? ObservationDescription { get; }
    public ICollection<CWE>? OtherServiceTestObservationIDsfortheObservation { get; }
    public ICollection<ST>? OtherNames { get; }
    public ST? PreferredReportNamefortheObservation { get; }
    public ST? PreferredShortNameorMnemonicfortheObservation { get; }
    public ST? PreferredLongNamefortheObservation { get; }
    public ID? Orderability { get; }
    public ICollection<CWE>? IdentityofInstrumentUsedtoPerformthisStudy { get; }
    public ICollection<CWE>? CodedRepresentationofMethod { get; }
    public ID? PortableDeviceIndicator { get; }
    public ICollection<CWE>? ObservationProducingDepartmentSection { get; }
    public XTN? TelephoneNumberofSection { get; }
    public CWE NatureofServiceTestObservation { get; }
    public CWE? ReportSubheader { get; }
    public ST? ReportDisplayOrder { get; }
    public DTM? DateTimeStampforAnyChangeinDefinitionfortheObservation { get; }
    public DTM? EffectiveDateTimeofChange { get; }
    public NM? TypicalTurnAroundTime { get; }
    public NM? ProcessingTime { get; }
    public ICollection<ID>? ProcessingPriority { get; }
    public ID? ReportingPriority { get; }
    public ICollection<CWE>? OutsideSitesWhereObservationMayBePerformed { get; }
    public ICollection<XAD>? AddressofOutsideSites { get; }
    public XTN? PhoneNumberofOutsideSite { get; }
    public CWE? ConfidentialityCode { get; }
    public ICollection<CWE>? ObservationsRequiredtoInterpretthisObservation { get; }
    public TX? InterpretationofObservations { get; }
    public ICollection<CWE>? ContraindicationstoObservations { get; }
    public ICollection<CWE>? ReflexTestsObservations { get; }
    public ICollection<TX>? RulesthatTriggerReflexTesting { get; }
    public ICollection<CWE>? FixedCannedMessage { get; }
    public ICollection<TX>? PatientPreparation { get; }
    public CWE? ProcedureMedication { get; }
    public TX? FactorsthatmayAffecttheObservation { get; }
    public ICollection<ST>? ServiceTestObservationPerformanceSchedule { get; }
    public TX? DescriptionofTestMethods { get; }
    public CWE? KindofQuantityObserved { get; }
    public CWE? PointVersusInterval { get; }
    public TX? ChallengeInformation { get; }
    public CWE? RelationshipModifier { get; }
    public CWE? TargetAnatomicSiteOfTest { get; }
    public CWE? ModalityofImagingMeasurement { get; }
    public ID? ExclusiveTest { get; }
    public ID? DiagnosticServSectID { get; }
    public CWE? TaxonomicClassificationCode { get; }
    public ICollection<ST>? OtherNames2 { get; }
    public ICollection<CWE>? ReplacementProducersServiceTestObservationID { get; }
    public ICollection<TX>? PriorResutsInstructions { get; }
    public TX? SpecialInstructions { get; }
    public ICollection<CWE>? TestCategory { get; }
    public CWE? ObservationIdentifierassociatedwithProducersServiceTestObservationID { get; }
    public CQ? TypicalTurnAroundTime2 { get; }
    public ICollection<CWE>? GenderRestriction { get; }
    public ICollection<NR>? AgeRestriction { get; }

    public OM1(Segment segment) : base(typeof(OM1), segment) {
        this.SequenceNumberTestObservationMasterFile = segment.GetRequiredField<NM>(1);
        this.ProducersServiceTestObservationID = segment.GetRequiredField<CWE>(2);
        this.PermittedDataTypes = segment.GetRepField<ID>(3);
        this.SpecimenRequired = segment.GetRequiredField<ID>(4);
        this.ProducerID = segment.GetRequiredField<CWE>(5);
        this.ObservationDescription = segment.GetField<TX>(6);
        this.OtherServiceTestObservationIDsfortheObservation = segment.GetRepField<CWE>(7);
        this.OtherNames = segment.GetRepField<ST>(8);
        this.PreferredReportNamefortheObservation = segment.GetField<ST>(9);
        this.PreferredShortNameorMnemonicfortheObservation = segment.GetField<ST>(10);
        this.PreferredLongNamefortheObservation = segment.GetField<ST>(11);
        this.Orderability = segment.GetField<ID>(12);
        this.IdentityofInstrumentUsedtoPerformthisStudy = segment.GetRepField<CWE>(13);
        this.CodedRepresentationofMethod = segment.GetRepField<CWE>(14);
        this.PortableDeviceIndicator = segment.GetField<ID>(15);
        this.ObservationProducingDepartmentSection = segment.GetRepField<CWE>(16);
        this.TelephoneNumberofSection = segment.GetField<XTN>(17);
        this.NatureofServiceTestObservation = segment.GetRequiredField<CWE>(18);
        this.ReportSubheader = segment.GetField<CWE>(19);
        this.ReportDisplayOrder = segment.GetField<ST>(20);
        this.DateTimeStampforAnyChangeinDefinitionfortheObservation = segment.GetField<DTM>(21);
        this.EffectiveDateTimeofChange = segment.GetField<DTM>(22);
        this.TypicalTurnAroundTime = segment.GetField<NM>(23);
        this.ProcessingTime = segment.GetField<NM>(24);
        this.ProcessingPriority = segment.GetRepField<ID>(25);
        this.ReportingPriority = segment.GetField<ID>(26);
        this.OutsideSitesWhereObservationMayBePerformed = segment.GetRepField<CWE>(27);
        this.AddressofOutsideSites = segment.GetRepField<XAD>(28);
        this.PhoneNumberofOutsideSite = segment.GetField<XTN>(29);
        this.ConfidentialityCode = segment.GetField<CWE>(30);
        this.ObservationsRequiredtoInterpretthisObservation = segment.GetRepField<CWE>(31);
        this.InterpretationofObservations = segment.GetField<TX>(32);
        this.ContraindicationstoObservations = segment.GetRepField<CWE>(33);
        this.ReflexTestsObservations = segment.GetRepField<CWE>(34);
        this.RulesthatTriggerReflexTesting = segment.GetRepField<TX>(35);
        this.FixedCannedMessage = segment.GetRepField<CWE>(36);
        this.PatientPreparation = segment.GetRepField<TX>(37);
        this.ProcedureMedication = segment.GetField<CWE>(38);
        this.FactorsthatmayAffecttheObservation = segment.GetField<TX>(39);
        this.ServiceTestObservationPerformanceSchedule = segment.GetRepField<ST>(40);
        this.DescriptionofTestMethods = segment.GetField<TX>(41);
        this.KindofQuantityObserved = segment.GetField<CWE>(42);
        this.PointVersusInterval = segment.GetField<CWE>(43);
        this.ChallengeInformation = segment.GetField<TX>(44);
        this.RelationshipModifier = segment.GetField<CWE>(45);
        this.TargetAnatomicSiteOfTest = segment.GetField<CWE>(46);
        this.ModalityofImagingMeasurement = segment.GetField<CWE>(47);
        this.ExclusiveTest = segment.GetField<ID>(48);
        this.DiagnosticServSectID = segment.GetField<ID>(49);
        this.TaxonomicClassificationCode = segment.GetField<CWE>(50);
        this.OtherNames2 = segment.GetRepField<ST>(51);
        this.ReplacementProducersServiceTestObservationID = segment.GetRepField<CWE>(52);
        this.PriorResutsInstructions = segment.GetRepField<TX>(53);
        this.SpecialInstructions = segment.GetField<TX>(54);
        this.TestCategory = segment.GetRepField<CWE>(55);
        this.ObservationIdentifierassociatedwithProducersServiceTestObservationID = segment.GetField<CWE>(56);
        this.TypicalTurnAroundTime2 = segment.GetField<CQ>(57);
        this.GenderRestriction = segment.GetRepField<CWE>(58);
        this.AgeRestriction = segment.GetRepField<NR>(59);
    }
}

public sealed record OM2 : Hl7Segment {
    public NM? SequenceNumberTestObservationMasterFile { get; }
    public CWE? UnitsofMeasure { get; }
    public ICollection<NM>? RangeofDecimalPrecision { get; }
    public CWE? CorrespondingSIUnitsofMeasure { get; }
    public TX? SIConversionFactor { get; }
    public ICollection<RFR>? Reference { get; }
    public ICollection<RFR>? CriticalRangeforOrdinalandContinuousObservations { get; }
    public RFR? AbsoluteRangeforOrdinalandContinuousObservations { get; }
    public ICollection<DLT>? DeltaCheckCriteria { get; }
    public NM? MinimumMeaningfulIncrements { get; }

    public OM2(Segment segment) : base(typeof(OM2), segment) {
        this.SequenceNumberTestObservationMasterFile = segment.GetField<NM>(1);
        this.UnitsofMeasure = segment.GetField<CWE>(2);
        this.RangeofDecimalPrecision = segment.GetRepField<NM>(3);
        this.CorrespondingSIUnitsofMeasure = segment.GetField<CWE>(4);
        this.SIConversionFactor = segment.GetField<TX>(5);
        this.Reference = segment.GetRepField<RFR>(6);
        this.CriticalRangeforOrdinalandContinuousObservations = segment.GetRepField<RFR>(7);
        this.AbsoluteRangeforOrdinalandContinuousObservations = segment.GetField<RFR>(8);
        this.DeltaCheckCriteria = segment.GetRepField<DLT>(9);
        this.MinimumMeaningfulIncrements = segment.GetField<NM>(10);
    }
}

public sealed record OM3 : Hl7Segment {
    public NM? SequenceNumberTestObservationMasterFile { get; }
    public CWE? PreferredCodingSystem { get; }
    public ICollection<CWE>? ValidCodedAnswers { get; }
    public ICollection<CWE>? NormalTextCodesforCategoricalObservations { get; }
    public ICollection<CWE>? AbnormalTextCodesforCategoricalObservations { get; }
    public ICollection<CWE>? CriticalTextCodesforCategoricalObservations { get; }
    public ID? ValueType { get; }

    public OM3(Segment segment) : base(typeof(OM3), segment) {
        this.SequenceNumberTestObservationMasterFile = segment.GetField<NM>(1);
        this.PreferredCodingSystem = segment.GetField<CWE>(2);
        this.ValidCodedAnswers = segment.GetRepField<CWE>(3);
        this.NormalTextCodesforCategoricalObservations = segment.GetRepField<CWE>(4);
        this.AbnormalTextCodesforCategoricalObservations = segment.GetRepField<CWE>(5);
        this.CriticalTextCodesforCategoricalObservations = segment.GetRepField<CWE>(6);
        this.ValueType = segment.GetField<ID>(7);
    }
}

public sealed record OM4 : Hl7Segment {
    public NM? SequenceNumberTestObservationMasterFile { get; }
    public ID? DerivedSpecimen { get; }
    public ICollection<TX>? ContainerDescription { get; }
    public ICollection<NM>? ContainerVolume { get; }
    public ICollection<CWE>? ContainerUnits { get; }
    public CWE? Specimen { get; }
    public CWE? Additive { get; }
    public TX? Preparation { get; }
    public TX? SpecialHandlingRequirements { get; }
    public CQ? NormalCollectionVolume { get; }
    public CQ? MinimumCollectionVolume { get; }
    public TX? SpecimenRequirements { get; }
    public ICollection<ID>? SpecimenPriorities { get; }
    public CQ? SpecimenRetentionTime { get; }
    public ICollection<CWE>? SpecimenHandlingCode { get; }
    public ID? SpecimenPreference { get; }
    public NM? PreferredSpecimenAttribtureSequenceID { get; }
    public ICollection<CWE>? TaxonomicClassificationCode { get; }

    public OM4(Segment segment) : base(typeof(OM4), segment) {
        this.SequenceNumberTestObservationMasterFile = segment.GetField<NM>(1);
        this.DerivedSpecimen = segment.GetField<ID>(2);
        this.ContainerDescription = segment.GetRepField<TX>(3);
        this.ContainerVolume = segment.GetRepField<NM>(4);
        this.ContainerUnits = segment.GetRepField<CWE>(5);
        this.Specimen = segment.GetField<CWE>(6);
        this.Additive = segment.GetField<CWE>(7);
        this.Preparation = segment.GetField<TX>(8);
        this.SpecialHandlingRequirements = segment.GetField<TX>(9);
        this.NormalCollectionVolume = segment.GetField<CQ>(10);
        this.MinimumCollectionVolume = segment.GetField<CQ>(11);
        this.SpecimenRequirements = segment.GetField<TX>(12);
        this.SpecimenPriorities = segment.GetRepField<ID>(13);
        this.SpecimenRetentionTime = segment.GetField<CQ>(14);
        this.SpecimenHandlingCode = segment.GetRepField<CWE>(15);
        this.SpecimenPreference = segment.GetField<ID>(16);
        this.PreferredSpecimenAttribtureSequenceID = segment.GetField<NM>(17);
        this.TaxonomicClassificationCode = segment.GetRepField<CWE>(18);
    }
}

public sealed record OM5 : Hl7Segment {
    public NM? SequenceNumberTestObservationMasterFile { get; }
    public ICollection<CWE>? TestObservationsIncludedWithinanOrderedTestBattery { get; }
    public ST? ObservationIDSuffixes { get; }

    public OM5(Segment segment) : base(typeof(OM5), segment) {
        this.SequenceNumberTestObservationMasterFile = segment.GetField<NM>(1);
        this.TestObservationsIncludedWithinanOrderedTestBattery = segment.GetRepField<CWE>(2);
        this.ObservationIDSuffixes = segment.GetField<ST>(3);
    }
}

public sealed record OM6 : Hl7Segment {
    public NM? SequenceNumberTestObservationMasterFile { get; }
    public TX? DerivationRule { get; }

    public OM6(Segment segment) : base(typeof(OM6), segment) {
        this.SequenceNumberTestObservationMasterFile = segment.GetField<NM>(1);
        this.DerivationRule = segment.GetField<TX>(2);
    }
}

public sealed record OM7 : Hl7Segment {
    public NM SequenceNumberTestObservationMasterFile { get; }
    public CWE UniversalServiceIdentifier { get; }
    public ICollection<CWE>? CategoryIdentifier { get; }
    public TX? CategoryDescription { get; }
    public ICollection<ST>? CategorySynonym { get; }
    public DTM? EffectiveTestServiceStartDateTime { get; }
    public DTM? EffectiveTestServiceEndDateTime { get; }
    public NM? TestServiceDefaultDurationQuantity { get; }
    public CWE? TestServiceDefaultDurationUnits { get; }
    public CWE? TestServiceDefaultFrequency { get; }
    public ID? ConsentIndicator { get; }
    public CWE? ConsentIdentifier { get; }
    public DTM? ConsentEffectiveStartDateTime { get; }
    public DTM? ConsentEffectiveEndDateTime { get; }
    public NM? ConsentIntervalQuantity { get; }
    public CWE? ConsentIntervalUnits { get; }
    public NM? ConsentWaitingPeriodQuantity { get; }
    public CWE? ConsentWaitingPeriodUnits { get; }
    public DTM? EffectiveDateTimeofChange { get; }
    public XCN? EnteredBy { get; }
    public ICollection<PL>? OrderableatLocation { get; }
    public CWE? FormularyStatus { get; }
    public ID? SpecialOrderIndicator { get; }
    public ICollection<CWE>? PrimaryKeyValueCDM { get; }

    public OM7(Segment segment) : base(typeof(OM7), segment) {
        this.SequenceNumberTestObservationMasterFile = segment.GetRequiredField<NM>(1);
        this.UniversalServiceIdentifier = segment.GetRequiredField<CWE>(2);
        this.CategoryIdentifier = segment.GetRepField<CWE>(3);
        this.CategoryDescription = segment.GetField<TX>(4);
        this.CategorySynonym = segment.GetRepField<ST>(5);
        this.EffectiveTestServiceStartDateTime = segment.GetField<DTM>(6);
        this.EffectiveTestServiceEndDateTime = segment.GetField<DTM>(7);
        this.TestServiceDefaultDurationQuantity = segment.GetField<NM>(8);
        this.TestServiceDefaultDurationUnits = segment.GetField<CWE>(9);
        this.TestServiceDefaultFrequency = segment.GetField<CWE>(10);
        this.ConsentIndicator = segment.GetField<ID>(11);
        this.ConsentIdentifier = segment.GetField<CWE>(12);
        this.ConsentEffectiveStartDateTime = segment.GetField<DTM>(13);
        this.ConsentEffectiveEndDateTime = segment.GetField<DTM>(14);
        this.ConsentIntervalQuantity = segment.GetField<NM>(15);
        this.ConsentIntervalUnits = segment.GetField<CWE>(16);
        this.ConsentWaitingPeriodQuantity = segment.GetField<NM>(17);
        this.ConsentWaitingPeriodUnits = segment.GetField<CWE>(18);
        this.EffectiveDateTimeofChange = segment.GetField<DTM>(19);
        this.EnteredBy = segment.GetField<XCN>(20);
        this.OrderableatLocation = segment.GetRepField<PL>(21);
        this.FormularyStatus = segment.GetField<CWE>(22);
        this.SpecialOrderIndicator = segment.GetField<ID>(23);
        this.PrimaryKeyValueCDM = segment.GetRepField<CWE>(24);
    }
}

public sealed record OMC : Hl7Segment {
    public NM? SequenceNumberTestObservationMasterFile { get; }
    public ID? SegmentActionCode { get; }
    public EI? SegmentUniqueKey { get; }
    public CWE ClinicalInformationRequest { get; }
    public ICollection<CWE> CollectionEventProcessStep { get; }
    public CWE CommunicationLocation { get; }
    public ID? AnswerRequired { get; }
    public ST? HintHelpText { get; }
    public ID? TypeofAnswer { get; }
    public ID? MultipleAnswersAllowed { get; }
    public ICollection<CWE>? AnswerChoices { get; }
    public NM? CharacterLimit { get; }
    public NM? NumberofDecimals { get; }

    public OMC(Segment segment) : base(typeof(OMC), segment) {
        this.SequenceNumberTestObservationMasterFile = segment.GetField<NM>(1);
        this.SegmentActionCode = segment.GetField<ID>(2);
        this.SegmentUniqueKey = segment.GetField<EI>(3);
        this.ClinicalInformationRequest = segment.GetRequiredField<CWE>(4);
        this.CollectionEventProcessStep = segment.GetRequiredRepField<CWE>(5);
        this.CommunicationLocation = segment.GetRequiredField<CWE>(6);
        this.AnswerRequired = segment.GetField<ID>(7);
        this.HintHelpText = segment.GetField<ST>(8);
        this.TypeofAnswer = segment.GetField<ID>(9);
        this.MultipleAnswersAllowed = segment.GetField<ID>(10);
        this.AnswerChoices = segment.GetRepField<CWE>(11);
        this.CharacterLimit = segment.GetField<NM>(12);
        this.NumberofDecimals = segment.GetField<NM>(13);
    }
}

public sealed record ORC : Hl7Segment {
    public ID OrderControl { get; }
    public EI? PlacerOrderNumber { get; }
    public EI? FillerOrderNumber { get; }
    public EI? PlacerOrderGroupNumber { get; }
    public ID? OrderStatus { get; }
    public ID? ResponseFlag { get; }
    public ST? QuantityTiming { get; }
    public ICollection<EIP>? ParentOrder { get; }
    public DTM? DateTimeofOrderEvent { get; }
    public XCN? EnteredBy { get; }
    public ST? VerifiedBy { get; }
    public ST? OrderingProvider { get; }
    public PL? EnterersLocation { get; }
    public XTN? CallBackPhoneNumber { get; }
    public DTM? OrderEffectiveDateTime { get; }
    public CWE? OrderControlCodeReason { get; }
    public ST? EnteringOrganization { get; }
    public ST? EnteringDevice { get; }
    public ST? ActionBy { get; }
    public CWE? AdvancedBeneficiaryNoticeCode { get; }
    public ST? OrderingFacilityName { get; }
    public ST? OrderingFacilityAddress { get; }
    public ST? OrderingFacilityPhoneNumber { get; }
    public ST? OrderingProviderAddress { get; }
    public CWE? OrderStatusModifier { get; }
    public CWE? AdvancedBeneficiaryNoticeOverrideReason { get; }
    public DTM? FillersExpectedAvailabilityDateTime { get; }
    public CWE? ConfidentialityCode { get; }
    public CWE? OrderType { get; }
    public CNE? EntererAuthorizationMode { get; }
    public ST? ParentUniversalServiceIdentifier { get; }
    public DT? AdvancedBeneficiaryNoticeDate { get; }
    public ICollection<CX>? AlternatePlacerOrderNumber { get; }
    public ICollection<CWE>? OrderWorkflowProfile { get; }
    public ID? ActionCode { get; }
    public DR? OrderStatusDateRange { get; }
    public DTM? OrderCreationDateTime { get; }
    public EI? FillerOrderGroupNumber { get; }

    public ORC(Segment segment) : base(typeof(ORC), segment) {
        this.OrderControl = segment.GetRequiredField<ID>(1);
        this.PlacerOrderNumber = segment.GetField<EI>(2);
        this.FillerOrderNumber = segment.GetField<EI>(3);
        this.PlacerOrderGroupNumber = segment.GetField<EI>(4);
        this.OrderStatus = segment.GetField<ID>(5);
        this.ResponseFlag = segment.GetField<ID>(6);
        this.QuantityTiming = segment.GetField<ST>(7);
        this.ParentOrder = segment.GetRepField<EIP>(8);
        this.DateTimeofOrderEvent = segment.GetField<DTM>(9);
        this.EnteredBy = segment.GetField<XCN>(10);
        this.VerifiedBy = segment.GetField<ST>(11);
        this.OrderingProvider = segment.GetField<ST>(12);
        this.EnterersLocation = segment.GetField<PL>(13);
        this.CallBackPhoneNumber = segment.GetField<XTN>(14);
        this.OrderEffectiveDateTime = segment.GetField<DTM>(15);
        this.OrderControlCodeReason = segment.GetField<CWE>(16);
        this.EnteringOrganization = segment.GetField<ST>(17);
        this.EnteringDevice = segment.GetField<ST>(18);
        this.ActionBy = segment.GetField<ST>(19);
        this.AdvancedBeneficiaryNoticeCode = segment.GetField<CWE>(20);
        this.OrderingFacilityName = segment.GetField<ST>(21);
        this.OrderingFacilityAddress = segment.GetField<ST>(22);
        this.OrderingFacilityPhoneNumber = segment.GetField<ST>(23);
        this.OrderingProviderAddress = segment.GetField<ST>(24);
        this.OrderStatusModifier = segment.GetField<CWE>(25);
        this.AdvancedBeneficiaryNoticeOverrideReason = segment.GetField<CWE>(26);
        this.FillersExpectedAvailabilityDateTime = segment.GetField<DTM>(27);
        this.ConfidentialityCode = segment.GetField<CWE>(28);
        this.OrderType = segment.GetField<CWE>(29);
        this.EntererAuthorizationMode = segment.GetField<CNE>(30);
        this.ParentUniversalServiceIdentifier = segment.GetField<ST>(31);
        this.AdvancedBeneficiaryNoticeDate = segment.GetField<DT>(32);
        this.AlternatePlacerOrderNumber = segment.GetRepField<CX>(33);
        this.OrderWorkflowProfile = segment.GetRepField<CWE>(34);
        this.ActionCode = segment.GetField<ID>(35);
        this.OrderStatusDateRange = segment.GetField<DR>(36);
        this.OrderCreationDateTime = segment.GetField<DTM>(37);
        this.FillerOrderGroupNumber = segment.GetField<EI>(38);
    }
}

public sealed record ORG : Hl7Segment {
    public SI SetIDORG { get; }
    public CWE? OrganizationUnitCode { get; }
    public CWE? OrganizationUnitTypeCode { get; }
    public ID? PrimaryOrgUnitIndicator { get; }
    public CX? PractitionerOrgUnitIdentifier { get; }
    public CWE? HealthCareProviderTypeCode { get; }
    public CWE? HealthCareProviderClassificationCode { get; }
    public CWE? HealthCareProviderAreaofSpecializationCode { get; }
    public DR? EffectiveDateRange { get; }
    public CWE? EmploymentStatusCode { get; }
    public ID? BoardApprovalIndicator { get; }
    public ID? PrimaryCarePhysicianIndicator { get; }
    public ICollection<CWE>? CostCenterCode { get; }

    public ORG(Segment segment) : base(typeof(ORG), segment) {
        this.SetIDORG = segment.GetRequiredField<SI>(1);
        this.OrganizationUnitCode = segment.GetField<CWE>(2);
        this.OrganizationUnitTypeCode = segment.GetField<CWE>(3);
        this.PrimaryOrgUnitIndicator = segment.GetField<ID>(4);
        this.PractitionerOrgUnitIdentifier = segment.GetField<CX>(5);
        this.HealthCareProviderTypeCode = segment.GetField<CWE>(6);
        this.HealthCareProviderClassificationCode = segment.GetField<CWE>(7);
        this.HealthCareProviderAreaofSpecializationCode = segment.GetField<CWE>(8);
        this.EffectiveDateRange = segment.GetField<DR>(9);
        this.EmploymentStatusCode = segment.GetField<CWE>(10);
        this.BoardApprovalIndicator = segment.GetField<ID>(11);
        this.PrimaryCarePhysicianIndicator = segment.GetField<ID>(12);
        this.CostCenterCode = segment.GetRepField<CWE>(13);
    }
}

public sealed record OVR : Hl7Segment {
    public CWE? BusinessRuleOverrideType { get; }
    public CWE? BusinessRuleOverrideCode { get; }
    public TX? OverrideComments { get; }
    public XCN? OverrideEnteredBy { get; }
    public XCN? OverrideAuthorizedBy { get; }

    public OVR(Segment segment) : base(typeof(OVR), segment) {
        this.BusinessRuleOverrideType = segment.GetField<CWE>(1);
        this.BusinessRuleOverrideCode = segment.GetField<CWE>(2);
        this.OverrideComments = segment.GetField<TX>(3);
        this.OverrideEnteredBy = segment.GetField<XCN>(4);
        this.OverrideAuthorizedBy = segment.GetField<XCN>(5);
    }
}

public sealed record PAC : Hl7Segment {
    public SI SetIdPAC { get; }
    public EI? PackageID { get; }
    public EI? ParentPackageID { get; }
    public NA? PositioninParentPackage { get; }
    public CWE PackageType { get; }
    public ICollection<CWE>? PackageCondition { get; }
    public ICollection<CWE>? PackageHandlingCode { get; }
    public ICollection<CWE>? PackageRiskCode { get; }
    public ID? ActionCode { get; }

    public PAC(Segment segment) : base(typeof(PAC), segment) {
        this.SetIdPAC = segment.GetRequiredField<SI>(1);
        this.PackageID = segment.GetField<EI>(2);
        this.ParentPackageID = segment.GetField<EI>(3);
        this.PositioninParentPackage = segment.GetField<NA>(4);
        this.PackageType = segment.GetRequiredField<CWE>(5);
        this.PackageCondition = segment.GetRepField<CWE>(6);
        this.PackageHandlingCode = segment.GetRepField<CWE>(7);
        this.PackageRiskCode = segment.GetRepField<CWE>(8);
        this.ActionCode = segment.GetField<ID>(9);
    }
}

public sealed record PCE : Hl7Segment {
    public SI SetIDPCE { get; }
    public CX? CostCenterAccountNumber { get; }
    public CWE? TransactionCode { get; }
    public CP? TransactionAmountUnit { get; }

    public PCE(Segment segment) : base(typeof(PCE), segment) {
        this.SetIDPCE = segment.GetRequiredField<SI>(1);
        this.CostCenterAccountNumber = segment.GetField<CX>(2);
        this.TransactionCode = segment.GetField<CWE>(3);
        this.TransactionAmountUnit = segment.GetField<CP>(4);
    }
}

public sealed record PCR : Hl7Segment {
    public CWE ImplicatedProduct { get; }
    public IS? GenericProduct { get; }
    public CWE? ProductClass { get; }
    public CQ? TotalDurationOfTherapy { get; }
    public DTM? ProductManufactureDate { get; }
    public DTM? ProductExpirationDate { get; }
    public DTM? ProductImplantationDate { get; }
    public DTM? ProductExplantationDate { get; }
    public CWE? SingleUseDevice { get; }
    public CWE? IndicationForProductUse { get; }
    public CWE? ProductProblem { get; }
    public ST? ProductSerialLotNumber { get; }
    public CWE? ProductAvailableForInspection { get; }
    public CWE? ProductEvaluationPerformed { get; }
    public CWE? ProductEvaluationStatus { get; }
    public CWE? ProductEvaluationResults { get; }
    public ID? EvaluatedProductSource { get; }
    public DTM? DateProductReturnedToManufacturer { get; }
    public ID? DeviceOperatorQualifications { get; }
    public ID? RelatednessAssessment { get; }
    public ID? ActionTakenInResponseToTheEvent { get; }
    public ID? EventCausalityObservations { get; }
    public ID? IndirectExposureMechanism { get; }

    public PCR(Segment segment) : base(typeof(PCR), segment) {
        this.ImplicatedProduct = segment.GetRequiredField<CWE>(1);
        this.GenericProduct = segment.GetField<IS>(2);
        this.ProductClass = segment.GetField<CWE>(3);
        this.TotalDurationOfTherapy = segment.GetField<CQ>(4);
        this.ProductManufactureDate = segment.GetField<DTM>(5);
        this.ProductExpirationDate = segment.GetField<DTM>(6);
        this.ProductImplantationDate = segment.GetField<DTM>(7);
        this.ProductExplantationDate = segment.GetField<DTM>(8);
        this.SingleUseDevice = segment.GetField<CWE>(9);
        this.IndicationForProductUse = segment.GetField<CWE>(10);
        this.ProductProblem = segment.GetField<CWE>(11);
        this.ProductSerialLotNumber = segment.GetField<ST>(12);
        this.ProductAvailableForInspection = segment.GetField<CWE>(13);
        this.ProductEvaluationPerformed = segment.GetField<CWE>(14);
        this.ProductEvaluationStatus = segment.GetField<CWE>(15);
        this.ProductEvaluationResults = segment.GetField<CWE>(16);
        this.EvaluatedProductSource = segment.GetField<ID>(17);
        this.DateProductReturnedToManufacturer = segment.GetField<DTM>(18);
        this.DeviceOperatorQualifications = segment.GetField<ID>(19);
        this.RelatednessAssessment = segment.GetField<ID>(20);
        this.ActionTakenInResponseToTheEvent = segment.GetField<ID>(21);
        this.EventCausalityObservations = segment.GetField<ID>(22);
        this.IndirectExposureMechanism = segment.GetField<ID>(23);
    }
}

public sealed record PD1 : Hl7Segment {
    public ICollection<CWE>? LivingDependency { get; }
    public CWE? LivingArrangement { get; }
    public ICollection<XON>? PatientPrimaryFacility { get; }
    public ST? PatientPrimaryCareProviderNameIDNo { get; }
    public CWE? StudentIndicator { get; }
    public CWE? Handicap { get; }
    public CWE? LivingWillCode { get; }
    public CWE? OrganDonorCode { get; }
    public ID? SeparateBill { get; }
    public ICollection<CX>? DuplicatePatient { get; }
    public CWE? PublicityCode { get; }
    public ID? ProtectionIndicator { get; }
    public DT? ProtectionIndicatorEffectiveDate { get; }
    public ICollection<XON>? PlaceofWorship { get; }
    public CWE? AdvanceDirectiveCode { get; }
    public CWE? ImmunizationRegistryStatus { get; }
    public DT? ImmunizationRegistryStatusEffectiveDate { get; }
    public DT? PublicityCodeEffectiveDate { get; }
    public CWE? MilitaryBranch { get; }
    public CWE? MilitaryRankGrade { get; }
    public CWE? MilitaryStatus { get; }
    public DT? AdvanceDirectiveLastVerifiedDate { get; }
    public DT? RetirementDate { get; }

    public PD1(Segment segment) : base(typeof(PD1), segment) {
        this.LivingDependency = segment.GetRepField<CWE>(1);
        this.LivingArrangement = segment.GetField<CWE>(2);
        this.PatientPrimaryFacility = segment.GetRepField<XON>(3);
        this.PatientPrimaryCareProviderNameIDNo = segment.GetField<ST>(4);
        this.StudentIndicator = segment.GetField<CWE>(5);
        this.Handicap = segment.GetField<CWE>(6);
        this.LivingWillCode = segment.GetField<CWE>(7);
        this.OrganDonorCode = segment.GetField<CWE>(8);
        this.SeparateBill = segment.GetField<ID>(9);
        this.DuplicatePatient = segment.GetRepField<CX>(10);
        this.PublicityCode = segment.GetField<CWE>(11);
        this.ProtectionIndicator = segment.GetField<ID>(12);
        this.ProtectionIndicatorEffectiveDate = segment.GetField<DT>(13);
        this.PlaceofWorship = segment.GetRepField<XON>(14);
        this.AdvanceDirectiveCode = segment.GetField<CWE>(15);
        this.ImmunizationRegistryStatus = segment.GetField<CWE>(16);
        this.ImmunizationRegistryStatusEffectiveDate = segment.GetField<DT>(17);
        this.PublicityCodeEffectiveDate = segment.GetField<DT>(18);
        this.MilitaryBranch = segment.GetField<CWE>(19);
        this.MilitaryRankGrade = segment.GetField<CWE>(20);
        this.MilitaryStatus = segment.GetField<CWE>(21);
        this.AdvanceDirectiveLastVerifiedDate = segment.GetField<DT>(22);
        this.RetirementDate = segment.GetField<DT>(23);
    }
}

public sealed record PDA : Hl7Segment {
    public ICollection<CWE>? DeathCauseCode { get; }
    public PL? DeathLocation { get; }
    public ID? DeathCertifiedIndicator { get; }
    public DTM? DeathCertificateSignedDateTime { get; }
    public XCN? DeathCertifiedBy { get; }
    public ID? AutopsyIndicator { get; }
    public DR? AutopsyStartandEndDateTime { get; }
    public XCN? AutopsyPerformedBy { get; }
    public ID? CoronerIndicator { get; }

    public PDA(Segment segment) : base(typeof(PDA), segment) {
        this.DeathCauseCode = segment.GetRepField<CWE>(1);
        this.DeathLocation = segment.GetField<PL>(2);
        this.DeathCertifiedIndicator = segment.GetField<ID>(3);
        this.DeathCertificateSignedDateTime = segment.GetField<DTM>(4);
        this.DeathCertifiedBy = segment.GetField<XCN>(5);
        this.AutopsyIndicator = segment.GetField<ID>(6);
        this.AutopsyStartandEndDateTime = segment.GetField<DR>(7);
        this.AutopsyPerformedBy = segment.GetField<XCN>(8);
        this.CoronerIndicator = segment.GetField<ID>(9);
    }
}

public sealed record PDC : Hl7Segment {
    public ICollection<XON> ManufacturerDistributor { get; }
    public CWE Country { get; }
    public ST BrandName { get; }
    public ST? DeviceFamilyName { get; }
    public CWE? GenericName { get; }
    public ICollection<ST>? ModelIdentifier { get; }
    public ST? CatalogueIdentifier { get; }
    public ICollection<ST>? OtherIdentifier { get; }
    public CWE? ProductCode { get; }
    public ID? MarketingBasis { get; }
    public ST? MarketingApprovalID { get; }
    public CQ? LabeledShelfLife { get; }
    public CQ? ExpectedShelfLife { get; }
    public DTM? DateFirstMarketed { get; }
    public DTM? DateLastMarketed { get; }

    public PDC(Segment segment) : base(typeof(PDC), segment) {
        this.ManufacturerDistributor = segment.GetRequiredRepField<XON>(1);
        this.Country = segment.GetRequiredField<CWE>(2);
        this.BrandName = segment.GetRequiredField<ST>(3);
        this.DeviceFamilyName = segment.GetField<ST>(4);
        this.GenericName = segment.GetField<CWE>(5);
        this.ModelIdentifier = segment.GetRepField<ST>(6);
        this.CatalogueIdentifier = segment.GetField<ST>(7);
        this.OtherIdentifier = segment.GetRepField<ST>(8);
        this.ProductCode = segment.GetField<CWE>(9);
        this.MarketingBasis = segment.GetField<ID>(10);
        this.MarketingApprovalID = segment.GetField<ST>(11);
        this.LabeledShelfLife = segment.GetField<CQ>(12);
        this.ExpectedShelfLife = segment.GetField<CQ>(13);
        this.DateFirstMarketed = segment.GetField<DTM>(14);
        this.DateLastMarketed = segment.GetField<DTM>(15);
    }
}

public sealed record PEO : Hl7Segment {
    public ICollection<CWE>? EventIdentifiersUsed { get; }
    public ICollection<CWE>? EventSymptomDiagnosisCode { get; }
    public DTM EventOnsetDateTime { get; }
    public DTM? EventExacerbationDateTime { get; }
    public DTM? EventImprovedDateTime { get; }
    public DTM? EventEndedDataTime { get; }
    public ICollection<XAD>? EventLocationOccurredAddress { get; }
    public ICollection<ID>? EventQualification { get; }
    public ID? EventSerious { get; }
    public ID? EventExpected { get; }
    public ICollection<ID>? EventOutcome { get; }
    public ID? PatientOutcome { get; }
    public ICollection<FT>? EventDescriptionfromOthers { get; }
    public ICollection<FT>? EventDescriptionfromOriginalReporter { get; }
    public ICollection<FT>? EventDescriptionfromPatient { get; }
    public ICollection<FT>? EventDescriptionfromPractitioner { get; }
    public ICollection<FT>? EventDescriptionfromAutopsy { get; }
    public ICollection<CWE>? CauseOfDeath { get; }
    public ICollection<XPN>? PrimaryObserverName { get; }
    public ICollection<XAD>? PrimaryObserverAddress { get; }
    public ICollection<XTN>? PrimaryObserverTelephone { get; }
    public ID? PrimaryObserversQualification { get; }
    public ID? ConfirmationProvidedBy { get; }
    public DTM? PrimaryObserverAwareDateTime { get; }
    public ID? PrimaryObserversidentityMayBeDivulged { get; }

    public PEO(Segment segment) : base(typeof(PEO), segment) {
        this.EventIdentifiersUsed = segment.GetRepField<CWE>(1);
        this.EventSymptomDiagnosisCode = segment.GetRepField<CWE>(2);
        this.EventOnsetDateTime = segment.GetRequiredField<DTM>(3);
        this.EventExacerbationDateTime = segment.GetField<DTM>(4);
        this.EventImprovedDateTime = segment.GetField<DTM>(5);
        this.EventEndedDataTime = segment.GetField<DTM>(6);
        this.EventLocationOccurredAddress = segment.GetRepField<XAD>(7);
        this.EventQualification = segment.GetRepField<ID>(8);
        this.EventSerious = segment.GetField<ID>(9);
        this.EventExpected = segment.GetField<ID>(10);
        this.EventOutcome = segment.GetRepField<ID>(11);
        this.PatientOutcome = segment.GetField<ID>(12);
        this.EventDescriptionfromOthers = segment.GetRepField<FT>(13);
        this.EventDescriptionfromOriginalReporter = segment.GetRepField<FT>(14);
        this.EventDescriptionfromPatient = segment.GetRepField<FT>(15);
        this.EventDescriptionfromPractitioner = segment.GetRepField<FT>(16);
        this.EventDescriptionfromAutopsy = segment.GetRepField<FT>(17);
        this.CauseOfDeath = segment.GetRepField<CWE>(18);
        this.PrimaryObserverName = segment.GetRepField<XPN>(19);
        this.PrimaryObserverAddress = segment.GetRepField<XAD>(20);
        this.PrimaryObserverTelephone = segment.GetRepField<XTN>(21);
        this.PrimaryObserversQualification = segment.GetField<ID>(22);
        this.ConfirmationProvidedBy = segment.GetField<ID>(23);
        this.PrimaryObserverAwareDateTime = segment.GetField<DTM>(24);
        this.PrimaryObserversidentityMayBeDivulged = segment.GetField<ID>(25);
    }
}

public sealed record PES : Hl7Segment {
    public ICollection<XON>? SenderOrganizationName { get; }
    public ICollection<XCN>? SenderIndividualName { get; }
    public ICollection<XAD>? SenderAddress { get; }
    public ICollection<XTN>? SenderTelephone { get; }
    public EI? SenderEventIdentifier { get; }
    public NM? SenderSequenceNumber { get; }
    public ICollection<FT>? SenderEventDescription { get; }
    public FT? SenderComment { get; }
    public DTM? SenderAwareDateTime { get; }
    public DTM EventReportDate { get; }
    public ID? EventReportTimingType { get; }
    public ID? EventReportSource { get; }
    public ICollection<ID>? EventReportedTo { get; }

    public PES(Segment segment) : base(typeof(PES), segment) {
        this.SenderOrganizationName = segment.GetRepField<XON>(1);
        this.SenderIndividualName = segment.GetRepField<XCN>(2);
        this.SenderAddress = segment.GetRepField<XAD>(3);
        this.SenderTelephone = segment.GetRepField<XTN>(4);
        this.SenderEventIdentifier = segment.GetField<EI>(5);
        this.SenderSequenceNumber = segment.GetField<NM>(6);
        this.SenderEventDescription = segment.GetRepField<FT>(7);
        this.SenderComment = segment.GetField<FT>(8);
        this.SenderAwareDateTime = segment.GetField<DTM>(9);
        this.EventReportDate = segment.GetRequiredField<DTM>(10);
        this.EventReportTimingType = segment.GetField<ID>(11);
        this.EventReportSource = segment.GetField<ID>(12);
        this.EventReportedTo = segment.GetRepField<ID>(13);
    }
}

public sealed record PID : Hl7Segment {
    public SI? SetIDPID { get; }
    public ST? PatientID { get; }
    public ICollection<CX> PatientIdentifierList { get; }
    public ST? AlternatePatientIDPID { get; }
    public ICollection<XPN> PatientName { get; }
    public ICollection<XPN>? MothersMaidenName { get; }
    public DTM? DateTimeofBirth { get; }
    public CWE? AdministrativeSex { get; }
    public ST? PatientAlias { get; }
    public ICollection<CWE>? Race { get; }
    public ICollection<XAD>? PatientAddress { get; }
    public ST? CountyCode { get; }
    public XTN? PhoneNumberHome { get; }
    public XTN? PhoneNumberBusiness { get; }
    public CWE? PrimaryLanguage { get; }
    public CWE? MaritalStatus { get; }
    public CWE? Religion { get; }
    public CX? PatientAccountNumber { get; }
    public ST? SSNNumberPatient { get; }
    public ST? DriversLicenseNumberPatient { get; }
    public ICollection<CX>? MothersIdentifier { get; }
    public ICollection<CWE>? EthnicGroup { get; }
    public ST? BirthPlace { get; }
    public ID? MultipleBirthIndicator { get; }
    public NM? BirthOrder { get; }
    public ICollection<CWE>? Citizenship { get; }
    public CWE? VeteransMilitaryStatus { get; }
    public CWE? Nationality { get; }
    public DTM? PatientDeathDateandTime { get; }
    public ID? PatientDeathIndicator { get; }
    public ID? IdentityUnknownIndicator { get; }
    public ICollection<CWE>? IdentityReliabilityCode { get; }
    public DTM? LastUpdateDateTime { get; }
    public HD? LastUpdateFacility { get; }
    public CWE? TaxonomicClassificationCode { get; }
    public CWE? BreedCode { get; }
    public ST? Strain { get; }
    public CWE? ProductionClassCode { get; }
    public ICollection<CWE>? TribalCitizenship { get; }
    public ICollection<XTN>? PatientTelecommunicationInformation { get; }

    public PID(Segment segment) : base(typeof(PID), segment) {
        this.SetIDPID = segment.GetField<SI>(1);
        this.PatientID = segment.GetField<ST>(2);
        this.PatientIdentifierList = segment.GetRequiredRepField<CX>(3);
        this.AlternatePatientIDPID = segment.GetField<ST>(4);
        this.PatientName = segment.GetRequiredRepField<XPN>(5);
        this.MothersMaidenName = segment.GetRepField<XPN>(6);
        this.DateTimeofBirth = segment.GetField<DTM>(7);
        this.AdministrativeSex = segment.GetField<CWE>(8);
        this.PatientAlias = segment.GetField<ST>(9);
        this.Race = segment.GetRepField<CWE>(10);
        this.PatientAddress = segment.GetRepField<XAD>(11);
        this.CountyCode = segment.GetField<ST>(12);
        this.PhoneNumberHome = segment.GetField<XTN>(13);
        this.PhoneNumberBusiness = segment.GetField<XTN>(14);
        this.PrimaryLanguage = segment.GetField<CWE>(15);
        this.MaritalStatus = segment.GetField<CWE>(16);
        this.Religion = segment.GetField<CWE>(17);
        this.PatientAccountNumber = segment.GetField<CX>(18);
        this.SSNNumberPatient = segment.GetField<ST>(19);
        this.DriversLicenseNumberPatient = segment.GetField<ST>(20);
        this.MothersIdentifier = segment.GetRepField<CX>(21);
        this.EthnicGroup = segment.GetRepField<CWE>(22);
        this.BirthPlace = segment.GetField<ST>(23);
        this.MultipleBirthIndicator = segment.GetField<ID>(24);
        this.BirthOrder = segment.GetField<NM>(25);
        this.Citizenship = segment.GetRepField<CWE>(26);
        this.VeteransMilitaryStatus = segment.GetField<CWE>(27);
        this.Nationality = segment.GetField<CWE>(28);
        this.PatientDeathDateandTime = segment.GetField<DTM>(29);
        this.PatientDeathIndicator = segment.GetField<ID>(30);
        this.IdentityUnknownIndicator = segment.GetField<ID>(31);
        this.IdentityReliabilityCode = segment.GetRepField<CWE>(32);
        this.LastUpdateDateTime = segment.GetField<DTM>(33);
        this.LastUpdateFacility = segment.GetField<HD>(34);
        this.TaxonomicClassificationCode = segment.GetField<CWE>(35);
        this.BreedCode = segment.GetField<CWE>(36);
        this.Strain = segment.GetField<ST>(37);
        this.ProductionClassCode = segment.GetField<CWE>(38);
        this.TribalCitizenship = segment.GetRepField<CWE>(39);
        this.PatientTelecommunicationInformation = segment.GetRepField<XTN>(40);
    }
}

public sealed record PKG : Hl7Segment {
    public SI SetIdPKG { get; }
    public CWE? PackagingUnits { get; }
    public CNE? DefaultOrderUnitOfMeasureIndicator { get; }
    public NM? PackageQuantity { get; }
    public CP? Price { get; }
    public CP? FutureItemPrice { get; }
    public DTM? FutureItemPriceEffectiveDate { get; }
    public CWE? GlobalTradeItemNumber { get; }
    public MO? ContractPrice { get; }
    public NM? QuantityofEach { get; }
    public EI? VendorCatalogNumber { get; }

    public PKG(Segment segment) : base(typeof(PKG), segment) {
        this.SetIdPKG = segment.GetRequiredField<SI>(1);
        this.PackagingUnits = segment.GetField<CWE>(2);
        this.DefaultOrderUnitOfMeasureIndicator = segment.GetField<CNE>(3);
        this.PackageQuantity = segment.GetField<NM>(4);
        this.Price = segment.GetField<CP>(5);
        this.FutureItemPrice = segment.GetField<CP>(6);
        this.FutureItemPriceEffectiveDate = segment.GetField<DTM>(7);
        this.GlobalTradeItemNumber = segment.GetField<CWE>(8);
        this.ContractPrice = segment.GetField<MO>(9);
        this.QuantityofEach = segment.GetField<NM>(10);
        this.VendorCatalogNumber = segment.GetField<EI>(11);
    }
}

public sealed record PM1 : Hl7Segment {
    public CWE HealthPlanID { get; }
    public ICollection<CX> InsuranceCompanyID { get; }
    public ICollection<XON>? InsuranceCompanyName { get; }
    public ICollection<XAD>? InsuranceCompanyAddress { get; }
    public ICollection<XPN>? InsuranceCoContactPerson { get; }
    public ICollection<XTN>? InsuranceCoPhoneNumber { get; }
    public ST? GroupNumber { get; }
    public ICollection<XON>? GroupName { get; }
    public DT? PlanEffectiveDate { get; }
    public DT? PlanExpirationDate { get; }
    public ID? PatientDOBRequired { get; }
    public ID? PatientGenderRequired { get; }
    public ID? PatientRelationshipRequired { get; }
    public ID? PatientSignatureRequired { get; }
    public ID? DiagnosisRequired { get; }
    public ID? ServiceRequired { get; }
    public ID? PatientNameRequired { get; }
    public ID? PatientAddressRequired { get; }
    public ID? SubscribersNameRequired { get; }
    public ID? WorkmansCompIndicator { get; }
    public ID? BillTypeRequired { get; }
    public ID? CommercialCarrierNameandAddressRequired { get; }
    public ST? PolicyNumberPattern { get; }
    public ST? GroupNumberPattern { get; }

    public PM1(Segment segment) : base(typeof(PM1), segment) {
        this.HealthPlanID = segment.GetRequiredField<CWE>(1);
        this.InsuranceCompanyID = segment.GetRequiredRepField<CX>(2);
        this.InsuranceCompanyName = segment.GetRepField<XON>(3);
        this.InsuranceCompanyAddress = segment.GetRepField<XAD>(4);
        this.InsuranceCoContactPerson = segment.GetRepField<XPN>(5);
        this.InsuranceCoPhoneNumber = segment.GetRepField<XTN>(6);
        this.GroupNumber = segment.GetField<ST>(7);
        this.GroupName = segment.GetRepField<XON>(8);
        this.PlanEffectiveDate = segment.GetField<DT>(9);
        this.PlanExpirationDate = segment.GetField<DT>(10);
        this.PatientDOBRequired = segment.GetField<ID>(11);
        this.PatientGenderRequired = segment.GetField<ID>(12);
        this.PatientRelationshipRequired = segment.GetField<ID>(13);
        this.PatientSignatureRequired = segment.GetField<ID>(14);
        this.DiagnosisRequired = segment.GetField<ID>(15);
        this.ServiceRequired = segment.GetField<ID>(16);
        this.PatientNameRequired = segment.GetField<ID>(17);
        this.PatientAddressRequired = segment.GetField<ID>(18);
        this.SubscribersNameRequired = segment.GetField<ID>(19);
        this.WorkmansCompIndicator = segment.GetField<ID>(20);
        this.BillTypeRequired = segment.GetField<ID>(21);
        this.CommercialCarrierNameandAddressRequired = segment.GetField<ID>(22);
        this.PolicyNumberPattern = segment.GetField<ST>(23);
        this.GroupNumberPattern = segment.GetField<ST>(24);
    }
}

public sealed record PMT : Hl7Segment {
    public EI PaymentRemittanceAdviceNumber { get; }
    public DTM PaymentRemittanceEffectiveDateTime { get; }
    public DTM PaymentRemittanceExpirationDateTime { get; }
    public CWE PaymentMethod { get; }
    public DTM PaymentRemittanceDateTime { get; }
    public CP PaymentRemittanceAmount { get; }
    public EI? CheckNumber { get; }
    public XON? PayeeBankIdentification { get; }
    public ST? PayeeTransitNumber { get; }
    public CX? PayeeBankAccountID { get; }
    public XON PaymentOrganization { get; }
    public ST? ESRCodeLine { get; }

    public PMT(Segment segment) : base(typeof(PMT), segment) {
        this.PaymentRemittanceAdviceNumber = segment.GetRequiredField<EI>(1);
        this.PaymentRemittanceEffectiveDateTime = segment.GetRequiredField<DTM>(2);
        this.PaymentRemittanceExpirationDateTime = segment.GetRequiredField<DTM>(3);
        this.PaymentMethod = segment.GetRequiredField<CWE>(4);
        this.PaymentRemittanceDateTime = segment.GetRequiredField<DTM>(5);
        this.PaymentRemittanceAmount = segment.GetRequiredField<CP>(6);
        this.CheckNumber = segment.GetField<EI>(7);
        this.PayeeBankIdentification = segment.GetField<XON>(8);
        this.PayeeTransitNumber = segment.GetField<ST>(9);
        this.PayeeBankAccountID = segment.GetField<CX>(10);
        this.PaymentOrganization = segment.GetRequiredField<XON>(11);
        this.ESRCodeLine = segment.GetField<ST>(12);
    }
}

public sealed record PR1 : Hl7Segment {
    public SI SetIDPR1 { get; }
    public ST? ProcedureCodingMethod { get; }
    public CNE ProcedureCode { get; }
    public ST? ProcedureDescription { get; }
    public DTM ProcedureDateTime { get; }
    public CWE? ProcedureFunctionalType { get; }
    public NM? ProcedureMinutes { get; }
    public ST? Anesthesiologist { get; }
    public CWE? AnesthesiaCode { get; }
    public NM? AnesthesiaMinutes { get; }
    public ST? Surgeon { get; }
    public ST? ProcedurePractitioner { get; }
    public CWE? ConsentCode { get; }
    public NM? ProcedurePriority { get; }
    public CWE? AssociatedDiagnosisCode { get; }
    public ICollection<CNE>? ProcedureCodeModifier { get; }
    public CWE? ProcedureDRGType { get; }
    public ICollection<CWE>? TissueTypeCode { get; }
    public EI? ProcedureIdentifier { get; }
    public ID? ProcedureActionCode { get; }
    public CWE? DRGProcedureDeterminationStatus { get; }
    public CWE? DRGProcedureRelevance { get; }
    public ICollection<PL>? TreatingOrganizationalUnit { get; }
    public ID? RespiratoryWithinSurgery { get; }
    public EI? ParentProcedureID { get; }

    public PR1(Segment segment) : base(typeof(PR1), segment) {
        this.SetIDPR1 = segment.GetRequiredField<SI>(1);
        this.ProcedureCodingMethod = segment.GetField<ST>(2);
        this.ProcedureCode = segment.GetRequiredField<CNE>(3);
        this.ProcedureDescription = segment.GetField<ST>(4);
        this.ProcedureDateTime = segment.GetRequiredField<DTM>(5);
        this.ProcedureFunctionalType = segment.GetField<CWE>(6);
        this.ProcedureMinutes = segment.GetField<NM>(7);
        this.Anesthesiologist = segment.GetField<ST>(8);
        this.AnesthesiaCode = segment.GetField<CWE>(9);
        this.AnesthesiaMinutes = segment.GetField<NM>(10);
        this.Surgeon = segment.GetField<ST>(11);
        this.ProcedurePractitioner = segment.GetField<ST>(12);
        this.ConsentCode = segment.GetField<CWE>(13);
        this.ProcedurePriority = segment.GetField<NM>(14);
        this.AssociatedDiagnosisCode = segment.GetField<CWE>(15);
        this.ProcedureCodeModifier = segment.GetRepField<CNE>(16);
        this.ProcedureDRGType = segment.GetField<CWE>(17);
        this.TissueTypeCode = segment.GetRepField<CWE>(18);
        this.ProcedureIdentifier = segment.GetField<EI>(19);
        this.ProcedureActionCode = segment.GetField<ID>(20);
        this.DRGProcedureDeterminationStatus = segment.GetField<CWE>(21);
        this.DRGProcedureRelevance = segment.GetField<CWE>(22);
        this.TreatingOrganizationalUnit = segment.GetRepField<PL>(23);
        this.RespiratoryWithinSurgery = segment.GetField<ID>(24);
        this.ParentProcedureID = segment.GetField<EI>(25);
    }
}

public sealed record PRA : Hl7Segment {
    public CWE? PrimaryKeyValuePRA { get; }
    public ICollection<CWE>? PractitionerGroup { get; }
    public ICollection<CWE>? PractitionerCategory { get; }
    public ID? ProviderBilling { get; }
    public ICollection<SPD>? Specialty { get; }
    public ICollection<PLN>? PractitionerIDNumbers { get; }
    public ICollection<PIP>? Privileges { get; }
    public DT? DateEnteredPractice { get; }
    public CWE? Institution { get; }
    public DT? DateLeftPractice { get; }
    public ICollection<CWE>? GovernmentReimbursementBillingEligibility { get; }
    public SI? SetIDPRA { get; }

    public PRA(Segment segment) : base(typeof(PRA), segment) {
        this.PrimaryKeyValuePRA = segment.GetField<CWE>(1);
        this.PractitionerGroup = segment.GetRepField<CWE>(2);
        this.PractitionerCategory = segment.GetRepField<CWE>(3);
        this.ProviderBilling = segment.GetField<ID>(4);
        this.Specialty = segment.GetRepField<SPD>(5);
        this.PractitionerIDNumbers = segment.GetRepField<PLN>(6);
        this.Privileges = segment.GetRepField<PIP>(7);
        this.DateEnteredPractice = segment.GetField<DT>(8);
        this.Institution = segment.GetField<CWE>(9);
        this.DateLeftPractice = segment.GetField<DT>(10);
        this.GovernmentReimbursementBillingEligibility = segment.GetRepField<CWE>(11);
        this.SetIDPRA = segment.GetField<SI>(12);
    }
}

public sealed record PRB : Hl7Segment {
    public ID ActionCode { get; }
    public DTM ActionDateTime { get; }
    public CWE ProblemID { get; }
    public EI ProblemInstanceID { get; }
    public EI? EpisodeofCareID { get; }
    public NM? ProblemListPriority { get; }
    public DTM? ProblemEstablishedDateTime { get; }
    public DTM? AnticipatedProblemResolutionDateTime { get; }
    public DTM? ActualProblemResolutionDateTime { get; }
    public CWE? ProblemClassification { get; }
    public ICollection<CWE>? ProblemManagementDiscipline { get; }
    public CWE? ProblemPersistence { get; }
    public CWE? ProblemConfirmationStatus { get; }
    public CWE? ProblemLifeCycleStatus { get; }
    public DTM? ProblemLifeCycleStatusDateTime { get; }
    public DTM? ProblemDateofOnset { get; }
    public ST? ProblemOnsetText { get; }
    public CWE? ProblemRanking { get; }
    public CWE? CertaintyofProblem { get; }
    public NM? ProbabilityofProblem { get; }
    public CWE? IndividualAwarenessofProblem { get; }
    public CWE? ProblemPrognosis { get; }
    public CWE? IndividualAwarenessofPrognosis { get; }
    public ST? FamilySignificantOtherAwarenessofProblemPrognosis { get; }
    public CWE? SecuritySensitivity { get; }
    public CWE? ProblemSeverity { get; }
    public CWE? ProblemPerspective { get; }
    public CNE? MoodCode { get; }

    public PRB(Segment segment) : base(typeof(PRB), segment) {
        this.ActionCode = segment.GetRequiredField<ID>(1);
        this.ActionDateTime = segment.GetRequiredField<DTM>(2);
        this.ProblemID = segment.GetRequiredField<CWE>(3);
        this.ProblemInstanceID = segment.GetRequiredField<EI>(4);
        this.EpisodeofCareID = segment.GetField<EI>(5);
        this.ProblemListPriority = segment.GetField<NM>(6);
        this.ProblemEstablishedDateTime = segment.GetField<DTM>(7);
        this.AnticipatedProblemResolutionDateTime = segment.GetField<DTM>(8);
        this.ActualProblemResolutionDateTime = segment.GetField<DTM>(9);
        this.ProblemClassification = segment.GetField<CWE>(10);
        this.ProblemManagementDiscipline = segment.GetRepField<CWE>(11);
        this.ProblemPersistence = segment.GetField<CWE>(12);
        this.ProblemConfirmationStatus = segment.GetField<CWE>(13);
        this.ProblemLifeCycleStatus = segment.GetField<CWE>(14);
        this.ProblemLifeCycleStatusDateTime = segment.GetField<DTM>(15);
        this.ProblemDateofOnset = segment.GetField<DTM>(16);
        this.ProblemOnsetText = segment.GetField<ST>(17);
        this.ProblemRanking = segment.GetField<CWE>(18);
        this.CertaintyofProblem = segment.GetField<CWE>(19);
        this.ProbabilityofProblem = segment.GetField<NM>(20);
        this.IndividualAwarenessofProblem = segment.GetField<CWE>(21);
        this.ProblemPrognosis = segment.GetField<CWE>(22);
        this.IndividualAwarenessofPrognosis = segment.GetField<CWE>(23);
        this.FamilySignificantOtherAwarenessofProblemPrognosis = segment.GetField<ST>(24);
        this.SecuritySensitivity = segment.GetField<CWE>(25);
        this.ProblemSeverity = segment.GetField<CWE>(26);
        this.ProblemPerspective = segment.GetField<CWE>(27);
        this.MoodCode = segment.GetField<CNE>(28);
    }
}

public sealed record PRC : Hl7Segment {
    public CWE PrimaryKeyValuePRC { get; }
    public ICollection<CWE>? FacilityIDPRC { get; }
    public ICollection<CWE>? Department { get; }
    public ICollection<CWE>? ValidPatientClasses { get; }
    public CP? Price { get; }
    public ICollection<ST>? Formula { get; }
    public NM? MinimumQuantity { get; }
    public NM? MaximumQuantity { get; }
    public MO? MinimumPrice { get; }
    public MO? MaximumPrice { get; }
    public DTM? EffectiveStartDate { get; }
    public DTM? EffectiveEndDate { get; }
    public CWE? PriceOverrideFlag { get; }
    public ICollection<CWE>? BillingCategory { get; }
    public ID? ChargeableFlag { get; }
    public ID? ActiveInactiveFlag { get; }
    public MO? Cost { get; }
    public CWE? ChargeonIndicator { get; }

    public PRC(Segment segment) : base(typeof(PRC), segment) {
        this.PrimaryKeyValuePRC = segment.GetRequiredField<CWE>(1);
        this.FacilityIDPRC = segment.GetRepField<CWE>(2);
        this.Department = segment.GetRepField<CWE>(3);
        this.ValidPatientClasses = segment.GetRepField<CWE>(4);
        this.Price = segment.GetField<CP>(5);
        this.Formula = segment.GetRepField<ST>(6);
        this.MinimumQuantity = segment.GetField<NM>(7);
        this.MaximumQuantity = segment.GetField<NM>(8);
        this.MinimumPrice = segment.GetField<MO>(9);
        this.MaximumPrice = segment.GetField<MO>(10);
        this.EffectiveStartDate = segment.GetField<DTM>(11);
        this.EffectiveEndDate = segment.GetField<DTM>(12);
        this.PriceOverrideFlag = segment.GetField<CWE>(13);
        this.BillingCategory = segment.GetRepField<CWE>(14);
        this.ChargeableFlag = segment.GetField<ID>(15);
        this.ActiveInactiveFlag = segment.GetField<ID>(16);
        this.Cost = segment.GetField<MO>(17);
        this.ChargeonIndicator = segment.GetField<CWE>(18);
    }
}

public sealed record PRD : Hl7Segment {
    public ICollection<CWE> ProviderRole { get; }
    public ICollection<XPN>? ProviderName { get; }
    public ICollection<XAD>? ProviderAddress { get; }
    public PL? ProviderLocation { get; }
    public ICollection<XTN>? ProviderCommunicationInformation { get; }
    public CWE? PreferredMethodofContact { get; }
    public ICollection<PLN>? ProviderIdentifiers { get; }
    public DTM? EffectiveStartDateofProviderRole { get; }
    public ICollection<DTM>? EffectiveEndDateofProviderRole { get; }
    public XON? ProviderOrganizationNameandIdentifier { get; }
    public ICollection<XAD>? ProviderOrganizationAddress { get; }
    public ICollection<PL>? ProviderOrganizationLocationInformation { get; }
    public ICollection<XTN>? ProviderOrganizationCommunicationInformation { get; }
    public CWE? ProviderOrganizationMethodofContact { get; }

    public PRD(Segment segment) : base(typeof(PRD), segment) {
        this.ProviderRole = segment.GetRequiredRepField<CWE>(1);
        this.ProviderName = segment.GetRepField<XPN>(2);
        this.ProviderAddress = segment.GetRepField<XAD>(3);
        this.ProviderLocation = segment.GetField<PL>(4);
        this.ProviderCommunicationInformation = segment.GetRepField<XTN>(5);
        this.PreferredMethodofContact = segment.GetField<CWE>(6);
        this.ProviderIdentifiers = segment.GetRepField<PLN>(7);
        this.EffectiveStartDateofProviderRole = segment.GetField<DTM>(8);
        this.EffectiveEndDateofProviderRole = segment.GetRepField<DTM>(9);
        this.ProviderOrganizationNameandIdentifier = segment.GetField<XON>(10);
        this.ProviderOrganizationAddress = segment.GetRepField<XAD>(11);
        this.ProviderOrganizationLocationInformation = segment.GetRepField<PL>(12);
        this.ProviderOrganizationCommunicationInformation = segment.GetRepField<XTN>(13);
        this.ProviderOrganizationMethodofContact = segment.GetField<CWE>(14);
    }
}

public sealed record PRT : Hl7Segment {
    public EI? ParticipationInstanceID { get; }
    public ID ActionCode { get; }
    public CWE? ActionReason { get; }
    public CWE RoleofParticipation { get; }
    public XCN? Person { get; }
    public CWE? PersonProviderType { get; }
    public CWE? OrganizationUnitType { get; }
    public XON? Organization { get; }
    public PL? Location { get; }
    public EI? Device { get; }
    public DTM? BeginDateTime { get; }
    public DTM? EndDateTime { get; }
    public CWE? QualitativeDuration { get; }
    public XAD? Address { get; }
    public ICollection<XTN>? TelecommunicationAddress { get; }
    public EI? UDIDeviceIdentifier { get; }
    public DTM? DeviceManufactureDate { get; }
    public DTM? DeviceExpiryDate { get; }
    public ST? DeviceLotNumber { get; }
    public ST? DeviceSerialNumber { get; }
    public EI? DeviceDonationIdentification { get; }
    public CNE? DeviceType { get; }
    public CWE? PreferredMethodofContact { get; }
    public ICollection<PLN>? ContactIdentifiers { get; }

    public PRT(Segment segment) : base(typeof(PRT), segment) {
        this.ParticipationInstanceID = segment.GetField<EI>(1);
        this.ActionCode = segment.GetRequiredField<ID>(2);
        this.ActionReason = segment.GetField<CWE>(3);
        this.RoleofParticipation = segment.GetRequiredField<CWE>(4);
        this.Person = segment.GetField<XCN>(5);
        this.PersonProviderType = segment.GetField<CWE>(6);
        this.OrganizationUnitType = segment.GetField<CWE>(7);
        this.Organization = segment.GetField<XON>(8);
        this.Location = segment.GetField<PL>(9);
        this.Device = segment.GetField<EI>(10);
        this.BeginDateTime = segment.GetField<DTM>(11);
        this.EndDateTime = segment.GetField<DTM>(12);
        this.QualitativeDuration = segment.GetField<CWE>(13);
        this.Address = segment.GetField<XAD>(14);
        this.TelecommunicationAddress = segment.GetRepField<XTN>(15);
        this.UDIDeviceIdentifier = segment.GetField<EI>(16);
        this.DeviceManufactureDate = segment.GetField<DTM>(17);
        this.DeviceExpiryDate = segment.GetField<DTM>(18);
        this.DeviceLotNumber = segment.GetField<ST>(19);
        this.DeviceSerialNumber = segment.GetField<ST>(20);
        this.DeviceDonationIdentification = segment.GetField<EI>(21);
        this.DeviceType = segment.GetField<CNE>(22);
        this.PreferredMethodofContact = segment.GetField<CWE>(23);
        this.ContactIdentifiers = segment.GetRepField<PLN>(24);
    }
}

public sealed record PSG : Hl7Segment {
    public EI ProviderProductServiceGroupNumber { get; }
    public EI? PayerProductServiceGroupNumber { get; }
    public SI ProductServiceGroupSequenceNumber { get; }
    public ID AdjudicateasGroup { get; }
    public CP ProductServiceGroupBilledAmount { get; }
    public ST ProductServiceGroupDescription { get; }

    public PSG(Segment segment) : base(typeof(PSG), segment) {
        this.ProviderProductServiceGroupNumber = segment.GetRequiredField<EI>(1);
        this.PayerProductServiceGroupNumber = segment.GetField<EI>(2);
        this.ProductServiceGroupSequenceNumber = segment.GetRequiredField<SI>(3);
        this.AdjudicateasGroup = segment.GetRequiredField<ID>(4);
        this.ProductServiceGroupBilledAmount = segment.GetRequiredField<CP>(5);
        this.ProductServiceGroupDescription = segment.GetRequiredField<ST>(6);
    }
}

public sealed record PSH : Hl7Segment {
    public ST ReportType { get; }
    public ST? ReportFormIdentifier { get; }
    public DTM ReportDate { get; }
    public DTM? ReportIntervalStartDate { get; }
    public DTM? ReportIntervalEndDate { get; }
    public CQ? QuantityManufactured { get; }
    public CQ? QuantityDistributed { get; }
    public ID? QuantityDistributedMethod { get; }
    public FT? QuantityDistributedComment { get; }
    public CQ? QuantityinUse { get; }
    public ID? QuantityinUseMethod { get; }
    public FT? QuantityinUseComment { get; }
    public NM? NumberofProductExperienceReportsFiledbyFacility { get; }
    public NM? NumberofProductExperienceReportsFiledbyDistributor { get; }

    public PSH(Segment segment) : base(typeof(PSH), segment) {
        this.ReportType = segment.GetRequiredField<ST>(1);
        this.ReportFormIdentifier = segment.GetField<ST>(2);
        this.ReportDate = segment.GetRequiredField<DTM>(3);
        this.ReportIntervalStartDate = segment.GetField<DTM>(4);
        this.ReportIntervalEndDate = segment.GetField<DTM>(5);
        this.QuantityManufactured = segment.GetField<CQ>(6);
        this.QuantityDistributed = segment.GetField<CQ>(7);
        this.QuantityDistributedMethod = segment.GetField<ID>(8);
        this.QuantityDistributedComment = segment.GetField<FT>(9);
        this.QuantityinUse = segment.GetField<CQ>(10);
        this.QuantityinUseMethod = segment.GetField<ID>(11);
        this.QuantityinUseComment = segment.GetField<FT>(12);
        this.NumberofProductExperienceReportsFiledbyFacility = segment.GetField<NM>(13);
        this.NumberofProductExperienceReportsFiledbyDistributor = segment.GetField<NM>(14);
    }
}

public sealed record PSL : Hl7Segment {
    public EI ProviderProductServiceLineItemNumber { get; }
    public EI? PayerProductServiceLineItemNumber { get; }
    public SI ProductServiceLineItemSequenceNumber { get; }
    public EI? ProviderTrackingID { get; }
    public EI? PayerTrackingID { get; }
    public CWE ProductServiceLineItemStatus { get; }
    public CWE ProductServiceCode { get; }
    public CWE? ProductServiceCodeModifier { get; }
    public ST? ProductServiceCodeDescription { get; }
    public DTM? ProductServiceEffectiveDate { get; }
    public DTM? ProductServiceExpirationDate { get; }
    public CQ? ProductServiceQuantity { get; }
    public CP? ProductServiceUnitCost { get; }
    public NM? NumberofItemsperUnit { get; }
    public CP? ProductServiceGrossAmount { get; }
    public CP? ProductServiceBilledAmount { get; }
    public CWE? ProductServiceClarificationCodeType { get; }
    public ST? ProductServiceClarificationCodeValue { get; }
    public EI? HealthDocumentReferenceIdentifier { get; }
    public CWE? ProcessingConsiderationCode { get; }
    public ID RestrictedDisclosureIndicator { get; }
    public CWE? RelatedProductServiceCodeIndicator { get; }
    public CP? ProductServiceAmountforPhysician { get; }
    public NM? ProductServiceCostFactor { get; }
    public CX? CostCenter { get; }
    public DR? BillingPeriod { get; }
    public NM? DayswithoutBilling { get; }
    public NM? SessionNo { get; }
    public XCN? ExecutingPhysicianID { get; }
    public XCN? ResponsiblePhysicianID { get; }
    public CWE? RoleExecutingPhysician { get; }
    public CWE? MedicalRoleExecutingPhysician { get; }
    public CWE? Sideofbody { get; }
    public NM? NumberofTPsPP { get; }
    public CP? TPValuePP { get; }
    public NM? InternalScalingFactorPP { get; }
    public NM? ExternalScalingFactorPP { get; }
    public CP? AmountPP { get; }
    public NM? NumberofTPsTechnicalPart { get; }
    public CP? TPValueTechnicalPart { get; }
    public NM? InternalScalingFactorTechnicalPart { get; }
    public NM? ExternalScalingFactorTechnicalPart { get; }
    public CP? AmountTechnicalPart { get; }
    public CP? TotalAmountProfessionalPartTechnicalPart { get; }
    public NM? VATRate { get; }
    public ID? MainService { get; }
    public ID? Validation { get; }
    public ST? Comment { get; }

    public PSL(Segment segment) : base(typeof(PSL), segment) {
        this.ProviderProductServiceLineItemNumber = segment.GetRequiredField<EI>(1);
        this.PayerProductServiceLineItemNumber = segment.GetField<EI>(2);
        this.ProductServiceLineItemSequenceNumber = segment.GetRequiredField<SI>(3);
        this.ProviderTrackingID = segment.GetField<EI>(4);
        this.PayerTrackingID = segment.GetField<EI>(5);
        this.ProductServiceLineItemStatus = segment.GetRequiredField<CWE>(6);
        this.ProductServiceCode = segment.GetRequiredField<CWE>(7);
        this.ProductServiceCodeModifier = segment.GetField<CWE>(8);
        this.ProductServiceCodeDescription = segment.GetField<ST>(9);
        this.ProductServiceEffectiveDate = segment.GetField<DTM>(10);
        this.ProductServiceExpirationDate = segment.GetField<DTM>(11);
        this.ProductServiceQuantity = segment.GetField<CQ>(12);
        this.ProductServiceUnitCost = segment.GetField<CP>(13);
        this.NumberofItemsperUnit = segment.GetField<NM>(14);
        this.ProductServiceGrossAmount = segment.GetField<CP>(15);
        this.ProductServiceBilledAmount = segment.GetField<CP>(16);
        this.ProductServiceClarificationCodeType = segment.GetField<CWE>(17);
        this.ProductServiceClarificationCodeValue = segment.GetField<ST>(18);
        this.HealthDocumentReferenceIdentifier = segment.GetField<EI>(19);
        this.ProcessingConsiderationCode = segment.GetField<CWE>(20);
        this.RestrictedDisclosureIndicator = segment.GetRequiredField<ID>(21);
        this.RelatedProductServiceCodeIndicator = segment.GetField<CWE>(22);
        this.ProductServiceAmountforPhysician = segment.GetField<CP>(23);
        this.ProductServiceCostFactor = segment.GetField<NM>(24);
        this.CostCenter = segment.GetField<CX>(25);
        this.BillingPeriod = segment.GetField<DR>(26);
        this.DayswithoutBilling = segment.GetField<NM>(27);
        this.SessionNo = segment.GetField<NM>(28);
        this.ExecutingPhysicianID = segment.GetField<XCN>(29);
        this.ResponsiblePhysicianID = segment.GetField<XCN>(30);
        this.RoleExecutingPhysician = segment.GetField<CWE>(31);
        this.MedicalRoleExecutingPhysician = segment.GetField<CWE>(32);
        this.Sideofbody = segment.GetField<CWE>(33);
        this.NumberofTPsPP = segment.GetField<NM>(34);
        this.TPValuePP = segment.GetField<CP>(35);
        this.InternalScalingFactorPP = segment.GetField<NM>(36);
        this.ExternalScalingFactorPP = segment.GetField<NM>(37);
        this.AmountPP = segment.GetField<CP>(38);
        this.NumberofTPsTechnicalPart = segment.GetField<NM>(39);
        this.TPValueTechnicalPart = segment.GetField<CP>(40);
        this.InternalScalingFactorTechnicalPart = segment.GetField<NM>(41);
        this.ExternalScalingFactorTechnicalPart = segment.GetField<NM>(42);
        this.AmountTechnicalPart = segment.GetField<CP>(43);
        this.TotalAmountProfessionalPartTechnicalPart = segment.GetField<CP>(44);
        this.VATRate = segment.GetField<NM>(45);
        this.MainService = segment.GetField<ID>(46);
        this.Validation = segment.GetField<ID>(47);
        this.Comment = segment.GetField<ST>(48);
    }
}

public sealed record PSS : Hl7Segment {
    public EI ProviderProductServiceSectionNumber { get; }
    public EI? PayerProductServiceSectionNumber { get; }
    public SI ProductServiceSectionSequenceNumber { get; }
    public CP BilledAmount { get; }
    public ST SectionDescriptionorHeading { get; }

    public PSS(Segment segment) : base(typeof(PSS), segment) {
        this.ProviderProductServiceSectionNumber = segment.GetRequiredField<EI>(1);
        this.PayerProductServiceSectionNumber = segment.GetField<EI>(2);
        this.ProductServiceSectionSequenceNumber = segment.GetRequiredField<SI>(3);
        this.BilledAmount = segment.GetRequiredField<CP>(4);
        this.SectionDescriptionorHeading = segment.GetRequiredField<ST>(5);
    }
}

public sealed record PTH : Hl7Segment {
    public ID ActionCode { get; }
    public CWE PathwayID { get; }
    public EI PathwayInstanceID { get; }
    public DTM PathwayEstablishedDateTime { get; }
    public CWE? PathwayLifeCycleStatus { get; }
    public DTM? ChangePathwayLifeCycleStatusDateTime { get; }
    public CNE? MoodCode { get; }

    public PTH(Segment segment) : base(typeof(PTH), segment) {
        this.ActionCode = segment.GetRequiredField<ID>(1);
        this.PathwayID = segment.GetRequiredField<CWE>(2);
        this.PathwayInstanceID = segment.GetRequiredField<EI>(3);
        this.PathwayEstablishedDateTime = segment.GetRequiredField<DTM>(4);
        this.PathwayLifeCycleStatus = segment.GetField<CWE>(5);
        this.ChangePathwayLifeCycleStatusDateTime = segment.GetField<DTM>(6);
        this.MoodCode = segment.GetField<CNE>(7);
    }
}

public sealed record PV1 : Hl7Segment {
    public SI? SetIDPV1 { get; }
    public CWE PatientClass { get; }
    public PL? AssignedPatientLocation { get; }
    public CWE? AdmissionType { get; }
    public CX? PreadmitNumber { get; }
    public PL? PriorPatientLocation { get; }
    public ICollection<XCN>? AttendingDoctor { get; }
    public ICollection<XCN>? ReferringDoctor { get; }
    public ICollection<XCN>? ConsultingDoctor { get; }
    public CWE? HospitalService { get; }
    public PL? TemporaryLocation { get; }
    public CWE? PreadmitTestIndicator { get; }
    public CWE? ReadmissionIndicator { get; }
    public CWE? AdmitSource { get; }
    public ICollection<CWE>? AmbulatoryStatus { get; }
    public CWE? VIPIndicator { get; }
    public ICollection<XCN>? AdmittingDoctor { get; }
    public CWE? PatientType { get; }
    public CX? VisitNumber { get; }
    public ICollection<FC>? FinancialClass { get; }
    public CWE? ChargePriceIndicator { get; }
    public CWE? CourtesyCode { get; }
    public CWE? CreditRating { get; }
    public ICollection<CWE>? ContractCode { get; }
    public ICollection<DT>? ContractEffectiveDate { get; }
    public ICollection<NM>? ContractAmount { get; }
    public ICollection<NM>? ContractPeriod { get; }
    public CWE? InterestCode { get; }
    public CWE? TransfertoBadDebtCode { get; }
    public DT? TransfertoBadDebtDate { get; }
    public CWE? BadDebtAgencyCode { get; }
    public NM? BadDebtTransferAmount { get; }
    public NM? BadDebtRecoveryAmount { get; }
    public CWE? DeleteAccountIndicator { get; }
    public DT? DeleteAccountDate { get; }
    public CWE? DischargeDisposition { get; }
    public DLD? DischargedtoLocation { get; }
    public CWE? DietType { get; }
    public CWE? ServicingFacility { get; }
    public CWE? BedStatus { get; }
    public CWE? AccountStatus { get; }
    public PL? PendingLocation { get; }
    public PL? PriorTemporaryLocation { get; }
    public DTM? AdmitDateTime { get; }
    public DTM? DischargeDateTime { get; }
    public NM? CurrentPatientBalance { get; }
    public NM? TotalCharges { get; }
    public NM? TotalAdjustments { get; }
    public NM? TotalPayments { get; }
    public ICollection<CX>? AlternateVisitID { get; }
    public CWE? VisitIndicator { get; }
    public ST? OtherHealthcareProvider { get; }
    public ST? ServiceEpisodeDescription { get; }
    public CX? ServiceEpisodeIdentifier { get; }

    public PV1(Segment segment) : base(typeof(PV1), segment) {
        this.SetIDPV1 = segment.GetField<SI>(1);
        this.PatientClass = segment.GetRequiredField<CWE>(2);
        this.AssignedPatientLocation = segment.GetField<PL>(3);
        this.AdmissionType = segment.GetField<CWE>(4);
        this.PreadmitNumber = segment.GetField<CX>(5);
        this.PriorPatientLocation = segment.GetField<PL>(6);
        this.AttendingDoctor = segment.GetRepField<XCN>(7);
        this.ReferringDoctor = segment.GetRepField<XCN>(8);
        this.ConsultingDoctor = segment.GetRepField<XCN>(9);
        this.HospitalService = segment.GetField<CWE>(10);
        this.TemporaryLocation = segment.GetField<PL>(11);
        this.PreadmitTestIndicator = segment.GetField<CWE>(12);
        this.ReadmissionIndicator = segment.GetField<CWE>(13);
        this.AdmitSource = segment.GetField<CWE>(14);
        this.AmbulatoryStatus = segment.GetRepField<CWE>(15);
        this.VIPIndicator = segment.GetField<CWE>(16);
        this.AdmittingDoctor = segment.GetRepField<XCN>(17);
        this.PatientType = segment.GetField<CWE>(18);
        this.VisitNumber = segment.GetField<CX>(19);
        this.FinancialClass = segment.GetRepField<FC>(20);
        this.ChargePriceIndicator = segment.GetField<CWE>(21);
        this.CourtesyCode = segment.GetField<CWE>(22);
        this.CreditRating = segment.GetField<CWE>(23);
        this.ContractCode = segment.GetRepField<CWE>(24);
        this.ContractEffectiveDate = segment.GetRepField<DT>(25);
        this.ContractAmount = segment.GetRepField<NM>(26);
        this.ContractPeriod = segment.GetRepField<NM>(27);
        this.InterestCode = segment.GetField<CWE>(28);
        this.TransfertoBadDebtCode = segment.GetField<CWE>(29);
        this.TransfertoBadDebtDate = segment.GetField<DT>(30);
        this.BadDebtAgencyCode = segment.GetField<CWE>(31);
        this.BadDebtTransferAmount = segment.GetField<NM>(32);
        this.BadDebtRecoveryAmount = segment.GetField<NM>(33);
        this.DeleteAccountIndicator = segment.GetField<CWE>(34);
        this.DeleteAccountDate = segment.GetField<DT>(35);
        this.DischargeDisposition = segment.GetField<CWE>(36);
        this.DischargedtoLocation = segment.GetField<DLD>(37);
        this.DietType = segment.GetField<CWE>(38);
        this.ServicingFacility = segment.GetField<CWE>(39);
        this.BedStatus = segment.GetField<CWE>(40);
        this.AccountStatus = segment.GetField<CWE>(41);
        this.PendingLocation = segment.GetField<PL>(42);
        this.PriorTemporaryLocation = segment.GetField<PL>(43);
        this.AdmitDateTime = segment.GetField<DTM>(44);
        this.DischargeDateTime = segment.GetField<DTM>(45);
        this.CurrentPatientBalance = segment.GetField<NM>(46);
        this.TotalCharges = segment.GetField<NM>(47);
        this.TotalAdjustments = segment.GetField<NM>(48);
        this.TotalPayments = segment.GetField<NM>(49);
        this.AlternateVisitID = segment.GetRepField<CX>(50);
        this.VisitIndicator = segment.GetField<CWE>(51);
        this.OtherHealthcareProvider = segment.GetField<ST>(52);
        this.ServiceEpisodeDescription = segment.GetField<ST>(53);
        this.ServiceEpisodeIdentifier = segment.GetField<CX>(54);
    }
}

public sealed record PV2 : Hl7Segment {
    public PL? PriorPendingLocation { get; }
    public CWE? AccommodationCode { get; }
    public CWE? AdmitReason { get; }
    public CWE? TransferReason { get; }
    public ICollection<ST>? PatientValuables { get; }
    public ST? PatientValuablesLocation { get; }
    public ICollection<CWE>? VisitUserCode { get; }
    public DTM? ExpectedAdmitDateTime { get; }
    public DTM? ExpectedDischargeDateTime { get; }
    public NM? EstimatedLengthofInpatientStay { get; }
    public NM? ActualLengthofInpatientStay { get; }
    public ST? VisitDescription { get; }
    public ICollection<XCN>? ReferralSourceCode { get; }
    public DT? PreviousServiceDate { get; }
    public ID? EmploymentIllnessRelatedIndicator { get; }
    public CWE? PurgeStatusCode { get; }
    public DT? PurgeStatusDate { get; }
    public CWE? SpecialProgramCode { get; }
    public ID? RetentionIndicator { get; }
    public NM? ExpectedNumberofInsurancePlans { get; }
    public CWE? VisitPublicityCode { get; }
    public ID? VisitProtectionIndicator { get; }
    public ICollection<XON>? ClinicOrganizationName { get; }
    public CWE? PatientStatusCode { get; }
    public CWE? VisitPriorityCode { get; }
    public DT? PreviousTreatmentDate { get; }
    public CWE? ExpectedDischargeDisposition { get; }
    public DT? SignatureonFileDate { get; }
    public DT? FirstSimilarIllnessDate { get; }
    public CWE? PatientChargeAdjustmentCode { get; }
    public CWE? RecurringServiceCode { get; }
    public ID? BillingMediaCode { get; }
    public DTM? ExpectedSurgeryDateandTime { get; }
    public ID? MilitaryPartnershipCode { get; }
    public ID? MilitaryNonAvailabilityCode { get; }
    public ID? NewbornBabyIndicator { get; }
    public ID? BabyDetainedIndicator { get; }
    public CWE? ModeofArrivalCode { get; }
    public ICollection<CWE>? RecreationalDrugUseCode { get; }
    public CWE? AdmissionLevelofCareCode { get; }
    public ICollection<CWE>? PrecautionCode { get; }
    public CWE? PatientConditionCode { get; }
    public CWE? LivingWillCode { get; }
    public CWE? OrganDonorCode { get; }
    public CWE? AdvanceDirectiveCode { get; }
    public DT? PatientStatusEffectiveDate { get; }
    public DTM? ExpectedLOAReturnDateTime { get; }
    public DTM? ExpectedPreadmissionTestingDateTime { get; }
    public ICollection<CWE>? NotifyClergyCode { get; }
    public DT? AdvanceDirectiveLastVerifiedDate { get; }

    public PV2(Segment segment) : base(typeof(PV2), segment) {
        this.PriorPendingLocation = segment.GetField<PL>(1);
        this.AccommodationCode = segment.GetField<CWE>(2);
        this.AdmitReason = segment.GetField<CWE>(3);
        this.TransferReason = segment.GetField<CWE>(4);
        this.PatientValuables = segment.GetRepField<ST>(5);
        this.PatientValuablesLocation = segment.GetField<ST>(6);
        this.VisitUserCode = segment.GetRepField<CWE>(7);
        this.ExpectedAdmitDateTime = segment.GetField<DTM>(8);
        this.ExpectedDischargeDateTime = segment.GetField<DTM>(9);
        this.EstimatedLengthofInpatientStay = segment.GetField<NM>(10);
        this.ActualLengthofInpatientStay = segment.GetField<NM>(11);
        this.VisitDescription = segment.GetField<ST>(12);
        this.ReferralSourceCode = segment.GetRepField<XCN>(13);
        this.PreviousServiceDate = segment.GetField<DT>(14);
        this.EmploymentIllnessRelatedIndicator = segment.GetField<ID>(15);
        this.PurgeStatusCode = segment.GetField<CWE>(16);
        this.PurgeStatusDate = segment.GetField<DT>(17);
        this.SpecialProgramCode = segment.GetField<CWE>(18);
        this.RetentionIndicator = segment.GetField<ID>(19);
        this.ExpectedNumberofInsurancePlans = segment.GetField<NM>(20);
        this.VisitPublicityCode = segment.GetField<CWE>(21);
        this.VisitProtectionIndicator = segment.GetField<ID>(22);
        this.ClinicOrganizationName = segment.GetRepField<XON>(23);
        this.PatientStatusCode = segment.GetField<CWE>(24);
        this.VisitPriorityCode = segment.GetField<CWE>(25);
        this.PreviousTreatmentDate = segment.GetField<DT>(26);
        this.ExpectedDischargeDisposition = segment.GetField<CWE>(27);
        this.SignatureonFileDate = segment.GetField<DT>(28);
        this.FirstSimilarIllnessDate = segment.GetField<DT>(29);
        this.PatientChargeAdjustmentCode = segment.GetField<CWE>(30);
        this.RecurringServiceCode = segment.GetField<CWE>(31);
        this.BillingMediaCode = segment.GetField<ID>(32);
        this.ExpectedSurgeryDateandTime = segment.GetField<DTM>(33);
        this.MilitaryPartnershipCode = segment.GetField<ID>(34);
        this.MilitaryNonAvailabilityCode = segment.GetField<ID>(35);
        this.NewbornBabyIndicator = segment.GetField<ID>(36);
        this.BabyDetainedIndicator = segment.GetField<ID>(37);
        this.ModeofArrivalCode = segment.GetField<CWE>(38);
        this.RecreationalDrugUseCode = segment.GetRepField<CWE>(39);
        this.AdmissionLevelofCareCode = segment.GetField<CWE>(40);
        this.PrecautionCode = segment.GetRepField<CWE>(41);
        this.PatientConditionCode = segment.GetField<CWE>(42);
        this.LivingWillCode = segment.GetField<CWE>(43);
        this.OrganDonorCode = segment.GetField<CWE>(44);
        this.AdvanceDirectiveCode = segment.GetField<CWE>(45);
        this.PatientStatusEffectiveDate = segment.GetField<DT>(46);
        this.ExpectedLOAReturnDateTime = segment.GetField<DTM>(47);
        this.ExpectedPreadmissionTestingDateTime = segment.GetField<DTM>(48);
        this.NotifyClergyCode = segment.GetRepField<CWE>(49);
        this.AdvanceDirectiveLastVerifiedDate = segment.GetField<DT>(50);
    }
}

public sealed record PYE : Hl7Segment {
    public SI SetIDPYE { get; }
    public CWE PayeeType { get; }
    public CWE? PayeeRelationshiptoInvoice { get; }
    public XON? PayeeIdentificationList { get; }
    public XPN? PayeePersonName { get; }
    public XAD? PayeeAddress { get; }
    public CWE? PaymentMethod { get; }

    public PYE(Segment segment) : base(typeof(PYE), segment) {
        this.SetIDPYE = segment.GetRequiredField<SI>(1);
        this.PayeeType = segment.GetRequiredField<CWE>(2);
        this.PayeeRelationshiptoInvoice = segment.GetField<CWE>(3);
        this.PayeeIdentificationList = segment.GetField<XON>(4);
        this.PayeePersonName = segment.GetField<XPN>(5);
        this.PayeeAddress = segment.GetField<XAD>(6);
        this.PaymentMethod = segment.GetField<CWE>(7);
    }
}

public sealed record QAK : Hl7Segment {
    public ST? QueryTag { get; }
    public ID? QueryResponseStatus { get; }
    public CWE? MessageQueryName { get; }
    public NM? HitCountTotal { get; }
    public NM? Thispayload { get; }
    public NM? Hitsremaining { get; }

    public QAK(Segment segment) : base(typeof(QAK), segment) {
        this.QueryTag = segment.GetField<ST>(1);
        this.QueryResponseStatus = segment.GetField<ID>(2);
        this.MessageQueryName = segment.GetField<CWE>(3);
        this.HitCountTotal = segment.GetField<NM>(4);
        this.Thispayload = segment.GetField<NM>(5);
        this.Hitsremaining = segment.GetField<NM>(6);
    }
}

public sealed record QID : Hl7Segment {
    public ST QueryTag { get; }
    public CWE MessageQueryName { get; }

    public QID(Segment segment) : base(typeof(QID), segment) {
        this.QueryTag = segment.GetRequiredField<ST>(1);
        this.MessageQueryName = segment.GetRequiredField<CWE>(2);
    }
}

public sealed record QPD : Hl7Segment {
    public CWE MessageQueryName { get; }
    public ST? QueryTag { get; }
    public ST? UserParameters { get; }

    public QPD(Segment segment) : base(typeof(QPD), segment) {
        this.MessageQueryName = segment.GetRequiredField<CWE>(1);
        this.QueryTag = segment.GetField<ST>(2);
        this.UserParameters = segment.GetField<ST>(3);
    }
}

public sealed record QRI : Hl7Segment {
    public NM? CandidateConfidence { get; }
    public ICollection<CWE>? MatchReasonCode { get; }
    public CWE? AlgorithmDescriptor { get; }

    public QRI(Segment segment) : base(typeof(QRI), segment) {
        this.CandidateConfidence = segment.GetField<NM>(1);
        this.MatchReasonCode = segment.GetRepField<CWE>(2);
        this.AlgorithmDescriptor = segment.GetField<CWE>(3);
    }
}

public sealed record RCP : Hl7Segment {
    public ID? QueryPriority { get; }
    public CQ? QuantityLimitedRequest { get; }
    public CNE? ResponseModality { get; }
    public DTM? ExecutionandDeliveryTime { get; }
    public ID? ModifyIndicator { get; }
    public ICollection<SRT>? SortbyField { get; }
    public ICollection<ID>? Segmentgroupinclusion { get; }

    public RCP(Segment segment) : base(typeof(RCP), segment) {
        this.QueryPriority = segment.GetField<ID>(1);
        this.QuantityLimitedRequest = segment.GetField<CQ>(2);
        this.ResponseModality = segment.GetField<CNE>(3);
        this.ExecutionandDeliveryTime = segment.GetField<DTM>(4);
        this.ModifyIndicator = segment.GetField<ID>(5);
        this.SortbyField = segment.GetRepField<SRT>(6);
        this.Segmentgroupinclusion = segment.GetRepField<ID>(7);
    }
}

public sealed record RDF : Hl7Segment {
    public NM NumberofColumnsperRow { get; }
    public ICollection<RCD> ColumnDescription { get; }

    public RDF(Segment segment) : base(typeof(RDF), segment) {
        this.NumberofColumnsperRow = segment.GetRequiredField<NM>(1);
        this.ColumnDescription = segment.GetRequiredRepField<RCD>(2);
    }
}

public sealed record RDT : Hl7Segment {
    public ST ColumnValue { get; }

    public RDT(Segment segment) : base(typeof(RDT), segment) {
        this.ColumnValue = segment.GetRequiredField<ST>(1);
    }
}

public sealed record REL : Hl7Segment {
    public SI? SetIDREL { get; }
    public CWE RelationshipType { get; }
    public EI ThisRelationshipInstanceIdentifier { get; }
    public EI SourceInformationInstanceIdentifier { get; }
    public EI TargetInformationInstanceIdentifier { get; }
    public EI? AssertingEntityInstanceID { get; }
    public XCN? AssertingPerson { get; }
    public XON? AssertingOrganization { get; }
    public XAD? AssertorAddress { get; }
    public XTN? AssertorContact { get; }
    public DR? AssertionDateRange { get; }
    public ID? NegationIndicator { get; }
    public CWE? CertaintyofRelationship { get; }
    public NM? PriorityNo { get; }
    public NM? PrioritySequenceNo { get; }
    public ID? SeparabilityIndicator { get; }
    public ID? SourceInformationInstanceObjectType { get; }
    public ID? TargetInformationInstanceObjectType { get; }

    public REL(Segment segment) : base(typeof(REL), segment) {
        this.SetIDREL = segment.GetField<SI>(1);
        this.RelationshipType = segment.GetRequiredField<CWE>(2);
        this.ThisRelationshipInstanceIdentifier = segment.GetRequiredField<EI>(3);
        this.SourceInformationInstanceIdentifier = segment.GetRequiredField<EI>(4);
        this.TargetInformationInstanceIdentifier = segment.GetRequiredField<EI>(5);
        this.AssertingEntityInstanceID = segment.GetField<EI>(6);
        this.AssertingPerson = segment.GetField<XCN>(7);
        this.AssertingOrganization = segment.GetField<XON>(8);
        this.AssertorAddress = segment.GetField<XAD>(9);
        this.AssertorContact = segment.GetField<XTN>(10);
        this.AssertionDateRange = segment.GetField<DR>(11);
        this.NegationIndicator = segment.GetField<ID>(12);
        this.CertaintyofRelationship = segment.GetField<CWE>(13);
        this.PriorityNo = segment.GetField<NM>(14);
        this.PrioritySequenceNo = segment.GetField<NM>(15);
        this.SeparabilityIndicator = segment.GetField<ID>(16);
        this.SourceInformationInstanceObjectType = segment.GetField<ID>(17);
        this.TargetInformationInstanceObjectType = segment.GetField<ID>(18);
    }
}

public sealed record RF1 : Hl7Segment {
    public CWE? ReferralStatus { get; }
    public CWE? ReferralPriority { get; }
    public CWE? ReferralType { get; }
    public ICollection<CWE>? ReferralDisposition { get; }
    public CWE? ReferralCategory { get; }
    public EI OriginatingReferralIdentifier { get; }
    public DTM? EffectiveDate { get; }
    public DTM? ExpirationDate { get; }
    public DTM? ProcessDate { get; }
    public ICollection<CWE>? ReferralReason { get; }
    public ICollection<EI>? ExternalReferralIdentifier { get; }
    public CWE? ReferralDocumentationCompletionStatus { get; }
    public DTM? PlannedTreatmentStopDate { get; }
    public ST? ReferralReasonText { get; }
    public CQ? NumberofAuthorizedTreatmentsUnits { get; }
    public CQ? NumberofUsedTreatmentsUnits { get; }
    public CQ? NumberofScheduleTreatmentsUnits { get; }
    public MO? RemainingBenefitAmount { get; }
    public XON? AuthorizedProvider { get; }
    public XCN? AuthorizedHealthProfessional { get; }
    public ST? SourceText { get; }
    public DTM? SourceDate { get; }
    public XTN? SourcePhone { get; }
    public ST? Comment { get; }
    public ID? ActionCode { get; }

    public RF1(Segment segment) : base(typeof(RF1), segment) {
        this.ReferralStatus = segment.GetField<CWE>(1);
        this.ReferralPriority = segment.GetField<CWE>(2);
        this.ReferralType = segment.GetField<CWE>(3);
        this.ReferralDisposition = segment.GetRepField<CWE>(4);
        this.ReferralCategory = segment.GetField<CWE>(5);
        this.OriginatingReferralIdentifier = segment.GetRequiredField<EI>(6);
        this.EffectiveDate = segment.GetField<DTM>(7);
        this.ExpirationDate = segment.GetField<DTM>(8);
        this.ProcessDate = segment.GetField<DTM>(9);
        this.ReferralReason = segment.GetRepField<CWE>(10);
        this.ExternalReferralIdentifier = segment.GetRepField<EI>(11);
        this.ReferralDocumentationCompletionStatus = segment.GetField<CWE>(12);
        this.PlannedTreatmentStopDate = segment.GetField<DTM>(13);
        this.ReferralReasonText = segment.GetField<ST>(14);
        this.NumberofAuthorizedTreatmentsUnits = segment.GetField<CQ>(15);
        this.NumberofUsedTreatmentsUnits = segment.GetField<CQ>(16);
        this.NumberofScheduleTreatmentsUnits = segment.GetField<CQ>(17);
        this.RemainingBenefitAmount = segment.GetField<MO>(18);
        this.AuthorizedProvider = segment.GetField<XON>(19);
        this.AuthorizedHealthProfessional = segment.GetField<XCN>(20);
        this.SourceText = segment.GetField<ST>(21);
        this.SourceDate = segment.GetField<DTM>(22);
        this.SourcePhone = segment.GetField<XTN>(23);
        this.Comment = segment.GetField<ST>(24);
        this.ActionCode = segment.GetField<ID>(25);
    }
}

public sealed record RFI : Hl7Segment {
    public DTM RequestDate { get; }
    public DTM ResponseDueDate { get; }
    public ID? PatientConsent { get; }
    public DTM? DateAdditionalInformationWasSubmitted { get; }

    public RFI(Segment segment) : base(typeof(RFI), segment) {
        this.RequestDate = segment.GetRequiredField<DTM>(1);
        this.ResponseDueDate = segment.GetRequiredField<DTM>(2);
        this.PatientConsent = segment.GetField<ID>(3);
        this.DateAdditionalInformationWasSubmitted = segment.GetField<DTM>(4);
    }
}

public sealed record RGS : Hl7Segment {
    public SI SetIDRGS { get; }
    public ID? SegmentActionCode { get; }
    public CWE? ResourceGroupID { get; }

    public RGS(Segment segment) : base(typeof(RGS), segment) {
        this.SetIDRGS = segment.GetRequiredField<SI>(1);
        this.SegmentActionCode = segment.GetField<ID>(2);
        this.ResourceGroupID = segment.GetField<CWE>(3);
    }
}

public sealed record RMI : Hl7Segment {
    public CWE? RiskManagementIncidentCode { get; }
    public DTM? DateTimeIncident { get; }
    public CWE? IncidentTypeCode { get; }

    public RMI(Segment segment) : base(typeof(RMI), segment) {
        this.RiskManagementIncidentCode = segment.GetField<CWE>(1);
        this.DateTimeIncident = segment.GetField<DTM>(2);
        this.IncidentTypeCode = segment.GetField<CWE>(3);
    }
}

public sealed record ROL : Hl7Segment {

    public ROL(Segment segment) : base(typeof(ROL), segment) {
    }
}

public sealed record RQ1 : Hl7Segment {
    public ST? AnticipatedPrice { get; }
    public CWE? ManufacturerIdentifier { get; }
    public ST? ManufacturersCatalog { get; }
    public CWE? VendorID { get; }
    public ST? VendorCatalog { get; }
    public ID? Taxable { get; }
    public ID? SubstituteAllowed { get; }

    public RQ1(Segment segment) : base(typeof(RQ1), segment) {
        this.AnticipatedPrice = segment.GetField<ST>(1);
        this.ManufacturerIdentifier = segment.GetField<CWE>(2);
        this.ManufacturersCatalog = segment.GetField<ST>(3);
        this.VendorID = segment.GetField<CWE>(4);
        this.VendorCatalog = segment.GetField<ST>(5);
        this.Taxable = segment.GetField<ID>(6);
        this.SubstituteAllowed = segment.GetField<ID>(7);
    }
}

public sealed record RQD : Hl7Segment {
    public SI? RequisitionLineNumber { get; }
    public CWE? ItemCodeInternal { get; }
    public CWE? ItemCodeExternal { get; }
    public CWE? HospitalItemCode { get; }
    public NM? RequisitionQuantity { get; }
    public CWE? RequisitionUnitofMeasure { get; }
    public CX? CostCenterAccountNumber { get; }
    public CWE? ItemNaturalAccountCode { get; }
    public CWE? DeliverToID { get; }
    public DT? DateNeeded { get; }

    public RQD(Segment segment) : base(typeof(RQD), segment) {
        this.RequisitionLineNumber = segment.GetField<SI>(1);
        this.ItemCodeInternal = segment.GetField<CWE>(2);
        this.ItemCodeExternal = segment.GetField<CWE>(3);
        this.HospitalItemCode = segment.GetField<CWE>(4);
        this.RequisitionQuantity = segment.GetField<NM>(5);
        this.RequisitionUnitofMeasure = segment.GetField<CWE>(6);
        this.CostCenterAccountNumber = segment.GetField<CX>(7);
        this.ItemNaturalAccountCode = segment.GetField<CWE>(8);
        this.DeliverToID = segment.GetField<CWE>(9);
        this.DateNeeded = segment.GetField<DT>(10);
    }
}

public sealed record RXA : Hl7Segment {
    public NM GiveSubIDCounter { get; }
    public NM AdministrationSubIDCounter { get; }
    public DTM DateTimeStartofAdministration { get; }
    public DTM DateTimeEndofAdministration { get; }
    public CWE AdministeredCode { get; }
    public NM AdministeredAmount { get; }
    public CWE? AdministeredUnits { get; }
    public CWE? AdministeredDosageForm { get; }
    public ICollection<CWE>? AdministrationNotes { get; }
    public ST? AdministeringProvider { get; }
    public ST? AdministeredatLocation { get; }
    public ST? AdministeredPer { get; }
    public NM? AdministeredStrength { get; }
    public CWE? AdministeredStrengthUnits { get; }
    public ICollection<ST>? SubstanceLotNumber { get; }
    public ICollection<DTM>? SubstanceExpirationDate { get; }
    public ICollection<CWE>? SubstanceManufacturerName { get; }
    public ICollection<CWE>? SubstanceTreatmentRefusalReason { get; }
    public ICollection<CWE>? Indication { get; }
    public ID? CompletionStatus { get; }
    public ID? ActionCodeRXA { get; }
    public DTM? SystemEntryDateTime { get; }
    public NM? AdministeredDrugStrengthVolume { get; }
    public CWE? AdministeredDrugStrengthVolumeUnits { get; }
    public CWE? AdministeredBarcodeIdentifier { get; }
    public ID? PharmacyOrderType { get; }
    public PL? Administerat { get; }
    public XAD? AdministeredatAddress { get; }
    public ICollection<EI>? AdministeredTagIdentifier { get; }

    public RXA(Segment segment) : base(typeof(RXA), segment) {
        this.GiveSubIDCounter = segment.GetRequiredField<NM>(1);
        this.AdministrationSubIDCounter = segment.GetRequiredField<NM>(2);
        this.DateTimeStartofAdministration = segment.GetRequiredField<DTM>(3);
        this.DateTimeEndofAdministration = segment.GetRequiredField<DTM>(4);
        this.AdministeredCode = segment.GetRequiredField<CWE>(5);
        this.AdministeredAmount = segment.GetRequiredField<NM>(6);
        this.AdministeredUnits = segment.GetField<CWE>(7);
        this.AdministeredDosageForm = segment.GetField<CWE>(8);
        this.AdministrationNotes = segment.GetRepField<CWE>(9);
        this.AdministeringProvider = segment.GetField<ST>(10);
        this.AdministeredatLocation = segment.GetField<ST>(11);
        this.AdministeredPer = segment.GetField<ST>(12);
        this.AdministeredStrength = segment.GetField<NM>(13);
        this.AdministeredStrengthUnits = segment.GetField<CWE>(14);
        this.SubstanceLotNumber = segment.GetRepField<ST>(15);
        this.SubstanceExpirationDate = segment.GetRepField<DTM>(16);
        this.SubstanceManufacturerName = segment.GetRepField<CWE>(17);
        this.SubstanceTreatmentRefusalReason = segment.GetRepField<CWE>(18);
        this.Indication = segment.GetRepField<CWE>(19);
        this.CompletionStatus = segment.GetField<ID>(20);
        this.ActionCodeRXA = segment.GetField<ID>(21);
        this.SystemEntryDateTime = segment.GetField<DTM>(22);
        this.AdministeredDrugStrengthVolume = segment.GetField<NM>(23);
        this.AdministeredDrugStrengthVolumeUnits = segment.GetField<CWE>(24);
        this.AdministeredBarcodeIdentifier = segment.GetField<CWE>(25);
        this.PharmacyOrderType = segment.GetField<ID>(26);
        this.Administerat = segment.GetField<PL>(27);
        this.AdministeredatAddress = segment.GetField<XAD>(28);
        this.AdministeredTagIdentifier = segment.GetRepField<EI>(29);
    }
}

public sealed record RXC : Hl7Segment {
    public ID RXComponentType { get; }
    public CWE ComponentCode { get; }
    public NM ComponentAmount { get; }
    public CWE ComponentUnits { get; }
    public NM? ComponentStrength { get; }
    public CWE? ComponentStrengthUnits { get; }
    public ICollection<CWE>? SupplementaryCode { get; }
    public NM? ComponentDrugStrengthVolume { get; }
    public CWE? ComponentDrugStrengthVolumeUnits { get; }
    public NM? DispenseAmount { get; }
    public CWE? DispenseUnits { get; }

    public RXC(Segment segment) : base(typeof(RXC), segment) {
        this.RXComponentType = segment.GetRequiredField<ID>(1);
        this.ComponentCode = segment.GetRequiredField<CWE>(2);
        this.ComponentAmount = segment.GetRequiredField<NM>(3);
        this.ComponentUnits = segment.GetRequiredField<CWE>(4);
        this.ComponentStrength = segment.GetField<NM>(5);
        this.ComponentStrengthUnits = segment.GetField<CWE>(6);
        this.SupplementaryCode = segment.GetRepField<CWE>(7);
        this.ComponentDrugStrengthVolume = segment.GetField<NM>(8);
        this.ComponentDrugStrengthVolumeUnits = segment.GetField<CWE>(9);
        this.DispenseAmount = segment.GetField<NM>(10);
        this.DispenseUnits = segment.GetField<CWE>(11);
    }
}

public sealed record RXD : Hl7Segment {
    public NM DispenseSubIDCounter { get; }
    public CWE DispenseGiveCode { get; }
    public DTM DateTimeDispensed { get; }
    public NM ActualDispenseAmount { get; }
    public CWE? ActualDispenseUnits { get; }
    public CWE? ActualDosageForm { get; }
    public ST PrescriptionNumber { get; }
    public NM? NumberofRefillsRemaining { get; }
    public ICollection<ST>? DispenseNotes { get; }
    public ICollection<XCN>? DispensingProvider { get; }
    public ID? SubstitutionStatus { get; }
    public CQ? TotalDailyDose { get; }
    public ST? DispensetoLocation { get; }
    public ID? NeedsHumanReview { get; }
    public ICollection<CWE>? SpecialDispensingInstructions { get; }
    public NM? ActualStrength { get; }
    public CWE? ActualStrengthUnit { get; }
    public ICollection<ST>? SubstanceLotNumber { get; }
    public ICollection<DTM>? SubstanceExpirationDate { get; }
    public ICollection<CWE>? SubstanceManufacturerName { get; }
    public ICollection<CWE>? Indication { get; }
    public NM? DispensePackageSize { get; }
    public CWE? DispensePackageSizeUnit { get; }
    public ID? DispensePackageMethod { get; }
    public ICollection<CWE>? SupplementaryCode { get; }
    public CWE? InitiatingLocation { get; }
    public CWE? PackagingAssemblyLocation { get; }
    public NM? ActualDrugStrengthVolume { get; }
    public CWE? ActualDrugStrengthVolumeUnits { get; }
    public CWE? DispensetoPharmacy { get; }
    public XAD? DispensetoPharmacyAddress { get; }
    public ID? PharmacyOrderType { get; }
    public CWE? DispenseType { get; }
    public ICollection<XTN>? PharmacyPhoneNumber { get; }
    public ICollection<EI>? DispenseTagIdentifier { get; }

    public RXD(Segment segment) : base(typeof(RXD), segment) {
        this.DispenseSubIDCounter = segment.GetRequiredField<NM>(1);
        this.DispenseGiveCode = segment.GetRequiredField<CWE>(2);
        this.DateTimeDispensed = segment.GetRequiredField<DTM>(3);
        this.ActualDispenseAmount = segment.GetRequiredField<NM>(4);
        this.ActualDispenseUnits = segment.GetField<CWE>(5);
        this.ActualDosageForm = segment.GetField<CWE>(6);
        this.PrescriptionNumber = segment.GetRequiredField<ST>(7);
        this.NumberofRefillsRemaining = segment.GetField<NM>(8);
        this.DispenseNotes = segment.GetRepField<ST>(9);
        this.DispensingProvider = segment.GetRepField<XCN>(10);
        this.SubstitutionStatus = segment.GetField<ID>(11);
        this.TotalDailyDose = segment.GetField<CQ>(12);
        this.DispensetoLocation = segment.GetField<ST>(13);
        this.NeedsHumanReview = segment.GetField<ID>(14);
        this.SpecialDispensingInstructions = segment.GetRepField<CWE>(15);
        this.ActualStrength = segment.GetField<NM>(16);
        this.ActualStrengthUnit = segment.GetField<CWE>(17);
        this.SubstanceLotNumber = segment.GetRepField<ST>(18);
        this.SubstanceExpirationDate = segment.GetRepField<DTM>(19);
        this.SubstanceManufacturerName = segment.GetRepField<CWE>(20);
        this.Indication = segment.GetRepField<CWE>(21);
        this.DispensePackageSize = segment.GetField<NM>(22);
        this.DispensePackageSizeUnit = segment.GetField<CWE>(23);
        this.DispensePackageMethod = segment.GetField<ID>(24);
        this.SupplementaryCode = segment.GetRepField<CWE>(25);
        this.InitiatingLocation = segment.GetField<CWE>(26);
        this.PackagingAssemblyLocation = segment.GetField<CWE>(27);
        this.ActualDrugStrengthVolume = segment.GetField<NM>(28);
        this.ActualDrugStrengthVolumeUnits = segment.GetField<CWE>(29);
        this.DispensetoPharmacy = segment.GetField<CWE>(30);
        this.DispensetoPharmacyAddress = segment.GetField<XAD>(31);
        this.PharmacyOrderType = segment.GetField<ID>(32);
        this.DispenseType = segment.GetField<CWE>(33);
        this.PharmacyPhoneNumber = segment.GetRepField<XTN>(34);
        this.DispenseTagIdentifier = segment.GetRepField<EI>(35);
    }
}

public sealed record RXE : Hl7Segment {
    public ST? QuantityTiming { get; }
    public CWE GiveCode { get; }
    public NM GiveAmountMinimum { get; }
    public NM? GiveAmountMaximum { get; }
    public CWE GiveUnits { get; }
    public CWE? GiveDosageForm { get; }
    public ICollection<CWE>? ProvidersAdministrationInstructions { get; }
    public ST? DeliverToLocation { get; }
    public ID? SubstitutionStatus { get; }
    public NM? DispenseAmount { get; }
    public CWE? DispenseUnits { get; }
    public NM? NumberOfRefills { get; }
    public ICollection<XCN>? OrderingProvidersDEANumber { get; }
    public ICollection<XCN>? PharmacistTreatmentSuppliersVerifierID { get; }
    public ST? PrescriptionNumber { get; }
    public NM? NumberofRefillsRemaining { get; }
    public NM? NumberofRefillsDosesDispensed { get; }
    public DTM? DTofMostRecentRefillorDoseDispensed { get; }
    public CQ? TotalDailyDose { get; }
    public ID? NeedsHumanReview { get; }
    public ICollection<CWE>? SpecialDispensingInstructions { get; }
    public ST? GivePer { get; }
    public ST? GiveRateAmount { get; }
    public CWE? GiveRateUnits { get; }
    public NM? GiveStrength { get; }
    public CWE? GiveStrengthUnits { get; }
    public ICollection<CWE>? GiveIndication { get; }
    public NM? DispensePackageSize { get; }
    public CWE? DispensePackageSizeUnit { get; }
    public ID? DispensePackageMethod { get; }
    public ICollection<CWE>? SupplementaryCode { get; }
    public DTM? OriginalOrderDateTime { get; }
    public NM? GiveDrugStrengthVolume { get; }
    public CWE? GiveDrugStrengthVolumeUnits { get; }
    public CWE? ControlledSubstanceSchedule { get; }
    public ID? FormularyStatus { get; }
    public ICollection<CWE>? PharmaceuticalSubstanceAlternative { get; }
    public CWE? PharmacyofMostRecentFill { get; }
    public NM? InitialDispenseAmount { get; }
    public CWE? DispensingPharmacy { get; }
    public XAD? DispensingPharmacyAddress { get; }
    public PL? DelivertoPatientLocation { get; }
    public XAD? DelivertoAddress { get; }
    public ID? PharmacyOrderType { get; }
    public ICollection<XTN>? PharmacyPhoneNumber { get; }

    public RXE(Segment segment) : base(typeof(RXE), segment) {
        this.QuantityTiming = segment.GetField<ST>(1);
        this.GiveCode = segment.GetRequiredField<CWE>(2);
        this.GiveAmountMinimum = segment.GetRequiredField<NM>(3);
        this.GiveAmountMaximum = segment.GetField<NM>(4);
        this.GiveUnits = segment.GetRequiredField<CWE>(5);
        this.GiveDosageForm = segment.GetField<CWE>(6);
        this.ProvidersAdministrationInstructions = segment.GetRepField<CWE>(7);
        this.DeliverToLocation = segment.GetField<ST>(8);
        this.SubstitutionStatus = segment.GetField<ID>(9);
        this.DispenseAmount = segment.GetField<NM>(10);
        this.DispenseUnits = segment.GetField<CWE>(11);
        this.NumberOfRefills = segment.GetField<NM>(12);
        this.OrderingProvidersDEANumber = segment.GetRepField<XCN>(13);
        this.PharmacistTreatmentSuppliersVerifierID = segment.GetRepField<XCN>(14);
        this.PrescriptionNumber = segment.GetField<ST>(15);
        this.NumberofRefillsRemaining = segment.GetField<NM>(16);
        this.NumberofRefillsDosesDispensed = segment.GetField<NM>(17);
        this.DTofMostRecentRefillorDoseDispensed = segment.GetField<DTM>(18);
        this.TotalDailyDose = segment.GetField<CQ>(19);
        this.NeedsHumanReview = segment.GetField<ID>(20);
        this.SpecialDispensingInstructions = segment.GetRepField<CWE>(21);
        this.GivePer = segment.GetField<ST>(22);
        this.GiveRateAmount = segment.GetField<ST>(23);
        this.GiveRateUnits = segment.GetField<CWE>(24);
        this.GiveStrength = segment.GetField<NM>(25);
        this.GiveStrengthUnits = segment.GetField<CWE>(26);
        this.GiveIndication = segment.GetRepField<CWE>(27);
        this.DispensePackageSize = segment.GetField<NM>(28);
        this.DispensePackageSizeUnit = segment.GetField<CWE>(29);
        this.DispensePackageMethod = segment.GetField<ID>(30);
        this.SupplementaryCode = segment.GetRepField<CWE>(31);
        this.OriginalOrderDateTime = segment.GetField<DTM>(32);
        this.GiveDrugStrengthVolume = segment.GetField<NM>(33);
        this.GiveDrugStrengthVolumeUnits = segment.GetField<CWE>(34);
        this.ControlledSubstanceSchedule = segment.GetField<CWE>(35);
        this.FormularyStatus = segment.GetField<ID>(36);
        this.PharmaceuticalSubstanceAlternative = segment.GetRepField<CWE>(37);
        this.PharmacyofMostRecentFill = segment.GetField<CWE>(38);
        this.InitialDispenseAmount = segment.GetField<NM>(39);
        this.DispensingPharmacy = segment.GetField<CWE>(40);
        this.DispensingPharmacyAddress = segment.GetField<XAD>(41);
        this.DelivertoPatientLocation = segment.GetField<PL>(42);
        this.DelivertoAddress = segment.GetField<XAD>(43);
        this.PharmacyOrderType = segment.GetField<ID>(44);
        this.PharmacyPhoneNumber = segment.GetRepField<XTN>(45);
    }
}

public sealed record RXG : Hl7Segment {
    public NM GiveSubIDCounter { get; }
    public NM? DispenseSubIDCounter { get; }
    public ST? QuantityTiming { get; }
    public CWE GiveCode { get; }
    public NM GiveAmountMinimum { get; }
    public NM? GiveAmountMaximum { get; }
    public CWE GiveUnits { get; }
    public CWE? GiveDosageForm { get; }
    public ICollection<CWE>? AdministrationNotes { get; }
    public ID? SubstitutionStatus { get; }
    public ST? DispensetoLocation { get; }
    public ID? NeedsHumanReview { get; }
    public ICollection<CWE>? SpecialAdministrationInstructions { get; }
    public ST? GivePer { get; }
    public ST? GiveRateAmount { get; }
    public CWE? GiveRateUnits { get; }
    public NM? GiveStrength { get; }
    public CWE? GiveStrengthUnits { get; }
    public ICollection<ST>? SubstanceLotNumber { get; }
    public ICollection<DTM>? SubstanceExpirationDate { get; }
    public ICollection<CWE>? SubstanceManufacturerName { get; }
    public ICollection<CWE>? Indication { get; }
    public NM? GiveDrugStrengthVolume { get; }
    public CWE? GiveDrugStrengthVolumeUnits { get; }
    public CWE? GiveBarcodeIdentifier { get; }
    public ID? PharmacyOrderType { get; }
    public CWE? DispensetoPharmacy { get; }
    public XAD? DispensetoPharmacyAddress { get; }
    public PL? DelivertoPatientLocation { get; }
    public XAD? DelivertoAddress { get; }
    public ICollection<EI>? GiveTagIdentifier { get; }
    public NM? DispenseAmount { get; }
    public CWE? DispenseUnits { get; }

    public RXG(Segment segment) : base(typeof(RXG), segment) {
        this.GiveSubIDCounter = segment.GetRequiredField<NM>(1);
        this.DispenseSubIDCounter = segment.GetField<NM>(2);
        this.QuantityTiming = segment.GetField<ST>(3);
        this.GiveCode = segment.GetRequiredField<CWE>(4);
        this.GiveAmountMinimum = segment.GetRequiredField<NM>(5);
        this.GiveAmountMaximum = segment.GetField<NM>(6);
        this.GiveUnits = segment.GetRequiredField<CWE>(7);
        this.GiveDosageForm = segment.GetField<CWE>(8);
        this.AdministrationNotes = segment.GetRepField<CWE>(9);
        this.SubstitutionStatus = segment.GetField<ID>(10);
        this.DispensetoLocation = segment.GetField<ST>(11);
        this.NeedsHumanReview = segment.GetField<ID>(12);
        this.SpecialAdministrationInstructions = segment.GetRepField<CWE>(13);
        this.GivePer = segment.GetField<ST>(14);
        this.GiveRateAmount = segment.GetField<ST>(15);
        this.GiveRateUnits = segment.GetField<CWE>(16);
        this.GiveStrength = segment.GetField<NM>(17);
        this.GiveStrengthUnits = segment.GetField<CWE>(18);
        this.SubstanceLotNumber = segment.GetRepField<ST>(19);
        this.SubstanceExpirationDate = segment.GetRepField<DTM>(20);
        this.SubstanceManufacturerName = segment.GetRepField<CWE>(21);
        this.Indication = segment.GetRepField<CWE>(22);
        this.GiveDrugStrengthVolume = segment.GetField<NM>(23);
        this.GiveDrugStrengthVolumeUnits = segment.GetField<CWE>(24);
        this.GiveBarcodeIdentifier = segment.GetField<CWE>(25);
        this.PharmacyOrderType = segment.GetField<ID>(26);
        this.DispensetoPharmacy = segment.GetField<CWE>(27);
        this.DispensetoPharmacyAddress = segment.GetField<XAD>(28);
        this.DelivertoPatientLocation = segment.GetField<PL>(29);
        this.DelivertoAddress = segment.GetField<XAD>(30);
        this.GiveTagIdentifier = segment.GetRepField<EI>(31);
        this.DispenseAmount = segment.GetField<NM>(32);
        this.DispenseUnits = segment.GetField<CWE>(33);
    }
}

public sealed record RXO : Hl7Segment {
    public CWE? RequestedGiveCode { get; }
    public NM? RequestedGiveAmountMinimum { get; }
    public NM? RequestedGiveAmountMaximum { get; }
    public CWE? RequestedGiveUnits { get; }
    public CWE? RequestedDosageForm { get; }
    public ICollection<CWE>? ProvidersPharmacyTreatmentInstructions { get; }
    public ICollection<CWE>? ProvidersAdministrationInstructions { get; }
    public ST? DeliverToLocation { get; }
    public ID? AllowSubstitutions { get; }
    public CWE? RequestedDispenseCode { get; }
    public NM? RequestedDispenseAmount { get; }
    public CWE? RequestedDispenseUnits { get; }
    public NM? NumberOfRefills { get; }
    public XCN? OrderingProvidersDEANumber { get; }
    public XCN? PharmacistTreatmentSuppliersVerifierID { get; }
    public ID? NeedsHumanReview { get; }
    public ST? RequestedGivePer { get; }
    public NM? RequestedGiveStrength { get; }
    public CWE? RequestedGiveStrengthUnits { get; }
    public ICollection<CWE>? Indication { get; }
    public ST? RequestedGiveRateAmount { get; }
    public CWE? RequestedGiveRateUnits { get; }
    public CQ? TotalDailyDose { get; }
    public ICollection<CWE>? SupplementaryCode { get; }
    public NM? RequestedDrugStrengthVolume { get; }
    public CWE? RequestedDrugStrengthVolumeUnits { get; }
    public ID? PharmacyOrderType { get; }
    public NM? DispensingInterval { get; }
    public EI? MedicationInstanceIdentifier { get; }
    public EI? SegmentInstanceIdentifier { get; }
    public CNE? MoodCode { get; }
    public CWE? DispensingPharmacy { get; }
    public XAD? DispensingPharmacyAddress { get; }
    public PL? DelivertoPatientLocation { get; }
    public XAD? DelivertoAddress { get; }
    public ICollection<XTN>? PharmacyPhoneNumber { get; }

    public RXO(Segment segment) : base(typeof(RXO), segment) {
        this.RequestedGiveCode = segment.GetField<CWE>(1);
        this.RequestedGiveAmountMinimum = segment.GetField<NM>(2);
        this.RequestedGiveAmountMaximum = segment.GetField<NM>(3);
        this.RequestedGiveUnits = segment.GetField<CWE>(4);
        this.RequestedDosageForm = segment.GetField<CWE>(5);
        this.ProvidersPharmacyTreatmentInstructions = segment.GetRepField<CWE>(6);
        this.ProvidersAdministrationInstructions = segment.GetRepField<CWE>(7);
        this.DeliverToLocation = segment.GetField<ST>(8);
        this.AllowSubstitutions = segment.GetField<ID>(9);
        this.RequestedDispenseCode = segment.GetField<CWE>(10);
        this.RequestedDispenseAmount = segment.GetField<NM>(11);
        this.RequestedDispenseUnits = segment.GetField<CWE>(12);
        this.NumberOfRefills = segment.GetField<NM>(13);
        this.OrderingProvidersDEANumber = segment.GetField<XCN>(14);
        this.PharmacistTreatmentSuppliersVerifierID = segment.GetField<XCN>(15);
        this.NeedsHumanReview = segment.GetField<ID>(16);
        this.RequestedGivePer = segment.GetField<ST>(17);
        this.RequestedGiveStrength = segment.GetField<NM>(18);
        this.RequestedGiveStrengthUnits = segment.GetField<CWE>(19);
        this.Indication = segment.GetRepField<CWE>(20);
        this.RequestedGiveRateAmount = segment.GetField<ST>(21);
        this.RequestedGiveRateUnits = segment.GetField<CWE>(22);
        this.TotalDailyDose = segment.GetField<CQ>(23);
        this.SupplementaryCode = segment.GetRepField<CWE>(24);
        this.RequestedDrugStrengthVolume = segment.GetField<NM>(25);
        this.RequestedDrugStrengthVolumeUnits = segment.GetField<CWE>(26);
        this.PharmacyOrderType = segment.GetField<ID>(27);
        this.DispensingInterval = segment.GetField<NM>(28);
        this.MedicationInstanceIdentifier = segment.GetField<EI>(29);
        this.SegmentInstanceIdentifier = segment.GetField<EI>(30);
        this.MoodCode = segment.GetField<CNE>(31);
        this.DispensingPharmacy = segment.GetField<CWE>(32);
        this.DispensingPharmacyAddress = segment.GetField<XAD>(33);
        this.DelivertoPatientLocation = segment.GetField<PL>(34);
        this.DelivertoAddress = segment.GetField<XAD>(35);
        this.PharmacyPhoneNumber = segment.GetRepField<XTN>(36);
    }
}

public sealed record RXR : Hl7Segment {
    public CWE Route { get; }
    public CWE? AdministrationSite { get; }
    public CWE? AdministrationDevice { get; }
    public CWE? AdministrationMethod { get; }
    public CWE? RoutingInstruction { get; }
    public CWE? AdministrationSiteModifier { get; }

    public RXR(Segment segment) : base(typeof(RXR), segment) {
        this.Route = segment.GetRequiredField<CWE>(1);
        this.AdministrationSite = segment.GetField<CWE>(2);
        this.AdministrationDevice = segment.GetField<CWE>(3);
        this.AdministrationMethod = segment.GetField<CWE>(4);
        this.RoutingInstruction = segment.GetField<CWE>(5);
        this.AdministrationSiteModifier = segment.GetField<CWE>(6);
    }
}

public sealed record RXV : Hl7Segment {
    public SI? SetIDRXV { get; }
    public ID BolusType { get; }
    public NM? BolusDoseAmount { get; }
    public CWE? BolusDoseAmountUnits { get; }
    public NM? BolusDoseVolume { get; }
    public CWE? BolusDoseVolumeUnits { get; }
    public ID PCAType { get; }
    public NM? PCADoseAmount { get; }
    public CWE? PCADoseAmountUnits { get; }
    public NM? PCADoseAmountVolume { get; }
    public CWE? PCADoseAmountVolumeUnits { get; }
    public NM? MaxDoseAmount { get; }
    public CWE? MaxDoseAmountUnits { get; }
    public NM? MaxDoseAmountVolume { get; }
    public CWE? MaxDoseAmountVolumeUnits { get; }
    public CQ MaxDoseperTime { get; }
    public CQ? LockoutInterval { get; }
    public CWE? SyringeManufacturer { get; }
    public CWE? SyringeModelNumber { get; }
    public NM? SyringeSize { get; }
    public CWE? SyringeSizeUnits { get; }
    public ID? ActionCode { get; }

    public RXV(Segment segment) : base(typeof(RXV), segment) {
        this.SetIDRXV = segment.GetField<SI>(1);
        this.BolusType = segment.GetRequiredField<ID>(2);
        this.BolusDoseAmount = segment.GetField<NM>(3);
        this.BolusDoseAmountUnits = segment.GetField<CWE>(4);
        this.BolusDoseVolume = segment.GetField<NM>(5);
        this.BolusDoseVolumeUnits = segment.GetField<CWE>(6);
        this.PCAType = segment.GetRequiredField<ID>(7);
        this.PCADoseAmount = segment.GetField<NM>(8);
        this.PCADoseAmountUnits = segment.GetField<CWE>(9);
        this.PCADoseAmountVolume = segment.GetField<NM>(10);
        this.PCADoseAmountVolumeUnits = segment.GetField<CWE>(11);
        this.MaxDoseAmount = segment.GetField<NM>(12);
        this.MaxDoseAmountUnits = segment.GetField<CWE>(13);
        this.MaxDoseAmountVolume = segment.GetField<NM>(14);
        this.MaxDoseAmountVolumeUnits = segment.GetField<CWE>(15);
        this.MaxDoseperTime = segment.GetRequiredField<CQ>(16);
        this.LockoutInterval = segment.GetField<CQ>(17);
        this.SyringeManufacturer = segment.GetField<CWE>(18);
        this.SyringeModelNumber = segment.GetField<CWE>(19);
        this.SyringeSize = segment.GetField<NM>(20);
        this.SyringeSizeUnits = segment.GetField<CWE>(21);
        this.ActionCode = segment.GetField<ID>(22);
    }
}

public sealed record SAC : Hl7Segment {
    public EI? ExternalAccessionIdentifier { get; }
    public EI? AccessionIdentifier { get; }
    public EI? ContainerIdentifier { get; }
    public EI? Primary { get; }
    public EI? EquipmentContainerIdentifier { get; }
    public ST? SpecimenSource { get; }
    public DTM? RegistrationDateTime { get; }
    public CWE? ContainerStatus { get; }
    public CWE? CarrierType { get; }
    public EI? CarrierIdentifier { get; }
    public NA? PositioninCarrier { get; }
    public CWE? TrayTypeSAC { get; }
    public EI? TrayIdentifier { get; }
    public NA? PositioninTray { get; }
    public ICollection<CWE>? Location { get; }
    public NM? ContainerHeight { get; }
    public NM? ContainerDiameter { get; }
    public NM? BarrierDelta { get; }
    public NM? BottomDelta { get; }
    public CWE? ContainerHeightDiameterDeltaUnits { get; }
    public NM? ContainerVolume { get; }
    public NM? AvailableSpecimenVolume { get; }
    public NM? InitialSpecimenVolume { get; }
    public CWE? VolumeUnits { get; }
    public CWE? SeparatorType { get; }
    public CWE? CapType { get; }
    public ICollection<CWE>? Additive { get; }
    public CWE? SpecimenComponent { get; }
    public SN? DilutionFactor { get; }
    public CWE? Treatment { get; }
    public SN? Temperature { get; }
    public NM? HemolysisIndex { get; }
    public CWE? HemolysisIndexUnits { get; }
    public NM? LipemiaIndex { get; }
    public CWE? LipemiaIndexUnits { get; }
    public NM? IcterusIndex { get; }
    public CWE? IcterusIndexUnits { get; }
    public NM? FibrinIndex { get; }
    public CWE? FibrinIndexUnits { get; }
    public ICollection<CWE>? SystemInducedContaminants { get; }
    public ICollection<CWE>? DrugInterference { get; }
    public CWE? ArtificialBlood { get; }
    public ICollection<CWE>? SpecialHandlingCode { get; }
    public ICollection<CWE>? OtherEnvironmentalFactors { get; }
    public CQ? ContainerLength { get; }
    public CQ? ContainerWidth { get; }
    public CWE? ContainerForm { get; }
    public CWE? ContainerMaterial { get; }
    public CWE? ContainerCommonName { get; }

    public SAC(Segment segment) : base(typeof(SAC), segment) {
        this.ExternalAccessionIdentifier = segment.GetField<EI>(1);
        this.AccessionIdentifier = segment.GetField<EI>(2);
        this.ContainerIdentifier = segment.GetField<EI>(3);
        this.Primary = segment.GetField<EI>(4);
        this.EquipmentContainerIdentifier = segment.GetField<EI>(5);
        this.SpecimenSource = segment.GetField<ST>(6);
        this.RegistrationDateTime = segment.GetField<DTM>(7);
        this.ContainerStatus = segment.GetField<CWE>(8);
        this.CarrierType = segment.GetField<CWE>(9);
        this.CarrierIdentifier = segment.GetField<EI>(10);
        this.PositioninCarrier = segment.GetField<NA>(11);
        this.TrayTypeSAC = segment.GetField<CWE>(12);
        this.TrayIdentifier = segment.GetField<EI>(13);
        this.PositioninTray = segment.GetField<NA>(14);
        this.Location = segment.GetRepField<CWE>(15);
        this.ContainerHeight = segment.GetField<NM>(16);
        this.ContainerDiameter = segment.GetField<NM>(17);
        this.BarrierDelta = segment.GetField<NM>(18);
        this.BottomDelta = segment.GetField<NM>(19);
        this.ContainerHeightDiameterDeltaUnits = segment.GetField<CWE>(20);
        this.ContainerVolume = segment.GetField<NM>(21);
        this.AvailableSpecimenVolume = segment.GetField<NM>(22);
        this.InitialSpecimenVolume = segment.GetField<NM>(23);
        this.VolumeUnits = segment.GetField<CWE>(24);
        this.SeparatorType = segment.GetField<CWE>(25);
        this.CapType = segment.GetField<CWE>(26);
        this.Additive = segment.GetRepField<CWE>(27);
        this.SpecimenComponent = segment.GetField<CWE>(28);
        this.DilutionFactor = segment.GetField<SN>(29);
        this.Treatment = segment.GetField<CWE>(30);
        this.Temperature = segment.GetField<SN>(31);
        this.HemolysisIndex = segment.GetField<NM>(32);
        this.HemolysisIndexUnits = segment.GetField<CWE>(33);
        this.LipemiaIndex = segment.GetField<NM>(34);
        this.LipemiaIndexUnits = segment.GetField<CWE>(35);
        this.IcterusIndex = segment.GetField<NM>(36);
        this.IcterusIndexUnits = segment.GetField<CWE>(37);
        this.FibrinIndex = segment.GetField<NM>(38);
        this.FibrinIndexUnits = segment.GetField<CWE>(39);
        this.SystemInducedContaminants = segment.GetRepField<CWE>(40);
        this.DrugInterference = segment.GetRepField<CWE>(41);
        this.ArtificialBlood = segment.GetField<CWE>(42);
        this.SpecialHandlingCode = segment.GetRepField<CWE>(43);
        this.OtherEnvironmentalFactors = segment.GetRepField<CWE>(44);
        this.ContainerLength = segment.GetField<CQ>(45);
        this.ContainerWidth = segment.GetField<CQ>(46);
        this.ContainerForm = segment.GetField<CWE>(47);
        this.ContainerMaterial = segment.GetField<CWE>(48);
        this.ContainerCommonName = segment.GetField<CWE>(49);
    }
}

public sealed record SCD : Hl7Segment {
    public TM? CycleStartTime { get; }
    public NM? CycleCount { get; }
    public CQ? TempMax { get; }
    public CQ? TempMin { get; }
    public NM? LoadNumber { get; }
    public CQ? ConditionTime { get; }
    public CQ? SterilizeTime { get; }
    public CQ? ExhaustTime { get; }
    public CQ? TotalCycleTime { get; }
    public CWE? DeviceStatus { get; }
    public DTM? CycleStartDateTime { get; }
    public CQ? DryTime { get; }
    public CQ? LeakRate { get; }
    public CQ? ControlTemperature { get; }
    public CQ? SterilizerTemperature { get; }
    public TM? CycleCompleteTime { get; }
    public CQ? UnderTemperature { get; }
    public CQ? OverTemperature { get; }
    public CNE? AbortCycle { get; }
    public CNE? Alarm { get; }
    public CNE? LonginChargePhase { get; }
    public CNE? LonginExhaustPhase { get; }
    public CNE? LonginFastExhaustPhase { get; }
    public CNE? Reset { get; }
    public XCN? OperatorUnload { get; }
    public CNE? DoorOpen { get; }
    public CNE? ReadingFailure { get; }
    public CWE? CycleType { get; }
    public CQ? ThermalRinseTime { get; }
    public CQ? WashTime { get; }
    public CQ? InjectionRate { get; }
    public CNE? ProcedureCode { get; }
    public ICollection<CX>? PatientIdentifierList { get; }
    public XCN? AttendingDoctor { get; }
    public SN? DilutionFactor { get; }
    public CQ? FillTime { get; }
    public CQ? InletTemperature { get; }

    public SCD(Segment segment) : base(typeof(SCD), segment) {
        this.CycleStartTime = segment.GetField<TM>(1);
        this.CycleCount = segment.GetField<NM>(2);
        this.TempMax = segment.GetField<CQ>(3);
        this.TempMin = segment.GetField<CQ>(4);
        this.LoadNumber = segment.GetField<NM>(5);
        this.ConditionTime = segment.GetField<CQ>(6);
        this.SterilizeTime = segment.GetField<CQ>(7);
        this.ExhaustTime = segment.GetField<CQ>(8);
        this.TotalCycleTime = segment.GetField<CQ>(9);
        this.DeviceStatus = segment.GetField<CWE>(10);
        this.CycleStartDateTime = segment.GetField<DTM>(11);
        this.DryTime = segment.GetField<CQ>(12);
        this.LeakRate = segment.GetField<CQ>(13);
        this.ControlTemperature = segment.GetField<CQ>(14);
        this.SterilizerTemperature = segment.GetField<CQ>(15);
        this.CycleCompleteTime = segment.GetField<TM>(16);
        this.UnderTemperature = segment.GetField<CQ>(17);
        this.OverTemperature = segment.GetField<CQ>(18);
        this.AbortCycle = segment.GetField<CNE>(19);
        this.Alarm = segment.GetField<CNE>(20);
        this.LonginChargePhase = segment.GetField<CNE>(21);
        this.LonginExhaustPhase = segment.GetField<CNE>(22);
        this.LonginFastExhaustPhase = segment.GetField<CNE>(23);
        this.Reset = segment.GetField<CNE>(24);
        this.OperatorUnload = segment.GetField<XCN>(25);
        this.DoorOpen = segment.GetField<CNE>(26);
        this.ReadingFailure = segment.GetField<CNE>(27);
        this.CycleType = segment.GetField<CWE>(28);
        this.ThermalRinseTime = segment.GetField<CQ>(29);
        this.WashTime = segment.GetField<CQ>(30);
        this.InjectionRate = segment.GetField<CQ>(31);
        this.ProcedureCode = segment.GetField<CNE>(32);
        this.PatientIdentifierList = segment.GetRepField<CX>(33);
        this.AttendingDoctor = segment.GetField<XCN>(34);
        this.DilutionFactor = segment.GetField<SN>(35);
        this.FillTime = segment.GetField<CQ>(36);
        this.InletTemperature = segment.GetField<CQ>(37);
    }
}

public sealed record SCH : Hl7Segment {
    public EI? PlacerAppointmentID { get; }
    public EI? FillerAppointmentID { get; }
    public NM? OccurrenceNumber { get; }
    public EI? PlacerOrderGroupNumber { get; }
    public CWE? ScheduleID { get; }
    public CWE EventReason { get; }
    public CWE? AppointmentReason { get; }
    public CWE? AppointmentType { get; }
    public NM? AppointmentDuration { get; }
    public CNE? AppointmentDurationUnits { get; }
    public ST? AppointmentTimingQuantity { get; }
    public ICollection<XCN>? PlacerContactPerson { get; }
    public XTN? PlacerContactPhoneNumber { get; }
    public ICollection<XAD>? PlacerContactAddress { get; }
    public PL? PlacerContactLocation { get; }
    public ICollection<XCN> FillerContactPerson { get; }
    public XTN? FillerContactPhoneNumber { get; }
    public ICollection<XAD>? FillerContactAddress { get; }
    public PL? FillerContactLocation { get; }
    public ICollection<XCN> EnteredByPerson { get; }
    public ICollection<XTN>? EnteredByPhoneNumber { get; }
    public PL? EnteredByLocation { get; }
    public EI? ParentPlacerAppointmentID { get; }
    public EI? ParentFillerAppointmentID { get; }
    public CWE? FillerStatusCode { get; }
    public EI? PlacerOrderNumber { get; }
    public EI? FillerOrderNumber { get; }
    public EIP? AlternatePlacerOrderGroupNumber { get; }

    public SCH(Segment segment) : base(typeof(SCH), segment) {
        this.PlacerAppointmentID = segment.GetField<EI>(1);
        this.FillerAppointmentID = segment.GetField<EI>(2);
        this.OccurrenceNumber = segment.GetField<NM>(3);
        this.PlacerOrderGroupNumber = segment.GetField<EI>(4);
        this.ScheduleID = segment.GetField<CWE>(5);
        this.EventReason = segment.GetRequiredField<CWE>(6);
        this.AppointmentReason = segment.GetField<CWE>(7);
        this.AppointmentType = segment.GetField<CWE>(8);
        this.AppointmentDuration = segment.GetField<NM>(9);
        this.AppointmentDurationUnits = segment.GetField<CNE>(10);
        this.AppointmentTimingQuantity = segment.GetField<ST>(11);
        this.PlacerContactPerson = segment.GetRepField<XCN>(12);
        this.PlacerContactPhoneNumber = segment.GetField<XTN>(13);
        this.PlacerContactAddress = segment.GetRepField<XAD>(14);
        this.PlacerContactLocation = segment.GetField<PL>(15);
        this.FillerContactPerson = segment.GetRequiredRepField<XCN>(16);
        this.FillerContactPhoneNumber = segment.GetField<XTN>(17);
        this.FillerContactAddress = segment.GetRepField<XAD>(18);
        this.FillerContactLocation = segment.GetField<PL>(19);
        this.EnteredByPerson = segment.GetRequiredRepField<XCN>(20);
        this.EnteredByPhoneNumber = segment.GetRepField<XTN>(21);
        this.EnteredByLocation = segment.GetField<PL>(22);
        this.ParentPlacerAppointmentID = segment.GetField<EI>(23);
        this.ParentFillerAppointmentID = segment.GetField<EI>(24);
        this.FillerStatusCode = segment.GetField<CWE>(25);
        this.PlacerOrderNumber = segment.GetField<EI>(26);
        this.FillerOrderNumber = segment.GetField<EI>(27);
        this.AlternatePlacerOrderGroupNumber = segment.GetField<EIP>(28);
    }
}

public sealed record SCP : Hl7Segment {
    public NM? NumberOfDecontaminationSterilizationDevices { get; }
    public CWE? LaborCalculationType { get; }
    public CWE? DateFormat { get; }
    public EI? DeviceNumber { get; }
    public ST? DeviceName { get; }
    public ST? DeviceModelName { get; }
    public CWE? DeviceType { get; }
    public CWE? LotControl { get; }

    public SCP(Segment segment) : base(typeof(SCP), segment) {
        this.NumberOfDecontaminationSterilizationDevices = segment.GetField<NM>(1);
        this.LaborCalculationType = segment.GetField<CWE>(2);
        this.DateFormat = segment.GetField<CWE>(3);
        this.DeviceNumber = segment.GetField<EI>(4);
        this.DeviceName = segment.GetField<ST>(5);
        this.DeviceModelName = segment.GetField<ST>(6);
        this.DeviceType = segment.GetField<CWE>(7);
        this.LotControl = segment.GetField<CWE>(8);
    }
}

public sealed record SDD : Hl7Segment {
    public EI? LotNumber { get; }
    public EI? DeviceNumber { get; }
    public ST? DeviceName { get; }
    public CWE? DeviceDataState { get; }
    public CWE? LoadStatus { get; }
    public NM? ControlCode { get; }
    public ST? OperatorName { get; }

    public SDD(Segment segment) : base(typeof(SDD), segment) {
        this.LotNumber = segment.GetField<EI>(1);
        this.DeviceNumber = segment.GetField<EI>(2);
        this.DeviceName = segment.GetField<ST>(3);
        this.DeviceDataState = segment.GetField<CWE>(4);
        this.LoadStatus = segment.GetField<CWE>(5);
        this.ControlCode = segment.GetField<NM>(6);
        this.OperatorName = segment.GetField<ST>(7);
    }
}

public sealed record SFT : Hl7Segment {
    public XON SoftwareVendorOrganization { get; }
    public ST SoftwareCertifiedVersionorReleaseNumber { get; }
    public ST SoftwareProductName { get; }
    public ST SoftwareBinaryID { get; }
    public TX? SoftwareProductInformation { get; }
    public DTM? SoftwareInstallDate { get; }

    public SFT(Segment segment) : base(typeof(SFT), segment) {
        this.SoftwareVendorOrganization = segment.GetRequiredField<XON>(1);
        this.SoftwareCertifiedVersionorReleaseNumber = segment.GetRequiredField<ST>(2);
        this.SoftwareProductName = segment.GetRequiredField<ST>(3);
        this.SoftwareBinaryID = segment.GetRequiredField<ST>(4);
        this.SoftwareProductInformation = segment.GetField<TX>(5);
        this.SoftwareInstallDate = segment.GetField<DTM>(6);
    }
}

public sealed record SGH : Hl7Segment {
    public SI SetIDSGH { get; }
    public ST? SegmentGroupName { get; }

    public SGH(Segment segment) : base(typeof(SGH), segment) {
        this.SetIDSGH = segment.GetRequiredField<SI>(1);
        this.SegmentGroupName = segment.GetField<ST>(2);
    }
}

public sealed record SGT : Hl7Segment {
    public SI SetIDSGT { get; }
    public ST? SegmentGroupName { get; }

    public SGT(Segment segment) : base(typeof(SGT), segment) {
        this.SetIDSGT = segment.GetRequiredField<SI>(1);
        this.SegmentGroupName = segment.GetField<ST>(2);
    }
}

public sealed record SHP : Hl7Segment {
    public EI ShipmentID { get; }
    public ICollection<EI>? InternalShipmentID { get; }
    public CWE? ShipmentStatus { get; }
    public DTM ShipmentStatusDateTime { get; }
    public TX? ShipmentStatusReason { get; }
    public CWE? ShipmentPriority { get; }
    public ICollection<CWE>? ShipmentConfidentiality { get; }
    public NM? NumberofPackagesinShipment { get; }
    public ICollection<CWE>? ShipmentCondition { get; }
    public ICollection<CWE>? ShipmentHandlingCode { get; }
    public ICollection<CWE>? ShipmentRiskCode { get; }
    public ID? ActionCode { get; }

    public SHP(Segment segment) : base(typeof(SHP), segment) {
        this.ShipmentID = segment.GetRequiredField<EI>(1);
        this.InternalShipmentID = segment.GetRepField<EI>(2);
        this.ShipmentStatus = segment.GetField<CWE>(3);
        this.ShipmentStatusDateTime = segment.GetRequiredField<DTM>(4);
        this.ShipmentStatusReason = segment.GetField<TX>(5);
        this.ShipmentPriority = segment.GetField<CWE>(6);
        this.ShipmentConfidentiality = segment.GetRepField<CWE>(7);
        this.NumberofPackagesinShipment = segment.GetField<NM>(8);
        this.ShipmentCondition = segment.GetRepField<CWE>(9);
        this.ShipmentHandlingCode = segment.GetRepField<CWE>(10);
        this.ShipmentRiskCode = segment.GetRepField<CWE>(11);
        this.ActionCode = segment.GetField<ID>(12);
    }
}

public sealed record SID : Hl7Segment {
    public CWE? ApplicationMethodIdentifier { get; }
    public ST? SubstanceLotNumber { get; }
    public ST? SubstanceContainerIdentifier { get; }
    public CWE? SubstanceManufacturerIdentifier { get; }

    public SID(Segment segment) : base(typeof(SID), segment) {
        this.ApplicationMethodIdentifier = segment.GetField<CWE>(1);
        this.SubstanceLotNumber = segment.GetField<ST>(2);
        this.SubstanceContainerIdentifier = segment.GetField<ST>(3);
        this.SubstanceManufacturerIdentifier = segment.GetField<CWE>(4);
    }
}

public sealed record SLT : Hl7Segment {
    public EI? DeviceNumber { get; }
    public ST? DeviceName { get; }
    public EI? LotNumber { get; }
    public EI? ItemIdentifier { get; }
    public ST? BarCode { get; }

    public SLT(Segment segment) : base(typeof(SLT), segment) {
        this.DeviceNumber = segment.GetField<EI>(1);
        this.DeviceName = segment.GetField<ST>(2);
        this.LotNumber = segment.GetField<EI>(3);
        this.ItemIdentifier = segment.GetField<EI>(4);
        this.BarCode = segment.GetField<ST>(5);
    }
}

public sealed record SPM : Hl7Segment {
    public SI? SetIDSPM { get; }
    public EIP? SpecimenIdentifier { get; }
    public ICollection<EIP>? SpecimenParentIDs { get; }
    public CWE SpecimenType { get; }
    public ICollection<CWE>? SpecimenTypeModifier { get; }
    public ICollection<CWE>? SpecimenAdditives { get; }
    public CWE? SpecimenCollectionMethod { get; }
    public CWE? SpecimenSourceSite { get; }
    public ICollection<CWE>? SpecimenSourceSiteModifier { get; }
    public CWE? SpecimenCollectionSite { get; }
    public ICollection<CWE>? SpecimenRole { get; }
    public CQ? SpecimenCollectionAmount { get; }
    public NM? GroupedSpecimenCount { get; }
    public ICollection<ST>? SpecimenDescription { get; }
    public ICollection<CWE>? SpecimenHandlingCode { get; }
    public ICollection<CWE>? SpecimenRiskCode { get; }
    public DR? SpecimenCollectionDateTime { get; }
    public DTM? SpecimenReceivedDateTime { get; }
    public DTM? SpecimenExpirationDateTime { get; }
    public ID? SpecimenAvailability { get; }
    public ICollection<CWE>? SpecimenRejectReason { get; }
    public CWE? SpecimenQuality { get; }
    public CWE? SpecimenAppropriateness { get; }
    public ICollection<CWE>? SpecimenCondition { get; }
    public CQ? SpecimenCurrentQuantity { get; }
    public NM? NumberofSpecimenContainers { get; }
    public CWE? ContainerType { get; }
    public CWE? ContainerCondition { get; }
    public CWE? SpecimenChildRole { get; }
    public ICollection<CX>? AccessionID { get; }
    public ICollection<CX>? OtherSpecimenID { get; }
    public EI? ShipmentID { get; }
    public DTM? CultureStartDateTime { get; }
    public DTM? CultureFinalDateTime { get; }
    public ID? ActionCode { get; }

    public SPM(Segment segment) : base(typeof(SPM), segment) {
        this.SetIDSPM = segment.GetField<SI>(1);
        this.SpecimenIdentifier = segment.GetField<EIP>(2);
        this.SpecimenParentIDs = segment.GetRepField<EIP>(3);
        this.SpecimenType = segment.GetRequiredField<CWE>(4);
        this.SpecimenTypeModifier = segment.GetRepField<CWE>(5);
        this.SpecimenAdditives = segment.GetRepField<CWE>(6);
        this.SpecimenCollectionMethod = segment.GetField<CWE>(7);
        this.SpecimenSourceSite = segment.GetField<CWE>(8);
        this.SpecimenSourceSiteModifier = segment.GetRepField<CWE>(9);
        this.SpecimenCollectionSite = segment.GetField<CWE>(10);
        this.SpecimenRole = segment.GetRepField<CWE>(11);
        this.SpecimenCollectionAmount = segment.GetField<CQ>(12);
        this.GroupedSpecimenCount = segment.GetField<NM>(13);
        this.SpecimenDescription = segment.GetRepField<ST>(14);
        this.SpecimenHandlingCode = segment.GetRepField<CWE>(15);
        this.SpecimenRiskCode = segment.GetRepField<CWE>(16);
        this.SpecimenCollectionDateTime = segment.GetField<DR>(17);
        this.SpecimenReceivedDateTime = segment.GetField<DTM>(18);
        this.SpecimenExpirationDateTime = segment.GetField<DTM>(19);
        this.SpecimenAvailability = segment.GetField<ID>(20);
        this.SpecimenRejectReason = segment.GetRepField<CWE>(21);
        this.SpecimenQuality = segment.GetField<CWE>(22);
        this.SpecimenAppropriateness = segment.GetField<CWE>(23);
        this.SpecimenCondition = segment.GetRepField<CWE>(24);
        this.SpecimenCurrentQuantity = segment.GetField<CQ>(25);
        this.NumberofSpecimenContainers = segment.GetField<NM>(26);
        this.ContainerType = segment.GetField<CWE>(27);
        this.ContainerCondition = segment.GetField<CWE>(28);
        this.SpecimenChildRole = segment.GetField<CWE>(29);
        this.AccessionID = segment.GetRepField<CX>(30);
        this.OtherSpecimenID = segment.GetRepField<CX>(31);
        this.ShipmentID = segment.GetField<EI>(32);
        this.CultureStartDateTime = segment.GetField<DTM>(33);
        this.CultureFinalDateTime = segment.GetField<DTM>(34);
        this.ActionCode = segment.GetField<ID>(35);
    }
}

public sealed record STF : Hl7Segment {
    public CWE? PrimaryKeyValueSTF { get; }
    public ICollection<CX>? StaffIdentifierList { get; }
    public ICollection<XPN>? StaffName { get; }
    public ICollection<CWE>? StaffType { get; }
    public CWE? AdministrativeSex { get; }
    public DTM? DateTimeofBirth { get; }
    public ID? ActiveInactiveFlag { get; }
    public ICollection<CWE>? Department { get; }
    public ICollection<CWE>? HospitalServiceSTF { get; }
    public ICollection<XTN>? Phone { get; }
    public ICollection<XAD>? OfficeHomeAddressBirthplace { get; }
    public ICollection<DIN>? InstitutionActivationDate { get; }
    public ICollection<DIN>? InstitutionInactivationDate { get; }
    public ICollection<CWE>? BackupPersonID { get; }
    public ICollection<ST>? EMailAddress { get; }
    public CWE? PreferredMethodofContact { get; }
    public CWE? MaritalStatus { get; }
    public ST? JobTitle { get; }
    public JCC? JobCodeClass { get; }
    public CWE? EmploymentStatusCode { get; }
    public ID? AdditionalInsuredonAuto { get; }
    public DLN? DriversLicenseNumberStaff { get; }
    public ID? CopyAutoIns { get; }
    public DT? AutoInsExpires { get; }
    public DT? DateLastDMVReview { get; }
    public DT? DateNextDMVReview { get; }
    public CWE? Race { get; }
    public CWE? EthnicGroup { get; }
    public ID? ReactivationApprovalIndicator { get; }
    public ICollection<CWE>? Citizenship { get; }
    public DTM? DateTimeofDeath { get; }
    public ID? DeathIndicator { get; }
    public CWE? InstitutionRelationshipTypeCode { get; }
    public DR? InstitutionRelationshipPeriod { get; }
    public DT? ExpectedReturnDate { get; }
    public ICollection<CWE>? CostCenterCode { get; }
    public ID? GenericClassificationIndicator { get; }
    public CWE? InactiveReasonCode { get; }
    public ICollection<CWE>? Genericresourcetypeorcategory { get; }
    public CWE? Religion { get; }
    public ED? Signature { get; }

    public STF(Segment segment) : base(typeof(STF), segment) {
        this.PrimaryKeyValueSTF = segment.GetField<CWE>(1);
        this.StaffIdentifierList = segment.GetRepField<CX>(2);
        this.StaffName = segment.GetRepField<XPN>(3);
        this.StaffType = segment.GetRepField<CWE>(4);
        this.AdministrativeSex = segment.GetField<CWE>(5);
        this.DateTimeofBirth = segment.GetField<DTM>(6);
        this.ActiveInactiveFlag = segment.GetField<ID>(7);
        this.Department = segment.GetRepField<CWE>(8);
        this.HospitalServiceSTF = segment.GetRepField<CWE>(9);
        this.Phone = segment.GetRepField<XTN>(10);
        this.OfficeHomeAddressBirthplace = segment.GetRepField<XAD>(11);
        this.InstitutionActivationDate = segment.GetRepField<DIN>(12);
        this.InstitutionInactivationDate = segment.GetRepField<DIN>(13);
        this.BackupPersonID = segment.GetRepField<CWE>(14);
        this.EMailAddress = segment.GetRepField<ST>(15);
        this.PreferredMethodofContact = segment.GetField<CWE>(16);
        this.MaritalStatus = segment.GetField<CWE>(17);
        this.JobTitle = segment.GetField<ST>(18);
        this.JobCodeClass = segment.GetField<JCC>(19);
        this.EmploymentStatusCode = segment.GetField<CWE>(20);
        this.AdditionalInsuredonAuto = segment.GetField<ID>(21);
        this.DriversLicenseNumberStaff = segment.GetField<DLN>(22);
        this.CopyAutoIns = segment.GetField<ID>(23);
        this.AutoInsExpires = segment.GetField<DT>(24);
        this.DateLastDMVReview = segment.GetField<DT>(25);
        this.DateNextDMVReview = segment.GetField<DT>(26);
        this.Race = segment.GetField<CWE>(27);
        this.EthnicGroup = segment.GetField<CWE>(28);
        this.ReactivationApprovalIndicator = segment.GetField<ID>(29);
        this.Citizenship = segment.GetRepField<CWE>(30);
        this.DateTimeofDeath = segment.GetField<DTM>(31);
        this.DeathIndicator = segment.GetField<ID>(32);
        this.InstitutionRelationshipTypeCode = segment.GetField<CWE>(33);
        this.InstitutionRelationshipPeriod = segment.GetField<DR>(34);
        this.ExpectedReturnDate = segment.GetField<DT>(35);
        this.CostCenterCode = segment.GetRepField<CWE>(36);
        this.GenericClassificationIndicator = segment.GetField<ID>(37);
        this.InactiveReasonCode = segment.GetField<CWE>(38);
        this.Genericresourcetypeorcategory = segment.GetRepField<CWE>(39);
        this.Religion = segment.GetField<CWE>(40);
        this.Signature = segment.GetField<ED>(41);
    }
}

public sealed record STZ : Hl7Segment {
    public CWE? SterilizationType { get; }
    public CWE? SterilizationCycle { get; }
    public CWE? MaintenanceCycle { get; }
    public CWE? MaintenanceType { get; }

    public STZ(Segment segment) : base(typeof(STZ), segment) {
        this.SterilizationType = segment.GetField<CWE>(1);
        this.SterilizationCycle = segment.GetField<CWE>(2);
        this.MaintenanceCycle = segment.GetField<CWE>(3);
        this.MaintenanceType = segment.GetField<CWE>(4);
    }
}

public sealed record TCC : Hl7Segment {
    public CWE UniversalServiceIdentifier { get; }
    public EI EquipmentTestApplicationIdentifier { get; }
    public ST? SpecimenSource { get; }
    public SN? AutoDilutionFactorDefault { get; }
    public SN? RerunDilutionFactorDefault { get; }
    public SN? PreDilutionFactorDefault { get; }
    public SN? EndogenousContentofPreDilutionDiluent { get; }
    public NM? InventoryLimitsWarningLevel { get; }
    public ID? AutomaticRerunAllowed { get; }
    public ID? AutomaticRepeatAllowed { get; }
    public ID? AutomaticReflexAllowed { get; }
    public SN? EquipmentDynamicRange { get; }
    public CWE? Units { get; }
    public CWE? ProcessingType { get; }
    public CWE? TestCriticality { get; }

    public TCC(Segment segment) : base(typeof(TCC), segment) {
        this.UniversalServiceIdentifier = segment.GetRequiredField<CWE>(1);
        this.EquipmentTestApplicationIdentifier = segment.GetRequiredField<EI>(2);
        this.SpecimenSource = segment.GetField<ST>(3);
        this.AutoDilutionFactorDefault = segment.GetField<SN>(4);
        this.RerunDilutionFactorDefault = segment.GetField<SN>(5);
        this.PreDilutionFactorDefault = segment.GetField<SN>(6);
        this.EndogenousContentofPreDilutionDiluent = segment.GetField<SN>(7);
        this.InventoryLimitsWarningLevel = segment.GetField<NM>(8);
        this.AutomaticRerunAllowed = segment.GetField<ID>(9);
        this.AutomaticRepeatAllowed = segment.GetField<ID>(10);
        this.AutomaticReflexAllowed = segment.GetField<ID>(11);
        this.EquipmentDynamicRange = segment.GetField<SN>(12);
        this.Units = segment.GetField<CWE>(13);
        this.ProcessingType = segment.GetField<CWE>(14);
        this.TestCriticality = segment.GetField<CWE>(15);
    }
}

public sealed record TCD : Hl7Segment {
    public CWE UniversalServiceIdentifier { get; }
    public SN? AutoDilutionFactor { get; }
    public SN? RerunDilutionFactor { get; }
    public SN? PreDilutionFactor { get; }
    public SN? EndogenousContentofPreDilutionDiluent { get; }
    public ID? AutomaticRepeatAllowed { get; }
    public ID? ReflexAllowed { get; }
    public CWE? AnalyteRepeatStatus { get; }
    public CQ? SpecimenConsumptionQuantity { get; }
    public NM? PoolSize { get; }
    public CWE? AutoDilutionType { get; }

    public TCD(Segment segment) : base(typeof(TCD), segment) {
        this.UniversalServiceIdentifier = segment.GetRequiredField<CWE>(1);
        this.AutoDilutionFactor = segment.GetField<SN>(2);
        this.RerunDilutionFactor = segment.GetField<SN>(3);
        this.PreDilutionFactor = segment.GetField<SN>(4);
        this.EndogenousContentofPreDilutionDiluent = segment.GetField<SN>(5);
        this.AutomaticRepeatAllowed = segment.GetField<ID>(6);
        this.ReflexAllowed = segment.GetField<ID>(7);
        this.AnalyteRepeatStatus = segment.GetField<CWE>(8);
        this.SpecimenConsumptionQuantity = segment.GetField<CQ>(9);
        this.PoolSize = segment.GetField<NM>(10);
        this.AutoDilutionType = segment.GetField<CWE>(11);
    }
}

public sealed record TQ1 : Hl7Segment {
    public SI? SetIDTQ1 { get; }
    public CQ? Quantity { get; }
    public ICollection<RPT>? RepeatPattern { get; }
    public ICollection<TM>? ExplicitTime { get; }
    public ICollection<CQ>? RelativeTimeandUnits { get; }
    public CQ? ServiceDuration { get; }
    public DTM? Startdatetime { get; }
    public DTM? Enddatetime { get; }
    public ICollection<CWE>? Priority { get; }
    public TX? Conditiontext { get; }
    public TX? Textinstruction { get; }
    public ID? Conjunction { get; }
    public CQ? Occurrenceduration { get; }
    public NM? Totaloccurrences { get; }

    public TQ1(Segment segment) : base(typeof(TQ1), segment) {
        this.SetIDTQ1 = segment.GetField<SI>(1);
        this.Quantity = segment.GetField<CQ>(2);
        this.RepeatPattern = segment.GetRepField<RPT>(3);
        this.ExplicitTime = segment.GetRepField<TM>(4);
        this.RelativeTimeandUnits = segment.GetRepField<CQ>(5);
        this.ServiceDuration = segment.GetField<CQ>(6);
        this.Startdatetime = segment.GetField<DTM>(7);
        this.Enddatetime = segment.GetField<DTM>(8);
        this.Priority = segment.GetRepField<CWE>(9);
        this.Conditiontext = segment.GetField<TX>(10);
        this.Textinstruction = segment.GetField<TX>(11);
        this.Conjunction = segment.GetField<ID>(12);
        this.Occurrenceduration = segment.GetField<CQ>(13);
        this.Totaloccurrences = segment.GetField<NM>(14);
    }
}

public sealed record TQ2 : Hl7Segment {
    public SI? SetIDTQ2 { get; }
    public ID? SequenceResultsFlag { get; }
    public EI? RelatedPlacerNumber { get; }
    public EI? RelatedFillerNumber { get; }
    public EI? RelatedPlacerGroupNumber { get; }
    public ID? SequenceConditionCode { get; }
    public ID? CyclicEntryExitIndicator { get; }
    public CQ? SequenceConditionTimeInterval { get; }
    public NM? CyclicGroupMaximumNumberofRepeats { get; }
    public ID? SpecialServiceRequestRelationship { get; }

    public TQ2(Segment segment) : base(typeof(TQ2), segment) {
        this.SetIDTQ2 = segment.GetField<SI>(1);
        this.SequenceResultsFlag = segment.GetField<ID>(2);
        this.RelatedPlacerNumber = segment.GetField<EI>(3);
        this.RelatedFillerNumber = segment.GetField<EI>(4);
        this.RelatedPlacerGroupNumber = segment.GetField<EI>(5);
        this.SequenceConditionCode = segment.GetField<ID>(6);
        this.CyclicEntryExitIndicator = segment.GetField<ID>(7);
        this.SequenceConditionTimeInterval = segment.GetField<CQ>(8);
        this.CyclicGroupMaximumNumberofRepeats = segment.GetField<NM>(9);
        this.SpecialServiceRequestRelationship = segment.GetField<ID>(10);
    }
}

public sealed record TXA : Hl7Segment {
    public SI SetIDTXA { get; }
    public CWE DocumentType { get; }
    public ID? DocumentContentPresentation { get; }
    public DTM? ActivityDateTime { get; }
    public XCN? PrimaryActivityProviderCodeName { get; }
    public DTM? OriginationDateTime { get; }
    public DTM? TranscriptionDateTime { get; }
    public ICollection<DTM>? EditDateTime { get; }
    public ICollection<XCN>? OriginatorCodeName { get; }
    public ICollection<XCN>? AssignedDocumentAuthenticator { get; }
    public XCN? TranscriptionistCodeName { get; }
    public EI UniqueDocumentNumber { get; }
    public EI? ParentDocumentNumber { get; }
    public ICollection<EI>? PlacerOrderNumber { get; }
    public EI? FillerOrderNumber { get; }
    public ST? UniqueDocumentFileName { get; }
    public ID DocumentCompletionStatus { get; }
    public ID? DocumentConfidentialityStatus { get; }
    public ID? DocumentAvailabilityStatus { get; }
    public ID? DocumentStorageStatus { get; }
    public ST? DocumentChangeReason { get; }
    public PPN? AuthenticationPersonTimeStamp { get; }
    public ICollection<XCN>? DistributedCopies { get; }
    public ICollection<CWE>? FolderAssignment { get; }
    public ICollection<ST>? DocumentTitle { get; }
    public DTM? AgreedDueDateTime { get; }
    public HD? CreatingFacility { get; }
    public CWE? CreatingSpecialty { get; }

    public TXA(Segment segment) : base(typeof(TXA), segment) {
        this.SetIDTXA = segment.GetRequiredField<SI>(1);
        this.DocumentType = segment.GetRequiredField<CWE>(2);
        this.DocumentContentPresentation = segment.GetField<ID>(3);
        this.ActivityDateTime = segment.GetField<DTM>(4);
        this.PrimaryActivityProviderCodeName = segment.GetField<XCN>(5);
        this.OriginationDateTime = segment.GetField<DTM>(6);
        this.TranscriptionDateTime = segment.GetField<DTM>(7);
        this.EditDateTime = segment.GetRepField<DTM>(8);
        this.OriginatorCodeName = segment.GetRepField<XCN>(9);
        this.AssignedDocumentAuthenticator = segment.GetRepField<XCN>(10);
        this.TranscriptionistCodeName = segment.GetField<XCN>(11);
        this.UniqueDocumentNumber = segment.GetRequiredField<EI>(12);
        this.ParentDocumentNumber = segment.GetField<EI>(13);
        this.PlacerOrderNumber = segment.GetRepField<EI>(14);
        this.FillerOrderNumber = segment.GetField<EI>(15);
        this.UniqueDocumentFileName = segment.GetField<ST>(16);
        this.DocumentCompletionStatus = segment.GetRequiredField<ID>(17);
        this.DocumentConfidentialityStatus = segment.GetField<ID>(18);
        this.DocumentAvailabilityStatus = segment.GetField<ID>(19);
        this.DocumentStorageStatus = segment.GetField<ID>(20);
        this.DocumentChangeReason = segment.GetField<ST>(21);
        this.AuthenticationPersonTimeStamp = segment.GetField<PPN>(22);
        this.DistributedCopies = segment.GetRepField<XCN>(23);
        this.FolderAssignment = segment.GetRepField<CWE>(24);
        this.DocumentTitle = segment.GetRepField<ST>(25);
        this.AgreedDueDateTime = segment.GetField<DTM>(26);
        this.CreatingFacility = segment.GetField<HD>(27);
        this.CreatingSpecialty = segment.GetField<CWE>(28);
    }
}

public sealed record UAC : Hl7Segment {
    public CWE UserAuthenticationCredentialTypeCode { get; }
    public ED UserAuthenticationCredential { get; }

    public UAC(Segment segment) : base(typeof(UAC), segment) {
        this.UserAuthenticationCredentialTypeCode = segment.GetRequiredField<CWE>(1);
        this.UserAuthenticationCredential = segment.GetRequiredField<ED>(2);
    }
}

public sealed record UB1 : Hl7Segment {
    public SI? SetIDUB1 { get; }
    public ST? BloodDeductible { get; }
    public ST? BloodFurnishedPints { get; }
    public ST? BloodReplacedPints { get; }
    public ST? BloodNotReplacedPints { get; }
    public ST? CoInsuranceDays { get; }
    public ST? ConditionCode { get; }
    public ST? CoveredDays { get; }
    public ST? NonCoveredDays { get; }
    public ST? ValueAmountCode { get; }
    public ST? NumberOfGraceDays { get; }
    public ST? SpecialProgramIndicator { get; }
    public ST? PSROURApprovalIndicator { get; }
    public ST? PSROURApprovedStayFm { get; }
    public ST? PSROURApprovedStayTo { get; }
    public ST? Occurrence { get; }
    public ST? OccurrenceSpan { get; }
    public ST? OccurSpanStartDate { get; }
    public ST? OccurSpanEndDate { get; }
    public ST? UB82Locator2 { get; }
    public ST? UB82Locator9 { get; }
    public ST? UB82Locator27 { get; }
    public ST? UB82Locator45 { get; }

    public UB1(Segment segment) : base(typeof(UB1), segment) {
        this.SetIDUB1 = segment.GetField<SI>(1);
        this.BloodDeductible = segment.GetField<ST>(2);
        this.BloodFurnishedPints = segment.GetField<ST>(3);
        this.BloodReplacedPints = segment.GetField<ST>(4);
        this.BloodNotReplacedPints = segment.GetField<ST>(5);
        this.CoInsuranceDays = segment.GetField<ST>(6);
        this.ConditionCode = segment.GetField<ST>(7);
        this.CoveredDays = segment.GetField<ST>(8);
        this.NonCoveredDays = segment.GetField<ST>(9);
        this.ValueAmountCode = segment.GetField<ST>(10);
        this.NumberOfGraceDays = segment.GetField<ST>(11);
        this.SpecialProgramIndicator = segment.GetField<ST>(12);
        this.PSROURApprovalIndicator = segment.GetField<ST>(13);
        this.PSROURApprovedStayFm = segment.GetField<ST>(14);
        this.PSROURApprovedStayTo = segment.GetField<ST>(15);
        this.Occurrence = segment.GetField<ST>(16);
        this.OccurrenceSpan = segment.GetField<ST>(17);
        this.OccurSpanStartDate = segment.GetField<ST>(18);
        this.OccurSpanEndDate = segment.GetField<ST>(19);
        this.UB82Locator2 = segment.GetField<ST>(20);
        this.UB82Locator9 = segment.GetField<ST>(21);
        this.UB82Locator27 = segment.GetField<ST>(22);
        this.UB82Locator45 = segment.GetField<ST>(23);
    }
}

public sealed record UB2 : Hl7Segment {
    public SI? SetIDUB2 { get; }
    public ST? CoInsuranceDays { get; }
    public CWE? ConditionCode { get; }
    public ST? CoveredDays { get; }
    public ST? NonCoveredDays { get; }
    public UVC? ValueAmountCode { get; }
    public OCD? OccurrenceCodeDate { get; }
    public OSP? OccurrenceSpanCodeDates { get; }
    public ST? UniformBillingLocator2 { get; }
    public ST? UniformBillingLocator11 { get; }
    public ST? UniformBillingLocator31 { get; }
    public ST? DocumentControlNumber { get; }
    public ST? UniformBillingLocator49 { get; }
    public ST? UniformBillingLocator56 { get; }
    public ST? UniformBillingLocator57 { get; }
    public ST? UniformBillingLocator78 { get; }
    public NM? SpecialVisitCount { get; }

    public UB2(Segment segment) : base(typeof(UB2), segment) {
        this.SetIDUB2 = segment.GetField<SI>(1);
        this.CoInsuranceDays = segment.GetField<ST>(2);
        this.ConditionCode = segment.GetField<CWE>(3);
        this.CoveredDays = segment.GetField<ST>(4);
        this.NonCoveredDays = segment.GetField<ST>(5);
        this.ValueAmountCode = segment.GetField<UVC>(6);
        this.OccurrenceCodeDate = segment.GetField<OCD>(7);
        this.OccurrenceSpanCodeDates = segment.GetField<OSP>(8);
        this.UniformBillingLocator2 = segment.GetField<ST>(9);
        this.UniformBillingLocator11 = segment.GetField<ST>(10);
        this.UniformBillingLocator31 = segment.GetField<ST>(11);
        this.DocumentControlNumber = segment.GetField<ST>(12);
        this.UniformBillingLocator49 = segment.GetField<ST>(13);
        this.UniformBillingLocator56 = segment.GetField<ST>(14);
        this.UniformBillingLocator57 = segment.GetField<ST>(15);
        this.UniformBillingLocator78 = segment.GetField<ST>(16);
        this.SpecialVisitCount = segment.GetField<NM>(17);
    }
}

public sealed record VAR : Hl7Segment {
    public EI VarianceInstanceID { get; }
    public DTM DocumentedDateTime { get; }
    public DTM? StatedVarianceDateTime { get; }
    public ICollection<XCN>? VarianceOriginator { get; }
    public CWE? VarianceClassification { get; }
    public ICollection<ST>? VarianceDescription { get; }

    public VAR(Segment segment) : base(typeof(VAR), segment) {
        this.VarianceInstanceID = segment.GetRequiredField<EI>(1);
        this.DocumentedDateTime = segment.GetRequiredField<DTM>(2);
        this.StatedVarianceDateTime = segment.GetField<DTM>(3);
        this.VarianceOriginator = segment.GetRepField<XCN>(4);
        this.VarianceClassification = segment.GetField<CWE>(5);
        this.VarianceDescription = segment.GetRepField<ST>(6);
    }
}

public sealed record VND : Hl7Segment {
    public SI SetIdVND { get; }
    public EI VendorIdentifier { get; }
    public ST? VendorName { get; }
    public EI? VendorCatalogNumber { get; }
    public CNE? PrimaryVendorIndicator { get; }
    public ICollection<EI>? Corporation { get; }
    public XCN? PrimaryContact { get; }
    public MOP? ContractAdjustment { get; }
    public ICollection<EI>? AssociatedContractID { get; }
    public ICollection<ST>? ClassofTrade { get; }
    public CWE? PricingTierLevel { get; }

    public VND(Segment segment) : base(typeof(VND), segment) {
        this.SetIdVND = segment.GetRequiredField<SI>(1);
        this.VendorIdentifier = segment.GetRequiredField<EI>(2);
        this.VendorName = segment.GetField<ST>(3);
        this.VendorCatalogNumber = segment.GetField<EI>(4);
        this.PrimaryVendorIndicator = segment.GetField<CNE>(5);
        this.Corporation = segment.GetRepField<EI>(6);
        this.PrimaryContact = segment.GetField<XCN>(7);
        this.ContractAdjustment = segment.GetField<MOP>(8);
        this.AssociatedContractID = segment.GetRepField<EI>(9);
        this.ClassofTrade = segment.GetRepField<ST>(10);
        this.PricingTierLevel = segment.GetField<CWE>(11);
    }
}

public sealed record ZL7 : Hl7Segment {
    public CWE PrimaykeyvalueZL7 { get; }
    public NM Displaysortkey { get; }

    public ZL7(Segment segment) : base(typeof(ZL7), segment) {
        this.PrimaykeyvalueZL7 = segment.GetRequiredField<CWE>(1);
        this.Displaysortkey = segment.GetRequiredField<NM>(2);
    }
}


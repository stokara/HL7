using NodaTime;

namespace HL7;

public sealed record FT1 : HL7Data<FT1> {
    public int? SetId { get; }
    public string TransactionId { get; }
    public string TransactionBatchId { get; }
    public Instant? TransactionDate { get; }
    public Instant? TransactionPostingDate { get; }
    public string TransactionType { get; }
    public HL7Property<CodedElement> TransactionCode { get; }
    public string TransactionDescription { get; }
    public string TransactionDescriptionAlt { get; }
    public decimal? TransactionQuantity { get; }
    public decimal? TransactionAmountExtended { get; }
    public decimal? TransactionAmountUnit { get; }
    public HL7Property<CodedElement> DepartmentCode { get; }
    public HL7Property<CodedElement> InsurancePlanId { get; }
    public decimal? InsuranceAmount { get; }
    public string AssignedPatientLocation { get; }
    public string FeeSchedule { get; }
    public string PatientType { get; }
    public HL7Property<CodedElement> DiagnosisCode { get; }
    public HL7Property<PersonName> PerformedByCode { get; }
    public HL7Property<PersonName> OrderedByCode { get; }
    public decimal? UnitCost { get; }
    public HL7Property<EntityIdentifier> FillerOrderNumber { get; }
    public HL7Property<PersonName> EnteredByCode { get; }
    public HL7Property<CptProcedure> ProcedureCode { get; }
    public HL7Property<CodedElement> ProcedureCodeModifier { get; }

    public FT1(Segment segment) : base(segment) {
        SetId = segment.GetFieldInt(1);
        TransactionId = segment.GetFieldString(2);
        TransactionBatchId = segment.GetFieldString(3);
        TransactionDate = segment.GetFieldInstant(4);
        TransactionPostingDate = segment.GetFieldInstant(5);
        TransactionType = segment.GetFieldString(6);
        TransactionCode = CodedElement.CreateHL7Property(segment, 7);
        TransactionDescription = segment.GetFieldString(8);
        TransactionDescriptionAlt = segment.GetFieldString(9);
        TransactionQuantity = segment.GetFieldDecimal(10);
        TransactionAmountExtended = segment.GetFieldDecimal(11);
        TransactionAmountUnit = segment.GetFieldDecimal(12);
        DepartmentCode = CodedElement.CreateHL7Property(segment, 13);
        InsurancePlanId = CodedElement.CreateHL7Property(segment, 14);
        InsuranceAmount = segment.GetFieldDecimal(15);
        AssignedPatientLocation = segment.GetFieldString(16);
        FeeSchedule = segment.GetFieldString(17);
        PatientType = segment.GetFieldString(18);
        DiagnosisCode = CodedElement.CreateHL7Property(segment, 19);
        PerformedByCode = PersonName.CreateHL7Property(segment, 20);
        OrderedByCode = PersonName.CreateHL7Property(segment, 21);
        UnitCost = segment.GetFieldDecimal(22);
        FillerOrderNumber = EntityIdentifier.CreateHL7Property(segment, 23);
        EnteredByCode = PersonName.CreateHL7Property(segment, 24);
        ProcedureCode = CptProcedure.CreateHL7Property(segment, 25);
        ProcedureCodeModifier = CodedElement.CreateHL7Property(segment, 26);
    }
}
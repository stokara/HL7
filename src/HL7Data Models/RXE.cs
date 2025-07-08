using NodaTime;

namespace HL7;

/// <summary>
///     RXE - Pharmacy/Treatment Encoded Order Segment (HL7 v2.3.1)
/// </summary>
public sealed record RXE : HL7Data<RXE> {
    public int? GiveSubIdCounter { get; }
    public int? DispenseSubIdCounter { get; }
    public string QuantityTiming { get; }
    public CodedElement GiveCode { get; }
    public decimal? GiveAmountMinimum { get; }
    public decimal? GiveAmountMaximum { get; }
    public CodedElement GiveUnits { get; }
    public CodedElement GiveDosageForm { get; }
    public string ProviderSAdministrationInstructions { get; }
    public string DeliverToLocation { get; }
    public string SubstitutionStatus { get; }
    public decimal? DispenseAmount { get; }
    public CodedElement DispenseUnits { get; }
    public int? NumberOfRefills { get; }
    public string OrderingProviderSDEANumber { get; }
    public string PharmacistTreatmentSupplierSVerifierId { get; }
    public string PrescriptionNumber { get; }
    public int? NumberOfRefillsRemaining { get; }
    public int? NumberOfRefillsDosesDispensed { get; }
    public Instant? D_T_SOfLastRefillOrDoseDispensed { get; }
    public decimal? TotalDailyDose { get; }
    public string NeedsHumanReview { get; }
    public string PharmacyTreatmentSupplierSSpecialDispensingInstructions { get; }
    public string GivePerTimeUnit { get; }
    public decimal? GiveRateAmount { get; }
    public CodedElement GiveRateUnits { get; }
    public decimal? GiveStrength { get; }
    public CodedElement GiveStrengthUnits { get; }
    public string GiveIndication { get; }
    public decimal? DispensePackageSize { get; }
    public CodedElement DispensePackageSizeUnit { get; }
    public string DispensePackageMethod { get; }
    public HL7Property<CodedElement> SupplementaryCode { get; }
    public Instant? OriginalOrderDateTime { get; }

    public RXE(Segment segment) : base(segment) {
        GiveSubIdCounter = segment.GetFieldInt(1);
        DispenseSubIdCounter = segment.GetFieldInt(2);
        QuantityTiming = segment.GetFieldString(3);
        GiveCode = CodedElement.Parse(segment.GetField(4));
        GiveAmountMinimum = segment.GetFieldDecimal(5);
        GiveAmountMaximum = segment.GetFieldDecimal(6);
        GiveUnits = CodedElement.Parse(segment.GetField(7));
        GiveDosageForm = CodedElement.Parse(segment.GetField(8));
        ProviderSAdministrationInstructions = segment.GetFieldString(9);
        DeliverToLocation = segment.GetFieldString(10);
        SubstitutionStatus = segment.GetFieldString(11);
        DispenseAmount = segment.GetFieldDecimal(12);
        DispenseUnits = CodedElement.Parse(segment.GetField(13));
        NumberOfRefills = segment.GetFieldInt(14);
        OrderingProviderSDEANumber = segment.GetFieldString(15);
        PharmacistTreatmentSupplierSVerifierId = segment.GetFieldString(16);
        PrescriptionNumber = segment.GetFieldString(17);
        NumberOfRefillsRemaining = segment.GetFieldInt(18);
        NumberOfRefillsDosesDispensed = segment.GetFieldInt(19);
        D_T_SOfLastRefillOrDoseDispensed = segment.GetFieldInstant(20);
        TotalDailyDose = segment.GetFieldDecimal(21);
        NeedsHumanReview = segment.GetFieldString(22);
        PharmacyTreatmentSupplierSSpecialDispensingInstructions = segment.GetFieldString(23);
        GivePerTimeUnit = segment.GetFieldString(24);
        GiveRateAmount = segment.GetFieldDecimal(25);
        GiveRateUnits = CodedElement.Parse(segment.GetField(26));
        GiveStrength = segment.GetFieldDecimal(27);
        GiveStrengthUnits = CodedElement.Parse(segment.GetField(28));
        GiveIndication = segment.GetFieldString(29);
        DispensePackageSize = segment.GetFieldDecimal(30);
        DispensePackageSizeUnit = CodedElement.Parse(segment.GetField(31));
        DispensePackageMethod = segment.GetFieldString(32);
        SupplementaryCode = CodedElement.CreateHL7Property(segment, 33);
        OriginalOrderDateTime = segment.GetFieldInstant(34);
    }
}
namespace HL7;

/// <summary>
///     RXO - Pharmacy/Treatment Order Segment (HL7 v2.3.1)
/// </summary>
public sealed record RXO : HL7Data<RXO> {
    public CodedElement RequestedGiveCode { get; }
    public decimal? RequestedGiveAmountMinimum { get; }
    public decimal? RequestedGiveAmountMaximum { get; }
    public CodedElement RequestedGiveUnits { get; }
    public CodedElement RequestedDosageForm { get; }
    public string ProviderSPharmacyInstructions { get; }
    public string ProviderSAdministrationInstructions { get; }
    public string DeliverToLocation { get; }
    public string AllowSubstitutions { get; }
    public CodedElement RequestedDispenseCode { get; }
    public decimal? RequestedDispenseAmount { get; }
    public CodedElement RequestedDispenseUnits { get; }
    public int? NumberOfRefills { get; }
    public string OrderingProviderSDEANumber { get; }
    public string PharmacistTreatmentSupplierSVerifierId { get; }
    public string NeedsHumanReview { get; }
    public string RequestedGivePerTimeUnit { get; }
    public decimal? RequestedGiveStrength { get; }
    public CodedElement RequestedGiveStrengthUnits { get; }
    public string Indication { get; }
    public decimal? RequestedGiveRateAmount { get; }
    public CodedElement RequestedGiveRateUnits { get; }
    public decimal? TotalDailyDose { get; }
    public HL7Property<CodedElement> SupplementaryCode { get; }
    public decimal? RequestedDrugStrengthVolume { get; }
    public CodedElement RequestedDrugStrengthVolumeUnits { get; }
    public string PharmacyOrderType { get; }

    public RXO(Segment segment) : base(segment) {
        RequestedGiveCode = CodedElement.Parse(segment.GetField(1));
        RequestedGiveAmountMinimum = segment.GetFieldDecimal(2);
        RequestedGiveAmountMaximum = segment.GetFieldDecimal(3);
        RequestedGiveUnits = CodedElement.Parse(segment.GetField(4));
        RequestedDosageForm = CodedElement.Parse(segment.GetField(5));
        ProviderSPharmacyInstructions = segment.GetFieldString(6);
        ProviderSAdministrationInstructions = segment.GetFieldString(7);
        DeliverToLocation = segment.GetFieldString(8);
        AllowSubstitutions = segment.GetFieldString(9);
        RequestedDispenseCode = CodedElement.Parse(segment.GetField(10));
        RequestedDispenseAmount = segment.GetFieldDecimal(11);
        RequestedDispenseUnits = CodedElement.Parse(segment.GetField(12));
        NumberOfRefills = segment.GetFieldInt(13);
        OrderingProviderSDEANumber = segment.GetFieldString(14);
        PharmacistTreatmentSupplierSVerifierId = segment.GetFieldString(15);
        NeedsHumanReview = segment.GetFieldString(16);
        RequestedGivePerTimeUnit = segment.GetFieldString(17);
        RequestedGiveStrength = segment.GetFieldDecimal(18);
        RequestedGiveStrengthUnits = CodedElement.Parse(segment.GetField(19));
        Indication = segment.GetFieldString(20);
        RequestedGiveRateAmount = segment.GetFieldDecimal(21);
        RequestedGiveRateUnits = CodedElement.Parse(segment.GetField(22));
        TotalDailyDose = segment.GetFieldDecimal(23);
        SupplementaryCode = CodedElement.CreateHL7Property(segment, 24);
        RequestedDrugStrengthVolume = segment.GetFieldDecimal(25);
        RequestedDrugStrengthVolumeUnits = CodedElement.Parse(segment.GetField(26));
        PharmacyOrderType = segment.GetFieldString(27);
    }
}
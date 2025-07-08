using HL7.Elements;

namespace HL7;

/// <summary>
///     RXO - Pharmacy/Treatment Order Segment (HL7 v2.3.1)
/// </summary>
public sealed record RXO : HL7Data<RXO> {
    public CodedElement RequestedGiveCode { get; }
    public string RequestedGiveAmountMinimum { get; }
    public string RequestedGiveAmountMaximum { get; }
    public CodedElement RequestedGiveUnits { get; }
    public CodedElement RequestedDosageForm { get; }
    public string ProviderSPharmacyInstructions { get; }
    public string ProviderSAdministrationInstructions { get; }
    public string DeliverToLocation { get; }
    public string AllowSubstitutions { get; }
    public CodedElement RequestedDispenseCode { get; }
    public string RequestedDispenseAmount { get; }
    public CodedElement RequestedDispenseUnits { get; }
    public string NumberOfRefills { get; }
    public string OrderingProviderSDEANumber { get; }
    public string PharmacistTreatmentSupplierSVerifierId { get; }
    public string NeedsHumanReview { get; }
    public string RequestedGivePerTimeUnit { get; }
    public string RequestedGiveStrength { get; }
    public CodedElement RequestedGiveStrengthUnits { get; }
    public string Indication { get; }
    public string RequestedGiveRateAmount { get; }
    public CodedElement RequestedGiveRateUnits { get; }
    public string TotalDailyDose { get; }
    public CodedElement SupplementaryCode { get; }
    public string RequestedDrugStrengthVolume { get; }
    public CodedElement RequestedDrugStrengthVolumeUnits { get; }
    public string PharmacyOrderType { get; }

    public RXO(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        RequestedGiveCode = cnt > 1 ? CodedElement.Parse(fields[1]) : CodedElement.Empty;
        RequestedGiveAmountMinimum = cnt > 2 ? fields[2].Value : string.Empty;
        RequestedGiveAmountMaximum = cnt > 3 ? fields[3].Value : string.Empty;
        RequestedGiveUnits = cnt > 4 ? CodedElement.Parse(fields[4]) : CodedElement.Empty;
        RequestedDosageForm = cnt > 5 ? CodedElement.Parse(fields[5]) : CodedElement.Empty;
        ProviderSPharmacyInstructions = cnt > 6 ? fields[6].Value : string.Empty;
        ProviderSAdministrationInstructions = cnt > 7 ? fields[7].Value : string.Empty;
        DeliverToLocation = cnt > 8 ? fields[8].Value : string.Empty;
        AllowSubstitutions = cnt > 9 ? fields[9].Value : string.Empty;
        RequestedDispenseCode = cnt > 10 ? CodedElement.Parse(fields[10]) : CodedElement.Empty;
        RequestedDispenseAmount = cnt > 11 ? fields[11].Value : string.Empty;
        RequestedDispenseUnits = cnt > 12 ? CodedElement.Parse(fields[12]) : CodedElement.Empty;
        NumberOfRefills = cnt > 13 ? fields[13].Value : string.Empty;
        OrderingProviderSDEANumber = cnt > 14 ? fields[14].Value : string.Empty;
        PharmacistTreatmentSupplierSVerifierId = cnt > 15 ? fields[15].Value : string.Empty;
        NeedsHumanReview = cnt > 16 ? fields[16].Value : string.Empty;
        RequestedGivePerTimeUnit = cnt > 17 ? fields[17].Value : string.Empty;
        RequestedGiveStrength = cnt > 18 ? fields[18].Value : string.Empty;
        RequestedGiveStrengthUnits = cnt > 19 ? CodedElement.Parse(fields[19]) : CodedElement.Empty;
        Indication = cnt > 20 ? fields[20].Value : string.Empty;
        RequestedGiveRateAmount = cnt > 21 ? fields[21].Value : string.Empty;
        RequestedGiveRateUnits = cnt > 22 ? CodedElement.Parse(fields[22]) : CodedElement.Empty;
        TotalDailyDose = cnt > 23 ? fields[23].Value : string.Empty;
        SupplementaryCode = cnt > 24 ? CodedElement.Parse(fields[24]) : CodedElement.Empty;
        RequestedDrugStrengthVolume = cnt > 25 ? fields[25].Value : string.Empty;
        RequestedDrugStrengthVolumeUnits = cnt > 26 ? CodedElement.Parse(fields[26]) : CodedElement.Empty;
        PharmacyOrderType = cnt > 27 ? fields[27].Value : string.Empty;
    }
}
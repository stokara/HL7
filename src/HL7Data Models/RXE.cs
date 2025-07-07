namespace HL7;

/// <summary>
///     RXE - Pharmacy/Treatment Encoded Order Segment (HL7 v2.3.1)
/// </summary>
public sealed record RXE : HL7Data<RXE> {
    public string GiveSubIdCounter { get; }
    public string DispenseSubIdCounter { get; }
    public string QuantityTiming { get; }
    public string GiveCode { get; }
    public string GiveAmountMinimum { get; }
    public string GiveAmountMaximum { get; }
    public string GiveUnits { get; }
    public string GiveDosageForm { get; }
    public string ProviderSAdministrationInstructions { get; }
    public string DeliverToLocation { get; }
    public string SubstitutionStatus { get; }
    public string DispenseAmount { get; }
    public string DispenseUnits { get; }
    public string NumberOfRefills { get; }
    public string OrderingProviderSDEANumber { get; }
    public string PharmacistTreatmentSupplierSVerifierId { get; }
    public string PrescriptionNumber { get; }
    public string NumberOfRefillsRemaining { get; }
    public string NumberOfRefillsDosesDispensed { get; }
    public string D_T_SOfLastRefillOrDoseDispensed { get; }
    public string TotalDailyDose { get; }
    public string NeedsHumanReview { get; }
    public string PharmacyTreatmentSupplierSSpecialDispensingInstructions { get; }
    public string GivePerTimeUnit { get; }
    public string GiveRateAmount { get; }
    public string GiveRateUnits { get; }
    public string GiveStrength { get; }
    public string GiveStrengthUnits { get; }
    public string GiveIndication { get; }
    public string DispensePackageSize { get; }
    public string DispensePackageSizeUnit { get; }
    public string DispensePackageMethod { get; }
    public string SupplementaryCode { get; }
    public string OriginalOrderDateTime { get; }

    public RXE(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        GiveSubIdCounter = cnt > 1 ? fields[1].Value : string.Empty;
        DispenseSubIdCounter = cnt > 2 ? fields[2].Value : string.Empty;
        QuantityTiming = cnt > 3 ? fields[3].Value : string.Empty;
        GiveCode = cnt > 4 ? fields[4].Value : string.Empty;
        GiveAmountMinimum = cnt > 5 ? fields[5].Value : string.Empty;
        GiveAmountMaximum = cnt > 6 ? fields[6].Value : string.Empty;
        GiveUnits = cnt > 7 ? fields[7].Value : string.Empty;
        GiveDosageForm = cnt > 8 ? fields[8].Value : string.Empty;
        ProviderSAdministrationInstructions = cnt > 9 ? fields[9].Value : string.Empty;
        DeliverToLocation = cnt > 10 ? fields[10].Value : string.Empty;
        SubstitutionStatus = cnt > 11 ? fields[11].Value : string.Empty;
        DispenseAmount = cnt > 12 ? fields[12].Value : string.Empty;
        DispenseUnits = cnt > 13 ? fields[13].Value : string.Empty;
        NumberOfRefills = cnt > 14 ? fields[14].Value : string.Empty;
        OrderingProviderSDEANumber = cnt > 15 ? fields[15].Value : string.Empty;
        PharmacistTreatmentSupplierSVerifierId = cnt > 16 ? fields[16].Value : string.Empty;
        PrescriptionNumber = cnt > 17 ? fields[17].Value : string.Empty;
        NumberOfRefillsRemaining = cnt > 18 ? fields[18].Value : string.Empty;
        NumberOfRefillsDosesDispensed = cnt > 19 ? fields[19].Value : string.Empty;
        D_T_SOfLastRefillOrDoseDispensed = cnt > 20 ? fields[20].Value : string.Empty;
        TotalDailyDose = cnt > 21 ? fields[21].Value : string.Empty;
        NeedsHumanReview = cnt > 22 ? fields[22].Value : string.Empty;
        PharmacyTreatmentSupplierSSpecialDispensingInstructions = cnt > 23 ? fields[23].Value : string.Empty;
        GivePerTimeUnit = cnt > 24 ? fields[24].Value : string.Empty;
        GiveRateAmount = cnt > 25 ? fields[25].Value : string.Empty;
        GiveRateUnits = cnt > 26 ? fields[26].Value : string.Empty;
        GiveStrength = cnt > 27 ? fields[27].Value : string.Empty;
        GiveStrengthUnits = cnt > 28 ? fields[28].Value : string.Empty;
        GiveIndication = cnt > 29 ? fields[29].Value : string.Empty;
        DispensePackageSize = cnt > 30 ? fields[30].Value : string.Empty;
        DispensePackageSizeUnit = cnt > 31 ? fields[31].Value : string.Empty;
        DispensePackageMethod = cnt > 32 ? fields[32].Value : string.Empty;
        SupplementaryCode = cnt > 33 ? fields[33].Value : string.Empty;
        OriginalOrderDateTime = cnt > 34 ? fields[34].Value : string.Empty;
    }
}
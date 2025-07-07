namespace HL7;

/// <summary>
///     RXD - Pharmacy/Treatment Dispense Segment (HL7 v2.3.1)
/// </summary>
public sealed record RXD : HL7Data<RXD> {
    public string DispenseSubIdCounter { get; }
    public string DispenseGiveCode { get; }
    public string DateTimeDispensed { get; }
    public string ActualDispenseAmount { get; }
    public string ActualDispenseUnits { get; }
    public string ActualDosageForm { get; }
    public string PrescriptionNumber { get; }
    public string NumberOfRefillsRemaining { get; }
    public string DispenseNotes { get; }
    public string DispensingProvider { get; }
    public string SubstitutionStatus { get; }
    public string TotalDailyDose { get; }
    public string DispenseToLocation { get; }
    public string NeedsHumanReview { get; }
    public string SpecialDispensingInstructions { get; }
    public string ActualStrength { get; }
    public string ActualStrengthUnit { get; }
    public string SubstanceLotNumber { get; }
    public string SubstanceExpirationDate { get; }
    public string SubstanceManufacturerName { get; }
    public string Indication { get; }
    public string DispensePackageSize { get; }
    public string DispensePackageSizeUnit { get; }
    public string DispensePackageMethod { get; }
    public string SupplementaryCode { get; }
    public string InitiatingLocation { get; }
    public string PackagingAssemblyLocation { get; }
    public string ActualDrugStrengthVolume { get; }
    public string ActualDrugStrengthVolumeUnits { get; }
    public string DispenseBarcode { get; }

    public RXD(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        DispenseSubIdCounter = cnt > 1 ? fields[1].Value : string.Empty;
        DispenseGiveCode = cnt > 2 ? fields[2].Value : string.Empty;
        DateTimeDispensed = cnt > 3 ? fields[3].Value : string.Empty;
        ActualDispenseAmount = cnt > 4 ? fields[4].Value : string.Empty;
        ActualDispenseUnits = cnt > 5 ? fields[5].Value : string.Empty;
        ActualDosageForm = cnt > 6 ? fields[6].Value : string.Empty;
        PrescriptionNumber = cnt > 7 ? fields[7].Value : string.Empty;
        NumberOfRefillsRemaining = cnt > 8 ? fields[8].Value : string.Empty;
        DispenseNotes = cnt > 9 ? fields[9].Value : string.Empty;
        DispensingProvider = cnt > 10 ? fields[10].Value : string.Empty;
        SubstitutionStatus = cnt > 11 ? fields[11].Value : string.Empty;
        TotalDailyDose = cnt > 12 ? fields[12].Value : string.Empty;
        DispenseToLocation = cnt > 13 ? fields[13].Value : string.Empty;
        NeedsHumanReview = cnt > 14 ? fields[14].Value : string.Empty;
        SpecialDispensingInstructions = cnt > 15 ? fields[15].Value : string.Empty;
        ActualStrength = cnt > 16 ? fields[16].Value : string.Empty;
        ActualStrengthUnit = cnt > 17 ? fields[17].Value : string.Empty;
        SubstanceLotNumber = cnt > 18 ? fields[18].Value : string.Empty;
        SubstanceExpirationDate = cnt > 19 ? fields[19].Value : string.Empty;
        SubstanceManufacturerName = cnt > 20 ? fields[20].Value : string.Empty;
        Indication = cnt > 21 ? fields[21].Value : string.Empty;
        DispensePackageSize = cnt > 22 ? fields[22].Value : string.Empty;
        DispensePackageSizeUnit = cnt > 23 ? fields[23].Value : string.Empty;
        DispensePackageMethod = cnt > 24 ? fields[24].Value : string.Empty;
        SupplementaryCode = cnt > 25 ? fields[25].Value : string.Empty;
        InitiatingLocation = cnt > 26 ? fields[26].Value : string.Empty;
        PackagingAssemblyLocation = cnt > 27 ? fields[27].Value : string.Empty;
        ActualDrugStrengthVolume = cnt > 28 ? fields[28].Value : string.Empty;
        ActualDrugStrengthVolumeUnits = cnt > 29 ? fields[29].Value : string.Empty;
        DispenseBarcode = cnt > 30 ? fields[30].Value : string.Empty;
    }
}
using NodaTime;

namespace HL7;

/// <summary>
///     RXD - Pharmacy/Treatment Dispense Segment (HL7 v2.3.1)
/// </summary>
public sealed record RXD : HL7Data<RXD> {
    public int? DispenseSubIdCounter { get; }
    public CodedElement DispenseGiveCode { get; }
    public Instant? DateTimeDispensed { get; }
    public decimal? ActualDispenseAmount { get; }
    public CodedElement ActualDispenseUnits { get; }
    public CodedElement ActualDosageForm { get; }
    public string PrescriptionNumber { get; }
    public int? NumberOfRefillsRemaining { get; }
    public string DispenseNotes { get; }
    public string DispensingProvider { get; }
    public string SubstitutionStatus { get; }
    public decimal? TotalDailyDose { get; }
    public string DispenseToLocation { get; }
    public string NeedsHumanReview { get; }
    public string SpecialDispensingInstructions { get; }
    public decimal? ActualStrength { get; }
    public CodedElement ActualStrengthUnit { get; }
    public string SubstanceLotNumber { get; }
    public Instant? SubstanceExpirationDate { get; }
    public string SubstanceManufacturerName { get; }
    public string Indication { get; }
    public decimal? DispensePackageSize { get; }
    public CodedElement DispensePackageSizeUnit { get; }
    public string DispensePackageMethod { get; }
    public HL7Property<CodedElement> SupplementaryCode { get; }
    public string InitiatingLocation { get; }
    public string PackagingAssemblyLocation { get; }
    public decimal? ActualDrugStrengthVolume { get; }
    public CodedElement ActualDrugStrengthVolumeUnits { get; }
    public string DispenseBarcode { get; }

    public RXD(Segment segment) : base(segment) {
        DispenseSubIdCounter = segment.GetFieldInt(1);
        DispenseGiveCode = CodedElement.Parse(segment.GetField(2));
        DateTimeDispensed = segment.GetFieldInstant(3);
        ActualDispenseAmount = segment.GetFieldDecimal(4);
        ActualDispenseUnits = CodedElement.Parse(segment.GetField(5));
        ActualDosageForm = CodedElement.Parse(segment.GetField(6));
        PrescriptionNumber = segment.GetFieldString(7);
        NumberOfRefillsRemaining = segment.GetFieldInt(8);
        DispenseNotes = segment.GetFieldString(9);
        DispensingProvider = segment.GetFieldString(10);
        SubstitutionStatus = segment.GetFieldString(11);
        TotalDailyDose = segment.GetFieldDecimal(12);
        DispenseToLocation = segment.GetFieldString(13);
        NeedsHumanReview = segment.GetFieldString(14);
        SpecialDispensingInstructions = segment.GetFieldString(15);
        ActualStrength = segment.GetFieldDecimal(16);
        ActualStrengthUnit = CodedElement.Parse(segment.GetField(17));
        SubstanceLotNumber = segment.GetFieldString(18);
        SubstanceExpirationDate = segment.GetFieldInstant(19);
        SubstanceManufacturerName = segment.GetFieldString(20);
        Indication = segment.GetFieldString(21);
        DispensePackageSize = segment.GetFieldDecimal(22);
        DispensePackageSizeUnit = CodedElement.Parse(segment.GetField(23));
        DispensePackageMethod = segment.GetFieldString(24);
        SupplementaryCode = CodedElement.CreateHL7Property(segment, 25);
        InitiatingLocation = segment.GetFieldString(26);
        PackagingAssemblyLocation = segment.GetFieldString(27);
        ActualDrugStrengthVolume = segment.GetFieldDecimal(28);
        ActualDrugStrengthVolumeUnits = CodedElement.Parse(segment.GetField(29));
        DispenseBarcode = segment.GetFieldString(30);
    }
}
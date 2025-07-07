namespace HL7;

/// <summary>
///     RXA - Pharmacy/Treatment Administration (HL7 v2.3.1)
/// </summary>
public sealed record RXA : HL7Data<RXA> {
    public string GiveSubIDCounter { get; }
    public string AdministrationSubIDCounter { get; }
    public string DateTimeStartOfAdministration { get; }
    public string DateTimeEndOfAdministration { get; }
    public string AdministeredCode { get; }
    public string AdministeredAmount { get; }
    public string AdministeredUnits { get; }
    public string AdministeredDosageForm { get; }
    public string AdministrationNotes { get; }
    public string AdministeringProvider { get; }
    public string AdministeredAtLocation { get; }
    public string AdministeredPerTimeUnit { get; }
    public string AdministeredStrength { get; }
    public string AdministeredStrengthUnits { get; }
    public string SubstanceLotNumber { get; }
    public string SubstanceExpirationDate { get; }
    public string SubstanceManufacturerName { get; }
    public string SubstanceTreatmentRefusalReason { get; }
    public string Indication { get; }
    public string CompletionStatus { get; }
    public string ActionCodeRXA { get; }
    public string SystemEntryDateTime { get; }

    public RXA(Segment segment) : base(segment) {
        GiveSubIDCounter = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty;
        AdministrationSubIDCounter = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;
        DateTimeStartOfAdministration = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty;
        DateTimeEndOfAdministration = segment.Fields.Count > 4 ? segment.Fields[4].Value : string.Empty;
        AdministeredCode = segment.Fields.Count > 5 ? segment.Fields[5].Value : string.Empty;
        AdministeredAmount = segment.Fields.Count > 6 ? segment.Fields[6].Value : string.Empty;
        AdministeredUnits = segment.Fields.Count > 7 ? segment.Fields[7].Value : string.Empty;
        AdministeredDosageForm = segment.Fields.Count > 8 ? segment.Fields[8].Value : string.Empty;
        AdministrationNotes = segment.Fields.Count > 9 ? segment.Fields[9].Value : string.Empty;
        AdministeringProvider = segment.Fields.Count > 10 ? segment.Fields[10].Value : string.Empty;
        AdministeredAtLocation = segment.Fields.Count > 11 ? segment.Fields[11].Value : string.Empty;
        AdministeredPerTimeUnit = segment.Fields.Count > 12 ? segment.Fields[12].Value : string.Empty;
        AdministeredStrength = segment.Fields.Count > 13 ? segment.Fields[13].Value : string.Empty;
        AdministeredStrengthUnits = segment.Fields.Count > 14 ? segment.Fields[14].Value : string.Empty;
        SubstanceLotNumber = segment.Fields.Count > 15 ? segment.Fields[15].Value : string.Empty;
        SubstanceExpirationDate = segment.Fields.Count > 16 ? segment.Fields[16].Value : string.Empty;
        SubstanceManufacturerName = segment.Fields.Count > 17 ? segment.Fields[17].Value : string.Empty;
        SubstanceTreatmentRefusalReason = segment.Fields.Count > 18 ? segment.Fields[18].Value : string.Empty;
        Indication = segment.Fields.Count > 19 ? segment.Fields[19].Value : string.Empty;
        CompletionStatus = segment.Fields.Count > 20 ? segment.Fields[20].Value : string.Empty;
        ActionCodeRXA = segment.Fields.Count > 21 ? segment.Fields[21].Value : string.Empty;
        SystemEntryDateTime = segment.Fields.Count > 22 ? segment.Fields[22].Value : string.Empty;
    }
}
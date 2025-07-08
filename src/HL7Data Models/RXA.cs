using NodaTime;

namespace HL7;

/// <summary>
///     RXA - Pharmacy/Treatment Administration (HL7 v2.3.1)
/// </summary>
public sealed record RXA : HL7Data<RXA> {
    public int? GiveSubIDCounter { get; }
    public int? AdministrationSubIDCounter { get; }
    public Instant? DateTimeStartOfAdministration { get; }
    public Instant? DateTimeEndOfAdministration { get; }
    public HL7Property<CodedElement> AdministeredCode { get; }
    public decimal? AdministeredAmount { get; }
    public HL7Property<CodedElement> AdministeredUnits { get; }
    public HL7Property<CodedElement> AdministeredDosageForm { get; }
    public HL7Property<CodedElement> AdministrationNotes { get; }
    public HL7Property<PersonName> AdministeringProvider { get; }
    public HL7Property<CodedElement> AdministeredAtLocation { get; }
    public string AdministeredPerTimeUnit { get; }
    public decimal? AdministeredStrength { get; }
    public HL7Property<CodedElement> AdministeredStrengthUnits { get; }
    public string SubstanceLotNumber { get; }
    public Instant? SubstanceExpirationDate { get; }
    public string SubstanceManufacturerName { get; }
    public HL7Property<CodedElement> SubstanceTreatmentRefusalReason { get; }
    public HL7Property<CodedElement> Indication { get; }
    public string CompletionStatus { get; }
    public string ActionCodeRXA { get; }
    public Instant? SystemEntryDateTime { get; }

    public RXA(Segment segment) : base(segment) {
        GiveSubIDCounter = segment.GetFieldInt(1);
        AdministrationSubIDCounter = segment.GetFieldInt(2);
        DateTimeStartOfAdministration = segment.GetFieldInstant(3);
        DateTimeEndOfAdministration = segment.GetFieldInstant(4);
        AdministeredCode = CodedElement.CreateHL7Property(segment, 5);
        AdministeredAmount = segment.GetFieldDecimal(6);
        AdministeredUnits = CodedElement.CreateHL7Property(segment, 7);
        AdministeredDosageForm = CodedElement.CreateHL7Property(segment, 8);
        AdministrationNotes = CodedElement.CreateHL7Property(segment, 9);
        AdministeringProvider = PersonName.CreateHL7Property(segment, 10);
        AdministeredAtLocation = CodedElement.CreateHL7Property(segment, 11);
        AdministeredPerTimeUnit = segment.GetFieldString(12);
        AdministeredStrength = segment.GetFieldDecimal(13);
        AdministeredStrengthUnits = CodedElement.CreateHL7Property(segment, 14);
        SubstanceLotNumber = segment.GetFieldString(15);
        SubstanceExpirationDate = segment.GetFieldInstant(16);
        SubstanceManufacturerName = segment.GetFieldString(17);
        SubstanceTreatmentRefusalReason = CodedElement.CreateHL7Property(segment, 18);
        Indication = CodedElement.CreateHL7Property(segment, 19);
        CompletionStatus = segment.GetFieldString(20);
        ActionCodeRXA = segment.GetFieldString(21);
        SystemEntryDateTime = segment.GetFieldInstant(22);
    }
}
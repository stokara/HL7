namespace HL7;

/// <summary>
///     RXC - Pharmacy/Treatment Component Order Segment (HL7 v2.3.1)
/// </summary>
public sealed record RXC : HL7Data<RXC> {
    public string RxComponentType { get; }
    public HL7Property<CodedElement> ComponentCode { get; }
    public decimal? ComponentAmount { get; }
    public HL7Property<CodedElement> ComponentUnits { get; }
    public decimal? ComponentStrength { get; }
    public HL7Property<CodedElement> ComponentStrengthUnits { get; }
    public HL7Property<CodedElement> SupplementaryCode { get; }
    public decimal? ComponentDrugStrengthVolume { get; }
    public HL7Property<CodedElement> ComponentDrugStrengthVolumeUnits { get; }
    public string ComponentBarcode { get; }

    public RXC(Segment segment) : base(segment) {
        RxComponentType = segment.GetField(1)?.Value ?? "";
        ComponentCode = CodedElement.CreateHL7Property(segment, 2);
        ComponentAmount = segment.GetFieldDecimal(3);
        ComponentUnits = CodedElement.CreateHL7Property(segment, 4);
        ComponentStrength = segment.GetFieldDecimal(5);
        ComponentStrengthUnits = CodedElement.CreateHL7Property(segment, 6);
        SupplementaryCode = CodedElement.CreateHL7Property(segment, 7);
        ComponentDrugStrengthVolume = segment.GetFieldDecimal(8);
        ComponentDrugStrengthVolumeUnits = CodedElement.CreateHL7Property(segment, 9);
        ComponentBarcode = segment.GetFieldString(10);
    }
}
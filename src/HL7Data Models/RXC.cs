using HL7.Elements;

namespace HL7;

/// <summary>
///     RXC - Pharmacy/Treatment Component Order Segment (HL7 v2.3.1)
/// </summary>
public sealed record RXC : HL7Data<RXC> {
    public string RxComponentType { get; }
    public CodedElement ComponentCode { get; }
    public string ComponentAmount { get; }
    public CodedElement ComponentUnits { get; }
    public string ComponentStrength { get; }
    public CodedElement ComponentStrengthUnits { get; }
    public CodedElement SupplementaryCode { get; }
    public string ComponentDrugStrengthVolume { get; }
    public CodedElement ComponentDrugStrengthVolumeUnits { get; }
    public string ComponentBarcode { get; }

    public RXC(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        RxComponentType = cnt > 1 ? fields[1].Value : string.Empty;
        ComponentCode = cnt > 2 ? CodedElement.Parse(fields[2]) : CodedElement.Empty;
        ComponentAmount = cnt > 3 ? fields[3].Value : string.Empty;
        ComponentUnits = cnt > 4 ? CodedElement.Parse(fields[4]) : CodedElement.Empty;
        ComponentStrength = cnt > 5 ? fields[5].Value : string.Empty;
        ComponentStrengthUnits = cnt > 6 ? CodedElement.Parse(fields[6]) : CodedElement.Empty;
        SupplementaryCode = cnt > 7 ? CodedElement.Parse(fields[7]) : CodedElement.Empty;
        ComponentDrugStrengthVolume = cnt > 8 ? fields[8].Value : string.Empty;
        ComponentDrugStrengthVolumeUnits = cnt > 9 ? CodedElement.Parse(fields[9]) : CodedElement.Empty;
        ComponentBarcode = cnt > 10 ? fields[10].Value : string.Empty;
    }
}
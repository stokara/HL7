namespace HL7;

/// <summary>
///     RXC - Pharmacy/Treatment Component Order Segment (HL7 v2.3.1)
/// </summary>
public sealed record RXC : HL7Data<RXC> {
    public string RxComponentType { get; }
    public string ComponentCode { get; }
    public string ComponentAmount { get; }
    public string ComponentUnits { get; }
    public string ComponentStrength { get; }
    public string ComponentStrengthUnits { get; }
    public string SupplementaryCode { get; }
    public string ComponentDrugStrengthVolume { get; }
    public string ComponentDrugStrengthVolumeUnits { get; }
    public string ComponentBarcode { get; }

    public RXC(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        RxComponentType = cnt > 1 ? fields[1].Value : string.Empty;
        ComponentCode = cnt > 2 ? fields[2].Value : string.Empty;
        ComponentAmount = cnt > 3 ? fields[3].Value : string.Empty;
        ComponentUnits = cnt > 4 ? fields[4].Value : string.Empty;
        ComponentStrength = cnt > 5 ? fields[5].Value : string.Empty;
        ComponentStrengthUnits = cnt > 6 ? fields[6].Value : string.Empty;
        SupplementaryCode = cnt > 7 ? fields[7].Value : string.Empty;
        ComponentDrugStrengthVolume = cnt > 8 ? fields[8].Value : string.Empty;
        ComponentDrugStrengthVolumeUnits = cnt > 9 ? fields[9].Value : string.Empty;
        ComponentBarcode = cnt > 10 ? fields[10].Value : string.Empty;
    }
}
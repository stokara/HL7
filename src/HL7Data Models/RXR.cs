namespace HL7;

/// <summary>
///     RXR - Pharmacy/Treatment Route (HL7 v2.3.1)
/// </summary>
public sealed record RXR : HL7Data<RXR> {
    public string Route { get; }
    public string AdministrationSite { get; }
    public string AdministrationDevice { get; }
    public string AdministrationMethod { get; }
    public string RoutingInstruction { get; }
    public string AdministrationSiteModifier { get; }
    public string AdministrationDeviceModifier { get; }
    public string AdministrationMethodModifier { get; }

    public RXR(Segment segment) : base(segment) {
        Route = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty;
        AdministrationSite = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;
        AdministrationDevice = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty;
        AdministrationMethod = segment.Fields.Count > 4 ? segment.Fields[4].Value : string.Empty;
        RoutingInstruction = segment.Fields.Count > 5 ? segment.Fields[5].Value : string.Empty;
        AdministrationSiteModifier = segment.Fields.Count > 6 ? segment.Fields[6].Value : string.Empty;
        AdministrationDeviceModifier = segment.Fields.Count > 7 ? segment.Fields[7].Value : string.Empty;
        AdministrationMethodModifier = segment.Fields.Count > 8 ? segment.Fields[8].Value : string.Empty;
    }
}
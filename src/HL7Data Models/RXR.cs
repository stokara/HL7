namespace HL7;

/// <summary>
///     RXR - Pharmacy/Treatment Route (HL7 v2.3.1)
/// </summary>
public sealed record RXR : HL7Data<RXR> {
    public HL7Property<CodedElement> Route { get; }
    public HL7Property<CodedElement> AdministrationSite { get; }
    public HL7Property<CodedElement> AdministrationDevice { get; }
    public HL7Property<CodedElement> AdministrationMethod { get; }
    public HL7Property<CodedElement> RoutingInstruction { get; }
    public HL7Property<CodedElement> AdministrationSiteModifier { get; }
    public HL7Property<CodedElement> AdministrationDeviceModifier { get; }
    public HL7Property<CodedElement> AdministrationMethodModifier { get; }

    public RXR(Segment segment) : base(segment) {
        Route = CodedElement.CreateHL7Property(segment, 1);
        AdministrationSite = CodedElement.CreateHL7Property(segment, 2);
        AdministrationDevice = CodedElement.CreateHL7Property(segment, 3);
        AdministrationMethod = CodedElement.CreateHL7Property(segment, 4);
        RoutingInstruction = CodedElement.CreateHL7Property(segment, 5);
        AdministrationSiteModifier = CodedElement.CreateHL7Property(segment, 6);
        AdministrationDeviceModifier = CodedElement.CreateHL7Property(segment, 7);
        AdministrationMethodModifier = CodedElement.CreateHL7Property(segment, 8);
    }
}
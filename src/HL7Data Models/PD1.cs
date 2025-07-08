namespace HL7;

/// <summary>
///     PD1 - Patient Additional Demographic (HL7 v2.3.1)
/// </summary>
public sealed record PD1 : HL7Data<PD1> {
    public string LivingDependency { get; }
    public string LivingArrangement { get; }
    public HL7Property<PersonName> PrimaryFacility { get; }
    public HL7Property<PersonName> PrimaryCareProvider { get; }
    public string StudentIndicator { get; }
    public string Handicap { get; }
    public string LivingWillCode { get; }
    public string OrganDonorCode { get; }
    public string SeparateBill { get; }

    public PD1(Segment segment) : base(segment) {
        LivingDependency = segment.GetFieldString(1);
        LivingArrangement = segment.GetFieldString(2);
        PrimaryFacility = PersonName.CreateHL7Property(segment, 3);
        PrimaryCareProvider = PersonName.CreateHL7Property(segment, 4);
        StudentIndicator = segment.GetFieldString(5);
        Handicap = segment.GetFieldString(6);
        LivingWillCode = segment.GetFieldString(7);
        OrganDonorCode = segment.GetFieldString(8);
        SeparateBill = segment.GetFieldString(9);
    }
}
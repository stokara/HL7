namespace HL7;

/// <summary>
///     RGS - Resource Group Segment (HL7 v2.3.1)
/// </summary>
public sealed record RGS : HL7Data<RGS> {
    public int? SetId { get; }
    public string SegmentActionCode { get; }
    public HL7Property<CodedElement> ResourceGroupId { get; }

    public RGS(Segment segment) : base(segment) {
        SetId = segment.GetFieldInt(1);
        SegmentActionCode = segment.GetFieldString(2);
        ResourceGroupId = CodedElement.CreateHL7Property(segment, 3);
    }
}
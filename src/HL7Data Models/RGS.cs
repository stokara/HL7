namespace HL7;

/// <summary>
///     RGS - Resource Group Segment (HL7 v2.3.1)
/// </summary>
public sealed record RGS : HL7Data<RGS> {
    public string SetId { get; }
    public string SegmentActionCode { get; }
    public string ResourceGroupId { get; }

    public RGS(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        SetId = cnt > 1 ? fields[1].Value : string.Empty;
        SegmentActionCode = cnt > 2 ? fields[2].Value : string.Empty;
        ResourceGroupId = cnt > 3 ? fields[3].Value : string.Empty;
    }
}
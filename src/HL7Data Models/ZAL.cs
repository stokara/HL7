namespace HL7;

/// <summary>
///     ZAL - Example Custom Segment (Z-segments are site-specific)
/// </summary>
public sealed record ZAL : HL7Data<ZAL> {
    public string Field1 { get; }
    public string Field2 { get; }
    public string Field3 { get; }
    public string Field4 { get; }
    public string Field5 { get; }

    public ZAL(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        Field1 = cnt > 1 ? fields[1].Value : string.Empty;
        Field2 = cnt > 2 ? fields[2].Value : string.Empty;
        Field3 = cnt > 3 ? fields[3].Value : string.Empty;
        Field4 = cnt > 4 ? fields[4].Value : string.Empty;
        Field5 = cnt > 5 ? fields[5].Value : string.Empty;
    }
}
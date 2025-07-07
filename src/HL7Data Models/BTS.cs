namespace HL7;

/// <summary>
///     BTS - Batch Trailer Segment (HL7 v2.3.1)
///     Field 1: Batch Message Count (ST)
///     Field 2: Batch Comment (ST) (optional)
/// </summary>
public sealed record BTS : HL7Data<BTS> {
    public string BatchMessageCount { get; }
    public string BatchComment { get; }

    public BTS(Segment segment) : base(segment) {
        // HL7 fields are 1-based (segment.Fields[1] is the first field after the segment name)
        BatchMessageCount = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty;
        BatchComment = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;
    }
}
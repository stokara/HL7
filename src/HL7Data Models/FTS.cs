namespace HL7;

/// <summary>
///     FTS - File Trailer Segment (HL7 v2.3.1)
///     Field 1: File Batch Count (ST)
///     Field 2: File Trailer Comment (ST) (optional)
/// </summary>
public sealed record FTS : HL7Data<FTS> {
    public string FileBatchCount { get; }
    public string FileTrailerComment { get; }

    public FTS(Segment segment) : base(segment) {
        // HL7 fields are 1-based (segment.Fields[1] is the first field after the segment name)
        FileBatchCount = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty;
        FileTrailerComment = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;
    }
}
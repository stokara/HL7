namespace HL7;

public sealed record QRC : HL7Data<QRC> {
    public string QueryTag { get; private set; }
    public string QueryResponseStatus { get; private set; }
    public string QueryResponseDateTime { get; private set; }
    public string QueryResultsLevel { get; private set; }

    public QRC(Segment segment) : base(segment) {
        QueryTag = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty;
        QueryResponseStatus = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;
        QueryResponseDateTime = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty;
        QueryResultsLevel = segment.Fields.Count > 4 ? segment.Fields[4].Value : string.Empty;
    }
}
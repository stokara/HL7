using NodaTime;

namespace HL7;

public sealed record QRC : HL7Data<QRC> {
    public string QueryTag { get; }
    public string QueryResponseStatus { get; }
    public Instant? QueryResponseDateTime { get; }
    public string QueryResultsLevel { get; }

    public QRC(Segment segment) : base(segment) {
        QueryTag = segment.GetFieldString(1);
        QueryResponseStatus = segment.GetFieldString(2);
        QueryResponseDateTime = segment.GetFieldInstant(3);
        QueryResultsLevel = segment.GetFieldString(4);
    }
}
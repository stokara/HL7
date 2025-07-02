using System.IO;

public sealed record QRC {
    public string QueryTag { get; init; }
    public string QueryResponseStatus { get; init; }
    public string QueryResponseDateTime { get; init; }
    public string QueryResultsLevel { get; init; }

    private QRC() { }

    public static QRC Load(Segment segment) {
        if (segment.Name != "QRC") throw new InvalidDataException($"Invalid Segment - QRC data is in QRC Segment, this is {segment.Name}");

        return new QRC {
            QueryTag = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty,
            QueryResponseStatus = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty,
            QueryResponseDateTime = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty,
            QueryResultsLevel = segment.Fields.Count > 4 ? segment.Fields[4].Value : string.Empty
        };
    }
}
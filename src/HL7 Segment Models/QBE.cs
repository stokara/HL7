using System.IO;

public sealed record QBE {
    public string FieldSeparator { get;init; }
    public string QueryTag { get;init; }
    public string QueryName { get;init; }
    public string UserParameters { get;init; }

    private QBE() { }

    public static QBE Load(Segment segment) {
        if (segment.Name != "QBE") throw new InvalidDataException($"Invalid Segment - QBE data is in QBE Segment, this is {segment.Name}");

        return new QBE {
            FieldSeparator = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty,
            QueryTag = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty,
            QueryName = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty,
            UserParameters = segment.Fields.Count > 4 ? segment.Fields[4].Value : string.Empty
        };
    }
}
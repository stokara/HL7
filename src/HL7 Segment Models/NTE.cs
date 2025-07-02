using System.IO;

public sealed record NTE {
    public string SetId { get; private set; }
    public string SourceOfComment { get; private set; }
    public string Comment { get; private set; }

    private NTE() { }

    public static NTE Load(Segment segment) {
        if (segment.Name != "NTE") throw new InvalidDataException($"Invalid Segment - NTE data is in NTE Segment, this is {segment.Name}");

        return new NTE {
            SetId = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty,
            SourceOfComment = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty,
            Comment = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty
        };
    }
}
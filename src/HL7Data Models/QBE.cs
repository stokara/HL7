namespace HL7;

public sealed record QBE : HL7Data<QBE> {
    public string FieldSeparator { get; private set; }
    public string QueryTag { get; private set; }
    public string QueryName { get; private set; }
    public string UserParameters { get; private set; }

    public QBE(Segment segment) : base(segment) {
        FieldSeparator = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty;
        QueryTag = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;
        QueryName = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty;
        UserParameters = segment.Fields.Count > 4 ? segment.Fields[4].Value : string.Empty;
    }
}
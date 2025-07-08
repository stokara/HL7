namespace HL7;

public sealed record QBE : HL7Data<QBE> {
    public string FieldSeparator { get; }
    public string QueryTag { get; }
    public string QueryName { get; }
    public string UserParameters { get; }

    public QBE(Segment segment) : base(segment) {
        FieldSeparator = segment.GetFieldString(1);
        QueryTag = segment.GetFieldString(2);
        QueryName = segment.GetFieldString(3);
        UserParameters = segment.GetFieldString(4);
    }
}
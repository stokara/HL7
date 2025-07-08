namespace HL7;

public sealed record NTE : HL7Data<NTE> {
    public string SetId { get; }
    public string SourceOfComment { get; }
    public string Comment { get; }

    public NTE(Segment segment) : base(segment) {
        SetId = segment.GetFieldString(1);
        SourceOfComment = segment.GetFieldString(2);
        Comment = segment.GetFieldString(3);
    }
}

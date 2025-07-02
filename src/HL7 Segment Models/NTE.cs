public sealed record NTE : HL7Data {
    public override string Name => nameof(NTE);
    public string SetId { get; private set; }
    public string SourceOfComment { get; private set; }
    public string Comment { get; private set; }

    private NTE(Segment segment) : base(segment) {
        SetId = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty;
        SourceOfComment = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;
        Comment = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty;
    }

    static NTE() {
        SegmentLoader.Register("NTE", segment => new NTE(segment));
    }
}
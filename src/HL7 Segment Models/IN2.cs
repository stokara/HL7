public sealed record IN2 : IN1 {
    public override string Name => "IN2";
    public string InsuredsEmployeeId { get; private set; }

    private IN2(Segment segment) : base(segment) {
        InsuredsEmployeeId = segment.Fields.Count > 7 ? segment.Fields[7].Value : string.Empty;

    }
}
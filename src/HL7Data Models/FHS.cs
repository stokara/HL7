namespace HL7;

public sealed record FHS : HL7Data<FHS> {
    public FHS(Segment segment) : base(segment) { }
    // Add properties for FHS fields as needed
}
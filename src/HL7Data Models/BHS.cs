namespace HL7;

public sealed record BHS : HL7Data<BHS> {
    public BHS(Segment segment) : base(segment) { }
    // Add properties for BHS fields as needed
}
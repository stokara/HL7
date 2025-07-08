namespace HL7;

/// <summary>
///     ZRX - Example Custom Segment (Z-segments are site-specific)
/// </summary>
public sealed record ZRX : HL7Data<ZRX> {
    public HL7Property<CodedElement> Field1 { get; }
    public HL7Property<CodedElement> Field2 { get; }
    public HL7Property<CodedElement> Field3 { get; }
    public HL7Property<CodedElement> Field4 { get; }
    public HL7Property<CodedElement> Field5 { get; }

    public ZRX(Segment segment) : base(segment) {
        Field1 = CodedElement.CreateHL7Property(segment, 1);
        Field2 = CodedElement.CreateHL7Property(segment, 2);
        Field3 = CodedElement.CreateHL7Property(segment, 3);
        Field4 = CodedElement.CreateHL7Property(segment, 4);
        Field5 = CodedElement.CreateHL7Property(segment, 5);
    }
}
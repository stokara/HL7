using NodaTime;

namespace HL7;

/// <summary>
///     TQ1 - Timing/Quantity Segment (HL7 v2.3.1)
/// </summary>
public sealed record TQ1 : HL7Data<TQ1> {
    public int? SetId { get; }
    public decimal? Quantity { get; }
    public HL7Property<CodedElement> RepeatPattern { get; }
    public string ExplicitTime { get; }
    public HL7Property<CodedElement> RelativeTimeAndUnits { get; }
    public HL7Property<CodedElement> ServiceDuration { get; }
    public Instant? StartDateTime { get; }
    public Instant? EndDateTime { get; }
    public string Priority { get; }
    public HL7Property<CodedElement> ConditionText { get; }
    public string TextInstruction { get; }
    public string Conjunction { get; }
    public HL7Property<CodedElement> OrderSequencing { get; }
    public HL7Property<CodedElement> OccurrenceDuration { get; }
    public int? TotalOccurrences { get; }

    public TQ1(Segment segment) : base(segment) {
        SetId = segment.GetFieldInt(1);
        Quantity = segment.GetFieldDecimal(2);
        RepeatPattern = CodedElement.CreateHL7Property(segment, 3);
        ExplicitTime = segment.GetFieldString(4);
        RelativeTimeAndUnits = CodedElement.CreateHL7Property(segment, 5);
        ServiceDuration = CodedElement.CreateHL7Property(segment, 6);
        StartDateTime = segment.GetFieldInstant(7);
        EndDateTime = segment.GetFieldInstant(8);
        Priority = segment.GetFieldString(9);
        ConditionText = CodedElement.CreateHL7Property(segment, 10);
        TextInstruction = segment.GetFieldString(11);
        Conjunction = segment.GetFieldString(12);
        OrderSequencing = CodedElement.CreateHL7Property(segment, 13);
        OccurrenceDuration = CodedElement.CreateHL7Property(segment, 14);
        TotalOccurrences = segment.GetFieldInt(15);
    }
}
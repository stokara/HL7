namespace HL7;

/// <summary>
///     TQ1 - Timing/Quantity Segment (HL7 v2.3.1)
/// </summary>
public sealed record TQ1 : HL7Data<TQ1> {
    public string SetId { get; }
    public string Quantity { get; }
    public string RepeatPattern { get; }
    public string ExplicitTime { get; }
    public string RelativeTimeAndUnits { get; }
    public string ServiceDuration { get; }
    public string StartDateTime { get; }
    public string EndDateTime { get; }
    public string Priority { get; }
    public string ConditionText { get; }
    public string TextInstruction { get; }
    public string Conjunction { get; }
    public string OrderSequencing { get; }
    public string OccurrenceDuration { get; }
    public string TotalOccurrences { get; }

    public TQ1(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        SetId = cnt > 1 ? fields[1].Value : string.Empty;
        Quantity = cnt > 2 ? fields[2].Value : string.Empty;
        RepeatPattern = cnt > 3 ? fields[3].Value : string.Empty;
        ExplicitTime = cnt > 4 ? fields[4].Value : string.Empty;
        RelativeTimeAndUnits = cnt > 5 ? fields[5].Value : string.Empty;
        ServiceDuration = cnt > 6 ? fields[6].Value : string.Empty;
        StartDateTime = cnt > 7 ? fields[7].Value : string.Empty;
        EndDateTime = cnt > 8 ? fields[8].Value : string.Empty;
        Priority = cnt > 9 ? fields[9].Value : string.Empty;
        ConditionText = cnt > 10 ? fields[10].Value : string.Empty;
        TextInstruction = cnt > 11 ? fields[11].Value : string.Empty;
        Conjunction = cnt > 12 ? fields[12].Value : string.Empty;
        OrderSequencing = cnt > 13 ? fields[13].Value : string.Empty;
        OccurrenceDuration = cnt > 14 ? fields[14].Value : string.Empty;
        TotalOccurrences = cnt > 15 ? fields[15].Value : string.Empty;
    }
}
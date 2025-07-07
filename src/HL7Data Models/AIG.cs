namespace HL7;

/// <summary>
///     AIG - Appointment Information - General Resource Segment (HL7 v2.3.1)
/// </summary>
public sealed record AIG : HL7Data<AIG> {
    public string SetId { get; }
    public string SegmentActionCode { get; }
    public string ResourceId { get; }
    public string ResourceType { get; }
    public string ResourceGroup { get; }
    public string ResourceQuantity { get; }
    public string ResourceQuantityUnits { get; }
    public string StartDateTime { get; }
    public string StartDateTimeOffset { get; }
    public string StartDateTimeOffsetUnits { get; }
    public string Duration { get; }
    public string DurationUnits { get; }
    public string AllowSubstitutionCode { get; }
    public string FillerStatusCode { get; }

    public AIG(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        SetId = cnt > 1 ? fields[1].Value : string.Empty;
        SegmentActionCode = cnt > 2 ? fields[2].Value : string.Empty;
        ResourceId = cnt > 3 ? fields[3].Value : string.Empty;
        ResourceType = cnt > 4 ? fields[4].Value : string.Empty;
        ResourceGroup = cnt > 5 ? fields[5].Value : string.Empty;
        ResourceQuantity = cnt > 6 ? fields[6].Value : string.Empty;
        ResourceQuantityUnits = cnt > 7 ? fields[7].Value : string.Empty;
        StartDateTime = cnt > 8 ? fields[8].Value : string.Empty;
        StartDateTimeOffset = cnt > 9 ? fields[9].Value : string.Empty;
        StartDateTimeOffsetUnits = cnt > 10 ? fields[10].Value : string.Empty;
        Duration = cnt > 11 ? fields[11].Value : string.Empty;
        DurationUnits = cnt > 12 ? fields[12].Value : string.Empty;
        AllowSubstitutionCode = cnt > 13 ? fields[13].Value : string.Empty;
        FillerStatusCode = cnt > 14 ? fields[14].Value : string.Empty;
    }
}
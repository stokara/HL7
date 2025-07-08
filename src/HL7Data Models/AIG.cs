using NodaTime;

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
    public decimal? ResourceQuantity { get; }
    public string ResourceQuantityUnits { get; }
    public Instant? StartDateTime { get; }
    public decimal? StartDateTimeOffset { get; }
    public string StartDateTimeOffsetUnits { get; }
    public decimal? Duration { get; }
    public string DurationUnits { get; }
    public string AllowSubstitutionCode { get; }
    public string FillerStatusCode { get; }

    public AIG(Segment segment) : base(segment) {
        SetId = segment.GetFieldString(1);
        SegmentActionCode = segment.GetFieldString(2);
        ResourceId = segment.GetFieldString(3);
        ResourceType = segment.GetFieldString(4);
        ResourceGroup = segment.GetFieldString(5);
        ResourceQuantity = segment.GetFieldDecimal(6);
        ResourceQuantityUnits = segment.GetFieldString(7);
        StartDateTime = segment.GetFieldInstant(8);
        StartDateTimeOffset = segment.GetFieldDecimal(9);
        StartDateTimeOffsetUnits = segment.GetFieldString(10);
        Duration = segment.GetFieldDecimal(11);
        DurationUnits = segment.GetFieldString(12);
        AllowSubstitutionCode = segment.GetFieldString(13);
        FillerStatusCode = segment.GetFieldString(14);
    }
}
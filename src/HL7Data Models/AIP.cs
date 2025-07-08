using NodaTime;

namespace HL7;

/// <summary>
///     AIP - Appointment Information - Personnel Resource Segment (HL7 v2.3.1)
/// </summary>
public sealed record AIP : HL7Data<AIP> {
    public string SetId { get; }
    public string SegmentActionCode { get; }
    public string PersonnelResourceId { get; }
    public string ResourceType { get; }
    public string ResourceGroup { get; }
    public Instant? StartDateTime { get; }
    public decimal? StartDateTimeOffset { get; }
    public string StartDateTimeOffsetUnits { get; }
    public decimal? Duration { get; }
    public string DurationUnits { get; }
    public string AllowSubstitutionCode { get; }
    public string FillerStatusCode { get; }

    public AIP(Segment segment) : base(segment) {
        SetId = segment.GetFieldString(1);
        SegmentActionCode = segment.GetFieldString(2);
        PersonnelResourceId = segment.GetFieldString(3);
        ResourceType = segment.GetFieldString(4);
        ResourceGroup = segment.GetFieldString(5);
        StartDateTime = segment.GetFieldInstant(6);
        StartDateTimeOffset = segment.GetFieldDecimal(7);
        StartDateTimeOffsetUnits = segment.GetFieldString(8);
        Duration = segment.GetFieldDecimal(9);
        DurationUnits = segment.GetFieldString(10);
        AllowSubstitutionCode = segment.GetFieldString(11);
        FillerStatusCode = segment.GetFieldString(12);
    }
}
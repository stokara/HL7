namespace HL7;

/// <summary>
///     EVN - Event Type Segment (HL7 v2.3.1)
/// </summary>
public sealed record EVN : HL7Data<EVN> {
    public string EventTypeCode { get; }
    public string RecordedDateTime { get; }
    public string DateTimePlannedEvent { get; }
    public string EventReasonCode { get; }
    public string OperatorId { get; }
    public string EventOccurred { get; }
    public string EventFacility { get; }

    public EVN(Segment segment) : base(segment) {
        EventTypeCode = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty;
        RecordedDateTime = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;
        DateTimePlannedEvent = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty;
        EventReasonCode = segment.Fields.Count > 4 ? segment.Fields[4].Value : string.Empty;
        OperatorId = segment.Fields.Count > 5 ? segment.Fields[5].Value : string.Empty;
        EventOccurred = segment.Fields.Count > 6 ? segment.Fields[6].Value : string.Empty;
        EventFacility = segment.Fields.Count > 7 ? segment.Fields[7].Value : string.Empty;
    }
}
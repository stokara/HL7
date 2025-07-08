using NodaTime;

namespace HL7;

/// <summary>
///     EVN - Event Type Segment (HL7 v2.3.1)
/// </summary>
public sealed record EVN : HL7Data<EVN> {
    public string EventTypeCode { get; }
    public Instant? RecordedDateTime { get; }
    public Instant? DateTimePlannedEvent { get; }
    public string EventReasonCode { get; }
    public string OperatorId { get; }
    public Instant? EventOccurred { get; }
    public string EventFacility { get; }

    public EVN(Segment segment) : base(segment) {
        EventTypeCode = segment.GetFieldString(1);
        RecordedDateTime = segment.GetFieldInstant(2);
        DateTimePlannedEvent = segment.GetFieldInstant(3);
        EventReasonCode = segment.GetFieldString(4);
        OperatorId = segment.GetFieldString(5);
        EventOccurred = segment.GetFieldInstant(6);
        EventFacility = segment.GetFieldString(7);
    }
}
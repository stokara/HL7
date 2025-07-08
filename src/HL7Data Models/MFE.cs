using NodaTime;

namespace HL7;

/// <summary>
///     MFE - Master File Entry Segment (HL7 v2.3.1)
/// </summary>
public sealed record MFE : HL7Data<MFE> {
    public string RecordLevelEventCode { get; }
    public string MFNControlId { get; }
    public Instant? EffectiveDateTime { get; }
    public string PrimaryKeyValueMFE { get; }
    public string PrimaryKeyValueType { get; }

    public MFE(Segment segment) : base(segment) {
        RecordLevelEventCode = segment.GetFieldString(1);
        MFNControlId = segment.GetFieldString(2);
        EffectiveDateTime = segment.GetFieldInstant(3);
        PrimaryKeyValueMFE = segment.GetFieldString(4);
        PrimaryKeyValueType = segment.GetFieldString(5);
    }
}
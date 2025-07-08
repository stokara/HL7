using NodaTime;

namespace HL7;

/// <summary>
///     MFI - Master File Identification Segment (HL7 v2.3.1)
/// </summary>
public sealed record MFI : HL7Data<MFI> {
    public string MasterFileIdentifier { get; }
    public string MasterFileApplicationIdentifier { get; }
    public string FileLevelEventCode { get; }
    public Instant? EnteredDateTime { get; }
    public Instant? EffectiveDateTime { get; }
    public string ResponseLevelCode { get; }

    public MFI(Segment segment) : base(segment) {
        MasterFileIdentifier = segment.GetFieldString(1);
        MasterFileApplicationIdentifier = segment.GetFieldString(2);
        FileLevelEventCode = segment.GetFieldString(3);
        EnteredDateTime = segment.GetFieldInstant(4);
        EffectiveDateTime = segment.GetFieldInstant(5);
        ResponseLevelCode = segment.GetFieldString(6);
    }
}
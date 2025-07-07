namespace HL7;

/// <summary>
///     MFE - Master File Entry Segment (HL7 v2.3.1)
/// </summary>
public sealed record MFE : HL7Data<MFE> {
    public string RecordLevelEventCode { get; }
    public string MFNControlId { get; }
    public string EffectiveDateTime { get; }
    public string PrimaryKeyValueMFE { get; }
    public string PrimaryKeyValueType { get; }

    public MFE(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        RecordLevelEventCode = cnt > 1 ? fields[1].Value : string.Empty;
        MFNControlId = cnt > 2 ? fields[2].Value : string.Empty;
        EffectiveDateTime = cnt > 3 ? fields[3].Value : string.Empty;
        PrimaryKeyValueMFE = cnt > 4 ? fields[4].Value : string.Empty;
        PrimaryKeyValueType = cnt > 5 ? fields[5].Value : string.Empty;
    }
}
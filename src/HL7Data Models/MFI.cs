namespace HL7;

/// <summary>
///     MFI - Master File Identification Segment (HL7 v2.3.1)
/// </summary>
public sealed record MFI : HL7Data<MFI> {
    public string MasterFileIdentifier { get; }
    public string MasterFileApplicationIdentifier { get; }
    public string FileLevelEventCode { get; }
    public string EnteredDateTime { get; }
    public string EffectiveDateTime { get; }
    public string ResponseLevelCode { get; }

    public MFI(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        MasterFileIdentifier = cnt > 1 ? fields[1].Value : string.Empty;
        MasterFileApplicationIdentifier = cnt > 2 ? fields[2].Value : string.Empty;
        FileLevelEventCode = cnt > 3 ? fields[3].Value : string.Empty;
        EnteredDateTime = cnt > 4 ? fields[4].Value : string.Empty;
        EffectiveDateTime = cnt > 5 ? fields[5].Value : string.Empty;
        ResponseLevelCode = cnt > 6 ? fields[6].Value : string.Empty;
    }
}
namespace HL7;

/// <summary>
///     MRG - Merge Patient Information Segment (HL7 v2.3.1)
/// </summary>
public sealed record MRG : HL7Data<MRG> {
    public string PriorPatientIdentifierList { get; }
    public string PriorAlternatePatientId { get; }
    public string PriorPatientAccountNumber { get; }
    public string PriorPatientId { get; }
    public string PriorVisitNumber { get; }
    public string PriorAlternateVisitId { get; }
    public string PriorPatientName { get; }

    public MRG(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        PriorPatientIdentifierList = cnt > 1 ? fields[1].Value : string.Empty;
        PriorAlternatePatientId = cnt > 2 ? fields[2].Value : string.Empty;
        PriorPatientAccountNumber = cnt > 3 ? fields[3].Value : string.Empty;
        PriorPatientId = cnt > 4 ? fields[4].Value : string.Empty;
        PriorVisitNumber = cnt > 5 ? fields[5].Value : string.Empty;
        PriorAlternateVisitId = cnt > 6 ? fields[6].Value : string.Empty;
        PriorPatientName = cnt > 7 ? fields[7].Value : string.Empty;
    }
}
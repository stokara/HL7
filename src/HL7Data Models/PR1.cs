namespace HL7;

/// <summary>
///     PR1 - Procedures Segment (HL7 v2.3.1)
/// </summary>
public sealed record PR1 : HL7Data<PR1> {
    public string SetId { get; }
    public string ProcedureCodingMethod { get; }
    public string ProcedureCode { get; }
    public string ProcedureDescription { get; }
    public string ProcedureDateTime { get; }
    public string ProcedureType { get; }
    public string ProcedureMinutes { get; }
    public string Anesthesiologist { get; }
    public string AnesthesiaCode { get; }
    public string AnesthesiaMinutes { get; }
    public string Surgeon { get; }
    public string ProcedurePractitioner { get; }
    public string ConsentCode { get; }
    public string ProcedurePriority { get; }
    public string AssociatedDiagnosisCode { get; }

    public PR1(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        SetId = cnt > 1 ? fields[1].Value : string.Empty;
        ProcedureCodingMethod = cnt > 2 ? fields[2].Value : string.Empty;
        ProcedureCode = cnt > 3 ? fields[3].Value : string.Empty;
        ProcedureDescription = cnt > 4 ? fields[4].Value : string.Empty;
        ProcedureDateTime = cnt > 5 ? fields[5].Value : string.Empty;
        ProcedureType = cnt > 6 ? fields[6].Value : string.Empty;
        ProcedureMinutes = cnt > 7 ? fields[7].Value : string.Empty;
        Anesthesiologist = cnt > 8 ? fields[8].Value : string.Empty;
        AnesthesiaCode = cnt > 9 ? fields[9].Value : string.Empty;
        AnesthesiaMinutes = cnt > 10 ? fields[10].Value : string.Empty;
        Surgeon = cnt > 11 ? fields[11].Value : string.Empty;
        ProcedurePractitioner = cnt > 12 ? fields[12].Value : string.Empty;
        ConsentCode = cnt > 13 ? fields[13].Value : string.Empty;
        ProcedurePriority = cnt > 14 ? fields[14].Value : string.Empty;
        AssociatedDiagnosisCode = cnt > 15 ? fields[15].Value : string.Empty;
    }
}
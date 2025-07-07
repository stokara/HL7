namespace HL7;

/// <summary>
///     DG1 - Diagnosis Segment (HL7 v2.3.1)
/// </summary>
public sealed record DG1 : HL7Data<DG1> {
    public string SetId { get; }
    public string DiagnosisCodingMethod { get; }
    public string DiagnosisCode { get; }
    public string DiagnosisDescription { get; }
    public string DiagnosisDateTime { get; }
    public string DiagnosisType { get; }
    public string MajorDiagnosticCategory { get; }
    public string DiagnosticRelatedGroup { get; }
    public string DRGApprovalIndicator { get; }
    public string DRGGrouperReviewCode { get; }
    public string OutlierType { get; }
    public string OutlierDays { get; }
    public string OutlierCost { get; }
    public string GrouperVersionAndType { get; }
    public string DiagnosisPriority { get; }
    public string DiagnosingClinician { get; }
    public string DiagnosisClassification { get; }
    public string ConfidentialIndicator { get; }
    public string AttestationDateTime { get; }

    public DG1(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        SetId = cnt > 1 ? fields[1].Value : string.Empty;
        DiagnosisCodingMethod = cnt > 2 ? fields[2].Value : string.Empty;
        DiagnosisCode = cnt > 3 ? fields[3].Value : string.Empty;
        DiagnosisDescription = cnt > 4 ? fields[4].Value : string.Empty;
        DiagnosisDateTime = cnt > 5 ? fields[5].Value : string.Empty;
        DiagnosisType = cnt > 6 ? fields[6].Value : string.Empty;
        MajorDiagnosticCategory = cnt > 7 ? fields[7].Value : string.Empty;
        DiagnosticRelatedGroup = cnt > 8 ? fields[8].Value : string.Empty;
        DRGApprovalIndicator = cnt > 9 ? fields[9].Value : string.Empty;
        DRGGrouperReviewCode = cnt > 10 ? fields[10].Value : string.Empty;
        OutlierType = cnt > 11 ? fields[11].Value : string.Empty;
        OutlierDays = cnt > 12 ? fields[12].Value : string.Empty;
        OutlierCost = cnt > 13 ? fields[13].Value : string.Empty;
        GrouperVersionAndType = cnt > 14 ? fields[14].Value : string.Empty;
        DiagnosisPriority = cnt > 15 ? fields[15].Value : string.Empty;
        DiagnosingClinician = cnt > 16 ? fields[16].Value : string.Empty;
        DiagnosisClassification = cnt > 17 ? fields[17].Value : string.Empty;
        ConfidentialIndicator = cnt > 18 ? fields[18].Value : string.Empty;
        AttestationDateTime = cnt > 19 ? fields[19].Value : string.Empty;
    }
}
using NodaTime;

namespace HL7;

/// <summary>
///     DG1 - Diagnosis Segment (HL7 v2.3.1)
/// </summary>
public sealed record DG1 : HL7Data<DG1> {
    public string SetId { get; }
    public string DiagnosisCodingMethod { get; }
    public string DiagnosisCode { get; }
    public string DiagnosisDescription { get; }
    public Instant? DiagnosisDateTime { get; }
    public string DiagnosisType { get; }
    public string MajorDiagnosticCategory { get; }
    public string DiagnosticRelatedGroup { get; }
    public string DRGApprovalIndicator { get; }
    public string DRGGrouperReviewCode { get; }
    public string OutlierType { get; }
    public int? OutlierDays { get; }
    public decimal? OutlierCost { get; }
    public string GrouperVersionAndType { get; }
    public int? DiagnosisPriority { get; }
    public string DiagnosingClinician { get; }
    public string DiagnosisClassification { get; }
    public string ConfidentialIndicator { get; }
    public Instant? AttestationDateTime { get; }

    public DG1(Segment segment) : base(segment) {
        SetId = segment.GetFieldString(1);
        DiagnosisCodingMethod = segment.GetFieldString(2);
        DiagnosisCode = segment.GetFieldString(3);
        DiagnosisDescription = segment.GetFieldString(4);
        DiagnosisDateTime = segment.GetFieldInstant(5);
        DiagnosisType = segment.GetFieldString(6);
        MajorDiagnosticCategory = segment.GetFieldString(7);
        DiagnosticRelatedGroup = segment.GetFieldString(8);
        DRGApprovalIndicator = segment.GetFieldString(9);
        DRGGrouperReviewCode = segment.GetFieldString(10);
        OutlierType = segment.GetFieldString(11);
        OutlierDays = segment.GetFieldInt(12);
        OutlierCost = segment.GetFieldDecimal(13);
        GrouperVersionAndType = segment.GetFieldString(14);
        DiagnosisPriority = segment.GetFieldInt(15);
        DiagnosingClinician = segment.GetFieldString(16);
        DiagnosisClassification = segment.GetFieldString(17);
        ConfidentialIndicator = segment.GetFieldString(18);
        AttestationDateTime = segment.GetFieldInstant(19);
    }
}
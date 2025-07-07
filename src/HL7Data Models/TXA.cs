namespace HL7;

/// <summary>
///     TXA - Document Notification Segment (HL7 v2.3.1)
/// </summary>
public sealed record TXA : HL7Data<TXA> {
    public string SetId { get; }
    public string DocumentType { get; }
    public string DocumentContentPresentation { get; }
    public string ActivityDateTime { get; }
    public string PrimaryActivityProviderCodeName { get; }
    public string OriginationDateTime { get; }
    public string TranscriptionDateTime { get; }
    public string EditDateTime { get; }
    public string OriginatorCodeName { get; }
    public string AssignedDocumentAuthenticator { get; }
    public string TranscriptionistCodeName { get; }
    public string UniqueDocumentNumber { get; }
    public string ParentDocumentNumber { get; }
    public string PlacerOrderNumber { get; }
    public string FillerOrderNumber { get; }
    public string UniqueDocumentFileName { get; }
    public string DocumentCompletionStatus { get; }
    public string DocumentConfidentialityStatus { get; }
    public string DocumentAvailabilityStatus { get; }
    public string DocumentStorageStatus { get; }
    public string DocumentChangeReason { get; }
    public string AuthenticatedByCodeName { get; }
    public string TranscriptionistOrderNumber { get; }

    public TXA(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        SetId = cnt > 1 ? fields[1].Value : string.Empty;
        DocumentType = cnt > 2 ? fields[2].Value : string.Empty;
        DocumentContentPresentation = cnt > 3 ? fields[3].Value : string.Empty;
        ActivityDateTime = cnt > 4 ? fields[4].Value : string.Empty;
        PrimaryActivityProviderCodeName = cnt > 5 ? fields[5].Value : string.Empty;
        OriginationDateTime = cnt > 6 ? fields[6].Value : string.Empty;
        TranscriptionDateTime = cnt > 7 ? fields[7].Value : string.Empty;
        EditDateTime = cnt > 8 ? fields[8].Value : string.Empty;
        OriginatorCodeName = cnt > 9 ? fields[9].Value : string.Empty;
        AssignedDocumentAuthenticator = cnt > 10 ? fields[10].Value : string.Empty;
        TranscriptionistCodeName = cnt > 11 ? fields[11].Value : string.Empty;
        UniqueDocumentNumber = cnt > 12 ? fields[12].Value : string.Empty;
        ParentDocumentNumber = cnt > 13 ? fields[13].Value : string.Empty;
        PlacerOrderNumber = cnt > 14 ? fields[14].Value : string.Empty;
        FillerOrderNumber = cnt > 15 ? fields[15].Value : string.Empty;
        UniqueDocumentFileName = cnt > 16 ? fields[16].Value : string.Empty;
        DocumentCompletionStatus = cnt > 17 ? fields[17].Value : string.Empty;
        DocumentConfidentialityStatus = cnt > 18 ? fields[18].Value : string.Empty;
        DocumentAvailabilityStatus = cnt > 19 ? fields[19].Value : string.Empty;
        DocumentStorageStatus = cnt > 20 ? fields[20].Value : string.Empty;
        DocumentChangeReason = cnt > 21 ? fields[21].Value : string.Empty;
        AuthenticatedByCodeName = cnt > 22 ? fields[22].Value : string.Empty;
        TranscriptionistOrderNumber = cnt > 23 ? fields[23].Value : string.Empty;
    }
}
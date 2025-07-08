using NodaTime;

namespace HL7;

/// <summary>
///     TXA - Document Notification Segment (HL7 v2.3.1)
/// </summary>
public sealed record TXA : HL7Data<TXA> {
    public int? SetId { get; }
    public HL7Property<CodedElement> DocumentType { get; }
    public HL7Property<CodedElement> DocumentContentPresentation { get; }
    public Instant? ActivityDateTime { get; }
    public HL7Property<PersonName> PrimaryActivityProviderCodeName { get; }
    public Instant? OriginationDateTime { get; }
    public Instant? TranscriptionDateTime { get; }
    public Instant? EditDateTime { get; }
    public HL7Property<PersonName> OriginatorCodeName { get; }
    public HL7Property<PersonName> AssignedDocumentAuthenticator { get; }
    public HL7Property<PersonName> TranscriptionistCodeName { get; }
    public HL7Property<EntityIdentifier> UniqueDocumentNumber { get; }
    public HL7Property<EntityIdentifier> ParentDocumentNumber { get; }
    public HL7Property<EntityIdentifier> PlacerOrderNumber { get; }
    public HL7Property<EntityIdentifier> FillerOrderNumber { get; }
    public string UniqueDocumentFileName { get; }
    public string DocumentCompletionStatus { get; }
    public string DocumentConfidentialityStatus { get; }
    public string DocumentAvailabilityStatus { get; }
    public string DocumentStorageStatus { get; }
    public string DocumentChangeReason { get; }
    public HL7Property<PersonName> AuthenticatedByCodeName { get; }
    public HL7Property<EntityIdentifier> TranscriptionistOrderNumber { get; }

    public TXA(Segment segment) : base(segment) {
        SetId = segment.GetFieldInt(1);
        DocumentType = CodedElement.CreateHL7Property(segment, 2);
        DocumentContentPresentation = CodedElement.CreateHL7Property(segment, 3);
        ActivityDateTime = segment.GetFieldInstant(4);
        PrimaryActivityProviderCodeName = PersonName.CreateHL7Property(segment, 5);
        OriginationDateTime = segment.GetFieldInstant(6);
        TranscriptionDateTime = segment.GetFieldInstant(7);
        EditDateTime = segment.GetFieldInstant(8);
        OriginatorCodeName = PersonName.CreateHL7Property(segment, 9);
        AssignedDocumentAuthenticator = PersonName.CreateHL7Property(segment, 10);
        TranscriptionistCodeName = PersonName.CreateHL7Property(segment, 11);
        UniqueDocumentNumber = EntityIdentifier.CreateHL7Property(segment, 12);
        ParentDocumentNumber = EntityIdentifier.CreateHL7Property(segment, 13);
        PlacerOrderNumber = EntityIdentifier.CreateHL7Property(segment, 14);
        FillerOrderNumber = EntityIdentifier.CreateHL7Property(segment, 15);
        UniqueDocumentFileName = segment.GetFieldString(16);
        DocumentCompletionStatus = segment.GetFieldString(17);
        DocumentConfidentialityStatus = segment.GetFieldString(18);
        DocumentAvailabilityStatus = segment.GetFieldString(19);
        DocumentStorageStatus = segment.GetFieldString(20);
        DocumentChangeReason = segment.GetFieldString(21);
        AuthenticatedByCodeName = PersonName.CreateHL7Property(segment, 22);
        TranscriptionistOrderNumber = EntityIdentifier.CreateHL7Property(segment, 23);
    }
}
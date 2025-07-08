using NodaTime;

namespace HL7;

/// <summary>
///     SPM - Specimen Segment (HL7 v2.5)
/// </summary>
public sealed record SPM : HL7Data<SPM> {
    public string SetId { get; }
    public CodedElement SpecimenId { get; }
    public CodedElement SpecimenParentId { get; }
    public CodedElement SpecimenType { get; }
    public CodedElement SpecimenTypeModifier { get; }
    public CodedElement SpecimenAdditives { get; }
    public CodedElement SpecimenCollectionMethod { get; }
    public CodedElement SpecimenSourceSite { get; }
    public CodedElement SpecimenSourceSiteModifier { get; }
    public CodedElement SpecimenCollectionSite { get; }
    public CodedElement SpecimenRole { get; }
    public decimal? SpecimenCollectionAmount { get; }
    public int? GroupedSpecimenCount { get; }
    public string SpecimenDescription { get; }
    public CodedElement SpecimenHandlingCode { get; }
    public CodedElement SpecimenRiskCode { get; }
    public Instant? SpecimenCollectionDateTime { get; }
    public Instant? SpecimenReceivedDateTime { get; }
    public Instant? SpecimenExpirationDateTime { get; }
    public string SpecimenAvailability { get; }
    public HL7Property<CodedElement> SpecimenRejectReason { get; }
    public HL7Property<CodedElement> SpecimenQuality { get; }
    public HL7Property<CodedElement> SpecimenAppropriateness { get; }
    public HL7Property<CodedElement> SpecimenCondition { get; }
    public decimal? SpecimenCurrentQuantity { get; }
    public int? NumberOfSpecimenContainers { get; }
    public CodedElement ContainerType { get; }
    public CodedElement ContainerCondition { get; }
    public CodedElement SpecimenChildRole { get; }

    public SPM(Segment segment) : base(segment) {
        SetId = segment.GetFieldString(1);
        SpecimenId = CodedElement.Parse(segment.GetField(2));
        SpecimenParentId = CodedElement.Parse(segment.GetField(3));
        SpecimenType = CodedElement.Parse(segment.GetField(4));
        SpecimenTypeModifier = CodedElement.Parse(segment.GetField(5));
        SpecimenAdditives = CodedElement.Parse(segment.GetField(6));
        SpecimenCollectionMethod = CodedElement.Parse(segment.GetField(7));
        SpecimenSourceSite = CodedElement.Parse(segment.GetField(8));
        SpecimenSourceSiteModifier = CodedElement.Parse(segment.GetField(9));
        SpecimenCollectionSite = CodedElement.Parse(segment.GetField(10));
        SpecimenRole = CodedElement.Parse(segment.GetField(11));
        SpecimenCollectionAmount = segment.GetFieldDecimal(12);
        GroupedSpecimenCount = segment.GetFieldInt(13);
        SpecimenDescription = segment.GetFieldString(14);
        SpecimenHandlingCode = CodedElement.Parse(segment.GetField(15));
        SpecimenRiskCode = CodedElement.Parse(segment.GetField(16));
        SpecimenCollectionDateTime = segment.GetFieldInstant(17);
        SpecimenReceivedDateTime = segment.GetFieldInstant(18);
        SpecimenExpirationDateTime = segment.GetFieldInstant(19);
        SpecimenAvailability = segment.GetFieldString(20);
        SpecimenRejectReason = CodedElement.CreateHL7Property(segment, 21);
        SpecimenQuality = CodedElement.CreateHL7Property(segment, 22);
        SpecimenAppropriateness = CodedElement.CreateHL7Property(segment, 23);
        SpecimenCondition = CodedElement.CreateHL7Property(segment, 24);
        SpecimenCurrentQuantity = segment.GetFieldDecimal(25);
        NumberOfSpecimenContainers = segment.GetFieldInt(26);
        ContainerType = CodedElement.Parse(segment.GetField(27));
        ContainerCondition = CodedElement.Parse(segment.GetField(28));
        SpecimenChildRole = CodedElement.Parse(segment.GetField(29));
    }
}
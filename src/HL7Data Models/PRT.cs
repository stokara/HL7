using NodaTime;

namespace HL7;

/// <summary>
///     PRT - Participation Information Segment (HL7 v2.7)
/// </summary>
public sealed record PRT : HL7Data<PRT> {
    public string ActionCode { get; }
    public string ActionReason { get; }
    public HL7Property<CodedElement> Participation { get; }
    public HL7Property<PersonName> ParticipationPerson { get; }
    public HL7Property<CodedElement> ParticipationPersonProviderType { get; }
    public HL7Property<EntityIdentifier> ParticipationPersonIdentifier { get; }
    public HL7Property<CodedElement> ParticipantOrganizationUnitType { get; }
    public HL7Property<EntityIdentifier> ParticipationOrganization { get; }
    public Instant? ParticipationBeginDateTime { get; }
    public Instant? ParticipationEndDateTime { get; }
    public int? ParticipationDuration { get; }
    public HL7Property<CodedElement> ParticipationDurationUnits { get; }
    public HL7Property<Address> ParticipationOrganizationAddress { get; }
    public HL7Property<CodedElement> ParticipationOrganizationLocation { get; }

    public PRT(Segment segment) : base(segment) {
        ActionCode = segment.GetFieldString(1);
        ActionReason = segment.GetFieldString(2);
        Participation = CodedElement.CreateHL7Property(segment, 3);
        ParticipationPerson = PersonName.CreateHL7Property(segment, 4);
        ParticipationPersonProviderType = CodedElement.CreateHL7Property(segment, 5);
        ParticipationPersonIdentifier = EntityIdentifier.CreateHL7Property(segment, 6);
        ParticipantOrganizationUnitType = CodedElement.CreateHL7Property(segment, 7);
        ParticipationOrganization = EntityIdentifier.CreateHL7Property(segment, 8);
        ParticipationBeginDateTime = segment.GetFieldInstant(9);
        ParticipationEndDateTime = segment.GetFieldInstant(10);
        ParticipationDuration = segment.GetFieldInt(11);
        ParticipationDurationUnits = CodedElement.CreateHL7Property(segment, 12);
        ParticipationOrganizationAddress = Address.CreateHL7Property(segment, 13);
        ParticipationOrganizationLocation = CodedElement.CreateHL7Property(segment, 14);
    }
}
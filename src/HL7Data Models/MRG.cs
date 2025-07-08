namespace HL7;

/// <summary>
///     MRG - Merge Patient Information Segment (HL7 v2.3.1)
/// </summary>
public sealed record MRG : HL7Data<MRG> {
    public HL7Property<EntityIdentifier> PriorEntityIdentifierList { get; }
    public HL7Property<EntityIdentifier> PriorAlternatePatientId { get; }
    public HL7Property<EntityIdentifier> PriorPatientAccountNumber { get; }
    public HL7Property<EntityIdentifier> PriorPatientId { get; }
    public HL7Property<EntityIdentifier> PriorVisitNumber { get; }
    public HL7Property<EntityIdentifier> PriorAlternateVisitId { get; }
    public HL7Property<PersonName> PriorPatientName { get; }

    public MRG(Segment segment) : base(segment) {
        PriorEntityIdentifierList = EntityIdentifier.CreateHL7Property(segment, 1);
        PriorAlternatePatientId = EntityIdentifier.CreateHL7Property(segment, 2);
        PriorPatientAccountNumber = EntityIdentifier.CreateHL7Property(segment, 3);
        PriorPatientId = EntityIdentifier.CreateHL7Property(segment, 4);
        PriorVisitNumber = EntityIdentifier.CreateHL7Property(segment, 5);
        PriorAlternateVisitId = EntityIdentifier.CreateHL7Property(segment, 6);
        PriorPatientName = PersonName.CreateHL7Property(segment, 7);
    }
}
using NodaTime;

namespace HL7;

/// <summary>
///     PRA - Practitioner Detail Segment (HL7 v2.3.1)
/// </summary>
public sealed record PRA : HL7Data<PRA> {
    public HL7Property<EntityIdentifier> PrimaryKeyValuePRA { get; }
    public HL7Property<CodedElement> PractitionerGroup { get; }
    public HL7Property<CodedElement> PractitionerCategory { get; }
    public HL7Property<CodedElement> ProviderBilling { get; }
    public HL7Property<CodedElement> Specialty { get; }
    public HL7Property<EntityIdentifier> PractitionerIdNumbers { get; }
    public HL7Property<CodedElement> Privileges { get; }
    public Instant? DateEnteredPractice { get; }
    public HL7Property<CodedElement> Institution { get; }
    public Instant? DateLeftPractice { get; }
    public HL7Property<CodedElement> GovernmentReimbursementBillingEligibility { get; }
    public int? SetId { get; }

    public PRA(Segment segment) : base(segment) {
        PrimaryKeyValuePRA = EntityIdentifier.CreateHL7Property(segment, 1);
        PractitionerGroup = CodedElement.CreateHL7Property(segment, 2);
        PractitionerCategory = CodedElement.CreateHL7Property(segment, 3);
        ProviderBilling = CodedElement.CreateHL7Property(segment, 4);
        Specialty = CodedElement.CreateHL7Property(segment, 5);
        PractitionerIdNumbers = EntityIdentifier.CreateHL7Property(segment, 6);
        Privileges = CodedElement.CreateHL7Property(segment, 7);
        DateEnteredPractice = segment.GetFieldInstant(8);
        Institution = CodedElement.CreateHL7Property(segment, 9);
        DateLeftPractice = segment.GetFieldInstant(10);
        GovernmentReimbursementBillingEligibility = CodedElement.CreateHL7Property(segment, 11);
        SetId = segment.GetFieldInt(12);
    }
}
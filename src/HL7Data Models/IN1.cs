using NodaTime;

namespace HL7;

public record IN1 : HL7Data<IN1> {
    public string SetId { get; }
    public HL7Property<CodedElement> InsurancePlanId { get; }
    public HL7Property<EntityIdentifier> InsuranceCompanyId { get; }
    public string GroupNumber { get; }
    public HL7Property<PersonName> InsuredsName { get; }
    public string RelationshipToPatient { get; }
    public Instant? InsuredsDateOfBirth { get; }
    public string InsuredsSex { get; }
    public HL7Property<PersonName> InsuredsEmployerName { get; }
    public string InsuredsSSN { get; }
    public HL7Property<Address> InsuranceCompanyAddress { get; }
    public HL7Property<Phone> InsuranceCompanyPhoneNumber { get; }
    public string InsuranceCompanyName { get; }
    public HL7Property<EntityIdentifier> InsuredsEmployeeId { get; }
    public HL7Property<CodedElement> RelationshipToPatientCode { get; }
    public HL7Property<CodedElement> PlanType { get; }

    public IN1(Segment segment) : base(segment) {
        SetId = segment.GetFieldString(1);
        InsurancePlanId = CodedElement.CreateHL7Property(segment, 2);
        InsuranceCompanyId = EntityIdentifier.CreateHL7Property(segment, 3);
        InsuranceCompanyName = segment.GetFieldString(4);
        InsuranceCompanyAddress = Address.CreateHL7Property(segment, 5);
        InsuranceCompanyPhoneNumber = Phone.CreateHL7Property(segment, 6);
        GroupNumber = segment.GetFieldString(7);
        InsuredsName = PersonName.CreateHL7Property(segment, 8);
        RelationshipToPatient = segment.GetFieldString(9);
        InsuredsDateOfBirth = segment.GetFieldInstant(10);
        InsuredsSex = segment.GetFieldString(11);
        InsuredsEmployerName = PersonName.CreateHL7Property(segment, 13);
        InsuredsSSN = segment.GetFieldString(16);
        InsuredsEmployeeId = EntityIdentifier.CreateHL7Property(segment, 17);
        RelationshipToPatientCode = CodedElement.CreateHL7Property(segment, 17);
        PlanType = CodedElement.CreateHL7Property(segment, 14);
    }
}
using NodaTime;

namespace HL7;

/// <summary>
///     GT1 - Guarantor Segment (HL7 v2.3.1)
/// </summary>
public sealed record GT1 : HL7Data<GT1> {
    public string SetId { get; }
    public HL7Property<EntityIdentifier> GuarantorNumber { get; }
    public HL7Property<PersonName> GuarantorName { get; }
    public Instant? GuarantorDateTimeOfBirth { get; }
    public string GuarantorSex { get; }
    public HL7Property<Address> GuarantorAddress { get; }
    public HL7Property<Phone> GuarantorPhoneNumber { get; }
    public string GuarantorType { get; }
    public string GuarantorRelationship { get; }
    public string SSN { get; }

    public GT1(Segment segment) : base(segment) {
        SetId = segment.GetFieldString(1);
        GuarantorNumber = EntityIdentifier.CreateHL7Property(segment, 2);
        GuarantorName = PersonName.CreateHL7Property(segment, 3);
        GuarantorDateTimeOfBirth = segment.GetFieldInstant(8);
        GuarantorSex = segment.GetFieldString(9);
        GuarantorAddress = Address.CreateHL7Property(segment, 11);
        GuarantorPhoneNumber = Phone.CreateHL7Property(segment, 13);
        GuarantorType = segment.GetFieldString(14);
        GuarantorRelationship = segment.GetFieldString(15);
        SSN = segment.GetFieldString(16);
    }
}
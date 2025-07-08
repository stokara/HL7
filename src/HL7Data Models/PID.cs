using NodaTime;

namespace HL7;

public sealed record PID : HL7Data<PID> {
    public string SetId { get; }
    public HL7Property<EntityIdentifier> EntityIdentifierList { get; }
    public HL7Property<PersonName> PatientName { get; }
    public Instant? DateOfBirth { get; }
    public string Sex { get; }
    public HL7Property<Address>? Addresses { get; }
    public HL7Property<Phone>? PhoneNumbers { get; }
    public string MaritalStatus { get; }
    public string SSN { get; }

    public PID(Segment segment) : base(segment) {
        SetId = segment.GetFieldString(1);
        EntityIdentifierList = EntityIdentifier.CreateHL7Property(segment, 3);
        PatientName = PersonName.CreateHL7Property(segment, 5);
        DateOfBirth = segment.GetFieldInstant(7);
        Sex = segment.GetFieldString(8);
        Addresses = Address.CreateHL7Property(segment, 11);
        PhoneNumbers = Phone.CreateHL7Property(segment, 13);
        MaritalStatus = segment.GetFieldString(16);
        SSN = segment.GetFieldString(19);
    }
}
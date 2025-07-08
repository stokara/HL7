namespace HL7;

/// <summary>
///     NK1 - Next of Kin / Associated Parties (HL7 v2.3.1)
/// </summary>
public sealed record NK1 : HL7Data<NK1> {
    public string SetId { get; }
    public HL7Property<PersonName> Name { get; }
    public string Relationship { get; }
    public HL7Property<Address> Address { get; }
    public HL7Property<Phone> PhoneNumber { get; }
    public string ContactRole { get; }
    public string SSN { get; }

    public NK1(Segment segment) : base(segment) {
        SetId = segment.GetFieldString(1);
        Name = PersonName.CreateHL7Property(segment, 2);
        Relationship = segment.GetFieldString(3);
        Address = HL7.Address.CreateHL7Property(segment, 4);
        PhoneNumber = Phone.CreateHL7Property(segment, 5);
        ContactRole = segment.GetFieldString(7);
        SSN = segment.GetFieldString(33);
    }
}
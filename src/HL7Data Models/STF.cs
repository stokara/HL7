using NodaTime;

namespace HL7;

/// <summary>
///     STF - Staff Identification Segment (HL7 v2.3.1)
/// </summary>
public sealed record STF : HL7Data<STF> {
    public HL7Property<EntityIdentifier> PrimaryKeyValueSTF { get; }
    public HL7Property<CodedElement> StaffIdCode { get; }
    public HL7Property<PersonName> StaffName { get; }
    public HL7Property<CodedElement> StaffType { get; }
    public string AdministrativeSex { get; }
    public Instant? DateTimeOfBirth { get; }
    public string ActiveInactiveFlag { get; }
    public HL7Property<CodedElement> Department { get; }
    public HL7Property<CodedElement> Service { get; }
    public HL7Property<Phone> Phone { get; }
    public HL7Property<Address> OfficeHomeAddressBirthplace { get; }
    public Instant? InstitutionActivationDate { get; }
    public Instant? InstitutionInactivationDate { get; }
    public HL7Property<EntityIdentifier> BackupPersonId { get; }
    public string EmailAddress { get; }
    public HL7Property<CodedElement> PreferredMethodOfContact { get; }

    public STF(Segment segment) : base(segment) {
        PrimaryKeyValueSTF = EntityIdentifier.CreateHL7Property(segment, 1);
        StaffIdCode = CodedElement.CreateHL7Property(segment, 2);
        StaffName = PersonName.CreateHL7Property(segment, 3);
        StaffType = CodedElement.CreateHL7Property(segment, 4);
        AdministrativeSex = segment.GetFieldString(5);
        DateTimeOfBirth = segment.GetFieldInstant(6);
        ActiveInactiveFlag = segment.GetFieldString(7);
        Department = CodedElement.CreateHL7Property(segment, 8);
        Service = CodedElement.CreateHL7Property(segment, 9);
        Phone = Phone.CreateHL7Property(segment, 10);
        OfficeHomeAddressBirthplace = Address.CreateHL7Property(segment, 11);
        InstitutionActivationDate = segment.GetFieldInstant(12);
        InstitutionInactivationDate = segment.GetFieldInstant(13);
        BackupPersonId = EntityIdentifier.CreateHL7Property(segment, 14);
        EmailAddress = segment.GetFieldString(15);
        PreferredMethodOfContact = CodedElement.CreateHL7Property(segment, 16);
    }
}
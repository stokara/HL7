namespace HL7;

/// <summary>
///     SCH - Schedule Activity Information Segment (HL7 v2.3.1)
/// </summary>
public sealed record SCH : HL7Data<SCH> {
    public HL7Property<EntityIdentifier> PlacerAppointmentId { get; }
    public HL7Property<EntityIdentifier> FillerAppointmentId { get; }
    public int? OccurrenceNumber { get; }
    public HL7Property<EntityIdentifier> PlacerGroupNumber { get; }
    public HL7Property<CodedElement> ScheduleId { get; }
    public HL7Property<CodedElement> EventReason { get; }
    public HL7Property<CodedElement> AppointmentReason { get; }
    public HL7Property<CodedElement> AppointmentType { get; }
    public int? AppointmentDuration { get; }
    public HL7Property<CodedElement> AppointmentDurationUnits { get; }
    public HL7Property<CodedElement> AppointmentTimingQuantity { get; }
    public HL7Property<PersonName> PlacerContactPerson { get; }
    public HL7Property<Phone> PlacerContactPhoneNumber { get; }
    public HL7Property<Address> PlacerContactAddress { get; }
    public HL7Property<CodedElement> PlacerContactLocation { get; }
    public HL7Property<PersonName> FillerContactPerson { get; }
    public HL7Property<Phone> FillerContactPhoneNumber { get; }
    public HL7Property<Address> FillerContactAddress { get; }
    public HL7Property<CodedElement> FillerContactLocation { get; }
    public HL7Property<PersonName> EnteredByPerson { get; }
    public HL7Property<Phone> EnteredByPhoneNumber { get; }
    public HL7Property<CodedElement> EnteredByLocation { get; }
    public HL7Property<EntityIdentifier> ParentPlacerAppointmentId { get; }
    public HL7Property<EntityIdentifier> ParentFillerAppointmentId { get; }
    public HL7Property<CodedElement> FillerStatusCode { get; }

    public SCH(Segment segment) : base(segment) {
        PlacerAppointmentId = EntityIdentifier.CreateHL7Property(segment, 1);
        FillerAppointmentId = EntityIdentifier.CreateHL7Property(segment, 2);
        OccurrenceNumber = segment.GetFieldInt(3);
        PlacerGroupNumber = EntityIdentifier.CreateHL7Property(segment, 4);
        ScheduleId = CodedElement.CreateHL7Property(segment, 5);
        EventReason = CodedElement.CreateHL7Property(segment, 6);
        AppointmentReason = CodedElement.CreateHL7Property(segment, 7);
        AppointmentType = CodedElement.CreateHL7Property(segment, 8);
        AppointmentDuration = segment.GetFieldInt(9);
        AppointmentDurationUnits = CodedElement.CreateHL7Property(segment, 10);
        AppointmentTimingQuantity = CodedElement.CreateHL7Property(segment, 11);
        PlacerContactPerson = PersonName.CreateHL7Property(segment, 12);
        PlacerContactPhoneNumber = Phone.CreateHL7Property(segment, 13);
        PlacerContactAddress = Address.CreateHL7Property(segment, 14);
        PlacerContactLocation = CodedElement.CreateHL7Property(segment, 15);
        FillerContactPerson = PersonName.CreateHL7Property(segment, 16);
        FillerContactPhoneNumber = Phone.CreateHL7Property(segment, 17);
        FillerContactAddress = Address.CreateHL7Property(segment, 18);
        FillerContactLocation = CodedElement.CreateHL7Property(segment, 19);
        EnteredByPerson = PersonName.CreateHL7Property(segment, 20);
        EnteredByPhoneNumber = Phone.CreateHL7Property(segment, 21);
        EnteredByLocation = CodedElement.CreateHL7Property(segment, 22);
        ParentPlacerAppointmentId = EntityIdentifier.CreateHL7Property(segment, 23);
        ParentFillerAppointmentId = EntityIdentifier.CreateHL7Property(segment, 24);
        FillerStatusCode = CodedElement.CreateHL7Property(segment, 25);
    }
}
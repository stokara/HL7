namespace HL7;

public sealed record PV1 : HL7Data<PV1> {
    public int? SetId { get; }
    public string PatientClass { get; }
    public HL7Property<CodedElement> AssignedPatientLocation { get; }
    public HL7Property<PersonName> AttendingDoctor { get; }
    public HL7Property<EntityIdentifier> VisitNumber { get; }

    public PV1(Segment segment) : base(segment) {
        SetId = segment.GetFieldInt(1);
        PatientClass = segment.GetFieldString(2);
        AssignedPatientLocation = CodedElement.CreateHL7Property(segment, 3);
        AttendingDoctor = PersonName.CreateHL7Property(segment, 7);
        VisitNumber = EntityIdentifier.CreateHL7Property(segment, 19);
    }
}
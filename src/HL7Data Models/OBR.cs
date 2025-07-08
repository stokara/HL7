using NodaTime;

namespace HL7;

/// <summary>
///     OBR - Observation Request Segment (HL7 v2.3.1)
/// </summary>
public sealed record OBR : HL7Data<OBR> {
    public string SetId { get; }
    public HL7Property<EntityIdentifier> PlacerOrderNumber { get; }
    public HL7Property<EntityIdentifier> FillerOrderNumber { get; }
    public HL7Property<CodedElement> UniversalServiceIdentifier { get; }
    public string Priority { get; }
    public Instant? RequestedDateTime { get; }
    public Instant? ObservationDateTime { get; }
    public Instant? ObservationEndDateTime { get; }
    public decimal? CollectionVolume { get; }
    public HL7Property<EntityIdentifier> CollectorIdentifier { get; }
    public string SpecimenActionCode { get; }
    public HL7Property<CodedElement> DangerCode { get; }
    public string RelevantClinicalInfo { get; }
    public Instant? SpecimenReceivedDateTime { get; }
    public HL7Property<CodedElement> SpecimenSource { get; }
    public HL7Property<PersonName> OrderingProvider { get; }
    public HL7Property<Phone> OrderCallbackPhoneNumber { get; }
    public string PlacerField1 { get; }
    public string PlacerField2 { get; }
    public string FillerField1 { get; }
    public string FillerField2 { get; }
    public Instant? ResultsRptStatusChngDateTime { get; }
    public string ChargeToPractice { get; }
    public string DiagnosticServSectId { get; }
    public string ResultStatus { get; }
    public string ParentResult { get; }
    public string QuantityTiming { get; }
    public HL7Property<PersonName> ResultCopiesTo { get; }
    public string Parent { get; }
    public string TransportationMode { get; }
    public string ReasonForStudy { get; }
    public HL7Property<PersonName> PrincipalResultInterpreter { get; }
    public HL7Property<PersonName> AssistantResultInterpreter { get; }
    public HL7Property<PersonName> Technician { get; }
    public HL7Property<PersonName> Transcriptionist { get; }
    public Instant? ScheduledDateTime { get; }
    public int? NumberOfSampleContainers { get; }
    public string TransportLogisticsOfCollectedSample { get; }
    public string CollectorsComment { get; }
    public string TransportArrangementResponsibility { get; }
    public string TransportArranged { get; }
    public string EscortRequired { get; }
    public string PlannedPatientTransportComment { get; }

    public OBR(Segment segment) : base(segment) {
        SetId = segment.GetFieldString(1);
        PlacerOrderNumber = EntityIdentifier.CreateHL7Property(segment, 2);
        FillerOrderNumber = EntityIdentifier.CreateHL7Property(segment, 3);
        UniversalServiceIdentifier = CodedElement.CreateHL7Property(segment, 4);
        Priority = segment.GetFieldString(5);
        RequestedDateTime = segment.GetFieldInstant(6);
        ObservationDateTime = segment.GetFieldInstant(7);
        ObservationEndDateTime = segment.GetFieldInstant(8);
        CollectionVolume = segment.GetFieldDecimal(9);
        CollectorIdentifier = EntityIdentifier.CreateHL7Property(segment, 10);
        SpecimenActionCode = segment.GetFieldString(11);
        DangerCode = CodedElement.CreateHL7Property(segment, 12);
        RelevantClinicalInfo = segment.GetFieldString(13);
        SpecimenReceivedDateTime = segment.GetFieldInstant(14);
        SpecimenSource = CodedElement.CreateHL7Property(segment, 15);
        OrderingProvider = PersonName.CreateHL7Property(segment, 16);
        OrderCallbackPhoneNumber = Phone.CreateHL7Property(segment, 17);
        PlacerField1 = segment.GetFieldString(18);
        PlacerField2 = segment.GetFieldString(19);
        FillerField1 = segment.GetFieldString(20);
        FillerField2 = segment.GetFieldString(21);
        ResultsRptStatusChngDateTime = segment.GetFieldInstant(22);
        ChargeToPractice = segment.GetFieldString(23);
        DiagnosticServSectId = segment.GetFieldString(24);
        ResultStatus = segment.GetFieldString(25);
        ParentResult = segment.GetFieldString(26);
        QuantityTiming = segment.GetFieldString(27);
        ResultCopiesTo = PersonName.CreateHL7Property(segment, 28);
        Parent = segment.GetFieldString(29);
        TransportationMode = segment.GetFieldString(30);
        ReasonForStudy = segment.GetFieldString(31);
        PrincipalResultInterpreter = PersonName.CreateHL7Property(segment, 32);
        AssistantResultInterpreter = PersonName.CreateHL7Property(segment, 33);
        Technician = PersonName.CreateHL7Property(segment, 34);
        Transcriptionist = PersonName.CreateHL7Property(segment, 35);
        ScheduledDateTime = segment.GetFieldInstant(36);
        NumberOfSampleContainers = segment.GetFieldInt(37);
        TransportLogisticsOfCollectedSample = segment.GetFieldString(38);
        CollectorsComment = segment.GetFieldString(39);
        TransportArrangementResponsibility = segment.GetFieldString(40);
        TransportArranged = segment.GetFieldString(41);
        EscortRequired = segment.GetFieldString(42);
        PlannedPatientTransportComment = segment.GetFieldString(43);
    }
}
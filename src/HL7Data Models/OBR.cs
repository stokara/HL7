namespace HL7;

/// <summary>
///     OBR - Observation Request Segment (HL7 v2.3.1)
/// </summary>
public sealed record OBR : HL7Data<OBR> {
    public string SetId { get; }
    public string PlacerOrderNumber { get; }
    public string FillerOrderNumber { get; }
    public string UniversalServiceIdentifier { get; }
    public string Priority { get; }
    public string RequestedDateTime { get; }
    public string ObservationDateTime { get; }
    public string ObservationEndDateTime { get; }
    public string CollectionVolume { get; }
    public string CollectorIdentifier { get; }
    public string SpecimenActionCode { get; }
    public string DangerCode { get; }
    public string RelevantClinicalInfo { get; }
    public string SpecimenReceivedDateTime { get; }
    public string SpecimenSource { get; }
    public string OrderingProvider { get; }
    public string OrderCallbackPhoneNumber { get; }
    public string PlacerField1 { get; }
    public string PlacerField2 { get; }
    public string FillerField1 { get; }
    public string FillerField2 { get; }
    public string ResultsRptStatusChngDateTime { get; }
    public string ChargeToPractice { get; }
    public string DiagnosticServSectId { get; }
    public string ResultStatus { get; }
    public string ParentResult { get; }
    public string QuantityTiming { get; }
    public string ResultCopiesTo { get; }
    public string Parent { get; }
    public string TransportationMode { get; }
    public string ReasonForStudy { get; }
    public string PrincipalResultInterpreter { get; }
    public string AssistantResultInterpreter { get; }
    public string Technician { get; }
    public string Transcriptionist { get; }
    public string ScheduledDateTime { get; }
    public string NumberOfSampleContainers { get; }
    public string TransportLogisticsOfCollectedSample { get; }
    public string CollectorsComment { get; }
    public string TransportArrangementResponsibility { get; }
    public string TransportArranged { get; }
    public string EscortRequired { get; }
    public string PlannedPatientTransportComment { get; }

    public OBR(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        SetId = cnt > 1 ? fields[1].Value : string.Empty;
        PlacerOrderNumber = cnt > 2 ? fields[2].Value : string.Empty;
        FillerOrderNumber = cnt > 3 ? fields[3].Value : string.Empty;
        UniversalServiceIdentifier = cnt > 4 ? fields[4].Value : string.Empty;
        Priority = cnt > 5 ? fields[5].Value : string.Empty;
        RequestedDateTime = cnt > 6 ? fields[6].Value : string.Empty;
        ObservationDateTime = cnt > 7 ? fields[7].Value : string.Empty;
        ObservationEndDateTime = cnt > 8 ? fields[8].Value : string.Empty;
        CollectionVolume = cnt > 9 ? fields[9].Value : string.Empty;
        CollectorIdentifier = cnt > 10 ? fields[10].Value : string.Empty;
        SpecimenActionCode = cnt > 11 ? fields[11].Value : string.Empty;
        DangerCode = cnt > 12 ? fields[12].Value : string.Empty;
        RelevantClinicalInfo = cnt > 13 ? fields[13].Value : string.Empty;
        SpecimenReceivedDateTime = cnt > 14 ? fields[14].Value : string.Empty;
        SpecimenSource = cnt > 15 ? fields[15].Value : string.Empty;
        OrderingProvider = cnt > 16 ? fields[16].Value : string.Empty;
        OrderCallbackPhoneNumber = cnt > 17 ? fields[17].Value : string.Empty;
        PlacerField1 = cnt > 18 ? fields[18].Value : string.Empty;
        PlacerField2 = cnt > 19 ? fields[19].Value : string.Empty;
        FillerField1 = cnt > 20 ? fields[20].Value : string.Empty;
        FillerField2 = cnt > 21 ? fields[21].Value : string.Empty;
        ResultsRptStatusChngDateTime = cnt > 22 ? fields[22].Value : string.Empty;
        ChargeToPractice = cnt > 23 ? fields[23].Value : string.Empty;
        DiagnosticServSectId = cnt > 24 ? fields[24].Value : string.Empty;
        ResultStatus = cnt > 25 ? fields[25].Value : string.Empty;
        ParentResult = cnt > 26 ? fields[26].Value : string.Empty;
        QuantityTiming = cnt > 27 ? fields[27].Value : string.Empty;
        ResultCopiesTo = cnt > 28 ? fields[28].Value : string.Empty;
        Parent = cnt > 29 ? fields[29].Value : string.Empty;
        TransportationMode = cnt > 30 ? fields[30].Value : string.Empty;
        ReasonForStudy = cnt > 31 ? fields[31].Value : string.Empty;
        PrincipalResultInterpreter = cnt > 32 ? fields[32].Value : string.Empty;
        AssistantResultInterpreter = cnt > 33 ? fields[33].Value : string.Empty;
        Technician = cnt > 34 ? fields[34].Value : string.Empty;
        Transcriptionist = cnt > 35 ? fields[35].Value : string.Empty;
        ScheduledDateTime = cnt > 36 ? fields[36].Value : string.Empty;
        NumberOfSampleContainers = cnt > 37 ? fields[37].Value : string.Empty;
        TransportLogisticsOfCollectedSample = cnt > 38 ? fields[38].Value : string.Empty;
        CollectorsComment = cnt > 39 ? fields[39].Value : string.Empty;
        TransportArrangementResponsibility = cnt > 40 ? fields[40].Value : string.Empty;
        TransportArranged = cnt > 41 ? fields[41].Value : string.Empty;
        EscortRequired = cnt > 42 ? fields[42].Value : string.Empty;
        PlannedPatientTransportComment = cnt > 43 ? fields[43].Value : string.Empty;
    }
}
namespace HL7;

/// <summary>
///     OBX - Observation/Result Segment (HL7 v2.3.1)
/// </summary>
public sealed record OBX : HL7Data<OBX> {
    public string SetId { get; }
    public string ValueType { get; }
    public string ObservationIdentifier { get; }
    public string ObservationSubId { get; }
    public string ObservationValue { get; }
    public string Units { get; }
    public string ReferencesRange { get; }
    public string AbnormalFlags { get; }
    public string Probability { get; }
    public string NatureOfAbnormalTest { get; }
    public string ObservationResultStatus { get; }
    public string DateLastObsNormalValues { get; }
    public string UserDefinedAccessChecks { get; }
    public string DateTimeOfObservation { get; }
    public string ProducerId { get; }
    public string ResponsibleObserver { get; }
    public string ObservationMethod { get; }

    public OBX(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        SetId = cnt > 1 ? fields[1].Value : string.Empty;
        ValueType = cnt > 2 ? fields[2].Value : string.Empty;
        ObservationIdentifier = cnt > 3 ? fields[3].Value : string.Empty;
        ObservationSubId = cnt > 4 ? fields[4].Value : string.Empty;
        ObservationValue = cnt > 5 ? fields[5].Value : string.Empty;
        Units = cnt > 6 ? fields[6].Value : string.Empty;
        ReferencesRange = cnt > 7 ? fields[7].Value : string.Empty;
        AbnormalFlags = cnt > 8 ? fields[8].Value : string.Empty;
        Probability = cnt > 9 ? fields[9].Value : string.Empty;
        NatureOfAbnormalTest = cnt > 10 ? fields[10].Value : string.Empty;
        ObservationResultStatus = cnt > 11 ? fields[11].Value : string.Empty;
        DateLastObsNormalValues = cnt > 12 ? fields[12].Value : string.Empty;
        UserDefinedAccessChecks = cnt > 13 ? fields[13].Value : string.Empty;
        DateTimeOfObservation = cnt > 14 ? fields[14].Value : string.Empty;
        ProducerId = cnt > 15 ? fields[15].Value : string.Empty;
        ResponsibleObserver = cnt > 16 ? fields[16].Value : string.Empty;
        ObservationMethod = cnt > 17 ? fields[17].Value : string.Empty;
    }
}
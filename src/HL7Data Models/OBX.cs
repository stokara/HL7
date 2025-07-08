using System.Collections.Generic;
using System.Linq;
using NodaTime;

namespace HL7;

/// <summary>
///     OBX - Observation/Result Segment (HL7 v2.3.1)
/// </summary>
public sealed record OBX : HL7Data<OBX> {
    public string SetId { get; }
    public string ValueType { get; }
    public string ObservationIdentifier { get; }
    public string ObservationSubId { get; }
    public IReadOnlyList<ObservationValueElement> ObservationValue { get; }
    public string Units { get; }
    public string ReferencesRange { get; }
    public string AbnormalFlags { get; }
    public decimal? Probability { get; }
    public string NatureOfAbnormalTest { get; }
    public string ObservationResultStatus { get; }
    public Instant? DateLastObsNormalValues { get; }
    public string UserDefinedAccessChecks { get; }
    public Instant? DateTimeOfObservation { get; }
    public string ProducerId { get; }
    public string ResponsibleObserver { get; }
    public string ObservationMethod { get; }

    public OBX(Segment segment) : base(segment) {
        SetId = segment.GetFieldString(1);
        ValueType = segment.GetFieldString(2);
        ObservationIdentifier = segment.GetFieldString(3);
        ObservationSubId = segment.GetFieldString(4);
        ObservationValue = segment.Fields.Count > 5
            ? segment.Fields[5].HasRepetitions
                ? segment.Fields[5].Repetitions!.Select(ObservationValueElement.Parse).ToArray()
                : new[] { ObservationValueElement.Parse(segment.Fields[5]) }
            : new ObservationValueElement[0];
        Units = segment.GetFieldString(6);
        ReferencesRange = segment.GetFieldString(7);
        AbnormalFlags = segment.GetFieldString(8);
        Probability = segment.GetFieldDecimal(9);
        NatureOfAbnormalTest = segment.GetFieldString(10);
        ObservationResultStatus = segment.GetFieldString(11);
        DateLastObsNormalValues = segment.GetFieldInstant(12);
        UserDefinedAccessChecks = segment.GetFieldString(13);
        DateTimeOfObservation = segment.GetFieldInstant(14);
        ProducerId = segment.GetFieldString(15);
        ResponsibleObserver = segment.GetFieldString(16);
        ObservationMethod = segment.GetFieldString(17);
    }
}
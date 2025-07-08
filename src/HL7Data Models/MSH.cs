using System.Linq;
using NodaTime;

namespace HL7;

public sealed record MSH : HL7Data<MSH> {
    public string EncodingCharacters { get; }
    public string SendingApplication { get; }
    public string SendingFacility { get; }
    public string ReceivingApplication { get; }
    public string ReceivingFacility { get; }
    public Instant? DateTimeOfMessage { get; }
    public string Security { get; }
    public string MessageType { get; }
    public string MessageControlId { get; }
    public string ProcessingId { get; }
    public string VersionId { get; }
    public string SequenceNumber { get; }
    public string ContinuationPointer { get; }
    public string AcceptAcknowledgmentType { get; }
    public string ApplicationAcknowledgmentType { get; }
    public string CountryCode { get; }
    public string CharacterSet { get; }
    public string PrincipalLanguageOfMessage { get; }
    public string AlternateCharacterSetHandlingScheme { get; }

    public MSH(Message message) : base(message.Segments[0]) {
        var segment = message.Segments.Single(s => s.Name == "MSH");
        EncodingCharacters = segment.GetFieldString(1);
        SendingApplication = segment.GetFieldString(2);
        SendingFacility = segment.GetFieldString(3);
        ReceivingApplication = segment.GetFieldString(4);
        ReceivingFacility = segment.GetFieldString(5);
        DateTimeOfMessage = segment.GetFieldInstant(6);
        Security = segment.GetFieldString(7);
        MessageType = message.MessageType;
        MessageControlId = message.MessageControlId;
        ProcessingId = message.ProcessingId;
        VersionId = message.Version;
        SequenceNumber = segment.GetFieldString(13);
        ContinuationPointer = segment.GetFieldString(14);
        AcceptAcknowledgmentType = segment.GetFieldString(15);
        ApplicationAcknowledgmentType = segment.GetFieldString(16);
        CountryCode = segment.GetFieldString(17);
        CharacterSet = segment.GetFieldString(18);
        PrincipalLanguageOfMessage = segment.GetFieldString(19);
        AlternateCharacterSetHandlingScheme = segment.GetFieldString(20);
    }
}
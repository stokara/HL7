using NodaTime;

namespace HL7;

public sealed record MSH : HL7Data<MSH> {
    public string Delimiters { get; private set; }
    public string SendingApplication { get; private set; }
    public string SendingFacility { get; private set; }
    public string ReceivingApplication { get; private set; }
    public string ReceivingFacility { get; private set; }
    public Instant? MessageDateTime { get; private set; }
    public string Security { get; private set; }
    public string MessageType { get; private set; }
    public string MessageControlId { get; private set; }
    public string ProcessingId { get; private set; }
    public string VersionId { get; private set; }

    public MSH(Message message) : base(message.Segments[0]) {
        var segment = message.Segments[0];

        Delimiters = segment.Fields[0].Value;
        SendingApplication = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;
        SendingFacility = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty;
        ReceivingApplication = segment.Fields.Count > 4 ? segment.Fields[4].Value : string.Empty;
        ReceivingFacility = segment.Fields.Count > 5 ? segment.Fields[5].Value : string.Empty;
        Security = segment.Fields.Count > 7 ? segment.Fields[7].Value : string.Empty;
        MessageDateTime = message.MessageDateTime;
        MessageType = message.MessageType;
        MessageControlId = message.MessageControlId;
        ProcessingId = message.ProcessingId;
        VersionId = message.Version;
    }
}
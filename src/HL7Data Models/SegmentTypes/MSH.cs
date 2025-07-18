using System.Collections.Generic;

namespace HL7;

public sealed record MSH : Hl7Segment {
    public Hl7Encoding Encoding { get; set; }
    public HD? SendingApplication { get; }
    public HD? SendingFacility { get; }
    public HD? ReceivingApplication { get; }
    public ICollection<HD>? ReceivingFacility { get; }
    public DTM DateTimeofMessage { get; }
    public ST? Security { get; }
    public MSG MessageType { get; }
    public ST MessageControlID { get; }
    public PT ProcessingID { get; }
    public VID VersionID { get; }
    public NM? SequenceNumber { get; }
    public ST? ContinuationPointer { get; }
    public ID? AcceptAcknowledgmentType { get; }
    public ID? ApplicationAcknowledgmentType { get; }
    public ID? CountryCode { get; }
    public ICollection<ID>? CharacterSet { get; }
    public CWE? PrincipalLanguageOfMessage { get; }
    public ID? AlternateCharacterSetHandlingScheme { get; }
    public ICollection<EI>? MessageProfileIdentifier { get; }
    public XON? SendingResponsibleOrganization { get; }
    public XON? ReceivingResponsibleOrganization { get; }
    public HD? SendingNetworkAddress { get; }
    public HD? ReceivingNetworkAddress { get; }
    public CWE? SecurityClassificationTag { get; }
    public ICollection<CWE>? SecurityHandlingInstructions { get; }
    public ICollection<ST>? SpecialAccessRestrictionInstructions { get; }

    public MSH(MshSegment segment) : base(typeof(MSH), segment) {
        Encoding = segment.Encoding;
        this.SendingApplication = segment.GetField<HD>(1);
        this.SendingFacility = segment.GetField<HD>(2);
        this.ReceivingApplication = segment.GetField<HD>(3);
        this.ReceivingFacility = segment.GetRepField<HD>(4);
        this.DateTimeofMessage = segment.GetRequiredField<DTM>(5);
        this.Security = segment.GetField<ST>(6);
        this.MessageType = segment.GetRequiredField<MSG>(7);
        this.MessageControlID = segment.GetRequiredField<ST>(8);
        this.ProcessingID = segment.GetRequiredField<PT>(9);
        this.VersionID = segment.GetRequiredField<VID>(10);
        this.SequenceNumber = segment.GetField<NM>(11);
        this.ContinuationPointer = segment.GetField<ST>(12);
        this.AcceptAcknowledgmentType = segment.GetField<ID>(13);
        this.ApplicationAcknowledgmentType = segment.GetField<ID>(14);
        this.CountryCode = segment.GetField<ID>(15);
        this.CharacterSet = segment.GetRepField<ID>(16);
        this.PrincipalLanguageOfMessage = segment.GetField<CWE>(17);
        this.AlternateCharacterSetHandlingScheme = segment.GetField<ID>(18);
        this.MessageProfileIdentifier = segment.GetRepField<EI>(19);
        this.SendingResponsibleOrganization = segment.GetField<XON>(20);
        this.ReceivingResponsibleOrganization = segment.GetField<XON>(21);
        this.SendingNetworkAddress = segment.GetField<HD>(22);
        this.ReceivingNetworkAddress = segment.GetField<HD>(23);
        this.SecurityClassificationTag = segment.GetField<CWE>(24);
        this.SecurityHandlingInstructions = segment.GetRepField<CWE>(25);
        this.SpecialAccessRestrictionInstructions = segment.GetRepField<ST>(26);
    }
}
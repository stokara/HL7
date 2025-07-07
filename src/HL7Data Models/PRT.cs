namespace HL7;

/// <summary>
///     PRT - Participation Information Segment (HL7 v2.7)
/// </summary>
public sealed record PRT : HL7Data<PRT> {
    public string ActionCode { get; }
    public string ActionReason { get; }
    public string Participation { get; }
    public string ParticipationPerson { get; }
    public string ParticipationPersonProviderType { get; }
    public string ParticipationPersonIdentifier { get; }
    public string ParticipantOrganizationUnitType { get; }
    public string ParticipationOrganization { get; }
    public string ParticipationBeginDateTime { get; }
    public string ParticipationEndDateTime { get; }
    public string ParticipationDuration { get; }
    public string ParticipationDurationUnits { get; }
    public string ParticipationOrganizationAddress { get; }
    public string ParticipationOrganizationLocation { get; }

    public PRT(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        ActionCode = cnt > 1 ? fields[1].Value : string.Empty;
        ActionReason = cnt > 2 ? fields[2].Value : string.Empty;
        Participation = cnt > 3 ? fields[3].Value : string.Empty;
        ParticipationPerson = cnt > 4 ? fields[4].Value : string.Empty;
        ParticipationPersonProviderType = cnt > 5 ? fields[5].Value : string.Empty;
        ParticipationPersonIdentifier = cnt > 6 ? fields[6].Value : string.Empty;
        ParticipantOrganizationUnitType = cnt > 7 ? fields[7].Value : string.Empty;
        ParticipationOrganization = cnt > 8 ? fields[8].Value : string.Empty;
        ParticipationBeginDateTime = cnt > 9 ? fields[9].Value : string.Empty;
        ParticipationEndDateTime = cnt > 10 ? fields[10].Value : string.Empty;
        ParticipationDuration = cnt > 11 ? fields[11].Value : string.Empty;
        ParticipationDurationUnits = cnt > 12 ? fields[12].Value : string.Empty;
        ParticipationOrganizationAddress = cnt > 13 ? fields[13].Value : string.Empty;
        ParticipationOrganizationLocation = cnt > 14 ? fields[14].Value : string.Empty;
    }
}
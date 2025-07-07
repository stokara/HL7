namespace HL7;

/// <summary>
///     SPM - Specimen Segment (HL7 v2.5)
/// </summary>
public sealed record SPM : HL7Data<SPM> {
    public string SetId { get; }
    public string SpecimenId { get; }
    public string SpecimenParentId { get; }
    public string SpecimenType { get; }
    public string SpecimenTypeModifier { get; }
    public string SpecimenAdditives { get; }
    public string SpecimenCollectionMethod { get; }
    public string SpecimenSourceSite { get; }
    public string SpecimenSourceSiteModifier { get; }
    public string SpecimenCollectionSite { get; }
    public string SpecimenRole { get; }
    public string SpecimenCollectionAmount { get; }
    public string GroupedSpecimenCount { get; }
    public string SpecimenDescription { get; }
    public string SpecimenHandlingCode { get; }
    public string SpecimenRiskCode { get; }
    public string SpecimenCollectionDateTime { get; }
    public string SpecimenReceivedDateTime { get; }
    public string SpecimenExpirationDateTime { get; }
    public string SpecimenAvailability { get; }
    public string SpecimenRejectReason { get; }
    public string SpecimenQuality { get; }
    public string SpecimenAppropriateness { get; }
    public string SpecimenCondition { get; }
    public string SpecimenCurrentQuantity { get; }
    public string NumberOfSpecimenContainers { get; }
    public string ContainerType { get; }
    public string ContainerCondition { get; }
    public string SpecimenChildRole { get; }

    public SPM(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        SetId = cnt > 1 ? fields[1].Value : string.Empty;
        SpecimenId = cnt > 2 ? fields[2].Value : string.Empty;
        SpecimenParentId = cnt > 3 ? fields[3].Value : string.Empty;
        SpecimenType = cnt > 4 ? fields[4].Value : string.Empty;
        SpecimenTypeModifier = cnt > 5 ? fields[5].Value : string.Empty;
        SpecimenAdditives = cnt > 6 ? fields[6].Value : string.Empty;
        SpecimenCollectionMethod = cnt > 7 ? fields[7].Value : string.Empty;
        SpecimenSourceSite = cnt > 8 ? fields[8].Value : string.Empty;
        SpecimenSourceSiteModifier = cnt > 9 ? fields[9].Value : string.Empty;
        SpecimenCollectionSite = cnt > 10 ? fields[10].Value : string.Empty;
        SpecimenRole = cnt > 11 ? fields[11].Value : string.Empty;
        SpecimenCollectionAmount = cnt > 12 ? fields[12].Value : string.Empty;
        GroupedSpecimenCount = cnt > 13 ? fields[13].Value : string.Empty;
        SpecimenDescription = cnt > 14 ? fields[14].Value : string.Empty;
        SpecimenHandlingCode = cnt > 15 ? fields[15].Value : string.Empty;
        SpecimenRiskCode = cnt > 16 ? fields[16].Value : string.Empty;
        SpecimenCollectionDateTime = cnt > 17 ? fields[17].Value : string.Empty;
        SpecimenReceivedDateTime = cnt > 18 ? fields[18].Value : string.Empty;
        SpecimenExpirationDateTime = cnt > 19 ? fields[19].Value : string.Empty;
        SpecimenAvailability = cnt > 20 ? fields[20].Value : string.Empty;
        SpecimenRejectReason = cnt > 21 ? fields[21].Value : string.Empty;
        SpecimenQuality = cnt > 22 ? fields[22].Value : string.Empty;
        SpecimenAppropriateness = cnt > 23 ? fields[23].Value : string.Empty;
        SpecimenCondition = cnt > 24 ? fields[24].Value : string.Empty;
        SpecimenCurrentQuantity = cnt > 25 ? fields[25].Value : string.Empty;
        NumberOfSpecimenContainers = cnt > 26 ? fields[26].Value : string.Empty;
        ContainerType = cnt > 27 ? fields[27].Value : string.Empty;
        ContainerCondition = cnt > 28 ? fields[28].Value : string.Empty;
        SpecimenChildRole = cnt > 29 ? fields[29].Value : string.Empty;
    }
}
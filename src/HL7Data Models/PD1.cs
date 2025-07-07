namespace HL7;

/// <summary>
///     PD1 - Patient Additional Demographic (HL7 v2.3.1)
/// </summary>
public sealed record PD1 : HL7Data<PD1> {
    public string LivingDependency { get; }
    public string LivingArrangement { get; }
    public string PatientPrimaryFacility { get; }
    public string PatientPrimaryCareProviderNameIdNo { get; }
    public string StudentIndicator { get; }
    public string Handicap { get; }
    public string LivingWillCode { get; }
    public string OrganDonorCode { get; }
    public string SeparateBill { get; }
    public string DuplicatePatient { get; }
    public string PublicityCode { get; }
    public string ProtectionIndicator { get; }
    public string ProtectionIndicatorEffectiveDate { get; }
    public string PlaceOfWorship { get; }
    public string AdvanceDirectiveCode { get; }
    public string ImmunizationRegistryStatus { get; }
    public string ImmunizationRegistryStatusEffectiveDate { get; }
    public string PublicityCodeEffectiveDate { get; }
    public string MilitaryBranch { get; }
    public string MilitaryRankGrade { get; }
    public string MilitaryStatus { get; }

    public PD1(Segment segment) : base(segment) {
        LivingDependency = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty;
        LivingArrangement = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;
        PatientPrimaryFacility = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty;
        PatientPrimaryCareProviderNameIdNo = segment.Fields.Count > 4 ? segment.Fields[4].Value : string.Empty;
        StudentIndicator = segment.Fields.Count > 5 ? segment.Fields[5].Value : string.Empty;
        Handicap = segment.Fields.Count > 6 ? segment.Fields[6].Value : string.Empty;
        LivingWillCode = segment.Fields.Count > 7 ? segment.Fields[7].Value : string.Empty;
        OrganDonorCode = segment.Fields.Count > 8 ? segment.Fields[8].Value : string.Empty;
        SeparateBill = segment.Fields.Count > 9 ? segment.Fields[9].Value : string.Empty;
        DuplicatePatient = segment.Fields.Count > 10 ? segment.Fields[10].Value : string.Empty;
        PublicityCode = segment.Fields.Count > 11 ? segment.Fields[11].Value : string.Empty;
        ProtectionIndicator = segment.Fields.Count > 12 ? segment.Fields[12].Value : string.Empty;
        ProtectionIndicatorEffectiveDate = segment.Fields.Count > 13 ? segment.Fields[13].Value : string.Empty;
        PlaceOfWorship = segment.Fields.Count > 14 ? segment.Fields[14].Value : string.Empty;
        AdvanceDirectiveCode = segment.Fields.Count > 15 ? segment.Fields[15].Value : string.Empty;
        ImmunizationRegistryStatus = segment.Fields.Count > 16 ? segment.Fields[16].Value : string.Empty;
        ImmunizationRegistryStatusEffectiveDate = segment.Fields.Count > 17 ? segment.Fields[17].Value : string.Empty;
        PublicityCodeEffectiveDate = segment.Fields.Count > 18 ? segment.Fields[18].Value : string.Empty;
        MilitaryBranch = segment.Fields.Count > 19 ? segment.Fields[19].Value : string.Empty;
        MilitaryRankGrade = segment.Fields.Count > 20 ? segment.Fields[20].Value : string.Empty;
        MilitaryStatus = segment.Fields.Count > 21 ? segment.Fields[21].Value : string.Empty;
    }
}
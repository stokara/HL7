namespace HL7;

/// <summary>
///     AL1 - Patient Allergy Information Segment (HL7 v2.3.1)
/// </summary>
public sealed record AL1 : HL7Data<AL1> {
    public string SetId { get; }
    public string AllergyType { get; }
    public string AllergyCodeMnemonicDescription { get; }
    public string AllergySeverity { get; }
    public string AllergyReaction { get; }
    public string IdentificationDate { get; }

    public AL1(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        SetId = cnt > 1 ? fields[1].Value : string.Empty;
        AllergyType = cnt > 2 ? fields[2].Value : string.Empty;
        AllergyCodeMnemonicDescription = cnt > 3 ? fields[3].Value : string.Empty;
        AllergySeverity = cnt > 4 ? fields[4].Value : string.Empty;
        AllergyReaction = cnt > 5 ? fields[5].Value : string.Empty;
        IdentificationDate = cnt > 6 ? fields[6].Value : string.Empty;
    }
}
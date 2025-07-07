namespace HL7;

/// <summary>
///     PRA - Practitioner Detail Segment (HL7 v2.3.1)
/// </summary>
public sealed record PRA : HL7Data<PRA> {
    public string PrimaryKeyValuePRA { get; }
    public string PractitionerGroup { get; }
    public string PractitionerCategory { get; }
    public string ProviderBilling { get; }
    public string Specialty { get; }
    public string PractitionerIdNumbers { get; }
    public string Privileges { get; }
    public string DateEnteredPractice { get; }
    public string Institution { get; }
    public string DateLeftPractice { get; }
    public string GovernmentReimbursementBillingEligibility { get; }
    public string SetId { get; }

    public PRA(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        PrimaryKeyValuePRA = cnt > 1 ? fields[1].Value : string.Empty;
        PractitionerGroup = cnt > 2 ? fields[2].Value : string.Empty;
        PractitionerCategory = cnt > 3 ? fields[3].Value : string.Empty;
        ProviderBilling = cnt > 4 ? fields[4].Value : string.Empty;
        Specialty = cnt > 5 ? fields[5].Value : string.Empty;
        PractitionerIdNumbers = cnt > 6 ? fields[6].Value : string.Empty;
        Privileges = cnt > 7 ? fields[7].Value : string.Empty;
        DateEnteredPractice = cnt > 8 ? fields[8].Value : string.Empty;
        Institution = cnt > 9 ? fields[9].Value : string.Empty;
        DateLeftPractice = cnt > 10 ? fields[10].Value : string.Empty;
        GovernmentReimbursementBillingEligibility = cnt > 11 ? fields[11].Value : string.Empty;
        SetId = cnt > 12 ? fields[12].Value : string.Empty;
    }
}
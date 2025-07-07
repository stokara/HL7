namespace HL7;

/// <summary>
///     SFT - Software Segment (HL7 v2.3.1)
/// </summary>
public sealed record SFT : HL7Data<SFT> {
    public string SoftwareVendorOrganization { get; }
    public string SoftwareCertifiedVersionOrReleaseNumber { get; }
    public string SoftwareProductName { get; }
    public string SoftwareBinaryId { get; }
    public string SoftwareProductInformation { get; }
    public string SoftwareInstallDate { get; }

    public SFT(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        SoftwareVendorOrganization = cnt > 1 ? fields[1].Value : string.Empty;
        SoftwareCertifiedVersionOrReleaseNumber = cnt > 2 ? fields[2].Value : string.Empty;
        SoftwareProductName = cnt > 3 ? fields[3].Value : string.Empty;
        SoftwareBinaryId = cnt > 4 ? fields[4].Value : string.Empty;
        SoftwareProductInformation = cnt > 5 ? fields[5].Value : string.Empty;
        SoftwareInstallDate = cnt > 6 ? fields[6].Value : string.Empty;
    }
}
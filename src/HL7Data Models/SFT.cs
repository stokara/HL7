using NodaTime;

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
    public Instant? SoftwareInstallDate { get; }

    public SFT(Segment segment) : base(segment) {
        SoftwareVendorOrganization = segment.GetFieldString(1);
        SoftwareCertifiedVersionOrReleaseNumber = segment.GetFieldString(2);
        SoftwareProductName = segment.GetFieldString(3);
        SoftwareBinaryId = segment.GetFieldString(4);
        SoftwareProductInformation = segment.GetFieldString(5);
        SoftwareInstallDate = segment.GetFieldInstant(6);
    }
}
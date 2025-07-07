using System.Collections.Generic;

namespace HL7.PersonName;

/// <summary>
///     XPN - Extended Person Name (HL7 v2.3.1)
/// </summary>
public sealed record ExtendedPersonName : IPersonName {
    public string FamilyName { get; }
    public string GivenName { get; }
    public string SecondAndFurtherGivenNamesOrInitials { get; }
    public string Suffix { get; }
    public string Prefix { get; }
    public string Degree { get; }
    public string NameTypeCode { get; }
    public string NameRepresentationCode { get; }
    public string NameContext { get; }
    public string NameValidityRange { get; }
    public string NameAssemblyOrder { get; }
    public string EffectiveDate { get; }
    public string ExpirationDate { get; }
    public string ProfessionalSuffix { get; }

    public ExtendedPersonName(IReadOnlyList<Component> components) {
        FamilyName = components.Count > 0 ? components[0].Value : string.Empty;
        GivenName = components.Count > 1 ? components[1].Value : string.Empty;
        SecondAndFurtherGivenNamesOrInitials = components.Count > 2 ? components[2].Value : string.Empty;
        Suffix = components.Count > 3 ? components[3].Value : string.Empty;
        Prefix = components.Count > 4 ? components[4].Value : string.Empty;
        Degree = components.Count > 5 ? components[5].Value : string.Empty;
        NameTypeCode = components.Count > 6 ? components[6].Value : string.Empty;
        NameRepresentationCode = components.Count > 7 ? components[7].Value : string.Empty;
        NameContext = components.Count > 8 ? components[8].Value : string.Empty;
        NameValidityRange = components.Count > 9 ? components[9].Value : string.Empty;
        NameAssemblyOrder = components.Count > 10 ? components[10].Value : string.Empty;
        EffectiveDate = components.Count > 11 ? components[11].Value : string.Empty;
        ExpirationDate = components.Count > 12 ? components[12].Value : string.Empty;
        ProfessionalSuffix = components.Count > 13 ? components[13].Value : string.Empty;
    }

    public PersonNameKind PersonNameKind => PersonNameKind.Extended;
}
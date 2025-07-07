using System.Collections.Generic;

namespace HL7.PatientIdentifier;

/// <summary>
///     CX - Extended Composite ID with Check Digit (HL7 v2.3.1)
/// </summary>
public sealed record ExtendedPatientIdentifier : IPatientIdentifier {
    public string Id { get; }
    public string CheckDigit { get; }
    public string CheckDigitScheme { get; }
    public string AssigningAuthority { get; }
    public string IdentifierTypeCode { get; }
    public string AssigningFacility { get; }
    public string EffectiveDate { get; }
    public string ExpirationDate { get; }
    public string AssigningJurisdiction { get; }
    public string AssigningAgencyOrDepartment { get; }

    public ExtendedPatientIdentifier(IReadOnlyList<Component> components) {
        var cnt = components.Count;
        Id = cnt > 0 ? components[0].Value : string.Empty;
        CheckDigit = cnt > 1 ? components[1].Value : string.Empty;
        CheckDigitScheme = cnt > 2 ? components[2].Value : string.Empty;
        AssigningAuthority = cnt > 3 ? components[3].Value : string.Empty;
        IdentifierTypeCode = cnt > 4 ? components[4].Value : string.Empty;
        AssigningFacility = cnt > 5 ? components[5].Value : string.Empty;
        EffectiveDate = cnt > 6 ? components[6].Value : string.Empty;
        ExpirationDate = cnt > 7 ? components[7].Value : string.Empty;
        AssigningJurisdiction = cnt > 8 ? components[8].Value : string.Empty;
        AssigningAgencyOrDepartment = cnt > 9 ? components[9].Value : string.Empty;
    }

    public PatientIdentifierKind PatientIdentifierKind => PatientIdentifierKind.Extended;
}
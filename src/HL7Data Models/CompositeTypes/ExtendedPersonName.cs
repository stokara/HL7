using System.Collections.Generic;
using System.Linq;
using NodaTime;

namespace HL7;

/// <summary>
///     XPN - Extended Person Name (HL7 v2.3.1)
/// </summary>
public sealed record PersonName : IComposite {
    public string SimpleName => FamilyName;
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
    public Instant? EffectiveDate { get; }
    public Instant? ExpirationDate { get; }
    public string ProfessionalSuffix { get; }

    public PersonName(IReadOnlyList<Component> components) {
        IsExtended = true;
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
        EffectiveDate = components.Count > 11 ? Hl7DateParser.ParseInstant(components[11].Value) : null;
        ExpirationDate = components.Count > 12 ? Hl7DateParser.ParseInstant(components[12].Value) : null;
        ProfessionalSuffix = components.Count > 13 ? components[13].Value : string.Empty;
    }

    public PersonName(string phoneString) {
        FamilyName = phoneString;
        IsExtended = false;
    }

    public bool IsExtended { get; init; }

    public static HL7Property<PersonName> CreateHL7Property(Segment segment, int fieldNumber) {
        var field = segment.GetField(fieldNumber);
        if (field is null) return new HL7Property<PersonName>([new PersonName(string.Empty)]);
        return field.HasRepetitions
            ? new HL7Property<PersonName>(field.Repetitions!.Select(f => f.HasComponents ? new PersonName(f.Components!) : new PersonName(f.Value)).ToArray())
            : new HL7Property<PersonName>([field.HasComponents ? new PersonName(field.Components!) : new PersonName(field.Value)]);
    }
}
using System.Collections.Generic;
using System.Linq;
using NodaTime;

namespace HL7;

/// <summary>
///     CX - Extended Composite ID with Check Digit (HL7 v2.3.1)
/// </summary>
public sealed record EntityIdentifier : IComposite {
    public string SimpleIdentifier => Id;
    public string Id { get; }
    public string CheckDigit { get; }
    public string CheckDigitScheme { get; }
    public string AssigningAuthority { get; }
    public string IdentifierTypeCode { get; }
    public string AssigningFacility { get; }
    public Instant? EffectiveDate { get; }
    public Instant? ExpirationDate { get; }
    public string AssigningJurisdiction { get; }
    public string AssigningAgencyOrDepartment { get; }

    public EntityIdentifier(IReadOnlyList<Component> components) {
        IsExtended = true;
        var cnt = components.Count;
        Id = cnt > 0 ? components[0].Value : string.Empty;
        CheckDigit = cnt > 1 ? components[1].Value : string.Empty;
        CheckDigitScheme = cnt > 2 ? components[2].Value : string.Empty;
        AssigningAuthority = cnt > 3 ? components[3].Value : string.Empty;
        IdentifierTypeCode = cnt > 4 ? components[4].Value : string.Empty;
        AssigningFacility = cnt > 5 ? components[5].Value : string.Empty;
        EffectiveDate = cnt > 6 ? Hl7DateParser.ParseInstant(components[6].Value) : null;
        ExpirationDate = cnt > 7 ? Hl7DateParser.ParseInstant(components[7].Value) : null;
        AssigningJurisdiction = cnt > 8 ? components[8].Value : string.Empty;
        AssigningAgencyOrDepartment = cnt > 9 ? components[9].Value : string.Empty;
    }

    public EntityIdentifier(string pidString) {
        Id = pidString;
        IsExtended = false;
    }

    public bool IsExtended { get; init; }

    public static HL7Property<EntityIdentifier> CreateHL7Property(Segment segment, int fieldNumber) {
        var field = segment.GetField(fieldNumber);
        if (field is null) return new HL7Property<EntityIdentifier>([new EntityIdentifier(string.Empty)]);
        return field.HasRepetitions
            ? new HL7Property<EntityIdentifier>(field.Repetitions!.Select(f => f.HasComponents ? new EntityIdentifier(f.Components!) : new EntityIdentifier(f.Value)).ToArray())
            : new HL7Property<EntityIdentifier>([field.HasComponents ? new EntityIdentifier(field.Components!) : new EntityIdentifier(field.Value)]);
    }
}
using System.Collections.Generic;
using System.Linq;

namespace HL7;

/// <summary>
///     XTN - Extended Telecommunication Number (HL7 v2.3.1)
/// </summary>
public sealed record Phone : IComposite {
    public string SimplePhone => TelephoneNumber;
    public string TelephoneNumber { get; }
    public string TelecommunicationUseCode { get; }
    public string TelecommunicationEquipmentType { get; }
    public string EmailAddress { get; }
    public string CountryCode { get; }
    public string AreaCityCode { get; }
    public string LocalNumber { get; }
    public string Extension { get; }
    public string AnyText { get; }
    public string ExtensionPrefix { get; }
    public string SpeedDialCode { get; }
    public string UnformattedTelephoneNumber { get; }

    public Phone(string phoneString) {
        TelephoneNumber = phoneString;
        IsExtended = false;
    }

    public Phone(IReadOnlyList<Component> components) {
        var cnt = components.Count;
        TelephoneNumber = cnt > 0 ? components[0].Value : string.Empty;
        TelecommunicationUseCode = cnt > 1 ? components[1].Value : string.Empty;
        TelecommunicationEquipmentType = cnt > 2 ? components[2].Value : string.Empty;
        EmailAddress = cnt > 3 ? components[3].Value : string.Empty;
        CountryCode = cnt > 4 ? components[4].Value : string.Empty;
        AreaCityCode = cnt > 5 ? components[5].Value : string.Empty;
        LocalNumber = cnt > 6 ? components[6].Value : string.Empty;
        Extension = cnt > 7 ? components[7].Value : string.Empty;
        AnyText = cnt > 8 ? components[8].Value : string.Empty;
        ExtensionPrefix = cnt > 9 ? components[9].Value : string.Empty;
        SpeedDialCode = cnt > 10 ? components[10].Value : string.Empty;
        UnformattedTelephoneNumber = cnt > 11 ? components[11].Value : string.Empty;
        IsExtended = true;
    }

    public bool IsExtended { get; init; }

    public static HL7Property<Phone> CreateHL7Property(Segment segment, int fieldNumber) {
        var field = segment.GetField(fieldNumber);
        if (field is null) return new HL7Property<Phone>([new Phone(string.Empty)]);
        return field.HasRepetitions
            ? new HL7Property<Phone>(field.Repetitions!.Select(f => f.HasComponents ? new Phone(f.Components!) : new Phone(f.Value)).ToArray())
            : new HL7Property<Phone>([field.HasComponents ? new Phone(field.Components!) : new Phone(field.Value)]);
    }
}
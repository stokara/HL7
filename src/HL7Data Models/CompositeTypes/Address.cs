using System.Collections.Generic;
using System.Linq;

namespace HL7;

/// <summary>
///     XAD - Extended Address (HL7 v2.3.1)
/// </summary>
public sealed record Address : IComposite {
    public string SimpleAddress => StreetAddress;
    public string StreetAddress { get; }
    public string OtherDesignation { get; }
    public string City { get; }
    public string StateOrProvince { get; }
    public string ZipOrPostalCode { get; }
    public string Country { get; }
    public string AddressType { get; }
    public string OtherGeographicDesignation { get; }
    public string CountyParishCode { get; }
    public string CensusTract { get; }
    public string AddressRepresentationCode { get; }
    public string AddressValidityRange { get; }
    public string EffectiveDate { get; }
    public string ExpirationDate { get; }

    public Address(string addressString) {
        StreetAddress = addressString;
        IsExtended = false;
    }

    public Address(IReadOnlyList<Component> components) {
        var cnt = components.Count;
        StreetAddress = cnt > 0 ? components[0].Value : string.Empty;
        OtherDesignation = cnt > 1 ? components[1].Value : string.Empty;
        City = cnt > 2 ? components[2].Value : string.Empty;
        StateOrProvince = cnt > 3 ? components[3].Value : string.Empty;
        ZipOrPostalCode = cnt > 4 ? components[4].Value : string.Empty;
        Country = cnt > 5 ? components[5].Value : string.Empty;
        AddressType = cnt > 6 ? components[6].Value : string.Empty;
        OtherGeographicDesignation = cnt > 7 ? components[7].Value : string.Empty;
        CountyParishCode = cnt > 8 ? components[8].Value : string.Empty;
        CensusTract = cnt > 9 ? components[9].Value : string.Empty;
        AddressRepresentationCode = cnt > 10 ? components[10].Value : string.Empty;
        AddressValidityRange = cnt > 11 ? components[11].Value : string.Empty;
        EffectiveDate = cnt > 12 ? components[12].Value : string.Empty;
        ExpirationDate = cnt > 13 ? components[13].Value : string.Empty;
    }

    public bool IsExtended { get; init; }

    public static HL7Property<Address> CreateHL7Property(Segment segment, int fieldNumber) {
        var field = segment.GetField(fieldNumber);
        if (field is null) {
            return new HL7Property<Address>([new Address(string.Empty)]);
        }

        return field.HasRepetitions
            ? new HL7Property<Address>(field.Repetitions!.Select(rep => parse(rep)).ToList())
            : new HL7Property<Address>(parse(field));

        static Address parse(Field field) {
            return field.HasComponents ? new Address(field.Components!) : new Address(field.Value);
        }
    }
}
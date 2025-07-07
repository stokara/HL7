namespace HL7.Address;

public sealed record SimpleAddress : IAddress {
    public string Address { get; }

    public SimpleAddress(string? address) {
        Address = address ?? string.Empty;
    }

    public AddressKind AddressKind => AddressKind.Simple;
}
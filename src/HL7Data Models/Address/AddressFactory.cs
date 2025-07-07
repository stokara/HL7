namespace HL7.Address;

public static class AddressFactory {
    /// <summary>
    ///     Creates an IAddress from a Field: returns SimpleAddress if the field has no components, otherwise ExtendedAddress.
    /// </summary>
    public static IAddress Create(Field field) {
        if (field.HasComponents) {
            return new ExtendedAddress(field.Components!);
        }

        return new SimpleAddress(field.Value);
    }
}
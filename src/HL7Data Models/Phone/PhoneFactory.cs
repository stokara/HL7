namespace HL7.Phone;

public static class PhoneFactory {
    /// <summary>
    ///     Creates an IPhone from a Field: returns SimplePhone if the field has no components, otherwise ExtendedPhone.
    /// </summary>
    public static IPhone Create(Field field) {
        if (field.HasComponents) {
            return new ExtendedPhone(field.Components);
        }

        return new SimplePhone(field.Value);
    }
}
namespace HL7.PersonName;

public static class PersonNameFactory {
    /// <summary>
    ///     Creates an IPersonName from a Field: returns SimplePersonName if the field has no components, otherwise
    ///     ExtendedPersonName.
    /// </summary>
    public static IPersonName Create(Field field) {
        if (field.HasComponents) {
            return new ExtendedPersonName(field.Components);
        }

        return new SimplePersonName(field.Value);
    }
}
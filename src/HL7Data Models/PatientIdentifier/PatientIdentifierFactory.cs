namespace HL7.PatientIdentifier;

public static class PatientIdentifierFactory {
    /// <summary>
    ///     Creates an IPatientIdentifier from a Field: returns SimplePatientIdentifier if the field has no components,
    ///     otherwise ExtendedPatientIdentifier.
    /// </summary>
    public static IPatientIdentifier Create(Field field) {
        if (field.HasComponents) {
            return new ExtendedPatientIdentifier(field.Components);
        }

        return new SimplePatientIdentifier(field.Value);
    }
}
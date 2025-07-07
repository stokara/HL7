namespace HL7.PatientIdentifier;

public sealed record SimplePatientIdentifier : IPatientIdentifier {
    public string Value { get; }

    public SimplePatientIdentifier(string? value) {
        Value = value ?? string.Empty;
    }

    public PatientIdentifierKind PatientIdentifierKind => PatientIdentifierKind.Simple;
}
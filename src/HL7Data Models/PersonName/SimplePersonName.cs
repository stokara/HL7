namespace HL7.PersonName;

public sealed record SimplePersonName : IPersonName {
    public string Value { get; }

    public SimplePersonName(string? value) {
        Value = value ?? string.Empty;
    }

    public PersonNameKind PersonNameKind => PersonNameKind.Simple;
}
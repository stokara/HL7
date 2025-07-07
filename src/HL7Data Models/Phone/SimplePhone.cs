namespace HL7.Phone;

public sealed record SimplePhone : IPhone {
    public string Value { get; }

    public SimplePhone(string? value) {
        Value = value ?? string.Empty;
    }

    public PhoneKind PhoneKind => PhoneKind.Simple;
}
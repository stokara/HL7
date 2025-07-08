using System.Linq;

namespace HL7;

/// <summary>
///     Represents a coded element (CE) that can be simple or extended (composite).
/// </summary>
public sealed record CodedElement : IComposite {
    public string Identifier { get; }
    public string Text { get; }
    public string NameOfCodingSystem { get; }
    public string AlternateIdentifier { get; }
    public string AlternateText { get; }
    public string NameOfAlternateCodingSystem { get; }

    public CodedElement(string identifier) {
        Identifier = string.Empty;
        Text = identifier;
        NameOfCodingSystem = string.Empty;
        AlternateIdentifier = string.Empty;
        AlternateText = string.Empty;
        NameOfAlternateCodingSystem = string.Empty;
        IsExtended = false;
    }

    public CodedElement(string identifier, string text, string nameOfCodingSystem, string alternateIdentifier, string alternateText, string nameOfAlternateCodingSystem) {
        Identifier = identifier;
        Text = text;
        NameOfCodingSystem = nameOfCodingSystem;
        AlternateIdentifier = alternateIdentifier;
        AlternateText = alternateText;
        NameOfAlternateCodingSystem = nameOfAlternateCodingSystem;
        IsExtended = true;
    }

    public bool IsExtended { get; }

    public static HL7Property<CodedElement> CreateHL7Property(Segment segment, int fieldNumber) {
        var field = segment.GetField(fieldNumber);
        if (field is null) return new HL7Property<CodedElement>([new CodedElement(string.Empty)]);
        return field.HasRepetitions
            ? new HL7Property<CodedElement>(field.Repetitions!.Select(Parse).ToArray())
            : new HL7Property<CodedElement>([Parse(field)]);
    }

    public static CodedElement Parse(Field? field) {
        if (field is null) return new CodedElement(string.Empty);
        return field.HasComponents
            ? new CodedElement(
                field.Components!.Count > 0 ? field.Components[0].Value : string.Empty,
                field.Components.Count > 1 ? field.Components[1].Value : string.Empty,
                field.Components.Count > 2 ? field.Components[2].Value : string.Empty,
                field.Components.Count > 3 ? field.Components[3].Value : string.Empty,
                field.Components.Count > 4 ? field.Components[4].Value : string.Empty,
                field.Components.Count > 5 ? field.Components[5].Value : string.Empty)
            : new CodedElement(field.Value);
    }
}
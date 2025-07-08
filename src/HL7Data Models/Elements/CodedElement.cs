namespace HL7.Elements;

using HL7;
using System.Collections.Generic;

/// <summary>
/// Represents a coded element (CE) with components.
/// </summary>
public sealed record CodedElement(
    string Identifier,
    string Text,
    string NameOfCodingSystem,
    string AlternateIdentifier,
    string AlternateText,
    string NameOfAlternateCodingSystem) {
    public static readonly CodedElement Empty = new("", "", "", "", "", "");

    public static CodedElement Parse(Field field) {
        if (!field.HasComponents) return Empty;

        var c = field.Components!;
        return new CodedElement(
            c.Count > 0 ? c[0].Value : string.Empty,
            c.Count > 1 ? c[1].Value : string.Empty,
            c.Count > 2 ? c[2].Value : string.Empty,
            c.Count > 3 ? c[3].Value : string.Empty,
            c.Count > 4 ? c[4].Value : string.Empty,
            c.Count > 5 ? c[5].Value : string.Empty
        );
    }
}
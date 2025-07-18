using NodaTime;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HL7;

public record RawField {
    public IReadOnlyList<RawComponent> RepeatedFields { get; }
    public RawComponent? RawComponent => RepeatedFields.Count == 1 ? RepeatedFields[0] : null;

    public RawField(string rawFieldString, Hl7Encoding encoding) {
        RepeatedFields = string.IsNullOrWhiteSpace(rawFieldString)
            ? []
            : splitRepeatedFields();
        return;

        ReadOnlyCollection<RawComponent> splitRepeatedFields() =>
            rawFieldString
                .Split(encoding.RepeatDelimiter)
                .Select(f => new RawComponent(f, encoding, Hl7Structure.Hl7Component))
                .ToList()
                .AsReadOnly();
    }
}

public static class Hl7FieldHelper {
    public static Instant? GetDate(this IReadOnlyList<string> components, int index, char delimiter) {
        if (components.Count <= index)
            return null;

        var stringValue = components[index];
        if (string.IsNullOrEmpty(stringValue))
            return null;

        try {
            return Hl7DateParser.ParseInstant(stringValue);
        } catch (Exception) {
            return null;
        }
    }

    public static int? GetInt(this IReadOnlyList<string> components, int index, int? defaultValue = null) {
        if (components.Count < index || string.IsNullOrWhiteSpace(components[index - 1]))
            return defaultValue;

        return int.TryParse(components[index - 1], out var result)
            ? result
            : defaultValue;
    }

    public static decimal? GetDecimal(this IReadOnlyList<string> components, int index, decimal? defaultValue = null) {
        if (components.Count < index || string.IsNullOrWhiteSpace(components[index - 1]))
            return defaultValue;

        return decimal.TryParse(components[index - 1], out var result)
            ? result
            : defaultValue;
    }
}
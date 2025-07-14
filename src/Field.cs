using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NodaTime;

namespace HL7;

public record Field {
    public bool IsDelimitersField { get; init; }
    public string StringValue { get; init; } = "";
    public IReadOnlyList<string>? Components { get; init; } = [];
    public IReadOnlyList<Field>? Repetitions { get; init; } = [];
    public bool IsComposite => Components is { Count: > 0 };
    public bool HasRepetitions => Repetitions is { Count: > 0 };

    protected Field(string StringValue, IReadOnlyList<Field>? Repetitions = null) {
        this.StringValue = StringValue;
        this.Repetitions = Repetitions;
    }

    private Field(IReadOnlyList<string>? Components) {
        this.Components = Components;
    }

    public static Field Parse(Hl7Encoding encoding, string stringValue) {
        var hasRepetitions = stringValue.Contains(encoding.RepeatDelimiter);
        if (hasRepetitions) {
            var repeatFields = stringValue.Split(encoding.RepeatDelimiter);
            var repetitions = repeatFields.Select(fieldValue => Parse(encoding, fieldValue)).ToArray();
            return new Field(stringValue, Repetitions: repetitions);
        }

        var componentStrings = stringValue.Split(encoding.ComponentDelimiter);
        return new Field(componentStrings);
    }

    public static Field CreateDelimiterField(string value) => new(value) { IsDelimitersField = true };


    public string? GetComponent(int index, bool isThrowOnNull = false) {
        if (!IsComposite) {
            if (isThrowOnNull) throw new Hl7Exception($"Field {index} has no components.", Hl7Exception.ParsingError);

            return null;
        }

        // HL7 index is 1-based 
        if (index < 1 || index >= Components!.Count) {
            if (isThrowOnNull) throw new Hl7Exception($"Field {index} is out of range .", Hl7Exception.ParsingError);

            return null;
        }

        var result = Components[index];
        if (result is null && isThrowOnNull) throw new Hl7Exception($"Field {index} is required but missing.", Hl7Exception.RequiredFieldMissing);

        return result;
    }

    public virtual bool Equals(Field? other) {
        if (ReferenceEquals(this, other)) return true;

        return other is not null && string.Equals(this.StringValue, other.StringValue);
    }

    public override int GetHashCode() {
        var valueHash = StringValue.GetHashCode();

        var componentsHash = 0;
        if (IsComposite)
            componentsHash = Components!.Aggregate(0,
                (current, component) => HashCode.Combine(current, component.GetHashCode()));

        var repetitionsHash = 0;
        if (HasRepetitions)
            repetitionsHash = Repetitions!.Aggregate(0,
                (current, repetition) => HashCode.Combine(current, repetition.GetHashCode()));

        return HashCode.Combine(valueHash, componentsHash, repetitionsHash);
    }
}

public interface IHl7Field<out T> where T : class, IHl7DataType {
    public static T Parse(Field field, Hl7Encoding encoding) {
        if (field.HasRepetitions) throw new InvalidOperationException("Use RepField<T> for fields with repetitions.");

        return field.IsComposite
            ? ParseComponents(field.Components!, encoding.SubComponentDelimiter)
            : ParseComponents([field.StringValue], encoding.ComponentDelimiter);
    }

    [SuppressMessage("ReSharper", "ConvertTypeCheckPatternToNullCheck")]
    public static T ParseComponents(IReadOnlyList<string> componentStrings, char subComponentDelimiter) {
        Hl7DataType result = typeof(T) switch {
            Type t when t == typeof(HD) => new HD(componentStrings),
            Type t when t == typeof(CX) => new CX(componentStrings, subComponentDelimiter),
            Type t when t == typeof(SAD) => new SAD(componentStrings, subComponentDelimiter),
            // Add more types as needed
            _ => throw new NotSupportedException($"Component<{typeof(T).Name}>.ParseField is not supported for this type.")
        };
        return result as T ?? throw new InvalidCastException($"Failed to cast {typeof(T).Name} from {result.GetType().Name}");
    }
}

public static class Hl7FieldHelper {
    [return: NotNullIfNotNull("defaultValue")]
    public static T? Get<T>(this IReadOnlyList<string> components, int index, char delimiter, T? defaultValue = null) where T : class, IHl7DataType {
        if (components.Count <= index) return defaultValue;

        var stringValue = components[index];
        if (string.IsNullOrEmpty(stringValue)) return defaultValue;

        try {
            return IHl7Field<T>.ParseComponents([stringValue], delimiter);
        } catch (Exception) {
            return defaultValue;
        }
    }

    public static Instant? GetDate(this IReadOnlyList<string> components, int index, char delimiter) {
        if (components.Count <= index) return null;
        var stringValue = components[index];
        if (string.IsNullOrEmpty(stringValue)) return null;

        try {
            return Hl7DateParser.ParseInstant(stringValue);
        } catch (Exception) {
            return null;
        }
    }

    public static int? GetInt(this IReadOnlyList<string> components, int index, int? defaultValue = null) {
        if (components.Count < index || string.IsNullOrWhiteSpace(components[index - 1])) return defaultValue;
        return int.TryParse(components[index - 1], out var result) 
            ? result 
            : defaultValue;
    }

    public static decimal? GetDecimal(this IReadOnlyList<string> components, int index, decimal? defaultValue = null) {
        if (components.Count < index || string.IsNullOrWhiteSpace(components[index - 1])) return defaultValue;
        return decimal.TryParse(components[index - 1], out var result) 
            ? result 
            : defaultValue;
    }
}

public sealed record RepField<T>(IReadOnlyList<T> Repetitions) where T : class, IHl7DataType {
    public bool HasRepetitions => Repetitions.Count > 0;

    public string Serialize(Hl7Encoding encoding) =>
        Repetitions.Count == 0
            ? ""
            : string.Join(encoding.RepeatDelimiter, Repetitions.Select(rf => rf.Serialize(encoding)));

    public static RepField<T> Parse(Field field, Hl7Encoding encoding) {
        var repetitions = field.HasRepetitions
            ? field.Repetitions!.Select(f => IHl7Field<T>.Parse(f, encoding)).ToList().AsReadOnly()
            : new List<T> { IHl7Field<T>.Parse(field, encoding) }.AsReadOnly();
        return new RepField<T>(repetitions);
    }
}
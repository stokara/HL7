using System;
using System.Collections.Generic;
using System.Linq;

namespace HL7;

public sealed record Field {
    public bool IsDelimitersField { get; init; }
    public string Value { get; init; }
    public IReadOnlyList<Component>? Components { get; init; }
    public IReadOnlyList<Field>? Repetitions { get; init; }
    public bool HasComponents => Components is { Count: > 0 };
    public bool HasRepetitions => Repetitions is { Count: > 0 };

    private Field(string Value, IReadOnlyList<Component>? Components = null, IReadOnlyList<Field>? Repetitions = null) {
        this.Value = Value;
        this.Components = Components;
        this.Repetitions = Repetitions;
    }

    public static Field CreateDelimiterField(string value) {
        var component = Component.CreateDelimiterComponent(value);
        return new Field(value, [component]) { IsDelimitersField = true };
    }

    public static Field Parse(HL7Encoding encoding, string value) {
        var hasRepetitions = value.Contains(encoding.RepeatDelimiter);
        if (hasRepetitions) {
            var repeatFields = value.Split(encoding.RepeatDelimiter);
            var repetitions = repeatFields.Select(fieldValue => Parse(encoding, fieldValue)).ToArray();
            return new Field(value, Repetitions: repetitions);
        }

        var hasComponents = value.Contains(encoding.ComponentDelimiter);
        if (hasComponents) {
            var components = value
                .Split(encoding.ComponentDelimiter)
                .Select(c => Component.Parse(encoding, c)).ToArray();
            return new Field(value, components);
        }

        return new Field(value);
    }

    public string Serialize(HL7Encoding encoding) {
        if (HasRepetitions)
            return string.Join(encoding.RepeatDelimiter, Repetitions!.Select(rf => rf.Serialize(encoding)));
        if (!HasComponents) return encoding.Encode(this.Value);

        return string.Join(encoding.ComponentDelimiter.ToString(),
            Components!.Select(component =>
                component.HasSubComponents
                    ? string.Join(encoding.SubComponentDelimiter.ToString(),
                        component.SubComponents.Select(sc => encoding.Encode(sc.Value)))
                    : encoding.Encode(component.Value)
            )
        );
    }

    public bool Equals(Field? other) {
        if (ReferenceEquals(this, other)) return true;
        return other is not null && string.Equals(this.Value, other.Value);
    }

    public override int GetHashCode() {
        var valueHash = Value.GetHashCode();

        var componentsHash = 0;
        if (HasComponents)
            componentsHash = Components!.Aggregate(0,
                (current, component) => HashCode.Combine(current, component.GetHashCode()));

        var repetitionsHash = 0;
        if (HasRepetitions)
            repetitionsHash = Repetitions!.Aggregate(0,
                (current, repetition) => HashCode.Combine(current, repetition.GetHashCode()));

        return HashCode.Combine(valueHash, componentsHash, repetitionsHash);
    }
}
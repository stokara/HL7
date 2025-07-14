using System;
using System.Collections.Generic;
using NodaTime;
using System.Diagnostics.CodeAnalysis;

namespace HL7;

public interface IComponent {
    string? StringValue { get; }
    IReadOnlyList<IComponent>? SubComponents { get; }
}

public record Component<T> : IComponent {
    public string? StringValue { get; } = null;
    public IReadOnlyList<IComponent>? SubComponents { get; }
    public T? Value { get; }

    protected Component(IReadOnlyList<IComponent> SubComponents) {
        this.SubComponents = SubComponents;
    }

    protected Component(T value) {
        this.Value = value;
    }
}

public static class ComponentHelper {
    [return: NotNullIfNotNull("defaultValue")]
    public static T Get<T>(this IReadOnlyList<string> components, int index, Func<string, T> parse, T defaultValue) {
        if (components.Count < index) return defaultValue;
        var value = components[index-1];
        if (string.IsNullOrEmpty(value)) return defaultValue;

        try {
            return parse(value);
        } catch (Exception) {
            return defaultValue;
        }
    }

    public static T GetRequired<T>(this IReadOnlyList<string> components, int index, Func<string, T> parse) {
        if (components.Count < index) throw new Hl7Exception("index is out of bounds.", Hl7Exception.RequiredFieldMissing);
        var value = components[index - 1];
        return parse(value);
    }


    [return: NotNullIfNotNull("defaultValue")]
    public static string? GetString(this IReadOnlyList<string> components, int index, string? defaultValue = null) {
        if (components.Count < index) return defaultValue;
        var value = components[index-1];
        return string.IsNullOrEmpty(value) ? defaultValue : value;
    }

    public static string GetRequiredString(this IReadOnlyList<string> components, int index) {
        if (components.Count < index) throw new Hl7Exception("index is out of bounds.", Hl7Exception.RequiredFieldMissing);
        var value = components[index - 1];
        return string.IsNullOrEmpty(value) ? "" : value;
    }

    public static int? GetInt(this IReadOnlyList<string> components, int index, int? defaultValue) => Get(components, index, s => int.Parse(s), defaultValue);
    public static decimal? GetDecimal(this IReadOnlyList<string> components, int index, decimal? defaultValue) => Get(components, index, s => decimal.Parse(s), defaultValue);
    public static Instant? GetInstant(this IReadOnlyList<string> components, int index) => Get(components, index, s => Hl7DateParser.ParseInstant(s), null);
    public static int GetRequiredInt(this IReadOnlyList<string> components, int index, int? defaultValue) => GetRequired(components, index, int.Parse);
    public static decimal GetRequiredDecimal(this IReadOnlyList<string> components, int index) => GetRequired(components, index, decimal.Parse);
    public static Instant GetRequiredInstant(this IReadOnlyList<string> components, int index) {
        var result =  GetInstant(components, index);
        if (result is null) throw new Hl7Exception($"Invalid or missing value for Date Time for index:{index}.", Hl7Exception.RequiredFieldMissing);
        return result.Value;
    }


}



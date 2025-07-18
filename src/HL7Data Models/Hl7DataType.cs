using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HL7;

public enum Hl7Structure {
    Hl7Message,
    Hl7Segment,
    Hl7Field,
    Hl7RepField,
    Hl7Component,
    Hl7SubComponent,
    Hl7None
}

public enum Complexity {
    Complex,
    Simple,
    Primitive
}

public interface IHl7DataType {
    Hl7Structure? Structure { get; }
    Complexity? Complexity { get; }
    public string Serialize(Hl7Encoding encoding, Hl7Structure? sourceStructure = null);
}

public abstract record Hl7DataType : IHl7DataType {
    public string? StringValue { get; init; }

    public Hl7Structure? Structure { get; protected set; }
    public Complexity? Complexity { get; protected set; }

    protected Hl7DataType(Hl7Structure structure, Complexity complexity) {
        Structure = structure;
        Complexity = complexity;
    }

    protected Hl7DataType() { }

    public abstract string Serialize(Hl7Encoding encoding, Hl7Structure? sourceStructure = null);

    //public static T ParseDataType<T>(IReadOnlyList<string> componentStrings, Hl7Structure sourceStructure) where T : class, IHl7DataType {
    //    var type = typeof(T);

    //    if (constructorCache.TryGetValue(type, out var ctor) && ctor != null) {
    //        var parameters = ctor.GetParameters();
    //        if (parameters is [var valueParam, { ParameterType.IsEnum: true } enumParam]) {
    //            var paramType = valueParam.ParameterType;
    //            object? value = paramType switch {
    //                Type t when t == typeof(IReadOnlyList<string>) => componentStrings,
    //                Type t when t == typeof(string) => componentStrings[0],
    //                Type t when t == typeof(Instant?) => Hl7DateParser.ParseInstant(componentStrings[0]),
    //                Type t when t == typeof(decimal?) => decimal.TryParse(componentStrings[0], out var d) ? d : null,
    //                Type t when t == typeof(int?) => int.TryParse(componentStrings[0], out var i) ? i : null,
    //                _ => throw new NotSupportedException($"Unsupported parameter type {paramType.Name} for {type.Name}.")
    //            };
    //            return ctor.Invoke([value, sourceStructure]) as T
    //                   ?? throw new InvalidCastException($"Failed to cast {type.Name} from constructor result.");

    //        }
    //    }
    //    throw new NotSupportedException($"ParseDataType is not supported for type {type.Name}.");
    //}

    private static readonly Dictionary<Type, ConstructorInfo?> constructorCache = new();

    static Hl7DataType() {
        var assembly = typeof(Hl7DataType).Assembly;

        var types = assembly.GetTypes().Where(t => t is { IsClass: true, IsAbstract: false }
                                                   && typeof(Hl7DataType).IsAssignableFrom(t)
                                                   && (t.Name.Length < 3 || t.Name[0..3] != "Hl7"));
        foreach (var type in types) {
            constructorCache[type] = type.GetConstructors().First();
        }
    }

    private static readonly Dictionary<Type, PropertyInfo[]> PropertyCache = new();

    internal PropertyInfo[] GetProperties() {
        var type = GetType();
        if (!PropertyCache.TryGetValue(type, out var props)) {
            props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            PropertyCache[type] = props;
        }

        return props;
    }
}

public abstract record Hl7SimpleType : Hl7DataType {
    protected Hl7SimpleType(Hl7Structure structure) : base(structure, HL7.Complexity.Simple) { }

    public override string Serialize(Hl7Encoding encoding, Hl7Structure?  _) => StringValue ?? "";
}

public abstract record Hl7ComplexType : Hl7DataType {
    protected Hl7ComplexType(Hl7Structure structure) : base(structure, HL7.Complexity.Complex) { }

    protected Hl7ComplexType() { }

    public override string Serialize(Hl7Encoding encoding, Hl7Structure? sourceStructure = null) {
        if (this.Complexity == HL7.Complexity.Simple) return StringValue ?? "";
        
        var (delimiter1, hl7Structure) = sourceStructure switch {
            Hl7Structure.Hl7Message => (encoding.SegmentDelimiter, Hl7Structure.Hl7Field),
            Hl7Structure.Hl7Segment => (encoding.FieldDelimiter.ToString(), Hl7Structure.Hl7Component),
            Hl7Structure.Hl7Field => (encoding.ComponentDelimiter.ToString(), Hl7Structure.Hl7SubComponent),
            Hl7Structure.Hl7Component => (encoding.SubComponentDelimiter.ToString(), Hl7Structure.Hl7None),
            _ => ("", Hl7Structure.Hl7None)
        };
        var props = this.GetProperties().Select(p => p.GetValue(this)).ToArray();

        return string.Join(delimiter1, props.Select(v => (v as Hl7DataType)?.Serialize(encoding, hl7Structure) ?? string.Empty));
    }

    public override int GetHashCode() {
        var components = GetProperties();
        return components.Aggregate(0, (current, prop) => HashCode.Combine(current, prop.GetValue(this)?.GetHashCode() ?? 0));
    }
}
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HL7;

public record RawComponent {
    public string? ComponentValue { get; }
    public string[] SubComponents { get; set; }
    public Hl7Structure Structure { get; }

    public readonly Hl7Encoding Encoding;

    public RawComponent(string? stringValue, Hl7Encoding encoding, Hl7Structure structure) {
        this.Encoding = encoding;
        this.Structure = structure;
        if (string.IsNullOrEmpty(stringValue)) {
            SubComponents = [];
            return;
        }

        if (structure == Hl7Structure.Hl7Component) {
            if (stringValue.Contains(encoding.SubComponentDelimiter)) {
                SubComponents = stringValue.Split(encoding.SubComponentDelimiter);
                return;
            } 
        }
        SubComponents = [];
        ComponentValue = stringValue;
    }

    public T? Get<T>(int index, bool isRequired = false) where T : class, IHl7DataType {
        //if (index < 1 || index > SubComponents.Length) return null;

        try {
            switch (Structure) {
                case Hl7Structure.Hl7SubComponent:
                    return ParseDataType<T>(this, Hl7Structure.Hl7Component);
                case Hl7Structure.Hl7Component:
                {
                    var str = getComponentString(index);
                    var rawComponent = new RawComponent(str, Encoding, Hl7Structure.Hl7SubComponent);
                    return ParseDataType<T>(rawComponent, Hl7Structure.Hl7SubComponent);
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        } catch (Exception) {
            return null;
        }

        string? getComponentString(int fieldNumber) {
            // HL7 is 1-based after)
            //if (fieldNumber < 1 || fieldNumber >= SubComponents.Length) {
            //    if (isRequired) throw new Hl7Exception($"Field {fieldNumber} is out of range for Field {index}.", Hl7Exception.ParsingError);

            //    return null;
            //}
            if (SubComponents.Length == 0 && fieldNumber == 1) return ComponentValue;

            var result = SubComponents[fieldNumber - 1];
            if (result is null && isRequired) throw new Hl7Exception($"Component {fieldNumber} is required but missing in Field {index}.", Hl7Exception.RequiredFieldMissing);

            return result;
        }
    }

    public T Parse<T>(Hl7Structure sourceStructure) where T : class, IHl7DataType => ParseDataType<T>(this, sourceStructure);

    //[return: NotNullIfNotNull("defaultValue")]
    //public static T? Get<T>(this RawComponent rawComponent, int index, Hl7Structure sourceStructure, T? defaultValue = null) where T : class, IHl7DataType {
    //    if (rawComponents.Count < index)
    //        return defaultValue;

        //    var rawComponent = rawComponents[index - 1];  //HL7 is 1 based
        //    if (rawComponent.IsEmpty)
        //        return defaultValue;

        //    try {
        //        return parseComponents<T>([rawComponent], sourceStructure);
        //    } catch (Exception) {
        //        return defaultValue;
        //    }
        //}


    public static T ParseDataType<T>(RawComponent rawComponent, Hl7Structure structure) where T : class, IHl7DataType {
        var type = typeof(T);

        if (constructorCache.TryGetValue(type, out var ctor) && ctor != null) {
            var parameters = ctor.GetParameters();
            if (parameters is [var valueParam, _, { ParameterType.IsEnum: true }]
                && parameters[1].ParameterType == typeof(Hl7Encoding)) {
                var paramType = valueParam.ParameterType;
                object? value = paramType switch {
                    Type t when t == typeof(string) => rawComponent.ComponentValue,
                    Type t when t == typeof(IReadOnlyList<string>) => rawComponent.SubComponents,
                    Type t when t == typeof(Instant?) => Hl7DateParser.ParseInstant(rawComponent.ComponentValue),
                    Type t when t == typeof(decimal?) => decimal.TryParse(rawComponent.ComponentValue, out var d) ? d : null,
                    Type t when t == typeof(int?) => int.TryParse(rawComponent.ComponentValue, out var i) ? i : null,
                    _ => throw new NotSupportedException($"Unsupported parameter type {paramType.Name} for {type.Name}.")
                };
                return ctor.Invoke([value, rawComponent.Encoding, structure]) as T ?? throw new InvalidCastException($"Failed to cast {type.Name} from constructor result.");
            }

            if (parameters is [var singleParam]) {
                var paramType = singleParam.ParameterType;
                object? value = paramType switch {
                    Type t when t == typeof(string) => rawComponent.ComponentValue,
                    Type t when t == typeof(IReadOnlyList<string>) => rawComponent.SubComponents,
                    Type t when t == typeof(Instant?) => Hl7DateParser.ParseInstant(rawComponent.ComponentValue),
                    Type t when t == typeof(decimal?) => decimal.TryParse(rawComponent.ComponentValue, out var d) ? d : null,
                    Type t when t == typeof(int?) => int.TryParse(rawComponent.ComponentValue, out var i) ? i : null,
                    _ => throw new NotSupportedException($"Unsupported parameter type {paramType.Name} for {type.Name}.")
                };
                return ctor.Invoke([value]) as T ?? throw new InvalidCastException($"Failed to cast {type.Name} from constructor result.");
            }
        }
        throw new NotSupportedException($"ParseDataType is not supported for type {type.Name}.");
    }

    private static readonly Dictionary<Type, ConstructorInfo?> constructorCache = new();

    static RawComponent() {
        var assembly = typeof(Hl7DataType).Assembly;

        var types = assembly.GetTypes().Where(t => t is { IsClass: true, IsAbstract: false }
                                                   && typeof(Hl7DataType).IsAssignableFrom(t)
                                                   && (t.Name.Length < 3 || t.Name[0..3] != "Hl7"));
        foreach (var type in types) {
            constructorCache[type] = type.GetConstructors().First();
        }
    }
}

//public record Component<T>  {
//    public string? StringValue { get; } = null;
//    public IReadOnlyList<Component>? SubComponents { get; }
//    public T? Value { get; }

//    protected Component(IReadOnlyList<IComponent> SubComponents) {
//        this.SubComponents = SubComponents;
//    }

//    protected Component(T value) {
//        this.Value = value;
//    }
//}

//public static class ComponentHelper {

//    [return: NotNullIfNotNull("defaultValue")]
//    public static Hl7Component<T>? Get<T>(this IReadOnlyList<string> components, int index, Func<string, T> parse, T defaultValue) where T : class, IHl7DataType {
//        if (components.Count < index) return new Hl7Component<T>(defaultValue);
//        var value = components[index-1];
//        if (string.IsNullOrEmpty(value)) return new Hl7Component<T>(defaultValue);

//        try {
//            var inner = parse(value);
//            return new Hl7Component<T>(inner);
//        } catch (Exception) {
//            return new Hl7Component<T>(defaultValue);
//        }
//    }

//    public static Hl7Component<T> GetRequired<T>(this IReadOnlyList<string> components, int index, Func<string, T> parse) where T : class, IHl7DataType {
//        if (components.Count < index) throw new Hl7Exception("index is out of bounds.", Hl7Exception.RequiredFieldMissing);
//        var value = components[index - 1];
//        try {
//            var inner = parse(value);
//            return new Hl7Component<T>(inner);
//        } catch (Exception ex) {
//            throw new Hl7Exception(ex.Message, Hl7Exception.ParsingError);
//        }
//    }


//    [return: NotNullIfNotNull("defaultValue")]
//    public static string? GetString(this IReadOnlyList<string> components, int index, string? defaultValue = null) {
//        if (components.Count < index) return defaultValue;
//        var value = components[index-1];
//        return string.IsNullOrEmpty(value) ? defaultValue : value;
//    }

//    public static string GetRequiredString(this IReadOnlyList<string> components, int index) {
//        if (components.Count < index) throw new Hl7Exception("index is out of bounds.", Hl7Exception.RequiredFieldMissing);
//        var value = components[index - 1];
//        return string.IsNullOrEmpty(value) ? "" : value;
//    }

//    //public static int? GetInt(this IReadOnlyList<string> components, int index, int? defaultValue) => Get(components, index, s => int.Parse(s), defaultValue);
//    //public static decimal? GetDecimal(this IReadOnlyList<string> components, int index, decimal? defaultValue) => Get(components, index, s => decimal.Parse(s), defaultValue);
//    //public static Instant? GetInstant(this IReadOnlyList<string> components, int index) => Get(components, index, s => Hl7DateParser.ParseInstant(s), null);
//    //public static int GetRequiredInt(this IReadOnlyList<string> components, int index, int? defaultValue) => GetRequired(components, index, int.Parse);
//    //public static decimal GetRequiredDecimal(this IReadOnlyList<string> components, int index) => GetRequired(components, index, decimal.Parse);
//    //public static Instant GetRequiredInstant(this IReadOnlyList<string> components, int index) {
//    //    var result =  GetInstant(components, index);
//    //    if (result is null) throw new Hl7Exception($"Invalid or missing value for Date Time for index:{index}.", Hl7Exception.RequiredFieldMissing);
//    //    return result.Value;
//    //}


//}
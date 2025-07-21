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
            if (stringValue.Contains(encoding.ComponentDelimiter)) {
                SubComponents = stringValue.Split(encoding.ComponentDelimiter);
                return;
            } 
        }
        if (structure == Hl7Structure.Hl7SubComponent) {
            if (stringValue.Contains(encoding.SubComponentDelimiter)) {
                SubComponents = stringValue.Split(encoding.SubComponentDelimiter);
                return;
            }
        }
        SubComponents = [];
        ComponentValue = stringValue;
    }

    public T? Get<T>(int index, bool isRequired = false) where T : class, IHl7DataType {
        try {
            switch (Structure) {
                case Hl7Structure.Hl7SubComponent:
                    return ParseDataType<T>(this);
                case Hl7Structure.Hl7Component: {
                    var str = getComponentString(index);
                    var rawComponent = new RawComponent(str, Encoding, Hl7Structure.Hl7SubComponent);
                    return ParseDataType<T>(rawComponent);
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        } catch (Exception) {
            return null;
        }

        string? getComponentString(int fieldNumber) {
            if (SubComponents.Length == 0 && fieldNumber == 1) return ComponentValue;

            var result = SubComponents[fieldNumber - 1];
            if (result is null && isRequired) throw new Hl7Exception($"Component {fieldNumber} is required but missing in Field {index}.", Hl7Exception.RequiredFieldMissing);

            return result;
        }
    }

    public T Parse<T>() where T : class, IHl7DataType => ParseDataType<T>(this);
    
    public static T ParseDataType<T>(RawComponent rawComponent) where T : class, IHl7DataType {
        var type = typeof(T);

        if (constructorCache.TryGetValue(type, out var ctor) && ctor != null) {
            var parameters = ctor.GetParameters();
            if (parameters is [var valueParam]) {
                var paramType = valueParam.ParameterType;
                object? value = paramType switch {
                    Type t when t == typeof(RawComponent) => rawComponent,
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
using System;
using System.Linq;

namespace HL7;

public interface IHl7DataType {
    public string Serialize(Hl7Encoding encoding);
}

public abstract record Hl7DataType : IHl7DataType {
    public virtual string Serialize(Hl7Encoding encoding) {
        var type = GetType();
        var properties = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        var encodedValues = properties
            .Select(prop => prop.GetValue(this))
            .Select(value => SerializePropertyValue(value, encoding))
            .ToList();
        return string.Join(encoding.ComponentDelimiter, encodedValues);
    }

    protected static string SerializePropertyValue(object? value, Hl7Encoding encoding) {
        if (value == null) return string.Empty;
        var valueType = value.GetType();

        if (IsPrimitiveType(valueType)) return encoding.Encode(value.ToString()!);
        if (valueType.IsClass && valueType != typeof(string)) return SerializeComplexObject(value, encoding);
        return encoding.Encode(value.ToString()!);
    }

    protected static bool IsPrimitiveType(Type type) => type == typeof(string) || type == typeof(int) || type == typeof(decimal);

    protected static string SerializeComplexObject(object value, Hl7Encoding encoding) {
        var subProps = value.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        var subEncoded = subProps
            .Select(subProp => subProp.GetValue(value))
            .Select(subVal => encoding.Encode(subVal?.ToString() ?? string.Empty));
        return string.Join(encoding.SubComponentDelimiter, subEncoded);
    }
}
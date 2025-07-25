﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HL7;

public abstract record Hl7Segment  {
    protected Hl7Segment(Type segmentType, Segment segment)  {
        if (segment.Name != segmentType.Name) {
            throw new InvalidDataException($"Invalid Segment when loading {segmentType.Name} using is {segment.Name}");
        }
    }

    public string Serialize(Hl7Encoding encoding) {
        var props = this.GetProperties().ToArray();
        var type = this.GetType();
        var initialString = $"{type.Name}{(type == typeof(MSH) ? encoding.ToString() : encoding.FieldDelimiter)}";
        return initialString + string.Join(encoding.FieldDelimiter, props.Select(p => serializeProperty(p)));

        string serializeProperty(PropertyInfo propertyInfo) {
            if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>)) {
                var collection = propertyInfo.GetValue(this) as System.Collections.IEnumerable;
                if (collection == null) return string.Empty;
                var serializedItems = collection.Cast<object?>().Select(item => (item as Hl7DataType)?.Serialize(encoding, Hl7Structure.Hl7RepField) ?? "");
                return string.Join(encoding.RepeatDelimiter.ToString(), serializedItems);
            }

            var h = (propertyInfo.GetValue(this) as Hl7DataType);
            if (h == null) return string.Empty;  //log a warning here 
            return h.Serialize(encoding, Hl7Structure.Hl7Component);
        }
    }

    private static readonly Dictionary<Type, PropertyInfo[]> propertyCache = new();

    internal PropertyInfo[] GetProperties() {
        var type = GetType();
        if (!propertyCache.TryGetValue(type, out var props)) {
            props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            propertyCache[type] = props;
        }
        return props;
    }
}
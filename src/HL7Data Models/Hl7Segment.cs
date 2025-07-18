using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HL7;

public abstract record Hl7Segment : Hl7ComplexType {

    protected Hl7Segment(Type segmentType, Segment segment) : base(Hl7Structure.Hl7Segment) {
        if (segment.Name != segmentType.Name) {
            throw new InvalidDataException($"Invalid Segment when loading {segmentType.Name} using is {segment.Name}");
        }
    }

    public override string Serialize(Hl7Encoding encoding, Hl7Structure structure) {
        var props = this.GetProperties().ToArray();
        var type = this.GetType();
        var initialString = $"{type.Name}{(type == typeof(MSH) ? encoding : "")}";
        return initialString + string.Join(encoding.FieldDelimiter, props.Select(p => serializeProperty(p)));

        string serializeProperty(PropertyInfo propertyInfo) {
            if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>)) {
                var collection = propertyInfo.GetValue(this) as System.Collections.IEnumerable;
                if (collection == null) return string.Empty;
                var serializedItems = collection.OfType<Hl7DataType>().Select(hl7Item => hl7Item.Serialize(encoding, structure));
                return string.Join(encoding.FieldDelimiter.ToString(), serializedItems);
            }

            var h = (propertyInfo.GetValue(this) as Hl7DataType);
            if (h == null) return string.Empty;  //log a warning here 
            return h.Serialize(encoding, Hl7Structure.Hl7Segment);
        }
    }
}
using System;
using System.IO;
using System.Linq;

namespace HL7;

public abstract record Hl7Segment : Hl7ComplexType {

    protected Hl7Segment(Type segmentType, Segment segment) : base(Hl7Structure.Hl7Segment) {
        if (segment.Name != segmentType.Name) {
            throw new InvalidDataException($"Invalid Segment when loading {segmentType.Name} using is {segment.Name}");
        }
    }

    public override string Serialize(Hl7Encoding encoding, Hl7Structure? _) {
        var props = this.GetProperties().Select(p => p.GetValue(this)).ToArray();
        var initialString = "";

        if (this is MSH msh) {
            initialString = $"{nameof(MSH)}{encoding}{encoding.FieldDelimiter}";
            props = props[2..];
        } else {
            var type = this.GetType();
            initialString = $"{type.Name}{encoding.FieldDelimiter}";
        }

        return initialString + string.Join(
            encoding.FieldDelimiter,
            props.Select(v => (v as Hl7DataType)?.Serialize(encoding, Hl7Structure.Hl7Segment) ?? string.Empty)
        );
    }
}
using System.Collections.Generic;
using System.Linq;

namespace HL7;

/// <summary>
///     Represents a value in OBX-5, supporting components.
/// </summary>
public sealed record ObservationValueElement(string Value, IReadOnlyList<string> Components) : IComposite {
    public bool IsExtended => true;
    public static ObservationValueElement Parse(Field field) {
        return field.HasComponents
            ? new ObservationValueElement(field.Value, field.Components!.Select(c => c.Value).ToArray())
            : new ObservationValueElement(field.Value, []);
    }

    public static HL7Property<ObservationValueElement> CreateHL7Property(Segment segment, int fieldNumber) {
        var field = segment.GetField(fieldNumber);
        if (field is null) return new HL7Property<ObservationValueElement>([new ObservationValueElement(string.Empty, [])]);
        return field.HasRepetitions
            ? new HL7Property<ObservationValueElement>(field.Repetitions!.Select(Parse).ToArray())
            : new HL7Property<ObservationValueElement>([Parse(field)]);
    }
}
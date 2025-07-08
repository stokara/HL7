using System.Collections.Generic;
using System.Linq;

namespace HL7;

/// <summary>
///     Represents a value in OBX-5, supporting components.
/// </summary>
public sealed record ObservationValueElement(string Value, IReadOnlyList<string> Components) {
    public static ObservationValueElement Parse(Field field) {
        return field.HasComponents
            ? new ObservationValueElement(field.Value, field.Components!.Select(c => c.Value).ToArray())
            : new ObservationValueElement(field.Value, []);
    }
}
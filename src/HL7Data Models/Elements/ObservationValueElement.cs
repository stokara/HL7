using System.Linq;

namespace HL7.Elements;

using HL7;
using System.Collections.Generic;

/// <summary>
/// Represents a value in OBX-5, supporting components.
/// </summary>
public sealed record ObservationValueElement(string Value, IReadOnlyList<string> Components) {
    public static ObservationValueElement Parse(Field field) =>
        field.HasComponents
            ? new ObservationValueElement(field.Value, field.Components!.Select(c => c.Value).ToArray())
            : new ObservationValueElement(field.Value, []);
}
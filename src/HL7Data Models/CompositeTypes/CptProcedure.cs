using System.Linq;

namespace HL7;

/// <summary>
///     Represents a CPT procedure code and description (used in FT1 and PR1).
/// </summary>
public sealed record CptProcedure(string Code, string Description) : IComposite {
    public bool IsExtended { get; } = true;
    public static CptProcedure Parse(Field field) {
        var code = field.HasComponents && field.Components!.Count > 0 ? field.Components[0].Value : field.Value;
        var desc = field.HasComponents && field.Components!.Count > 1 ? field.Components[1].Value : string.Empty;
        return new CptProcedure(code, desc);
    }

    public static HL7Property<CptProcedure> CreateHL7Property(Segment segment, int fieldNumber) {
        var field = segment.GetField(fieldNumber);
        if (field is null) return new HL7Property<CptProcedure>(new[] { new CptProcedure(string.Empty, string.Empty) });
        return field.HasRepetitions
            ? new HL7Property<CptProcedure>(field.Repetitions!.Select(Parse).ToArray())
            : new HL7Property<CptProcedure>(new[] { Parse(field) });
    }
}
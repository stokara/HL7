namespace HL7;

/// <summary>
///     Represents a CPT procedure code and description (used in FT1 and PR1).
/// </summary>
public sealed record CptProcedure(string Code, string Description) {
    public static CptProcedure Parse(Field field) {
        var code = field.HasComponents && field.Components!.Count > 0 ? field.Components[0].Value : field.Value;
        var desc = field.HasComponents && field.Components!.Count > 1 ? field.Components[1].Value : string.Empty;
        return new CptProcedure(code, desc);
    }
}
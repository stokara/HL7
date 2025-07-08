using NodaTime;

namespace HL7;

/// <summary>
///     AL1 - Patient Allergy Information Segment (HL7 v2.3.1)
/// </summary>
public sealed record AL1 : HL7Data<AL1> {
    public string SetId { get; }
    public string AllergyType { get; }
    public string AllergyCodeMnemonicDescription { get; }
    public string AllergySeverity { get; }
    public string AllergyReaction { get; }
    public Instant? IdentificationDate { get; }

    public AL1(Segment segment) : base(segment) {
        SetId = segment.GetFieldString(1);
        AllergyType = segment.GetFieldString(2);
        AllergyCodeMnemonicDescription = segment.GetFieldString(3);
        AllergySeverity = segment.GetFieldString(4);
        AllergyReaction = segment.GetFieldString(5);
        IdentificationDate = segment.GetFieldInstant(6);
    }
}
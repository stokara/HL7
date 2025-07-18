using NodaTime;

namespace HL7;

public sealed record TM : Hl7Date {
    public TM(Instant? dateTime) : base(dateTime) {
        Format = "HHmmss";
    }
}
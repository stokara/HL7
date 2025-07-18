using NodaTime;

namespace HL7;

public sealed record DTM : Hl7Date {
    public DTM(Instant? dateTime) : base(dateTime) {
        Format = "yyyyMMddHHmmss";
    }
}
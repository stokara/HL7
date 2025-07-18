using NodaTime;

namespace HL7;

public sealed record DT(Instant? Date) : Hl7Date(Date) { }
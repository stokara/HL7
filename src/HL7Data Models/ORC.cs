using NodaTime;

namespace HL7;

/// <summary>
///     ORC - Common Order Segment (HL7 v2.3.1)
/// </summary>
public sealed record ORC : HL7Data<ORC> {
    public string OrderControl { get; }
    public HL7Property<EntityIdentifier> PlacerOrderNumber { get; }
    public HL7Property<EntityIdentifier> FillerOrderNumber { get; }
    public HL7Property<EntityIdentifier> PlacerGroupNumber { get; }
    public string OrderStatus { get; }
    public string ResponseFlag { get; }
    public string QuantityTiming { get; }
    public string Parent { get; }
    public Instant? DateTimeOfTransaction { get; }
    public HL7Property<PersonName> EnteredBy { get; }
    public HL7Property<PersonName> VerifiedBy { get; }
    public HL7Property<PersonName> OrderingProvider { get; }
    public string EntererLocation { get; }
    public HL7Property<Phone> CallBackPhoneNumber { get; }
    public Instant? OrderEffectiveDateTime { get; }
    public string OrderControlCodeReason { get; }
    public string EnteringOrganization { get; }
    public string EnteringDevice { get; }
    public HL7Property<PersonName> ActionBy { get; }

    public ORC(Segment segment) : base(segment) {
        OrderControl = segment.GetFieldString(1);
        PlacerOrderNumber = EntityIdentifier.CreateHL7Property(segment, 2);
        FillerOrderNumber = EntityIdentifier.CreateHL7Property(segment, 3);
        PlacerGroupNumber = EntityIdentifier.CreateHL7Property(segment, 4);
        OrderStatus = segment.GetFieldString(5);
        ResponseFlag = segment.GetFieldString(6);
        QuantityTiming = segment.GetFieldString(7);
        Parent = segment.GetFieldString(8);
        DateTimeOfTransaction = segment.GetFieldInstant(9);
        EnteredBy = PersonName.CreateHL7Property(segment, 10);
        VerifiedBy = PersonName.CreateHL7Property(segment, 11);
        OrderingProvider = PersonName.CreateHL7Property(segment, 12);
        EntererLocation = segment.GetFieldString(13);
        CallBackPhoneNumber = Phone.CreateHL7Property(segment, 14);
        OrderEffectiveDateTime = segment.GetFieldInstant(15);
        OrderControlCodeReason = segment.GetFieldString(16);
        EnteringOrganization = segment.GetFieldString(17);
        EnteringDevice = segment.GetFieldString(18);
        ActionBy = PersonName.CreateHL7Property(segment, 19);
    }
}
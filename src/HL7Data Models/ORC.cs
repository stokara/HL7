namespace HL7;

/// <summary>
///     ORC - Common Order Segment (HL7 v2.3.1)
/// </summary>
public sealed record ORC : HL7Data<ORC> {
    public string OrderControl { get; }
    public string PlacerOrderNumber { get; }
    public string FillerOrderNumber { get; }
    public string PlacerGroupNumber { get; }
    public string OrderStatus { get; }
    public string ResponseFlag { get; }
    public string QuantityTiming { get; }
    public string Parent { get; }
    public string DateTimeOfTransaction { get; }
    public string EnteredBy { get; }
    public string VerifiedBy { get; }
    public string OrderingProvider { get; }
    public string EntererLocation { get; }
    public string CallBackPhoneNumber { get; }
    public string OrderEffectiveDateTime { get; }
    public string OrderControlCodeReason { get; }
    public string EnteringOrganization { get; }
    public string EnteringDevice { get; }
    public string ActionBy { get; }

    public ORC(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        OrderControl = cnt > 1 ? fields[1].Value : string.Empty;
        PlacerOrderNumber = cnt > 2 ? fields[2].Value : string.Empty;
        FillerOrderNumber = cnt > 3 ? fields[3].Value : string.Empty;
        PlacerGroupNumber = cnt > 4 ? fields[4].Value : string.Empty;
        OrderStatus = cnt > 5 ? fields[5].Value : string.Empty;
        ResponseFlag = cnt > 6 ? fields[6].Value : string.Empty;
        QuantityTiming = cnt > 7 ? fields[7].Value : string.Empty;
        Parent = cnt > 8 ? fields[8].Value : string.Empty;
        DateTimeOfTransaction = cnt > 9 ? fields[9].Value : string.Empty;
        EnteredBy = cnt > 10 ? fields[10].Value : string.Empty;
        VerifiedBy = cnt > 11 ? fields[11].Value : string.Empty;
        OrderingProvider = cnt > 12 ? fields[12].Value : string.Empty;
        EntererLocation = cnt > 13 ? fields[13].Value : string.Empty;
        CallBackPhoneNumber = cnt > 14 ? fields[14].Value : string.Empty;
        OrderEffectiveDateTime = cnt > 15 ? fields[15].Value : string.Empty;
        OrderControlCodeReason = cnt > 16 ? fields[16].Value : string.Empty;
        EnteringOrganization = cnt > 17 ? fields[17].Value : string.Empty;
        EnteringDevice = cnt > 18 ? fields[18].Value : string.Empty;
        ActionBy = cnt > 19 ? fields[19].Value : string.Empty;
    }
}
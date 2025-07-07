namespace HL7;

public sealed record FT1 : HL7Data<FT1> {
    public string SetId { get; private set; }
    public string TransactionDate { get; private set; }
    public string PostingDate { get; private set; }
    public string TransactionType { get; private set; }
    public string ProcedureCode { get; private set; }
    public string ProcedureDescription { get; private set; }
    public string Quantity { get; private set; }
    public string Amount { get; private set; }
    public string PerformingProvider { get; private set; }

    public FT1(Segment segment) : base(segment) {
        SetId = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty;
        TransactionDate = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;
        PostingDate = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty;
        TransactionType = segment.Fields.Count > 6 ? segment.Fields[6].Value : string.Empty;
        if (segment.Fields.Count > 7 && segment.Fields[7].HasComponents) {
            ProcedureCode = segment.Fields[7].Components![0].Value;
            ProcedureDescription = segment.Fields[7].Components![1].Value;
        } else {
            ProcedureCode = segment.Fields.Count > 7 ? segment.Fields[7].Value : string.Empty;
            ProcedureDescription = string.Empty;
        }

        Quantity = segment.Fields.Count > 8 ? segment.Fields[8].Value : string.Empty;
        Amount = segment.Fields.Count > 9 ? segment.Fields[9].Value : string.Empty;
        PerformingProvider = segment.Fields.Count > 12 ? segment.Fields[12].Value : string.Empty;
    }
}
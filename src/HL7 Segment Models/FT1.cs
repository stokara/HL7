using System.IO;

public sealed record FT1 {
    public string SetId { get; private set; }
    public string TransactionDate { get; private set; }
    public string PostingDate { get; private set; }
    public string TransactionType { get; private set; }
    public string ProcedureCode { get; private set; }
    public string ProcedureDescription { get; private set; }
    public string Quantity { get; private set; }
    public string Amount { get; private set; }
    public string PerformingProvider { get; private set; }

    private FT1() {
    }

    public static FT1 Load(Segment segment) {
        if (segment.Name != "FT1") throw new InvalidDataException($"Invalid Segment - FT1 data is in FT1 Segment, this is {segment.Name}");

        var newFt1 = new FT1 {
            SetId = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty,
            TransactionDate = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty,
            PostingDate = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty,
            TransactionType = segment.Fields.Count > 6 ? segment.Fields[6].Value : string.Empty,
            Quantity = segment.Fields.Count > 8 ? segment.Fields[8].Value : string.Empty,
            Amount = segment.Fields.Count > 9 ? segment.Fields[9].Value : string.Empty,
            PerformingProvider = segment.Fields.Count > 12 ? segment.Fields[12].Value : string.Empty
        };
        if (segment.Fields.Count > 7 && segment.Fields[7].HasComponents) {
            newFt1.ProcedureCode = segment.Fields[7].Components![0].Value;
            newFt1.ProcedureDescription = segment.Fields[7].Components![1].Value;
        } else {
            newFt1.ProcedureCode = segment.Fields.Count > 7 ? segment.Fields[7].Value : string.Empty;
            newFt1.ProcedureDescription = string.Empty;
        }

        return newFt1;
    }
}
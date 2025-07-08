using HL7.Elements;
using System.Collections.Generic;
using System.Linq;

namespace HL7;

public sealed record FT1 : HL7Data<FT1> {
    public string SetId { get; }
    public string TransactionDate { get; }
    public string PostingDate { get; }
    public string TransactionType { get; }
    public IReadOnlyList<CptProcedure> Procedures { get; }
    public string Quantity { get; }
    public string Amount { get; }
    public string PerformingProvider { get; }

    public FT1(Segment segment) : base(segment) {
        SetId = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty;
        TransactionDate = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;
        PostingDate = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty;
        TransactionType = segment.Fields.Count > 6 ? segment.Fields[6].Value : string.Empty;
        Procedures = segment.Fields.Count > 7
            ? segment.Fields[7].HasRepetitions
                ? [..segment.Fields[7].Repetitions!.Select(CptProcedure.Parse)]
                : [CptProcedure.Parse(segment.Fields[7])]
            : [];
        Quantity = segment.Fields.Count > 8 ? segment.Fields[8].Value : string.Empty;
        Amount = segment.Fields.Count > 9 ? segment.Fields[9].Value : string.Empty;
        PerformingProvider = segment.Fields.Count > 12 ? segment.Fields[12].Value : string.Empty;
    }
}
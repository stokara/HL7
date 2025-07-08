using System.Collections.Generic;
using System.Linq;
using NodaTime;

namespace HL7;

public sealed record FT1 : HL7Data<FT1> {
    public string SetId { get; }
    public Instant? TransactionDate { get; }
    public Instant? PostingDate { get; }
    public string TransactionType { get; }
    public IReadOnlyList<CptProcedure> Procedures { get; }
    public decimal? Quantity { get; }
    public decimal? Amount { get; }
    public string PerformingProvider { get; }

    public FT1(Segment segment) : base(segment) {
        SetId = segment.GetFieldString(1);
        TransactionDate = segment.GetFieldInstant(2);
        PostingDate = segment.GetFieldInstant(3);
        TransactionType = segment.GetFieldString(6);
        Procedures = segment.Fields.Count > 7
            ? segment.Fields[7].HasRepetitions
                ? segment.Fields[7].Repetitions!.Select(CptProcedure.Parse).ToArray()
                : [CptProcedure.Parse(segment.Fields[7])]
            : [];
        Quantity = segment.GetFieldDecimal(8);
        Amount = segment.GetFieldDecimal(9);
        PerformingProvider = segment.GetFieldString(13);
    }
}
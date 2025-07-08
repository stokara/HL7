using System.Collections.Generic;
using System.Linq;
using NodaTime;

namespace HL7;

/// <summary>
///     PR1 - Procedures Segment (HL7 v2.3.1)
/// </summary>
public sealed record PR1 : HL7Data<PR1> {
    public int? SetId { get; }
    public string ProcedureCodingMethod { get; }
    public IReadOnlyList<CptProcedure> Procedures { get; }
    public Instant? ProcedureDateTime { get; }
    public string ProcedureType { get; }
    public int? ProcedureMinutes { get; }
    public HL7Property<PersonName> Anesthesiologist { get; }
    public HL7Property<CodedElement> AnesthesiaCode { get; }
    public int? AnesthesiaMinutes { get; }
    public HL7Property<PersonName> Surgeon { get; }
    public HL7Property<PersonName> ProcedurePractitioner { get; }
    public HL7Property<CodedElement> ConsentCode { get; }
    public int? ProcedurePriority { get; }
    public HL7Property<CodedElement> AssociatedDiagnosisCode { get; }

    public PR1(Segment segment) : base(segment) {
        SetId = segment.GetFieldInt(1);
        ProcedureCodingMethod = segment.GetFieldString(2);
        Procedures = segment.Fields.Count > 3
            ? segment.Fields[3].HasRepetitions
                ? segment.Fields[3].Repetitions!.Select(CptProcedure.Parse).ToArray()
                : [CptProcedure.Parse(segment.Fields[3])]
            : [];
        ProcedureDateTime = segment.GetFieldInstant(5);
        ProcedureType = segment.GetFieldString(6);
        ProcedureMinutes = segment.GetFieldInt(7);
        Anesthesiologist = PersonName.CreateHL7Property(segment, 8);
        AnesthesiaCode = CodedElement.CreateHL7Property(segment, 9);
        AnesthesiaMinutes = segment.GetFieldInt(10);
        Surgeon = PersonName.CreateHL7Property(segment, 11);
        ProcedurePractitioner = PersonName.CreateHL7Property(segment, 12);
        ConsentCode = CodedElement.CreateHL7Property(segment, 13);
        ProcedurePriority = segment.GetFieldInt(14);
        AssociatedDiagnosisCode = CodedElement.CreateHL7Property(segment, 15);
    }
}
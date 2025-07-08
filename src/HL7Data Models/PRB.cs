using NodaTime;

namespace HL7;

/// <summary>
///     PRB - Problem Details Segment (HL7 v2.3.1)
/// </summary>
public sealed record PRB : HL7Data<PRB> {
    public string ActionCode { get; }
    public Instant? ActionDateTime { get; }
    public HL7Property<CodedElement> ProblemId { get; }
    public HL7Property<EntityIdentifier> ProblemInstanceId { get; }
    public HL7Property<EntityIdentifier> EpisodeOfCareId { get; }
    public int? ProblemListPriority { get; }
    public Instant? ProblemEstablishedDateTime { get; }
    public Instant? AnticipatedProblemResolutionDateTime { get; }
    public Instant? ActualProblemResolutionDateTime { get; }
    public HL7Property<CodedElement> ProblemClassification { get; }
    public HL7Property<CodedElement> ProblemManagementDiscipline { get; }
    public string ProblemPersistence { get; }
    public HL7Property<CodedElement> ProblemConfirmationStatus { get; }
    public HL7Property<CodedElement> ProblemLifeCycleStatus { get; }
    public Instant? ProblemLifeCycleStatusDateTime { get; }
    public Instant? ProblemDateOfOnset { get; }
    public string ProblemOnsetText { get; }
    public int? ProblemRanking { get; }
    public HL7Property<CodedElement> CertaintyOfProblem { get; }
    public decimal? ProbabilityOfProblem { get; }
    public string IndividualAwarenessOfProblem { get; }
    public string ProblemPrognosis { get; }
    public string IndividualAwarenessOfPrognosis { get; }
    public string FamilyAwarenessOfProblem { get; }
    public string FamilyAwarenessOfPrognosis { get; }
    public string SecuritySensitivity { get; }

    public PRB(Segment segment) : base(segment) {
        ActionCode = segment.GetFieldString(1);
        ActionDateTime = segment.GetFieldInstant(2);
        ProblemId = CodedElement.CreateHL7Property(segment, 3);
        ProblemInstanceId = EntityIdentifier.CreateHL7Property(segment, 4);
        EpisodeOfCareId = EntityIdentifier.CreateHL7Property(segment, 5);
        ProblemListPriority = segment.GetFieldInt(6);
        ProblemEstablishedDateTime = segment.GetFieldInstant(7);
        AnticipatedProblemResolutionDateTime = segment.GetFieldInstant(8);
        ActualProblemResolutionDateTime = segment.GetFieldInstant(9);
        ProblemClassification = CodedElement.CreateHL7Property(segment, 10);
        ProblemManagementDiscipline = CodedElement.CreateHL7Property(segment, 11);
        ProblemPersistence = segment.GetFieldString(12);
        ProblemConfirmationStatus = CodedElement.CreateHL7Property(segment, 13);
        ProblemLifeCycleStatus = CodedElement.CreateHL7Property(segment, 14);
        ProblemLifeCycleStatusDateTime = segment.GetFieldInstant(15);
        ProblemDateOfOnset = segment.GetFieldInstant(16);
        ProblemOnsetText = segment.GetFieldString(17);
        ProblemRanking = segment.GetFieldInt(18);
        CertaintyOfProblem = CodedElement.CreateHL7Property(segment, 19);
        ProbabilityOfProblem = segment.GetFieldDecimal(20);
        IndividualAwarenessOfProblem = segment.GetFieldString(21);
        ProblemPrognosis = segment.GetFieldString(22);
        IndividualAwarenessOfPrognosis = segment.GetFieldString(23);
        FamilyAwarenessOfProblem = segment.GetFieldString(24);
        FamilyAwarenessOfPrognosis = segment.GetFieldString(25);
        SecuritySensitivity = segment.GetFieldString(26);
    }
}
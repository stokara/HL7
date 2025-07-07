namespace HL7;

/// <summary>
///     PRB - Problem Details Segment (HL7 v2.3.1)
/// </summary>
public sealed record PRB : HL7Data<PRB> {
    public string ActionCode { get; }
    public string ActionDateTime { get; }
    public string ProblemId { get; }
    public string ProblemInstanceId { get; }
    public string EpisodeOfCareId { get; }
    public string ProblemListPriority { get; }
    public string ProblemEstablishedDateTime { get; }
    public string AnticipatedProblemResolutionDateTime { get; }
    public string ActualProblemResolutionDateTime { get; }
    public string ProblemClassification { get; }
    public string ProblemManagementDiscipline { get; }
    public string ProblemPersistence { get; }
    public string ProblemConfirmationStatus { get; }
    public string ProblemLifeCycleStatus { get; }
    public string ProblemLifeCycleStatusDateTime { get; }
    public string ProblemDateOfOnset { get; }
    public string ProblemOnsetText { get; }
    public string ProblemRanking { get; }
    public string CertaintyOfProblem { get; }
    public string ProbabilityOfProblem { get; }
    public string IndividualAwarenessOfProblem { get; }
    public string ProblemPrognosis { get; }
    public string IndividualAwarenessOfPrognosis { get; }
    public string FamilyAwarenessOfProblem { get; }
    public string FamilyAwarenessOfPrognosis { get; }
    public string SecuritySensitivity { get; }

    public PRB(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        ActionCode = cnt > 1 ? fields[1].Value : string.Empty;
        ActionDateTime = cnt > 2 ? fields[2].Value : string.Empty;
        ProblemId = cnt > 3 ? fields[3].Value : string.Empty;
        ProblemInstanceId = cnt > 4 ? fields[4].Value : string.Empty;
        EpisodeOfCareId = cnt > 5 ? fields[5].Value : string.Empty;
        ProblemListPriority = cnt > 6 ? fields[6].Value : string.Empty;
        ProblemEstablishedDateTime = cnt > 7 ? fields[7].Value : string.Empty;
        AnticipatedProblemResolutionDateTime = cnt > 8 ? fields[8].Value : string.Empty;
        ActualProblemResolutionDateTime = cnt > 9 ? fields[9].Value : string.Empty;
        ProblemClassification = cnt > 10 ? fields[10].Value : string.Empty;
        ProblemManagementDiscipline = cnt > 11 ? fields[11].Value : string.Empty;
        ProblemPersistence = cnt > 12 ? fields[12].Value : string.Empty;
        ProblemConfirmationStatus = cnt > 13 ? fields[13].Value : string.Empty;
        ProblemLifeCycleStatus = cnt > 14 ? fields[14].Value : string.Empty;
        ProblemLifeCycleStatusDateTime = cnt > 15 ? fields[15].Value : string.Empty;
        ProblemDateOfOnset = cnt > 16 ? fields[16].Value : string.Empty;
        ProblemOnsetText = cnt > 17 ? fields[17].Value : string.Empty;
        ProblemRanking = cnt > 18 ? fields[18].Value : string.Empty;
        CertaintyOfProblem = cnt > 19 ? fields[19].Value : string.Empty;
        ProbabilityOfProblem = cnt > 20 ? fields[20].Value : string.Empty;
        IndividualAwarenessOfProblem = cnt > 21 ? fields[21].Value : string.Empty;
        ProblemPrognosis = cnt > 22 ? fields[22].Value : string.Empty;
        IndividualAwarenessOfPrognosis = cnt > 23 ? fields[23].Value : string.Empty;
        FamilyAwarenessOfProblem = cnt > 24 ? fields[24].Value : string.Empty;
        FamilyAwarenessOfPrognosis = cnt > 25 ? fields[25].Value : string.Empty;
        SecuritySensitivity = cnt > 26 ? fields[26].Value : string.Empty;
    }
}
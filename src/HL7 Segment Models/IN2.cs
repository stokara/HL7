using System.IO;

public sealed record IN2 {
    public string SetId { get; private set; }
    public string InsurancePlanId { get; private set; }
    public string InsuranceCompanyId { get; private set; }
    public string InsuranceCompanyName { get; private set; }
    public string InsuranceCompanyAddress { get; private set; }
    public string InsuredsEmployeeId { get; private set; }
    public string InsuredsName { get; private set; }
    public string RelationshipToPatient { get; private set; }
    public string InsuredsDateOfBirth { get; private set; }
    public string InsuredsSex { get; private set; }
    public string InsuredsEmployerName { get; private set; }
    public string InsuredsSSN { get; private set; }

    private IN2() { }

    public static IN2 Load(Segment segment) {
        if (segment.Name != "IN2") throw new InvalidDataException($"Invalid Segment - Secondary Insurance Data is in IN2 Segment, this is {segment.Name}");

        return new IN2 {
            SetId = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty,
            InsurancePlanId = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty,
            InsuranceCompanyId = segment.Fields.Count > 3 ? segment.Fields[3].Value : string.Empty,
            InsuranceCompanyName = segment.Fields.Count > 4 ? segment.Fields[4].Value : string.Empty,
            InsuranceCompanyAddress = segment.Fields.Count > 5 ? segment.Fields[5].Value : string.Empty,
            InsuredsEmployeeId = segment.Fields.Count > 7 ? segment.Fields[7].Value : string.Empty,
            InsuredsName = segment.Fields.Count > 8 ? segment.Fields[8].Value : string.Empty,
            RelationshipToPatient = segment.Fields.Count > 9 ? segment.Fields[9].Value : string.Empty,
            InsuredsDateOfBirth = segment.Fields.Count > 10 ? segment.Fields[10].Value : string.Empty,
            InsuredsSex = segment.Fields.Count > 11 ? segment.Fields[11].Value : string.Empty,
            InsuredsEmployerName = segment.Fields.Count > 13 ? segment.Fields[13].Value : string.Empty,
            InsuredsSSN = segment.Fields.Count > 16 ? segment.Fields[16].Value : string.Empty
        };
    }
}
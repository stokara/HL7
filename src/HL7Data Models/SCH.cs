namespace HL7;

/// <summary>
///     SCH - Schedule Activity Information Segment (HL7 v2.3.1)
/// </summary>
public sealed record SCH : HL7Data<SCH> {
    public string PlacerAppointmentId { get; }
    public string FillerAppointmentId { get; }
    public string OccurrenceNumber { get; }
    public string PlacerGroupNumber { get; }
    public string ScheduleId { get; }
    public string EventReason { get; }
    public string AppointmentReason { get; }
    public string AppointmentType { get; }
    public string AppointmentDuration { get; }
    public string AppointmentDurationUnits { get; }
    public string AppointmentTimingQuantity { get; }
    public string PlacerContactPerson { get; }
    public string PlacerContactPhoneNumber { get; }
    public string PlacerContactAddress { get; }
    public string PlacerContactLocation { get; }
    public string FillerContactPerson { get; }
    public string FillerContactPhoneNumber { get; }
    public string FillerContactAddress { get; }
    public string FillerContactLocation { get; }
    public string EnteredByPerson { get; }
    public string EnteredByPhoneNumber { get; }
    public string EnteredByLocation { get; }
    public string ParentPlacerAppointmentId { get; }
    public string ParentFillerAppointmentId { get; }
    public string FillerStatusCode { get; }

    public SCH(Segment segment) : base(segment) {
        var fields = segment.Fields;
        var cnt = fields.Count;
        PlacerAppointmentId = cnt > 1 ? fields[1].Value : string.Empty;
        FillerAppointmentId = cnt > 2 ? fields[2].Value : string.Empty;
        OccurrenceNumber = cnt > 3 ? fields[3].Value : string.Empty;
        PlacerGroupNumber = cnt > 4 ? fields[4].Value : string.Empty;
        ScheduleId = cnt > 5 ? fields[5].Value : string.Empty;
        EventReason = cnt > 6 ? fields[6].Value : string.Empty;
        AppointmentReason = cnt > 7 ? fields[7].Value : string.Empty;
        AppointmentType = cnt > 8 ? fields[8].Value : string.Empty;
        AppointmentDuration = cnt > 9 ? fields[9].Value : string.Empty;
        AppointmentDurationUnits = cnt > 10 ? fields[10].Value : string.Empty;
        AppointmentTimingQuantity = cnt > 11 ? fields[11].Value : string.Empty;
        PlacerContactPerson = cnt > 12 ? fields[12].Value : string.Empty;
        PlacerContactPhoneNumber = cnt > 13 ? fields[13].Value : string.Empty;
        PlacerContactAddress = cnt > 14 ? fields[14].Value : string.Empty;
        PlacerContactLocation = cnt > 15 ? fields[15].Value : string.Empty;
        FillerContactPerson = cnt > 16 ? fields[16].Value : string.Empty;
        FillerContactPhoneNumber = cnt > 17 ? fields[17].Value : string.Empty;
        FillerContactAddress = cnt > 18 ? fields[18].Value : string.Empty;
        FillerContactLocation = cnt > 19 ? fields[19].Value : string.Empty;
        EnteredByPerson = cnt > 20 ? fields[20].Value : string.Empty;
        EnteredByPhoneNumber = cnt > 21 ? fields[21].Value : string.Empty;
        EnteredByLocation = cnt > 22 ? fields[22].Value : string.Empty;
        ParentPlacerAppointmentId = cnt > 23 ? fields[23].Value : string.Empty;
        ParentFillerAppointmentId = cnt > 24 ? fields[24].Value : string.Empty;
        FillerStatusCode = cnt > 25 ? fields[25].Value : string.Empty;
    }
}
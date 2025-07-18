using System;
using System.Globalization;
using System.Text.RegularExpressions;
using NodaTime;

namespace HL7;

public static class Hl7DateParser {
    private static readonly string Hl7DateRegex =
        @"^\s*((?:18|19|20)[0-9]{2})(?:(1[0-2]|0[1-9])(?:(3[0-1]|[1-2][0-9]|0[1-9])(?:([0-1][0-9]|2[0-3])(?:([0-5][0-9])(?:([0-5][0-9](?:\.[0-9]{1,4})?)?)?)?)?)?)?(?:([+-][0-1][0-9]|[+-]2[0-3])([0-5][0-9]))?\s*$";

    private record Hl7DateParts(
        int Year,
        int Month,
        int Day,
        int Hours,
        int Minutes,
        int Seconds,
        int Milliseconds,
        int TzHours,
        int TzMinutes
    );

    private static bool tryParseHl7DateParts(string dateTimeString, out Hl7DateParts? parts) {
        var matches = Regex.Matches(dateTimeString, Hl7DateRegex, RegexOptions.Singleline);

        if (matches.Count != 1) {
            parts = null;
            return false;
        }

        var groups = matches[0].Groups;
        var year = int.Parse(groups[1].Value, CultureInfo.InvariantCulture);
        var month = groups[2].Success ? int.Parse(groups[2].Value, CultureInfo.InvariantCulture) : 1;
        var day = groups[3].Success ? int.Parse(groups[3].Value, CultureInfo.InvariantCulture) : 1;
        var hours = groups[4].Success ? int.Parse(groups[4].Value, CultureInfo.InvariantCulture) : 0;
        var mins = groups[5].Success ? int.Parse(groups[5].Value, CultureInfo.InvariantCulture) : 0;

        var fsecs = groups[6].Success ? float.Parse(groups[6].Value, CultureInfo.InvariantCulture) : 0;
        var secs = (int)Math.Truncate(fsecs);
        var msecs = (int)Math.Truncate(fsecs * 1000) % 1000;

        var tzh = groups[7].Success ? int.Parse(groups[7].Value, CultureInfo.InvariantCulture) : 0;
        var tzm = groups[8].Success ? int.Parse(groups[8].Value, CultureInfo.InvariantCulture) : 0;

        parts = new Hl7DateParts(year, month, day, hours, mins, secs, msecs, tzh, tzm);
        return true;
    }

    public static OffsetDateTime? ParseOffsetDateTime(string dateTimeString, bool throwException = false) {
        try {
            if (!tryParseHl7DateParts(dateTimeString, out var parts)) throw new FormatException("Invalid date format");

            var offset = Offset.FromHoursAndMinutes(parts!.TzHours, parts.TzMinutes);
            var localDateTime = new LocalDateTime(parts.Year, parts.Month, parts.Day, parts.Hours, parts.Minutes, parts.Seconds, parts.Milliseconds);
            return new OffsetDateTime(localDateTime, offset);
        } catch {
            if (throwException) throw;

            return null;
        }
    }

    public static Instant? ParseInstant(string? dateTimeString, bool throwException = false) {
        if (dateTimeString is null) return null;
        var odt = ParseOffsetDateTime(dateTimeString, throwException);
        return odt?.ToInstant();
    }

    public static string GetFormat(string dateTimeString) {
        var len= dateTimeString.Length;
        var format = "yyyy";
        if (len >= 6) format += "MM";
        if (len >= 8) format += "dd";
        if (len >= 10) format += "HH";
        if (len >= 12) format += "mm";
        if (len >= 14) format += "ss";
        var fracMatch = Regex.Match(dateTimeString, @"\.(\d{1,4})");
        if (fracMatch.Success) format += ".fff";
        if (dateTimeString.Contains('+') || dateTimeString.Contains('-')) format += "zzz";
        return  format;
    }
}
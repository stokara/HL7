using System;
using HL7;
using NodaTime;
using Xunit;

namespace HL7test;

public class DateTimeTimeTests {
    [Theory]
    [InlineData("   20151231234500.1234+1800   ")]
    [InlineData("20151231234500.1234+1800")]
    [InlineData("20151231234500.1234-1800")]
    [InlineData("20151231234500.1234")]
    [InlineData("20151231234500.12")]
    [InlineData("20151231234500")]
    [InlineData("201512312345")]
    [InlineData("2015123123")]
    [InlineData("20151231")]
    [InlineData("201512")]
    [InlineData("2015")]
    public void ParseOffsetDateTime_Smoke_Positive(string dateTimeString) {
        var odt = Hl7DateParser.ParseOffsetDateTime(dateTimeString);
        Assert.NotNull(odt);
    }

    [Theory]
    [InlineData("   20151231234500.1234+2358   ")] // Out of range for NodaTime
    [InlineData("20151231234500.1234+2358")]
    [InlineData("20151231234500.1234-2358")]
    [InlineData("20151231234500.1234+23581")]
    [InlineData("20151231234500.1234+23")]
    [InlineData("20151231234500.12345")]
    [InlineData("20151231234500.")]
    [InlineData("2015123123450")]
    [InlineData("20151231234")]
    [InlineData("201512312")]
    [InlineData("2015123")]
    [InlineData("20151")]
    [InlineData("201")]
    public void ParseOffsetDateTime_Smoke_Negative(string dateTimeString) {
        var odt = Hl7DateParser.ParseOffsetDateTime(dateTimeString);
        Assert.Null(odt);
    }

    [Fact]
    public void ParseOffsetDateTime_Correctness() {
        var odt = Hl7DateParser.ParseOffsetDateTime("20151231234500.1234-1800");
        var expected = new LocalDateTime(2015, 12, 31, 23, 45, 00, 123);
        Assert.Equal(expected, odt.Value.LocalDateTime);
        Assert.Equal(Offset.FromHoursAndMinutes(-18, 0), odt.Value.Offset);
    }

    [Fact]
    public void ParseOffsetDateTime_Correctness_WithPositiveOffset() {
        var odt = Hl7DateParser.ParseOffsetDateTime("20151231234500.1234+1800");
        var expected = new LocalDateTime(2015, 12, 31, 23, 45, 00, 123);
        Assert.Equal(expected, odt.Value.LocalDateTime);
        Assert.Equal(Offset.FromHoursAndMinutes(18, 0), odt.Value.Offset);
    }

    [Fact]
    public void ParseOffsetDateTime_WithException() {
        Assert.Throws<FormatException>(() => Hl7DateParser.ParseOffsetDateTime("201", true));
    }

    [Theory]
    [InlineData("18151231")]
    [InlineData("19151231")]
    [InlineData("20151231")]
    public void ParseOffsetDateTime_Year(string dateTimeString) {
        var odt = Hl7DateParser.ParseOffsetDateTime(dateTimeString);
        Assert.NotNull(odt);
    }

    [Theory]
    [InlineData("1701231")]
    [InlineData("16151231")]
    [InlineData("00001231")]
    public void ParseOffsetDateTime_Year_Negative(string dateTimeString) {
        var odt = Hl7DateParser.ParseOffsetDateTime(dateTimeString);
        Assert.Null(odt);
    }

    [Fact]
    public void ParseOffsetDateTime_OffsetOutOfRange() {
        Assert.Null(Hl7DateParser.ParseOffsetDateTime("20151231234500.1234+1900"));
    }
}
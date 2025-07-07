using System.IO;
using HL7;
using Xunit;

namespace HL7test;

public class HL7Test {
    private readonly string HL7_ORM;
    private readonly string HL7_ADT;

    public HL7Test() {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Sample Files");
        this.HL7_ORM = File.ReadAllText(Path.Combine(path, "Sample-ORM.txt"));
        this.HL7_ADT = File.ReadAllText(Path.Combine(path, "Sample-ADT.txt"));
    }

    [Fact]
    public void SmokeTest() {
        var message = Message.Parse(this.HL7_ORM);
        Assert.NotNull(message);
    }

    [Fact]
    public void ParseTest1() {
        var message = Message.Parse(this.HL7_ORM);
        Assert.NotNull(message);
    }

    [Fact]
    public void ParseTest2() {
        var message = Message.Parse(this.HL7_ADT);
        Assert.NotNull(message);
    }

    [Fact]
    public void ReadSegmentTest() {
        var message = Message.Parse(this.HL7_ORM);
        Assert.NotNull(message.Segments[0]);
    }

    [Fact]
    public void ReadFieldTest() {
        var message = Message.Parse(this.HL7_ADT);
        var mshSegment = message.Segments[0];
        var msh9 = mshSegment.Fields[8].Value;
        Assert.Equal("ADT^O01", msh9);
    }
}
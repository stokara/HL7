using System.IO;
using HL7;
using Xunit;

namespace HL7test;

public class AckNackTests {
    private readonly string HL7_ORM;
    private readonly string HL7_ADT;

    public AckNackTests() {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Sample Files") + "\\";
        this.HL7_ORM = File.ReadAllText(path + "Sample-ORM.txt");
        this.HL7_ADT = File.ReadAllText(path + "Sample-ADT.txt");
    }

    [Fact]
    public void GetAckTest() {
        var message = Message.Parse(this.HL7_ADT);
        Assert.NotNull(message);
        // TODO: Update GetValue, GetACK, etc. to use new API
    }

    [Fact]
    public void GetNackTest() {
        var message = Message.Parse(this.HL7_ADT);
        Assert.NotNull(message);
        // TODO: Update GetNACK, GetValue, etc. to use new API
    }

    [Fact]
    public void GenerateAckNoEscapeDelimiterTest() {
        var sampleMessage = "MSH|^~\\&|EPIC||||20191107134803|ALEVIB01|ORM^O01|23|T|2.3|||||||||||";
        sampleMessage = $"{sampleMessage}\nPID|1||MRN_123^^^IDX^MRN||Smith F S R E T^John||19600101|M";
        var message = Message.Parse(sampleMessage);
        Assert.NotNull(message);
    }
}
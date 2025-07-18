using System.IO;
using HL7;
using Xunit;

namespace HL7test;

public class AckNackTests {

    [Fact]
    public void GenerateAckNoEscapeDelimiterTest() {
        var sampleMessage = "MSH|^~\\&|EPIC||||20191107134803|ALEVIB01|ORM^O01|23|T|2.3|||||||||||";
        sampleMessage = $"{sampleMessage}\nPID|1||MRN_123^^^IDX^MRN||Smith F S R E T^John||19600101|M";
        var message = Message.Parse(sampleMessage);
        Assert.NotNull(message);
    }
}
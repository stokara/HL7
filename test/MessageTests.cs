using HL7;
using Xunit;

namespace HL7test;

public class MessageTests {
    [Fact]
    public void LoadHL7Message_ReturnsTrue_AndPopulatesRecords_OnValidMessage() {
        // Minimal valid HL7 message with two segments of the same type (e.g., FT1)
        var message = """
                      MSH|^~\&|App|Fac|App|Fac|202501010101||ADT^A01|123|P|2.5
                      FT1|1|20250101|20250101|||CG|1234^ProcedureDesc|1|100|USD||||Provider1
                      FT1|2|20250102|20250102|||CG|5678^AnotherProc|2|200|USD||||Provider2
                      """;

        var result = HL7Message.TryCreate(message, out var hl7Message);

        Assert.True(result);
        Assert.True(hl7Message.HL7Records.ContainsKey(typeof(FT1)));
        var ft1List = hl7Message.HL7Records[typeof(FT1)];
        Assert.Equal(2, ft1List.Count);

        var ft1_1 = (FT1)ft1List[0];
        Assert.Equal("1", ft1_1.SetId);
        Assert.Equal("1234", ft1_1.ProcedureCode);
        Assert.Equal("ProcedureDesc", ft1_1.ProcedureDescription);

        var ft1_2 = (FT1)ft1List[1];
        Assert.Equal("2", ft1_2.SetId);
        Assert.Equal("5678", ft1_2.ProcedureCode);
        Assert.Equal("AnotherProc", ft1_2.ProcedureDescription);
    }

    [Fact]
    public void LoadHL7Message_ReturnsFalse_OnInvalidMessage() {
        // Invalid HL7 message (missing MSH)
        const string message = "FT1|1|20250101|20250101|||CG|1234^ProcedureDesc|1|100|USD||||Provider1";

        var result = HL7Message.TryCreate(message, out var hl7Message);

        Assert.False(result);
        Assert.Null(hl7Message);
    }

    [Fact]
    public void RetrieveMSH_Segment_Success() {
        var message = """
                      MSH|^~\&|App|Fac|App|Fac|202501010101||ADT^A01|123|P|2.5
                      FT1|1|20250101|20250101|||CG|1234^ProcedureDesc|1|100|USD||||Provider1
                      """;

        var result = HL7Message.TryCreate(message, out var hl7Message);

        var msh = hl7Message.MSH;
        Assert.Equal("App", msh.SendingApplication);
        Assert.Equal("Fac", msh.SendingFacility);
        Assert.Equal("ADT_A01", msh.MessageType);
        Assert.Equal("123", msh.MessageControlId);
        Assert.Equal("2.5", msh.VersionId);
    }
}
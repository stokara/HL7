using HL7;
using System.IO;
using Xunit;

namespace HL7test;

public class MessageReadTests {
    [Fact]
    public void LoadHL7Message_ReturnsTrue_AndPopulatesRecords_OnValidMessage() {
        // Read HL7 message from sample file
        var message = File.ReadAllText("Sample Files/DFT-P03 Charge.txt");

        var result = Hl7Message.TryCreate(message, out var hl7Message);
        Assert.True(result);
        var ft1List = hl7Message!.GetHl7Segments<FT1>();
        Assert.NotEmpty(ft1List);
    }

    [Fact]
    public void LoadHL7Message_ReturnsFalse_OnInvalidMessage() {
        // Invalid HL7 message (missing MSH)
        const string message = "FT1|1|20250101|20250101|||CG|1234^ProcedureDesc|1|100|USD||||Provider1";

        Assert.Throws<Hl7Exception>(() => Hl7Message.Create(message));
    }

    [Fact]
    public void RetrieveMSH_Segment_Success() {
        var message = """
                      MSH|^~\&|Healthmatics|Healthmatics EHR|Ntierprise|Ntierprise Clinic|20190416084748||DFT^P03|1477-3|P|2.3|||NE|NE
                      FT1|1|E8866||20190416110000|20190416110000|CG||||1||||||^^^MainOffi|||J11.1^INFLUENZA WITH OTHER RESPIRATORY MANIFESTATIONS^I10~487.1^INFLUENZA WITH OTHER RESPIRATORY MANIFESTATIONS^I9~J03.90^INFLUENZA WITH OTHER RESPIRATORY MANIFESTATIONS^I10~J40^BRONCHITIS, NOT SPECIFIED AS ACUTE OR CHRONIC^I10~490^BRONCHITIS, NOT SPECIFIED AS ACUTE OR CHRONIC^I9|TM^Manning^Terry^^^^^^&7654321&UPIN|Manning^Manning^Terry^^^^^^&7654321&UPIN||||99214^OFFICE OUTPATIENT VISIT 25 MINUTES
                      """;

        var result = Hl7Message.TryCreate(message, out var hl7Message);

        var msh = hl7Message.MSH;
        Assert.Equal("Healthmatics", msh.SendingApplication?.StringValue);
        Assert.Equal("Healthmatics EHR", msh.SendingFacility?.StringValue);
        Assert.Equal("DFT^P03", msh.MessageType.StringValue);
        Assert.Equal("1477-3", msh.MessageControlID.StringValue);
        Assert.Equal("2.3", msh.VersionID.StringValue);
    }
}
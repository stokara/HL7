using HL7;
using System.IO;
using System.Linq;
using Xunit;

namespace HL7test;

public class MessageTests {
    [Fact]
    public void LoadHL7Message_ReturnsTrue_AndPopulatesRecords_OnValidMessage() {
        // Read HL7 message from sample file
        var message = File.ReadAllText("Sample Files/DFT-P03 Charge.txt");

        var result = HL7Message.TryCreate(message, out var hl7Message);

        Assert.True(result);
        Assert.True(hl7Message.HL7Records.ContainsKey(typeof(FT1)));
        var ft1List = hl7Message.HL7Records[typeof(FT1)];
        Assert.NotEmpty(ft1List);
        var ft1_1 = (FT1)ft1List[0];
        Assert.NotNull(ft1_1);
        // Optionally, add more asserts based on the sample file content
    }

    [Fact]
    public void LoadHL7Message_ReturnsFalse_OnInvalidMessage() {
        // Invalid HL7 message (missing MSH)
        const string message = "FT1|1|20250101|20250101|||CG|1234^ProcedureDesc|1|100|USD||||Provider1";

        Assert.Throws<Hl7Exception>(() => HL7Message.TryCreate(message, out var hl7Message));
    }

    [Fact]
    public void RetrieveMSH_Segment_Success() {
        var message = """
                      MSH|^~\&|Healthmatics|Healthmatics EHR|Ntierprise|Ntierprise Clinic|20190416084748||DFT^P03|1477-3|P|2.3|||NE|NE                      FT1|1|E8866||20190416110000|20190416110000|CG||||1||||||^^^MainOffi|||J11.1^INFLUENZA WITH OTHER RESPIRATORY MANIFESTATIONS^I10~487.1^INFLUENZA WITH OTHER RESPIRATORY MANIFESTATIONS^I9~J03.90^INFLUENZA WITH OTHER RESPIRATORY MANIFESTATIONS^I10~J40^BRONCHITIS, NOT SPECIFIED AS ACUTE OR CHRONIC^I10~490^BRONCHITIS, NOT SPECIFIED AS ACUTE OR CHRONIC^I9|TM^Manning^Terry^^^^^^&7654321&UPIN|Manning^Manning^Terry^^^^^^&7654321&UPIN||||99214^OFFICE OUTPATIENT VISIT 25 MINUTES
                      """;

        var result = HL7Message.TryCreate(message, out var hl7Message);

        var msh = hl7Message.MSH;
        Assert.Equal("Healthmatics", msh.SendingApplication);
        Assert.Equal("Healthmatics EHR", msh.SendingFacility);
        Assert.Equal("DFT_P03", msh.MessageType);
        Assert.Equal("1477-3", msh.MessageControlId);
        Assert.Equal("2.3", msh.VersionId);
    }
}
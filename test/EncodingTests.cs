using System.Diagnostics.CodeAnalysis;
using System.Linq;
using HL7;
using Xunit;

namespace HL7test;

public class EncodingTests {
    private readonly Hl7Encoding defaultEncoder = new(
        fieldDelimiter: '|',
        componentDelimiter: '^',
        repeatDelimiter: '~',
        escapeCharacter: '\\',
        subComponentDelimiter: '&'
    );
    
    [Fact]
    public void EncodeDecode_RoundTripAscii() {
        var input = "ABC|DEF^GHI~JKL\\MNO&PQR";
        var encoded = defaultEncoder.Encode(input);
        var decoded = defaultEncoder.Decode(encoded);
        Assert.Equal(input, decoded);
    }

    [Fact]
    public void EncodeDecode_RoundTripNonAscii() {
        var input = "Täglich 1 Tablette oral einnehmen";
        var encoded = defaultEncoder.Encode(input);
        var decoded = defaultEncoder.Decode(encoded);
        Assert.Equal(input, decoded);
    }

    [Fact]
    public void EncodeDecode_RoundTripWithHexEscape() {
        var input = "Line1\r\nLine2";
        var encoded = defaultEncoder.Encode(input);
        Assert.Contains("\\X0D\\", encoded);
        Assert.Contains("\\X0A\\", encoded);
        var decoded = defaultEncoder.Decode(encoded);
        Assert.Equal(input, decoded);
    }

    [Fact]
    public void Encode_SpecialDelimiters() {
        var input = "A|B^C~D\\E&F";
        var encoded = defaultEncoder.Encode(input);
        Assert.Contains("\\F\\", encoded);
        Assert.Contains("\\S\\", encoded);
        Assert.Contains("\\R\\", encoded);
        Assert.Contains("\\E\\", encoded);
        Assert.Contains("\\T\\", encoded);
    }

    [Fact]
    public void Decode_ExistingEscapeSequences() {
        var input = @"ABC\F\DEF\S\GHI\R\JKL\E\MNO\T\PQR";
        var expected = "ABC|DEF^GHI~JKL\\MNO&PQR";
        var decoded = defaultEncoder.Decode(input);
        Assert.Equal(expected, decoded);
    }

    [Fact]
    public void Encode_SkipExistingEscapeSequences() {
        var input = @"ABC\F\DEF";
        var encoded = defaultEncoder.Encode(input);
        Assert.Contains("\\F\\", encoded);
    }

    [Fact]
    public void TextNotRequiringEncodingShouldBeUnchanged() {
        var enc = defaultEncoder.Encode("<1");
        Assert.Equal("<1", enc);
    }

    [Fact]
    public void MessageWithDoubleNewlineTest() {
        const string sampleMessage = "MSH|^~\\&|SA|SF|RA|RF|20110613083617||ADT^A04|123|P|2.7||||\n\nEVN|A04|20110613083617||\r\n";
        var message = Message.Parse(sampleMessage);
        Assert.Equal(2, message.Segments.Count);
    }

    [Fact]
    public void CustomDelimiterTest() {
        var message = Message.Parse("MSH124531FIRST1SECOND1THIRD1FOURTH1FIFTH1ORU2R05F5SIXTH1ADT2A081T1.81VERSION||\r\n");
        var result = message.SerializeMessage();

        Assert.Equal("MSH124531FIRST1SECOND1", result[..22]);
    }

    [Fact]
    public void SegmentParse_StandardDelimiters() {
        var encoding = new Hl7Encoding('|', '^', '~', '\\', '&');
        var segmentStr = "PID|1|12345|DOE^JOHN";
        var segment = Segment.Parse(encoding, segmentStr);

        Assert.Equal("PID", segment.Name);
        Assert.Equal(4, segment.Fields.Count);
        Assert.Equal("1", segment.Fields[1].StringValue);
        Assert.Equal("12345", segment.Fields[2].StringValue);
        Assert.Equal("DOE^JOHN", segment.Fields[3].StringValue);
    }

    [Fact]
    public void SegmentParse_NonStandardDelimiters() {
        var encoding = new Hl7Encoding('!', '@', '#', '$', '%');
        var segmentStr = "ZZZ!A!B@C$D%E";
        var segment = Segment.Parse(encoding, segmentStr);

        Assert.Equal("ZZZ", segment.Name);
        Assert.Equal(3, segment.Fields.Count);
        Assert.Equal("A", segment.Fields[1].StringValue);
        Assert.Equal("B@C$D%E", segment.Fields[2].StringValue);
    }

    [Fact]
    public void SegmentParse_EscapedDelimiter() {
        var encoding = new Hl7Encoding('|', '^', '~', '\\', '&');
        var segmentStr = @"OBX|1|TX|Some\F\StringValue|End";
        var segment = Segment.Parse(encoding, segmentStr);

        Assert.Equal("OBX", segment.Name);
        Assert.Equal(5, segment.Fields.Count);
        Assert.Equal(@"Some\F\StringValue", segment.Fields[3].StringValue);
        Assert.Equal("End", segment.Fields[4].StringValue);
    }

    [Fact]
    public void SegmentParse_MSH_WithStandardDelimiters() {
        var segmentStr = @"MSH|^~\&|SendingApp|SendingFac|ReceivingApp|ReceivingFac|202407021200||ADT^A01|123456|P|2.5|\r\n";
        var result = Segment.ParseMSH(segmentStr);

        var segment = result.mshSegment;
        Assert.Equal("MSH", segment.Name);
        Assert.Equal("|^~\\&", segment.Fields[1].StringValue);
        Assert.Equal("SendingApp", segment.Fields[2].StringValue);
        Assert.Equal("ReceivingApp", segment.Fields[4].StringValue);
        Assert.Equal("ADT^A01", segment.Fields[8].StringValue);
        Assert.Equal("2.5", segment.Fields[11].StringValue);
    }

    [Fact]
    public void SegmentParse_MSH_WithNonStandardDelimiters() {
        var segmentStr = @"MSH!@#$%!App1!Fac1!App2!Fac2!202507021200!!ADT@A01!654321!P!2.8!\r\n";
        var result = Segment.ParseMSH(segmentStr);

        Assert.Equal("MSH", result.mshSegment.Name);
        Assert.Equal("!@#$%", result.mshSegment.Fields[1].StringValue);
        Assert.Equal("App1", result.mshSegment.Fields[2].StringValue);
        Assert.Equal("App2", result.mshSegment.Fields[4].StringValue);
        Assert.Equal("ADT@A01", result.mshSegment.Fields[8].StringValue);
        Assert.Equal("2.8", result.mshSegment.Fields[11].StringValue);
    }

    [Fact]
    public void FieldParse_SimpleValue() {
        var encoding = new Hl7Encoding('|', '^', '~', '\\', '&');
        var value = "SIMPLE";
        var field = Field.Parse(encoding, value);
        Assert.Equal("SIMPLE", field.StringValue);
        Assert.False(field.IsComposite);
        Assert.False(field.HasRepetitions);
    }

    [Fact]
    public void FieldParse_WithComponents() {
        var encoding = new Hl7Encoding('|', '^', '~', '\\', '&');
        const string value = "DOE^JOHN^A";
        var field = Field.Parse(encoding, value);
        Assert.Equal("DOE^JOHN^A", field.StringValue);
        Assert.True(field.IsComposite);
        Assert.False(field.HasRepetitions);
        Assert.Equal(3, field.Components?.Count);
        Assert.Equal("DOE", field.Components![0].Value);
        Assert.Equal("JOHN", field.Components[1].Value);
        Assert.Equal("A", field.Components[2].Value);
    }

    [Fact]
    public void FieldParse_WithRepetitions() {
        var encoding = new Hl7Encoding('|', '^', '~', '\\', '&');
        var value = "A~B~C";
        var field = Field.Parse(encoding, value);
        Assert.Equal("A~B~C", field.StringValue);
        Assert.False(field.IsComposite);
        Assert.True(field.HasRepetitions);
        Assert.Equal(3, field.Repetitions?.Count);
        Assert.Equal("A", field.Repetitions![0].StringValue);
        Assert.Equal("B", field.Repetitions[1].StringValue);
        Assert.Equal("C", field.Repetitions[2].StringValue);
    }

    [Fact]
    public void FieldParse_WithComponentsAndRepetitions() {
        var encoding = new Hl7Encoding('|', '^', '~', '\\', '&');
        const string value = "A^B~C^D";
        var field = Field.Parse(encoding, value);
        Assert.Equal("A^B~C^D", field.StringValue);
        Assert.True(field.HasRepetitions);
        Assert.Equal(2, field.Repetitions?.Count);
        Assert.Equal("A^B", field.Repetitions![0].StringValue);
        Assert.Equal("C^D", field.Repetitions[1].StringValue);
        Assert.True(field.Repetitions[0].IsComposite);
        Assert.Equal("A", field.Repetitions[0].Components![0].Value);
        Assert.Equal("B", field.Repetitions[0].Components[1].Value);
    }

    [Fact]
    public void FieldParse_WithEscapedDelimiter() {
        var encoding = new Hl7Encoding('|', '^', '~', '\\', '&');
        var value = @"A\F\B";
        var field = Field.Parse(encoding, value);
        Assert.Equal(@"A\F\B", field.StringValue);
        Assert.False(field.IsComposite);
        Assert.False(field.HasRepetitions);
    }

    [Fact]
    public void FieldParse_CustomDelimiters() {
        var encoding = new Hl7Encoding('!', '@', '#', '$', '%');
        var value = "A@B@C";
        var field = Field.Parse(encoding, value);
        Assert.Equal("A@B@C", field.StringValue);
        Assert.True(field.IsComposite);
        Assert.Equal(3, field.Components!.Count);
        Assert.Equal("A", field.Components[0].Value);
        Assert.Equal("B", field.Components[1].Value);
        Assert.Equal("C", field.Components[2].Value);
    }

    [Fact]
    public void MessageRoundTrip_Is_Equal() {
        var sampleMessage =
            """
            MSH|^~\&|ATHENANET|18802555^Orthopaedic Sample Org|Aspyra - 18802555|13274090^ORTHOPAEDIC INSTITUTE|20241119113500||ORM^O01|57492555M18802|P|2.5.1||||||||
            PID||500036547^^^Enterprise ID||500036547^^^Patient ID|JOHN^DOE^||20050904|M||2106-3|1380 SAMPLE STREET^\X0A\^NEW YORK^NY^55755-5055||(555)261-2203|||S||^^^||||2186-5||||||||
            PV1||O|80D18802^^^SAMPLE ORTHO URGENT CARE||||1905555652^JANE^D^DOE||||||||||1037^ABCDE8|||||||||||||||||||||||||||20241119||||||||
            """;
        var message = Message.Parse(sampleMessage);
        var str = message.SerializeMessage();
        var message2 = Message.Parse(str);
        
        for (var i = 0; i < message.Segments.Count; i++) {
            var seg1 = message.Segments[i];
            var seg2 = message2.Segments[i];
            Assert.Equal(seg1.Fields.Count, seg2.Fields.Count);
            for (int j = 0; j < seg1.Fields.Count; j++) {
                Assert.Equal(seg1.Fields[j].StringValue, seg2.Fields[j].StringValue);
            }
            Assert.Equal(seg1.Name, seg2.Name);
        }
    }


    [Fact]
    public void LinqQueryFindsMessageValue() {
        var sampleMessage = """
                            MSH|^~\&|Main_HIS|XYZ_HOSPITAL|iFW|ABC_Lab|20160915003015||ACK|9B38584D|P|2.6.1|
                            MSA|AA|9B38584D|\E\T\E\
                            """;
        
        var message = Message.Parse(sampleMessage);
        var msa = message.Segments.FirstOrDefault(s => s.Name == "MSA");
        Assert.NotNull(msa);
        Assert.Equal(@"\E\T\E\", msa.Fields[3].StringValue);
    }


    [Fact]
    public void TrailingFieldDelimiterProducesEmptyField() { 
        var sampleMessage = """
                            MSH|^~\&|Main_HIS|XYZ_HOSPITAL|iFW|ABC_Lab|20160915003015||ACK|9B38584D|P|2.6.1|
                            MSA|FIRST|SECOND|THIRD|
                            """;

        var message = Message.Parse(sampleMessage);
        var msa = message.Segments.FirstOrDefault(s => s.Name == "MSA");
        Assert.NotNull(msa);
        Assert.Equal(string.Empty, msa.Fields[4].StringValue);
    }

    [Fact]
    public void EncodeDecode_HexEscape_Newline() {
        var encoding = new Hl7Encoding('|', '^', '~', '\\', '&');
        var input = "1380 SAMPLE STREET^\n^NEW YORK^NY^55755-5055";
        var encoded = encoding.Encode(input);
        Assert.Contains("\\X0A\\", encoded);
        var decoded = encoding.Decode(encoded);
        Assert.Equal(input, decoded);
    }

    [Fact]
    public void EncodeDecode_HexEscape_OA() {
        var encoding = new Hl7Encoding('|', '^', '~', '\\', '&');
        var input = @"1380 SAMPLE STREET^\X0A^NEW YORK^NY^55755-5055";
        var encoded = encoding.Encode(input);
        Assert.Contains("\\X0A\\", encoded);
        var decoded = encoding.Decode(encoded);
        Assert.Equal(input, decoded);
    }

    [Fact]
    public void Decode_HexEscape_Newline() {
        var encoding = new Hl7Encoding('|', '^', '~', '\\', '&');
        var encoded = @"1380 SAMPLE STREET^\X0A\^NEW YORK^NY^55755-5055";
        var expected = "1380 SAMPLE STREET^\n^NEW YORK^NY^55755-5055";
        var decoded = encoding.Decode(encoded);
        Assert.Equal(expected, decoded);
    }

    [Fact]
    public void Encode_HexEscape_Newline() {
        var encoding = new Hl7Encoding('|', '^', '~', '\\', '&');
        var input = "1380 SAMPLE STREET^\n^NEW YORK^NY^55755-5055";
        var encoded = encoding.Encode(input);
        var expected = "1380 SAMPLE STREET\\S\\\\X0A\\\\S\\NEW YORK\\S\\NY\\S\\55755-5055";
        Assert.Equal(expected, encoded);
    }

    [Fact]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void Decode_MalformedEscapeSequences() {
        // Missing closing escape
        const string input1 = @"ABC\FDEF";
        const string expected1 = @"ABC\FDEF";
        var decoded1 = defaultEncoder.Decode(input1);
        Assert.Equal(expected1, decoded1);

        // Unknown escape code
        const string input2 = @"ABC\Z\DEF";
        const string expected2 = "ABCZDEF";
        var decoded2 = defaultEncoder.Decode(input2);
        Assert.Equal(expected2, decoded2);

        // Empty escape sequence
        const string input3 = @"ABC\\DEF";
        const string expected3 = "ABCDEF";
        var decoded3 = defaultEncoder.Decode(input3);
        Assert.Equal(expected3, decoded3);
    }
}
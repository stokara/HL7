using HL7;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
    public void SegmentParse_StandardDelimiters() {
        var encoding = new Hl7Encoding('|', '^', '~', '\\', '&');
        var segmentStr = "PID|1|12345|DOE^JOHN";
        var segment = Segment.Parse(encoding, segmentStr);

        Assert.Equal("PID", segment.Name);
        Assert.Equal(4, segment.FieldCount);
    }

    [Fact]
    public void SegmentParse_NonStandardDelimiters() {
        var encoding = new Hl7Encoding('!', '@', '#', '$', '%');
        var segmentStr = "ZZZ!A!B@C$D%E";
        var segment = Segment.Parse(encoding, segmentStr);

        Assert.Equal("ZZZ", segment.Name);
        Assert.Equal(3, segment.FieldCount);
    }

    [Fact]
    public void SegmentParse_EscapedDelimiter() {
        var encoding = new Hl7Encoding('|', '^', '~', '\\', '&');
        var segmentStr = @"OBX|1|TX|Some\F\StringValue|End";
        var segment = Segment.Parse(encoding, segmentStr);

        Assert.Equal("OBX", segment.Name);
        Assert.Equal(5, segment.FieldCount);
    }

    [Fact]
    public void SegmentParse_MSH_WithStandardDelimiters() {
        var segmentStr = @"MSH|^~\&|SendingApp|SendingFac|ReceivingApp|ReceivingFac|202407021200||ADT^A01|123456|P|2.5|\r\n";
        var segment = new MshSegment(segmentStr);

        Assert.Equal("SendingApp", segment.GetRawField(3).RawComponent.ComponentValue);
        Assert.Equal("ReceivingApp", segment.GetRawField(5).RawComponent.ComponentValue);
        Assert.Equal("2.5", segment.GetRawField(12).RawComponent.ComponentValue);
    }

    [Fact]
    public void SegmentParse_MSH_WithNonStandardDelimiters() {
        var segmentStr = @"MSH!@#$%!App1!Fac1!App2!Fac2!202507021200!!ADT@A01!654321!P!2.8!\r\n";
        var msh = new MshSegment(segmentStr);

        Assert.Equal("MSH", msh.Name);
        Assert.Equal("App1", msh.GetRawField(3).RawComponent.ComponentValue);
        Assert.Equal("App2", msh.GetRawField(5).RawComponent.ComponentValue);
        Assert.Equal("2.8", msh.GetRawField(12).RawComponent.ComponentValue);
    }

    [Fact]
    public void FieldParse_SimpleValue() {
        var value = "SIMPLE";
        var field = new RawField(value, defaultEncoder);
        Assert.Equal("SIMPLE", field.RawComponent.ComponentValue);
    }

    [Fact]
    public void ComponentParse_WithComponents() {
        const string value = "DOE^JOHN^A";
        var component = new RawComponent( value, defaultEncoder, Hl7Structure.Hl7Component);
        Assert.Equal(3, component.SubComponents.Length);
        Assert.Equal("DOE", component.SubComponents[0]);
        Assert.Equal("JOHN", component.SubComponents[1]);
        Assert.Equal("A", component.SubComponents[2]);
    }

    [Fact]
    public void FieldParse_WithRepetitions() {
        var value = "A~B~C";
        var field = new RawField( value, defaultEncoder);
        Assert.Equal(3, field.RepeatedFields.Count);
    }

    [Fact]
    public void FieldParse_WithComponentsAndRepetitions() {
        const string value = "A^B~C^D";
        var field = new RawField(value, defaultEncoder);
        Assert.Equal(2, field.RepeatedFields.Count);
    }

    [Fact]
    public void FieldParse_WithEscapedDelimiter() {
        var value = @"A\F\B";
        var field = new RawField(value, defaultEncoder);
        Assert.Single(field.RepeatedFields);
    }

    [Fact]
    public void FieldParse_CustomDelimiters() {
        var encoding = new Hl7Encoding('!', '@', '#', '$', '%');
        var value = "A@B@C";
        var component = new RawComponent(value, encoding, Hl7Structure.Hl7Component);
        Assert.Equal(3, component.SubComponents.Length);
    }

    [Fact]
    public void MessageRoundTrip_Is_Equal() {
        var sampleMessage =
            """
            MSH|^~\&|ATHENANET|18802555^Orthopaedic Sample Org|Aspyra - 18802555|13274090^ORTHOPAEDIC INSTITUTE|20241119113500||ORM^O01|57492555M18802|P|2.5.1||||||||
            PID||500036547^^^Enterprise ID||500036547^^^Patient ID|JOHN^DOE^||20050904|M||2106-3|1380 SAMPLE STREET^\X0A\^NEW YORK^NY^55755-5055||(555)261-2203|||S||||||||||||||
            PV1||O|80D18802^^^SAMPLE ORTHO URGENT CARE||||1905555652^JANE^D^DOE||||||||||1037^ABCDE8|||||||||||||||||||||||||||||||||||
            """;
        var hl7Message = Hl7Message.Create(sampleMessage);
        var str = hl7Message.Serialize();

        Assert.True(areEquivalent(sampleMessage, str));
    }

    private static bool areEquivalent(string expected, string sut) {
        string[] lineEndings = ["\r\n", "\n", "\r"];
        var expectedLines = expected.Split(lineEndings, StringSplitOptions.None);
        var sutLines = sut.Split(lineEndings, StringSplitOptions.None);

        if (expectedLines.Length != sutLines.Length) return false;
        return !expectedLines.Where((t, i) => !compareSegmentLine(t, sutLines[i])).Any();

        bool compareSegmentLine(string expectedLine, string sutLine) {
            if (sutLine.Length < expectedLine.Length) return false;
            if (!sutLine.StartsWith(expectedLine)) return false;

            var extra = sutLine[expectedLine.Length..];
            return extra.Length <= 0 || extra.All(c => c == '|');
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
        Assert.Equal(@"\E\T\E\", msa.GetRawField(4).RawComponent.ComponentValue);
    }


    //[Fact]
    ////is this correct?
    //public void TrailingFieldDelimiterProducesEmptyField() { 
    //    var sampleMessage = """
    //                        MSH|^~\&|Main_HIS|XYZ_HOSPITAL|iFW|ABC_Lab|20160915003015||ACK|9B38584D|P|2.6.1|
    //                        MSA|FIRST|SECOND|THIRD|
    //                        """;

    //    var message = Message.Parse(sampleMessage);
    //    var msa = message.Segments.FirstOrDefault(s => s.Name == "MSA");
    //    Assert.NotNull(msa);
    //    Assert.Equal(5, msa.FieldCount);
    //}

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
using HL7;
using System.Linq;
using Xunit;

namespace HL7test;

public class EncodingTests {
    private readonly Hl7Encoding defaultEncoder = new(
        FieldDelimiter: '|',
        ComponentDelimiter: '^',
        RepeatDelimiter: '~',
        EscapeCharacter: '\\',
        SubComponentDelimiter: '&'
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
        var segment = new Segment(segmentStr, encoding);

        Assert.Equal("PID", segment.Name);
        Assert.Equal(4, segment.FieldCount);
    }

    [Fact]
    public void SegmentParse_NonStandardDelimiters() {
        var encoding = new Hl7Encoding('!', '@', '#', '$', '%');
        var segmentStr = "ZZZ!A!B@C$D%E";
        var segment = new Segment(segmentStr, encoding);

        Assert.Equal("ZZZ", segment.Name);
        Assert.Equal(3, segment.FieldCount);
    }

    [Fact]
    public void SegmentParse_EscapedDelimiter() {
        var encoding = new Hl7Encoding('|', '^', '~', '\\', '&');
        var segmentStr = @"OBX|1|TX|Some\F\StringValue|End";
        var segment = new Segment(segmentStr, encoding);

        Assert.Equal("OBX", segment.Name);
        Assert.Equal(5, segment.FieldCount);
    }

    [Fact]
    public void SegmentParse_MSH_WithStandardDelimiters() {
        var segmentStr = @"MSH|^~\&|SendingApp|SendingFac|ReceivingApp|ReceivingFac|202407021200||ADT^A01|123456|P|2.5|\r\n";
        var segment = new MshSegment(segmentStr);

        Assert.Equal("SendingApp", segment.GetRawFieldString(1));
        Assert.Equal("ReceivingApp", segment.GetRawFieldString(3));
        Assert.Equal("2.5", segment.GetRawFieldString(10));
    }

    [Fact]
    public void SegmentParse_MSH_WithNonStandardDelimiters() {
        var segmentStr = @"MSH!@#$%!App1!Fac1!App2!Fac2!202507021200!!ADT@A01!654321!P!2.8!\r\n";
        var msh = new MshSegment(segmentStr);

        Assert.Equal("MSH", msh.Name);
        Assert.Equal("App1", msh.GetRawFieldString(1));
        Assert.Equal("App2", msh.GetRawFieldString(3));
        Assert.Equal("2.8", msh.GetRawFieldString(10));
    }

    [Fact]
    public void FieldParse_SimpleValue() {
        var value = "SIMPLE";
        var field = new RawComponent(value, defaultEncoder, Hl7Structure.Hl7Field);
        Assert.Equal("SIMPLE", field.ComponentValue);
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
    public void FieldParse_CustomDelimiters() {
        var encoding = new Hl7Encoding('!', '@', '#', '$', '%');
        var value = "A@B@C";
        var component = new RawComponent(value, encoding, Hl7Structure.Hl7Component);
        Assert.Equal(3, component.SubComponents.Length);
    }

    [Fact]
    public void LinqQueryFindsMessageValue() {
        var sampleMessage = """
                           MSH|^~\&|SndApp^1.2.3.4.5^ISO|SndFac^1.2.3.4.5^ISO|RcvApp^1.2.3.4.5^ISO| RcvFac^1.2.3.4.5^ISO|20150601135823+0100|ADTADM|ADT^A01^ADT_A01|4637382|P|2.5.1|||AL|NE|USA|ASCII|en|||SndOrg^L^0009^1^1000^AssignAuth&1.2.3.4.5.6&ISO^XX^AssignFac&1.2.3.4.5.6&ISO^^67890| RecOrg^L^0011^2^1000^AssignAuth&1.2.3.4.5.7&ISO^XX^AssignFac&1.2.3.4.5.7&ISO^^45678|^ftp://www.goodhealth.org/somearea/someapp^URI|^ftp://www.goodlab.org/somearea/someapp^URI
                           EVN|A01|20150601135823+0100||ADT_EVENT|23432^Smith^Gordon^Denny^Jr^MD^^ AssignAuth&1.2.3.4.5.6&ISO^L^9^1000^DN^ AssignFac&1.2.3.4.5.7&ISO^^G^20100101000000+0100^20330101000000+0100^doctor|20150601135822+0100|EventFac^1.2.3.4.5^ISO
                           """;
        
        var message = Message.Parse(sampleMessage);
        var msa = message.Segments.FirstOrDefault(s => s.Name == "EVN");
        Assert.NotNull(msa);
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
    public void Decode_MissingClosingEscape_ReturnsInputUnchanged() {
        const string input = @"ABC\FDEF";
        var decoded = defaultEncoder.Decode(input);
        Assert.Equal(input, decoded);
    }

    [Fact]
    public void Decode_UnknownEscapeCode_ReturnsInputUnchanged() {
        const string input = @"ABC\Z\DEF";
        var decoded = defaultEncoder.Decode(input);
        Assert.Equal(input, decoded);
    }

    [Fact]
    public void Decode_EmptyEscapeSequence_RemovesEscapeCharacters() {
        const string input = @"ABC\\DEF";
        const string expected = "ABCDEF";
        var decoded = defaultEncoder.Decode(input);
        Assert.Equal(expected, decoded);
    }
}
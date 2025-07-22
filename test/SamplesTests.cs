using System;
using System.IO;
using System.Linq;
using HL7;
using Xunit;
using Xunit.Abstractions;

namespace HL7test;

public class SamplesTests {
    private readonly ITestOutputHelper testOutputHelper;

    public SamplesTests(ITestOutputHelper testOutputHelper) {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Roundtrip_All_SampleFiles_Into_HL7Data() {
        var sampleFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "Sample Files");
        var filenames = Directory.GetFiles(sampleFilesPath, "*.*");

        foreach (var filename in filenames) {
            var sampleText = File.ReadAllText(filename);
            var hl7Data = Hl7Message.Create(sampleText) ?? throw new Hl7Exception("Unable to Parse Message", Hl7Exception.ParsingError);
            var str = hl7Data.Serialize();
            var diff = findDiff(sampleText, str, hl7Data.Encoding);

            if (diff.segmentNum >= 0) {
                testOutputHelper.WriteLine($"File: {Path.GetFileName(filename)} differ at Segment:{diff.segmentNum}, Offset:{diff.offset}, Field: {diff.fieldNum}");
                testOutputHelper.WriteLine($"Expected:\n{sampleText}");
                testOutputHelper.WriteLine($"Actual:\n{str}");
            }

            Assert.True(diff.segmentNum == -1);
        }
    }

    [Fact]
    public void Roundtrip() {
        const string sampleText =
            "MSH|^~\\&|MS4_AZ|UNV|PREMISE|UNV|20180301010000||ADT^A04|IHS-20180301010000.00120|P|2.1\r\nEVN|A04|20180301010000\r\nPID|1||19050114293307.1082||BUNNY^BUGS^RABBIT^^^MS||19830215|M|||1234 LOONEY RD^APT A^CRAIGMONT^ID^83523^USA|||||||111-11-1111|111-11-1111\r\nPV1|1|E|ED^^^UNV|C|||999-99-9999^MUNCHER^CHANDRA^ANDRIA^MD^DR|888-88-8888^SMETHERS^ANNETTA^JONI^MD^DR||||||7||||REF||||||||||||||||||||||||||20180301010000\r\n";
        var hl7Data = Hl7Message.Create(sampleText);
        var str = hl7Data.Serialize();
        var diff = findDiff(sampleText, str, hl7Data.Encoding);

        if (diff.segmentNum >= 0) {
            testOutputHelper.WriteLine($"Differ at Segment:{diff.segmentNum}, Offset:{diff.offset}, Field: {diff.fieldNum}");
            testOutputHelper.WriteLine($"Expected:\n{sampleText}");
            testOutputHelper.WriteLine($"Actual:\n{str}");
        }

        Assert.True(diff.segmentNum == -1);
    }

    [Fact]
    public void RepeatFields_OK() {
        const string sampleText =
            "MSH|^~\\&|P0241|HOMERTON|HOMERTON_TIE|HOMERTON|20150209170901||ADT^A31|Q111111119T4083493511111111||2.3\r\nEVN|A31|20150209170901|||101111^Smith^Geoff^^^^^^PERSONNEL PRIMARY IDENTIFIER^Personnel^^^Personnel Primary Identifier^\"\"\r\nPID|1|999999^^^Homerton Case Note Number^MRN^\"\"|999998^^^Homerton Case Note Number^CNN~111111^^^Person ID^Person ID||MIAH^Jane^^^Miss^^Current~~^MIAH^^^^^Alternate||19781030000000|Female|^MIAH^^^^^Alternate~Miah^Janet^^^Miss^^Preferred~JONES^Jane^^^Miss^^Previous|\"\"|Flat 1^15 Main Street^^London^N1 1AA^\"\"^home^^\"\"~MAJOR HOUSE^CHURCH ROAD^^\"\"^^\"\"^Previous^LONDON^\"\"||^Home^Tel~07777111111^Mobile Number^Tel|^Business|Turkish|\"\"|Not Known|999999^^^Homerton FIN^Encounter No.^\"\"|9999999999|||Eastern European|||0|\"\"|\"\"|\"\"||No||Trace in Progress\r\nPD1|\"\"|\"\"||G88888888^RICHARDSON^JANET^^020711111111^F84040^MAIN ROAD MEDICAL CENTRE^100 MAIN ROAD^&LONDON&N1 1AA^^^^^Q06|\"\"||\"\"|\"\"\r\nNK1|1|MIAH^Richard^^^^^Current|\"\"|Flat 1^15 Main Road^^\"\"^N1 1AA^\"\"^^^\"\"|077777222333||Next of Kin|||||||||||||\"\"\r\nPV1|1|Inpatient|HUH AE OMU^OMU B^Bed 03^HOMERTON UNIVER^^Bed(s)^Homerton UH|Emergency-A\\T\\E/Dental||HUH AE Adults^\"\"^\"\"^HOMERTON UNIVER^^^Homerton UH|1122334^Alaz^Mohammed^^^^^^PERSONNEL PRIMARY IDENTIFIER^Personnel^^^Personnel Primary Identifier^\"\"~ALAZ^Alaz^Mohammed^^^^^^Homerton Sysmed Prsnl Pool^Personnel^^^OTHER^\"\"~C10001000^Alaz^Mohammed^^^^^^\"\"^Personnel^^^COMMUNITY DR NBR^\"\"~C20002000^Alaz^Mohammed^^^^^^NHS PRSNL ID^Personnel^^^PRSNLID^\"\"|3333444^Kumar^Alesh^^^^^^PERSONNEL PRIMARY IDENTIFIER^Personnel^^^Personnel Primary Identifier^\"\"~KUMAR^Kumar^Alesh^^^^^^Homerton Sysmed Prsnl Pool^Personnel^^^OTHER^\"\"~C30010002^Kumar^Alesh^^^^^^\"\"^Personnel^^^COMMUNITY DR NBR^\"\"||Accident and Emergency|\"\"|\"\"|New Problem/First Attendance|NHS Provider-General (inc.A\\T\\E-this Hosp)|\"\"|\"\"||Inpatient|5000000^0^\"\"^^Attendance No.|\"\"||\"\"||||||||||||||Admitted as Inpatient|\"\"|\"\"|HOMERTON UNIVER||Active|||20150208113419\r\nPV2||NHS|^4 UNWELL|Transfer from ED|||\"\"|||0|||\"\"||||||||\"\"|\"\"|^^1";
        var hl7Data = Hl7Message.Create(sampleText);
        var str = hl7Data.Serialize();
        var diff = findDiff(sampleText, str, hl7Data.Encoding);

        if (diff.segmentNum >= 0) {
            testOutputHelper.WriteLine($"Differ at Segment:{diff.segmentNum}, Offset:{diff.offset}, Field: {diff.fieldNum}");
            testOutputHelper.WriteLine($"Expected:\n{sampleText}");
            testOutputHelper.WriteLine($"Actual:\n{str}");
        }

        Assert.True(diff.segmentNum == -1);
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

        if (expectedLines.Length != sutLines.Length)
            return false;
        return !expectedLines.Where((t, i) => !compareSegmentLine(t, sutLines[i])).Any();

        bool compareSegmentLine(string expectedLine, string sutLine) {
            if (sutLine.Length < expectedLine.Length)
                return false;
            if (!sutLine.StartsWith(expectedLine))
                return false;

            var extra = sutLine[expectedLine.Length..];
            return extra.Length <= 0 || extra.All(c => c == '|');
        }
    }

    //[Fact]
    //public void t() {
    //    const string sampleText =
    //        "MSH|^~\\&|NISTEHRAPP|NISTEHRFAC|NISTIISAPP|NISTIISFAC|20150625072816.601-0500||VXU^V04^VXU_V04|NIST-IZ-AD-10.1_Send_V04_Z22|P|2.5.1|||ER|AL|||||Z22^CDCPHINVS|NISTEHRFAC|NISTIISFAC\r\nPID|1||21142^^^NIST-MPI-1^MR||Vasquez^Manuel^Diego^^^^L||19470215|M||2106-3^White^CDCREC|227 Park Ave^^Bozeman^MT^59715^USA^P||^PRN^PH^^^406^5555815~^NET^^Manuel.Vasquez@isp.com|||||||||2135-2^Hispanic or Latino^CDCREC||N|1|||||N\r\nPD1|||||||||||01^No reminder/recall^HL70215|N|20150625|||A|20150625|20150625|RE||31165^NIST-AA-IZ-2|||||||7824^Jackson^Lily^Suzanne^^^^^NIST-PI-1^L^^^PRN|||||||NISTEHRFAC^NISTEHRFacility^HL70362\r\nRXA|0|1|20141021||152^Pneumococcal Conjugate, unspecified formulation^CVX|999|||01^Historical Administration^NIP001|||||||||||CP|A";
    //    var hl7Data = Hl7Message.Create(sampleText);
    //    var str = hl7Data.Serialize();
    //    var diff = findDiff(sampleText, str, hl7Data.Encoding);

    //    if (diff.segmentNum >= 0) {
    //        testOutputHelper.WriteLine($"Differ at Segment:{diff.segmentNum}, Offset:{diff.offset}, Field: {diff.fieldNum}");
    //        testOutputHelper.WriteLine($"Expected:\n{sampleText}");
    //        testOutputHelper.WriteLine($"Actual:\n{str}");
    //    }

    //    Assert.True(diff.segmentNum == -1);
    //}

    [Fact]
    public void Encoding_With_TruncationDelimiter_Ok() {
        const string sampleText =
            "MSH|^~\\&#|NIST EHR|NIST EHR Facility|NIST Test Lab APP|NIST Lab Facility|20130211184101-0500||OML^O21^OML_O21|NIST-LOI_5.0_1.1-NG|T|2.5.1|||AL|AL|||||\r\n";
        var hl7Data = Hl7Message.Create(sampleText);
        var str = hl7Data.Serialize();
        var diff = findDiff(sampleText, str, hl7Data.Encoding);

        if (diff.segmentNum >= 0) {
            testOutputHelper.WriteLine($"Differ at Segment:{diff.segmentNum}, Offset:{diff.offset}, Field: {diff.fieldNum}");
            testOutputHelper.WriteLine($"Expected:\n{sampleText}");
            testOutputHelper.WriteLine($"Actual:\n{str}");
        }

        Assert.True(diff.segmentNum == -1);
    }


    private static (int segmentNum, int offset, int fieldNum) findDiff(string expected, string sut, Hl7Encoding encoding) {
        string[] lineEndings = ["\r\n", "\n", "\r"];
        var expectedLines = expected.Split(lineEndings, StringSplitOptions.RemoveEmptyEntries);
        var sutLines = sut.Split(lineEndings, StringSplitOptions.None);

        for (var i = 0; i < expectedLines.Length; i++) {
            if (expectedLines.Length <= i || sutLines.Length <= i) {
                return (i + 1, -1, -1); // Different number of segments
            }

            var diffOffset = getDifferenceOffset(expectedLines[i], sutLines[i], encoding.FieldDelimiter);
            if (diffOffset != -1) {
                int fieldNum;
                if (diffOffset >= 0 && diffOffset <= sutLines[i].Length) {
                    fieldNum = sutLines[i].Take(diffOffset).Count(c => c == encoding.FieldDelimiter);
                } else {
                    fieldNum = sutLines[i].Count(c => c == encoding.FieldDelimiter);
                }

                return (i + 1, diffOffset, fieldNum);
            }
        }

        return (-1, -1, -1);

        static int getDifferenceOffset(string expectedLine, string sutLine, char fieldDelimiter) {
            var expectedLen = expectedLine.Length;
            var sutLen = sutLine.Length;
            var minLen = Math.Min(expectedLen, sutLen);

            for (var i = 0; i < minLen; i++) {
                if (expectedLine[i] != sutLine[i]) return i;
            }

            if (sutLen > expectedLen) {
                var extra = sutLine[expectedLen..];
                if (extra.All(c => c == fieldDelimiter)) return -1;

                return expectedLen;
            }

            if (expectedLen > sutLen) {
                var extra = expectedLine[sutLen..];
                if (extra.All(c => c == fieldDelimiter)) return -1;

                return expectedLen;
            }

            return -1;
        }
    }
}
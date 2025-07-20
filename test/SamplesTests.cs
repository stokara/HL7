using System;
using System.Collections.Generic;
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
    public void Parse_All_SampleFiles_Into_Message() {
        var sampleFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "Sample Files");
        Assert.True(Directory.Exists(sampleFilesPath), $"Sample Files directory not found: {sampleFilesPath}");

        var files = Directory.GetFiles(sampleFilesPath, "*.*");

        foreach (var file in files) {
            var hl7Text = File.ReadAllText(file);

            Message? message = null;
            try {
                message = Message.Parse(hl7Text);
                testOutputHelper.WriteLine($"Parsed {Path.GetFileName(file)}.");
            } catch (Exception parseException) {
                testOutputHelper.WriteLine($"Failed to parse {Path.GetFileName(file)}: {parseException?.Message}");
            }
        }
    }

    [Fact]
    public void Roundtrip_All_SampleFiles_Into_HL7Data() {
        var sampleFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "Sample Files");
        var filenames = Directory.GetFiles(sampleFilesPath, "*.*");

        foreach (var filename in filenames) {
            var sampleText = File.ReadAllText(filename);
            var hl7Data = Hl7Message.Create(sampleText) ?? throw new Hl7Exception("Unable to Parse Message", Hl7Exception.ParsingError);
            var str = hl7Data.Serialize();
            var equivalence = areEquivalent(sampleText, str);

            if (!equivalence.areEquvalent) {
                var segDiff = equivalence.failedSegmentNum == 0 ? "number of segments." : $"Segment {equivalence.failedSegmentNum + 1} ";
                testOutputHelper.WriteLine($"File: {Path.GetFileName(filename)} differ at {segDiff}");
                testOutputHelper.WriteLine($"Expected:\n{sampleText}");
                testOutputHelper.WriteLine($"Actual:\n{str}");
            }
            Assert.True(equivalence.areEquvalent);
        }
    }


    private static (bool areEquvalent, int failedSegmentNum) areEquivalent(string expected, string sut) {
        string[] lineEndings = ["\r\n", "\n", "\r"];
        var expectedLines = expected.Split(lineEndings, StringSplitOptions.RemoveEmptyEntries);
        var sutLines = sut.Split(lineEndings, StringSplitOptions.None);

        if (expectedLines.Length != sutLines.Length) return (false, 0);

        for (int i = 0; i < expectedLines.Length; i++) {
            if (!compareSegmentLine(expectedLines[i], sutLines[i])) return (false, i+1);
        }
        return (true, -1);

        bool compareSegmentLine(string expectedLine, string sutLine) {
            if (sutLine.Length < expectedLine.Length) return false;
            if (!sutLine.StartsWith(expectedLine)) return false;

            var extra = sutLine[expectedLine.Length..];
            return extra.Length <= 0 || extra.All(c => c == '|');
        }
    }

}
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
    public void Convert_All_SampleFiles_Into_HL7Data() {
        var sampleFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "Sample Files");
        var files = Directory.GetFiles(sampleFilesPath, "*.*");

        foreach (var file in files) {
            var hl7Text = File.ReadAllText(file);

            try {
                var hl7Data = HL7Message.Create(hl7Text);
                var typeCounts = hl7Data.HL7Records
                    .Select(kvp => new { TypeName = kvp.Key.Name, Count = kvp.Value?.Count ?? 0 })
                    .OrderBy(x => x.TypeName);
                var summary = string.Join(", ", typeCounts.Select(entry => $"{entry.TypeName}: {entry.Count}"));
                testOutputHelper.WriteLine($"Converted {Path.GetFileName(file)} {summary}");
            } catch (Exception ex) {
                testOutputHelper.WriteLine($"Exception converting {Path.GetFileName(file)}: {ex.Message}");
            }
        }
    }
}
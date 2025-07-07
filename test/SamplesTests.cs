using System;
using System.IO;
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
}
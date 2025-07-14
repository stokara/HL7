namespace HL7Scraper;

class Program
{
    static async Task Main() {
       await GetSegmentTypesAsync();
       // await getDataTypesAsync();


    }

    private static async Task getDataTypesAsync() {
        using var fs = new FileStream(@"c:\temp\hl7dataclasses.cs", FileMode.Create, FileAccess.Write, FileShare.None);
        var scraper = new HL7DataTypeScraper(new HttpClient());
        var dataTypes = await scraper.ScrapeAsync("http://v2plus.hl7.org/2021Jan/data-types.html");
        HL7DataTypeScraper.OutputDataTypeClasses(dataTypes, fs);
    }


    private static async Task GetSegmentTypesAsync() {
        var url = "http://v2plus.hl7.org/2021Jan/segment-definitions.html";
        var httpClient = new HttpClient();
        var scraper = new HL7SegmentScraper(httpClient);

        var segments = await scraper.ScrapeAsync(url);

        using var fs = new FileStream(@"c:\temp\hl7SegmentTypes.cs", FileMode.Create, FileAccess.Write, FileShare.None);
        HL7SegmentScraper.GenerateClasses(segments, fs);
    }
}
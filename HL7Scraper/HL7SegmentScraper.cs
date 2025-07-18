using System.Text;
using HtmlAgilityPack;

namespace HL7Scraper;

public record DataElement(int Order, string Name, bool IsRequired, bool CanRepeat, string DataType, string PropType);

public record SegmentDefinition(string SegmentName, List<DataElement> DataElements);

public class HL7SegmentScraper {
    private readonly HttpClient httpClient;

    public HL7SegmentScraper(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    public async Task<List<SegmentDefinition>> ScrapeAsync(string url) {
        var segmentLinks = await getSegmentLinksAsync(url);
        var segments = new List<SegmentDefinition>();

        foreach (var segmentUrl in segmentLinks) {
            var segment = await parseSegmentAsync(segmentUrl);
            if (segment != null && segment.SegmentName != "MSH") segments.Add(segment);
        }
        return segments;
    }

    private async Task<List<string>> getSegmentLinksAsync(string url) {
        var html = await httpClient.GetStringAsync(url);
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var links = new List<string>();
        var segmentLinks = doc.DocumentNode.SelectNodes("//a[contains(@href, 'segment-definition/')]");
        if (segmentLinks != null) {
            var baseUri = new Uri(url);
            foreach (var link in segmentLinks) {
                var href = link.Attributes["href"].Value;
                var segmentUrl = new Uri(baseUri, href).ToString();
                links.Add(segmentUrl);
            }
        }

        return links;
    }

    private async Task<SegmentDefinition?> parseSegmentAsync(string segmentUrl) {
        try {
            Console.WriteLine($"Fetching: {segmentUrl}");
            var segmentHtml = await httpClient.GetStringAsync(segmentUrl);
            var segmentDoc = new HtmlDocument();
            segmentDoc.LoadHtml(segmentHtml);

            var segmentName = getSegmentNameFromUrl(segmentUrl);

            var table = segmentDoc.DocumentNode.SelectSingleNode("//table[contains(@class, 'segment-definition-table')]"); // Fallback: use the first table if not found
            if (table == null) {
                table = segmentDoc.DocumentNode.SelectSingleNode("//table");
            }

            var rows = table?.SelectNodes(".//tr[position()>1]"); // skip header

            var dataElements = rows != null ? parseDataElements(rows) : new List<DataElement>();
            return new SegmentDefinition(segmentName, dataElements);
        } catch (HttpRequestException ex) {
            Console.WriteLine($"404 or network error for: {segmentUrl} - {ex.Message}");
            return null;
        }
    }

    private static string getSegmentNameFromUrl(string url) {
        var fileName = url.Split('/').Last();
        var name = fileName.Split('.').First();
        return name.ToUpperInvariant();
    }

    private List<DataElement> parseDataElements(HtmlNodeCollection rows) {
        var dataElements = new List<DataElement>();
        var propNameCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (var row in rows) {
            var cells = row.SelectNodes(".//td");
            if (cells == null || cells.Count < 4) continue;

            int num;
            var numText = cells[0].InnerText.Trim();
            if (!int.TryParse(numText, out num)) num = 0;

            // Sanitize name: remove dashes, slashes, and non-alphanumeric characters
            var rawName = cells[2].InnerText.Trim();
            var baseName = new string(rawName.Where(c => char.IsLetterOrDigit(c)).ToArray());
            if (string.IsNullOrEmpty(baseName)) baseName = "Field";
            baseName = char.ToUpper(baseName[0]) + baseName.Substring(1);

            // Ensure uniqueness
            var propName = baseName;
            if (propNameCounts.TryGetValue(baseName, out var count)) {
                count++;
                propNameCounts[baseName] = count;
                propName = $"{baseName}{count}";
            } else {
                propNameCounts[baseName] = 1;
            }

            var cardinality = cells[5].InnerText.Trim().Replace("[", "").Replace("]", "");
            var datatype = cells[9].InnerText.Trim();

            // Exclude if datatype or cardinality is missing
            if (string.IsNullOrWhiteSpace(datatype) || string.IsNullOrWhiteSpace(cardinality)) continue;
            if (datatype.Equals("Varies", StringComparison.OrdinalIgnoreCase)) datatype = "ST";

            bool isRequired = false, canRepeat = false;
            var parts = cardinality.Split([".."], StringSplitOptions.None);
            if (parts.Length == 2) {
                isRequired = parts[0] == "1";
                canRepeat = parts[1] == "*" || parts[1].Equals("n", StringComparison.OrdinalIgnoreCase);
            }

            var propType = (canRepeat ? $"ICollection<{datatype}>" : $"{datatype}") + (isRequired ? "" : "?");
            dataElements.Add(new DataElement(num, propName, isRequired, canRepeat, datatype, propType));
        }

        return dataElements;
    }

    public static void GenerateClasses(List<SegmentDefinition> segments, Stream stream) {
        using var writer = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true);
        writer.WriteLine("namespace HL7;");
        writer.WriteLine();

        foreach (var segment in segments.Where(s => !string.IsNullOrWhiteSpace( s.SegmentName))) {
            writer.WriteLine($"public sealed record {segment.SegmentName} : Hl7Segment {{");
            generateProperties(segment);
            writer.WriteLine();
            generateConstructor(segment);
            writer.WriteLine("}");
            writer.WriteLine();
        }
        writer.Flush();
        return;

        void generateProperties(SegmentDefinition segment) {
            foreach (var de in segment.DataElements) {
                writer.WriteLine($"    public {de.PropType} {de.Name} {{ get; }}");
            }
        }

        void generateConstructor(SegmentDefinition segment) {
            writer.WriteLine($"    public {segment.SegmentName}(Segment segment) : base(typeof({segment.SegmentName}), segment) {{");
            for (var i = 0; i < segment.DataElements.Count; i++) {
                var de = segment.DataElements[i];
                var getMethod = $"Get{(de.IsRequired ? "Required" : "")}{(de.CanRepeat ? "Rep" : "")}Field";
                writer.WriteLine($"        this.{de.Name} = segment.{getMethod}<{de.DataType}>({i+1});");
            }
            writer.WriteLine("    }");
        }
    }

// Helper to sanitize property names (PascalCase, remove invalid chars)
    private static string sanitizePropertyName(string name) {
        var dashIndex = name.IndexOf('-');
        if (dashIndex >= 0) name = name.Substring(0, dashIndex);

        var valid = new string(name.Where(char.IsLetterOrDigit).ToArray());
        if (string.IsNullOrEmpty(valid)) valid = "field";

        return char.ToUpper(valid[0]) + valid.Substring(1);
    }
}
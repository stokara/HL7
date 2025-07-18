using System.Text;
using HtmlAgilityPack;

namespace HL7Scraper;

public record DataTypeComponent(int Order, string Name, bool IsRequired, string DataTypeName);

public record DataTypeDefinition(string Name, List<DataTypeComponent> Components);

public class HL7DataTypeScraper {
    private readonly HttpClient httpClient;

    public HL7DataTypeScraper(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    public async Task<List<DataTypeDefinition>> ScrapeAsync(string url) {
        var dataTypeLinks = await getDataTypeLinksAsync(url);
        var dataTypes = new List<DataTypeDefinition>();

        foreach (var dataTypeUrl in dataTypeLinks) {
            var dataType = await parseDataTypeAsync(dataTypeUrl);
            if (dataType != null)
                dataTypes.Add(dataType);
        }

        return dataTypes;
    }

    private async Task<List<string>> getDataTypeLinksAsync(string url) {
        var html = await httpClient.GetStringAsync(url);
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var links = new List<string>();
        var dataTypeLinks = doc.DocumentNode.SelectNodes("//a[contains(@href, 'data-type/')]");
        if (dataTypeLinks != null) {
            var baseUri = new Uri(url);
            foreach (var link in dataTypeLinks) {
                var href = link.Attributes["href"].Value;
                var dataTypeUrl = new Uri(baseUri, href).ToString();
                links.Add(dataTypeUrl);
            }
        }

        return links;
    }

    private async Task<DataTypeDefinition?> parseDataTypeAsync(string dataTypeUrl) {
        try {
            Console.WriteLine($"Fetching: {dataTypeUrl}");
            var html = await httpClient.GetStringAsync(dataTypeUrl);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var dataTypeName = getDataTypeNameFromUrl(dataTypeUrl);

            // Find the HL7 Attribute Table for the data type
            var table = doc.DocumentNode.SelectSingleNode("//table[contains(@class, 'datatype-table')]");
            if (table == null) return null;

            var rows = table.SelectNodes(".//tr[position()>1]"); // skip header
            var components = rows != null ? parseDataTypeComponents(rows) : [];

            return new DataTypeDefinition(dataTypeName, components);
        } catch (HttpRequestException ex) {
            Console.WriteLine($"404 or network error for: {dataTypeUrl} - {ex.Message}");
            return null;
        }
    }

    private static string getDataTypeNameFromUrl(string url) {
        var fileName = url.Split('/').Last();
        var name = fileName.Split('.').First();
        return name.ToUpperInvariant();
    }

    private List<DataTypeComponent> parseDataTypeComponents(HtmlNodeCollection rows) {
        var components = new List<DataTypeComponent>();
        var propNameCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (var row in rows) {
            var cells = row.SelectNodes(".//td");
            if (cells == null || cells.Count < 4)
                continue;

            int.TryParse(cells[0].InnerText.Trim(), out var order);
            var baseName = cells[1].InnerText.Trim().Replace(" ", "");
            var name = sanitizePropertyName(baseName);
            if (propNameCounts.TryGetValue(baseName, out var count)) {
                count++;
                propNameCounts[baseName] = count;
                name = $"{baseName}{count}";
            } else {
                propNameCounts[baseName] = 1;
            }

            var cardinality = cells[4].InnerText.Trim().Replace("[", "").Replace("]", "");
            var datatype = cells[8].InnerText.Trim();

            if (string.IsNullOrWhiteSpace(datatype) || string.IsNullOrWhiteSpace(cardinality)) continue;

            var isRequired = false;
            var parts = cardinality.Split([".."], StringSplitOptions.None);
            if (parts.Length == 2) isRequired = parts[0] == "1";

            components.Add(new DataTypeComponent(order, name, isRequired, datatype));
        }

        return components;
    }

    private static string sanitizePropertyName(string name) {
        var valid = new string(name.Where(char.IsLetterOrDigit).ToArray());
        if (string.IsNullOrEmpty(valid)) valid = "field";
        return char.ToUpper(valid[0]) + valid[1..];
    }

    public static void OutputDataTypeClasses(List<DataTypeDefinition> dataTypes, Stream stream) {
        // List of types to exclude
        var excludedSimpleTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "DT", "DTM", "FT", "GTS", "ID", "IS", "NM", "SI", "SNM", "ST", "TM", "TX"
        };

        using var writer = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true);
        writer.WriteLine("namespace HL7;");
        writer.WriteLine();
        
        foreach (var dd in dataTypes) {
            if (excludedSimpleTypes.Contains(dd.Name)) continue;

            writer.WriteLine($"public sealed record {dd.Name} : Hl7ComplexType {{");
            generateProperties(dd);

            writer.WriteLine();
            generateConstructor(dd);

            writer.WriteLine("}");
            writer.WriteLine();
        }

        writer.Flush();
        return;

        void generateConstructor(DataTypeDefinition dd) {
            writer.WriteLine($"    public {dd.Name}(RawComponent rawComponent) {{");
            const string simpleBlock = """
                                               if (rawComponent.SubComponents.Length == 0) {
                                                   this.StringValue = rawComponent.ComponentValue;
                                                   this.Complexity = HL7.Complexity.Simple;
                                                   return;
                                               }
                                       """;
            writer.WriteLine(simpleBlock);
            for (var i = 0; i < dd.Components.Count; i++) {
                var comp = dd.Components[i];
                var propName = comp.Name;
                var propType = comp.DataTypeName;

                writer.WriteLine(propType == "string"
                    ? $"            {propName} = rawComponent.GetString({i + 1});"
                    : $"            {propName} = rawComponent.Get<{propType}>({i + 1});");
            }
            writer.WriteLine("    }");
        }

        void generateProperties(DataTypeDefinition dd) {
            foreach (var comp in dd.Components) {
                var propName = comp.Name;
                var propType = comp.DataTypeName + (comp.IsRequired ? "" : "?");
                writer.WriteLine($"    public {propType} {propName} {{ get; }}");
            }
        }
    }

}
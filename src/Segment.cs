using NodaTime;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7;

public record Segment {
    protected IReadOnlyList<string> RawFieldStrings { get; set; }
    public int FieldCount => RawFieldStrings.Count;

    public string Name { get; protected set; }

    public Hl7Encoding Encoding { get; protected init; }

    protected Segment() { } //used by MshSegment

    public Segment(string rawSegmentString, Hl7Encoding encoding) {
        Name = rawSegmentString[..3];
        if (Name == "MSH") throw new Hl7Exception("Use MshSegment for MSH", Hl7Exception.BadMessage);

        this.Encoding = encoding;
        this.RawFieldStrings = SplitFields(rawSegmentString, encoding.FieldDelimiter);
    }

    protected List<string> SplitFields(string value, char splitOn) {
        var fields = new List<string>();
        var sb = new StringBuilder();
        var inEscape = false;

        for (var i = 0; i < value.Length; i++) {
            var c = value[i];
            if (c == Encoding.EscapeCharacter) {
                inEscape = !inEscape;
                sb.Append(c);
                continue;
            }

            if (c == splitOn && !inEscape) {
                fields.Add(sb.ToString());
                sb.Clear();
            } else {
                sb.Append(c);
            }
        }

        fields.Add(sb.ToString());
        return fields;
    }

    public T? GetField<T>(int fieldNumber) where T : Hl7DataType {
        var fieldString = GetRawFieldString(fieldNumber);
        return parseFieldString<T>(fieldString);
    }

    public T GetRequiredField<T>(int fieldNumber) where T : Hl7DataType {
        var fieldString = GetRawFieldString(fieldNumber, isRequired: true);
        return parseFieldString<T>(fieldString)!;
    }

    public ICollection<T>? GetRepField<T>(int fieldNumber) where T : Hl7DataType {
        var fieldString = GetRawFieldString(fieldNumber);
        if (string.IsNullOrEmpty(fieldString)) return null;

        var fieldStrings = SplitFields(fieldString, Encoding.RepeatDelimiter);
        return fieldStrings.Select(s => parseFieldString<T>(s)).ToList()!;
    }

    public ICollection<T> GetRequiredRepField<T>(int fieldNumber) where T : Hl7DataType {
        var fieldString = GetRawFieldString(fieldNumber, true);
        var fieldStrings = SplitFields(fieldString!, Encoding.RepeatDelimiter);
        return fieldStrings.Select(s => parseFieldString<T>(s)).ToList()!;
    }

    public virtual string? GetRawFieldString(int fieldNumber, bool isRequired = false) {
        // HL7 rawFields are 1-based after the segment name (Components[0] is the segment name)
        if (fieldNumber < 1 || fieldNumber >= RawFieldStrings.Count) {
            if (isRequired) throw new Hl7Exception($"Field {fieldNumber} is out of range for segment {Name}.", Hl7Exception.ParsingError);

            return null;
        }

        var result = RawFieldStrings[fieldNumber];
        if (result is null && isRequired) throw new Hl7Exception($"Field {fieldNumber} is required but missing in segment {Name}.", Hl7Exception.RequiredFieldMissing);

        return result;
    }

    private T? parseFieldString<T>(string? fieldString) where T : Hl7DataType {
        if (string.IsNullOrEmpty(fieldString)) return null;

        var structure = (typeof(T).IsSubclassOf(typeof(Hl7SimpleType))) ? Hl7Structure.Hl7None : Hl7Structure.Hl7Field;
        var fieldComponent = new RawComponent(fieldString, Encoding, structure);
        return fieldComponent.Parse<T>();
    }
}

public sealed record MshSegment : Segment {
    public MshSegment(string rawSegmentString) {
        Name = rawSegmentString[..3];
        if (Name != "MSH") throw new Hl7Exception("MSH not found at the beginning of the rawSegmentString", Hl7Exception.BadMessage);

        var fieldDelimiter = rawSegmentString[3];
        var delimiterFieldEnd = rawSegmentString.IndexOf(fieldDelimiter, 4);
        if (delimiterFieldEnd < 0) throw new Hl7Exception("Invalid MSH segment: delimiter field not terminated", Hl7Exception.BadMessage);

        Encoding = new Hl7Encoding(rawSegmentString[3..delimiterFieldEnd]);
        var fields = new List<string> { "MSH" };
        fields.AddRange(SplitFields(rawSegmentString[(delimiterFieldEnd + 1)..], Encoding.FieldDelimiter));
        RawFieldStrings = fields;
    }
}
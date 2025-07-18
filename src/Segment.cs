using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7;

public record Segment {
    protected IReadOnlyList<RawField> RawFields { get; set; }
    public int FieldCount => RawFields.Count;

    public string Name { get; protected set; }

    protected Segment() { }
    
    private Segment(string name, RawField[] rawFields) {
        Name = name;
        this.RawFields = rawFields;
    }

    public static bool TryParse(Hl7Encoding encoding, string value, out Segment? segment) {
        segment = null;
        try {
            segment = Parse(encoding, value);
            return true;
        } catch {
            return false;
        }
    }

    public static Segment Parse(Hl7Encoding encoding, string value) {
        var name = value[..3];
        if (name == "MSH") throw new Hl7Exception("Use ParseMSH for MSH segment.", Hl7Exception.BadMessage);

        var strings = SplitFields(value[3..], encoding.FieldDelimiter, encoding.EscapeCharacter);
        var rawFields = strings.Select(s => new RawField(s, encoding)).ToArray();
        return new Segment(name, rawFields);
    }

    protected static List<string> SplitFields(string value, char fieldDelimiter, char escapeCharacter) {
        var fields = new List<string>();
        var sb = new StringBuilder();
        var inEscape = false;

        for (var i = 0; i < value.Length; i++) {
            var c = value[i];
            if (c == escapeCharacter) {
                inEscape = !inEscape;
                sb.Append(c);
                continue;
            }

            if (c == fieldDelimiter && !inEscape) {
                fields.Add(sb.ToString());
                sb.Clear();
            } else {
                sb.Append(c);
            }
        }

        fields.Add(sb.ToString());
        return fields;
    }

    public override int GetHashCode() => RawFields.Aggregate(17, (current, field) => current * 31 + field.GetHashCode());

    public T? GetField<T>(int fieldNumber) where T : class, IHl7DataType {
        var rawField = GetRawField(fieldNumber);
        return rawField is null ? null : parseField<T>(rawField);
    }
    
    public ICollection<T>? GetRepField<T>(int fieldNumber) where T : class, IHl7DataType {
        var rawField = GetRawField(fieldNumber);
        return rawField is null ? null : parseRepFields<T>(rawField);
    }

    public ICollection<T> GetRequiredRepField<T>(int fieldNumber) where T : class, IHl7DataType {
        var rawField = GetRawField(fieldNumber);
        return rawField is null ? [] : parseRepFields<T>(rawField);
    }

    public T GetRequiredField<T>(int fieldNumber) where T : class, IHl7DataType {
        var rawField = GetRawField(fieldNumber, isRequired: true);
        return parseField<T>(rawField!);
    }

    public RawField? GetRawField(int fieldNumber, bool isRequired = false) {
        // HL7 rawFields are 1-based after the segment name (RepeatedFields[0] is the segment name)
        if (fieldNumber < 1 || fieldNumber > RawFields.Count) {
            if (isRequired) throw new Hl7Exception($"Field {fieldNumber} is out of range for segment {Name}.", Hl7Exception.ParsingError);

            return null;
        }

        var result = RawFields[fieldNumber-1];
        if (result is null && isRequired) throw new Hl7Exception($"Field {fieldNumber} is required but missing in segment {Name}.", Hl7Exception.RequiredFieldMissing);

        return result;
    }

    private static T? parseField<T>(RawField rawField) where T : class, IHl7DataType => rawField.RawComponent?.Parse<T>(Hl7Structure.Hl7Component);

    private static ICollection<T> parseRepFields<T>(RawField rawField) where T : class, IHl7DataType => 
        rawField.RepeatedFields.Select(rf => rf.Parse<T>(Hl7Structure.Hl7Component)).ToList();
}

public sealed record MshSegment : Segment {
    public char FieldDelimiter { get; }
    public Hl7Encoding Encoding { get; }

    public MshSegment(string rawSegmentString) {
        Name = rawSegmentString[..3];
        if (Name != "MSH") throw new Hl7Exception("MSH not found at the beginning of the rawSegmentString", Hl7Exception.BadMessage);

        FieldDelimiter = rawSegmentString[3];
        var delimiterFieldEnd = rawSegmentString.IndexOf(FieldDelimiter, 4);
        if (delimiterFieldEnd < 0) throw new Hl7Exception("Invalid MSH segment: delimiter field not terminated", Hl7Exception.BadMessage);

        Encoding = Hl7Encoding.FromString(rawSegmentString[3..delimiterFieldEnd]);

        var strings = SplitFields(rawSegmentString[(delimiterFieldEnd + 1)..], Encoding.FieldDelimiter, Encoding.EscapeCharacter);
        var rawFields = strings.Select(s => new RawField(s, Encoding)).ToArray();
        RawFields = rawFields;
    }

    public new RawField? GetRawField(int fieldNumber, bool isRequired = false) {
        return base.GetRawField(fieldNumber-2, isRequired);
    }
}
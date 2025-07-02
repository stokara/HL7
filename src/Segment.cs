using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



public sealed record Segment {
    public string Name => Fields.First().Value;
    public IReadOnlyList<Field> Fields { get; init; }

    private Segment(IReadOnlyList<Field> Fields) {
        this.Fields = Fields;
    }

    public static Segment Parse(Hl7Encoding encoding, string value, int sequenceNo = 0) {
        try {
            var isMshSegment = value[..3] == "MSH";
            var rawFields = splitFields(isMshSegment ? value[9..] : value, encoding.FieldDelimiter,
                encoding.EscapeCharacter);
            var fields = new List<Field>(rawFields.Count + (isMshSegment ? 2 : 0));

            if (isMshSegment) {
                fields.Add(Field.Parse(encoding, "MSH"));
                fields.Add(Field.CreateDelimiterField(value[4..8]));
            }

            fields.AddRange(rawFields.Select(strField => Field.Parse(encoding, strField)));
            return new Segment(fields.AsReadOnly());
        } catch (Exception ex) {
            throw;
        }
    }

    private static List<string> splitFields(string value, char fieldDelimiter, char escapeCharacter) {
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

    public string Serialize(Hl7Encoding encoding) {
        StringBuilder sb = new();
        for (var i = 0; i < this.Fields.Count; i++) {
            if (i > 0) sb.Append(encoding.FieldDelimiter);

            var field = this.Fields[i];

            if (field.IsDelimitersField) {
                sb.Append(field.Value);
                continue;
            }

            if (field.HasRepetitions) {
                for (var j = 0; j < field.Repetitions!.Count; j++) {
                    if (j > 0) sb.Append(encoding.RepeatDelimiter);
                    sb.Append(field.Repetitions[j].Serialize(encoding));
                }
            } else sb.Append(field.Serialize(encoding));
        }

        sb.Append(encoding.SegmentDelimiter);
        return sb.ToString();
    }

    public bool Equals(Segment? other) {
        if (ReferenceEquals(this, other)) return true;
        if (other is null) return false;
        if (Fields.Count != other.Fields.Count) return false;
        var diff = Fields.Where((t, i) => !t.Equals(other.Fields[i]));
        var result = !diff.Any();
        return result;
    }

    public override int GetHashCode() => Fields.Aggregate(17, (current, field) => current * 31 + field.GetHashCode());
}
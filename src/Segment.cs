using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7;

public sealed record Segment {
    private readonly Field[] fields;
    public string Name => fields[0].Value;
    public IReadOnlyList<Field> Fields => fields;

    private Segment(Field[] fields) {
        this.fields = fields;
    }

    public static bool TryParse(HL7Encoding encoding, string value, out Segment? segment, int sequenceNo = 0) {
        segment = null;
        try {
            segment = Parse(encoding, value, sequenceNo);
            return true;
        } catch {
            return false;
        }
    }

    public static Segment Parse(HL7Encoding encoding, string value, int sequenceNo = 0) {
        if (value.StartsWith("MSH", StringComparison.Ordinal)) throw new HL7Exception("Use ParseMSH for MSH segment.", HL7Exception.BadMessage);
        var rawFields = splitFields(value, encoding.FieldDelimiter, encoding.EscapeCharacter);
        var fields = new Field[rawFields.Count];
        for (int i = 0; i < rawFields.Count; i++) {
            fields[i] = Field.Parse(encoding, rawFields[i]);
        }
        return new Segment(fields);
    }

    public static (Segment mshSegment, HL7Encoding encoding) ParseMSH(string value, int sequenceNo = 0) {
        if (!value.StartsWith("MSH", StringComparison.Ordinal)) throw new HL7Exception("MSH segment not found at the beginning of the message", HL7Exception.BadMessage);
        var fieldDelimiter = value[3];
        var delimiterFieldEnd = value.IndexOf(fieldDelimiter, 4);
        if (delimiterFieldEnd < 0) throw new HL7Exception("Invalid MSH segment: delimiter field not terminated", HL7Exception.BadMessage);

        var delimiterField = value[3..delimiterFieldEnd];
        var encoding = HL7Encoding.FromString(delimiterField);
        var remainingStr = value[(delimiterFieldEnd + 1)..];

        var fields = new List<Field> {
            Field.Parse(encoding, "MSH"),
            Field.CreateDelimiterField(delimiterField)
        };
        var rawFields = splitFields(remainingStr, encoding.FieldDelimiter, encoding.EscapeCharacter);
        fields.AddRange(rawFields.Select(f => Field.Parse(encoding, f)));
        var mshSegment = new Segment(fields.ToArray());
        return (mshSegment, encoding);
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

    public string Serialize(HL7Encoding encoding) {
        StringBuilder sb = new();
        for (var i = 0; i < this.Fields.Count; i++) {
            var field = this.Fields[i];

            if (field.IsDelimitersField) {
                sb.Append(field.Value);
                continue;
            }

            if (i > 0) sb.Append(encoding.FieldDelimiter);

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

    public Field? GetField(int fieldNumber) {
        int index = fieldNumber - 1;
        if (index < 0 || index >= Fields.Count) return null;
        return Fields[index];
    }
}
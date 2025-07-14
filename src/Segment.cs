using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodaTime;

namespace HL7;

public sealed record Segment {
    public string Name => fields[0].StringValue;
    public IReadOnlyList<Field> Fields => fields;

    private readonly Field[] fields;
    public Hl7Encoding HL7Encoding { get; }

    private Segment(Hl7Encoding HL7Encoding, Field[] fields) {
        this.fields = fields;
        this.HL7Encoding = HL7Encoding;
    }

    public static bool TryParse(Hl7Encoding encoding, string value, out Segment? segment, int sequenceNo = 0) {
        segment = null;
        try {
            segment = Parse(encoding, value, sequenceNo);
            return true;
        } catch {
            return false;
        }
    }

    public static Segment Parse(Hl7Encoding encoding, string value, int sequenceNo = 0) {
        if (value.StartsWith("MSH", StringComparison.Ordinal)) throw new Hl7Exception("Use ParseMSH for MSH segment.", Hl7Exception.BadMessage);

        var rawFields = splitFields(value, encoding.FieldDelimiter, encoding.EscapeCharacter);
        var fields = new Field[rawFields.Count];
        for (var i = 0; i < rawFields.Count; i++) {
            fields[i] = Field.Parse(encoding, rawFields[i]);
        }

        return new Segment(encoding, fields);
    }

    public static (Segment mshSegment, Hl7Encoding encoding) ParseMSH(string value, int sequenceNo = 0) {
        if (!value.StartsWith("MSH", StringComparison.Ordinal)) throw new Hl7Exception("MSH segment not found at the beginning of the message", Hl7Exception.BadMessage);

        var fieldDelimiter = value[3];
        var delimiterFieldEnd = value.IndexOf(fieldDelimiter, 4);
        if (delimiterFieldEnd < 0) throw new Hl7Exception("Invalid MSH segment: delimiter field not terminated", Hl7Exception.BadMessage);

        var delimiterField = value[3..delimiterFieldEnd];
        var encoding = Hl7Encoding.FromString(delimiterField);
        var remainingStr = value[(delimiterFieldEnd + 1)..];

        var fields = new List<Field> {
            Field.Parse(encoding, "MSH"),
            Field.CreateDelimiterField(delimiterField)
        };
        var rawFields = splitFields(remainingStr, encoding.FieldDelimiter, encoding.EscapeCharacter);
        fields.AddRange(rawFields.Select(f => Field.Parse(encoding, f)));
        var mshSegment = new Segment(encoding, fields.ToArray());
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

    //public string Serialize(Hl7Encoding Hl7Encoding) {
    //    StringBuilder sb = new();
    //    for (var i = 0; i < this.Fields.Count; i++) {
    //        var field = this.Fields[i];

    //        if (field.IsDelimitersField) {
    //            sb.Append(field.StringValue);
    //            continue;
    //        }

    //        if (i > 0) sb.Append(Hl7Encoding.FieldDelimiter);

    //        if (field.HasRepetitions) {
    //            for (var j = 0; j < field.Repetitions!.Count; j++) {
    //                if (j > 0) sb.Append(Hl7Encoding.RepeatDelimiter);
    //                sb.Append(field.Repetitions[j].Serialize(Hl7Encoding));
    //            }
    //        } else sb.Append(field.Serialize(Hl7Encoding));
    //    }

    //    sb.Append(Hl7Encoding.SegmentDelimiter);
    //    return sb.ToString();
    //}

    public bool Equals(Segment? other) {
        if (ReferenceEquals(this, other)) return true;
        if (other is null) return false;
        if (Fields.Count != other.Fields.Count) return false;

        var diff = Fields.Where((t, i) => !t.Equals(other.Fields[i]));
        var result = !diff.Any();
        return result;
    }

    public override int GetHashCode() => Fields.Aggregate(17, (current, field) => current * 31 + field.GetHashCode());

    public T? GetField<T>(int fieldNumber) where T : class, IHl7DataType {
        var field = GetField(fieldNumber);
        return field is null ? null : IHl7Field<T>.Parse(field, HL7Encoding);
    }

    public T GetRequiredField<T>(int fieldNumber) where T : class, IHl7DataType {
        var field = GetField(fieldNumber, isRequired: true);
        return IHl7Field<T>.Parse(field!, HL7Encoding);
    }
    
    public RepField<T> GetRepField<T>(int fieldNumber) where T : class, IHl7DataType {
        var field = GetField(fieldNumber);
        if (field is null) return new RepField<T>([]);
        if (!field.HasRepetitions) {
            var singleItem = IHl7Field<T>.Parse(field, HL7Encoding);
            return new RepField<T>([singleItem]);
        }
        var items = field.Repetitions!.Select(repetition => IHl7Field<T>.Parse(repetition, HL7Encoding)).ToArray();
        return new RepField<T>(items);
    }

    public Field? GetField(int fieldNumber, bool isRequired = false) {
        // HL7 fields are 1-based after the segment name (Fields[0] is the segment name)
        if (fieldNumber < 1 || fieldNumber >= Fields.Count) {
            if (isRequired) throw new Hl7Exception($"Field {fieldNumber} is out of range for segment {Name}.", Hl7Exception.ParsingError);

            return null;
        }

        var result = Fields[fieldNumber];
        if (result is null && isRequired) throw new Hl7Exception($"Field {fieldNumber} is required but missing in segment {Name}.", Hl7Exception.RequiredFieldMissing);

        return result;
    }

    public string GetFieldString(int fieldNumber, bool isRequired = false) {
        var field = GetField(fieldNumber, isRequired);
        return field is null ? string.Empty : field.StringValue;
    }

    public Instant? GetFieldInstant(int fieldNumber) {
        var field = GetField(fieldNumber);
        return string.IsNullOrWhiteSpace(field?.StringValue) ? null : Hl7DateParser.ParseInstant(field.StringValue);
    }

    public Instant GetRequiredFieldInstant(int fieldNumber) {
        var field = getRequiredField(fieldNumber);
        return Hl7DateParser.ParseInstant(field.StringValue, true)!.Value;
    }

    public int? GetFieldInt(int fieldNumber) {
        var field = GetField(fieldNumber);
        return string.IsNullOrWhiteSpace(field?.StringValue) ? null : Int32.Parse(field.StringValue);
    }

    public int GetRequiredFieldInt(int fieldNumber) {
        var field = getRequiredField(fieldNumber);
        return Int32.Parse(field.StringValue);
    }

    private Field getRequiredField(int fieldNumber) {
        var field = GetField(fieldNumber, true);
        if (string.IsNullOrWhiteSpace(field?.StringValue))
            throw new Hl7Exception($"Field {fieldNumber} is required but missing in segment {Name}.", Hl7Exception.RequiredFieldMissing);

        return field;
    }

    public decimal? GetFieldDecimal(int fieldNumber) {
        var field = GetField(fieldNumber);
        return string.IsNullOrWhiteSpace(field?.StringValue) ? null : decimal.Parse(field.StringValue);
    }

    public decimal GetRequiredFieldDecimal(int fieldNumber) {
        var field = getRequiredField(fieldNumber);
        return decimal.Parse(field.StringValue);
    }
}
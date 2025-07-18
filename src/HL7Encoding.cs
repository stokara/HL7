using System;
using System.Linq;
using System.Text;

namespace HL7;

public record Hl7Encoding {
    public char FieldDelimiter { get; init; }
    public char ComponentDelimiter { get; init; }
    public char RepeatDelimiter { get; init; }
    public char EscapeCharacter { get; init; }
    public char SubComponentDelimiter { get; init; }
    public string SegmentDelimiter { get; init; }
    public string PresentButNull { get; init; }

    private static readonly string[] SegmentDelimiters = ["\r\n", "\n\r", "\r", "\n"];

    public Hl7Encoding(char fieldDelimiter, char componentDelimiter, char repeatDelimiter, char escapeCharacter,
        char subComponentDelimiter, string segmentDelimiter = "\r", string presentButNull = "\"\"") {
        FieldDelimiter = fieldDelimiter;
        ComponentDelimiter = componentDelimiter;
        RepeatDelimiter = repeatDelimiter;
        EscapeCharacter = escapeCharacter;
        SubComponentDelimiter = subComponentDelimiter;
        SegmentDelimiter = segmentDelimiter;
        PresentButNull = presentButNull;
    }
    
    public string GetDelimiter(Hl7Structure structure) {
        return structure switch {
            Hl7Structure.Hl7Segment => SegmentDelimiter,
            Hl7Structure.Hl7Field => FieldDelimiter.ToString(),
            Hl7Structure.Hl7RepField => RepeatDelimiter.ToString(),
            Hl7Structure.Hl7Component => ComponentDelimiter.ToString(),
            Hl7Structure.Hl7SubComponent => SubComponentDelimiter.ToString(),
            Hl7Structure.Hl7None => "",
            _ => throw new ArgumentOutOfRangeException(nameof(structure), structure, null)
        };
    }
    
    public static Hl7Encoding FromString(string delimiters) {
        var fieldDelimiter = delimiters[0];
        var componentDelimiter = delimiters[1];
        var repeatDelimiter = delimiters[2];
        var escapeCharacter = delimiters[3];
        var subComponentDelimiter = delimiters[4];
        var segmentDelimiter = SegmentDelimiters.FirstOrDefault(delimiters.Contains) ?? "\r\n";
        return new Hl7Encoding(fieldDelimiter, componentDelimiter, repeatDelimiter, escapeCharacter,
            subComponentDelimiter, segmentDelimiter);
    }

    public string Encode(string? val) {
        if (string.IsNullOrEmpty(val)) return ""; //May need a value for PresentButNull

        var sb = new StringBuilder();

        for (var i = 0; i < val.Length; i++) {
            var c = val[i];

            if (c == EscapeCharacter) {
                int end = val.IndexOf(EscapeCharacter, i + 1);
                if (end > i + 1) {
                    // Copy the escape sequence as-is
                    sb.Append(val, i, end - i + 1);
                    i = end;
                    continue;
                }
            }

            var continueEncoding = true;
            if (c == '<') {
                continueEncoding = false;
                // special case <B>
                if (val.Length >= i + 3 && val[i + 1] == 'B' && val[i + 2] == '>') {
                    appendUsingEscape("H");
                    i += 2;
                }
                // special case </B>
                else if (val.Length >= i + 4 && val[i + 1] == '/' && val[i + 2] == 'B' && val[i + 3] == '>') {
                    appendUsingEscape("N");
                    i += 3;
                }
                // special case <BR>
                else if (val.Length >= i + 4 && val[i + 1] == 'B' && val[i + 2] == 'R' && val[i + 3] == '>') {
                    appendUsingEscape(".br");
                    i += 3;
                } else {
                    continueEncoding = true;
                }
            }

            if (!continueEncoding) continue;

            if (c == ComponentDelimiter) appendUsingEscape("S");
            else if (c == EscapeCharacter) appendUsingEscape("E");
            else if (c == FieldDelimiter) appendUsingEscape("F");
            else if (c == RepeatDelimiter) appendUsingEscape("R");
            else if (c == SubComponentDelimiter) appendUsingEscape("T");
            else if (c == 10 || c == 13) // All other non-visible characters will be preserved
            {
                var v = $"{(int)c:X2}";
                if ((v.Length % 2) != 0)
                    v = "0" + v; // make number of digits even, this test would only be needed for values > 0xFF
                sb.Append($"{this.EscapeCharacter}X{v}{this.EscapeCharacter}");
            } else if (c < 32 || c > 126) {
                // non-printable or non-ASCII
                var bytes = Encoding.UTF8.GetBytes(new[] { c });
                var hex = BitConverter.ToString(bytes).Replace("-", "");
                appendUsingEscape("X" + hex);
            } else sb.Append(c);
        }

        return sb.ToString();

        void appendUsingEscape(string code) {
            sb.Append(EscapeCharacter);
            sb.Append(code);
            sb.Append(EscapeCharacter);
        }
    }

    public string Decode(string encodedValue) {
        if (string.IsNullOrWhiteSpace(encodedValue) || !encodedValue.Contains(EscapeCharacter)) return encodedValue;

        var result = new StringBuilder(encodedValue.Length);
        var i = 0;
        while (i < encodedValue.Length) {
            var c = encodedValue[i];

            if (c != EscapeCharacter) {
                result.Append(c);
                i++;
                continue;
            }

            // Find the next escape character
            var end = encodedValue.IndexOf(EscapeCharacter, i + 1);
            if (end == -1) {
                // Malformed escape, append the rest as-is
                result.Append(encodedValue, i, encodedValue.Length - i);
                break;
            }

            var seq = encodedValue.Substring(i + 1, end - i - 1);
            i = end + 1;

            if (seq.Length == 0) continue;

            switch (seq) {
                case "H":
                    result.Append("<B>");
                    break;
                case "N":
                    result.Append("</B>");
                    break;
                case "F":
                    result.Append(FieldDelimiter);
                    break;
                case "S":
                    result.Append(ComponentDelimiter);
                    break;
                case "T":
                    result.Append(SubComponentDelimiter);
                    break;
                case "R":
                    result.Append(RepeatDelimiter);
                    break;
                case "E":
                    result.Append(EscapeCharacter);
                    break;
                case ".br":
                    result.Append("<BR>");
                    break;
                default:
                    if (seq.Length > 1 && seq[0] == 'X')
                        result.Append(DecodeHexString(seq.Substring(1)));
                    else
                        result.Append(seq);
                    break;
            }
        }

        return result.ToString();
    }

    public static string DecodeHexString(string hex) {
        var numberChars = hex.Length;
        var bytes = new byte[numberChars / 2];

        for (var i = 0; i < numberChars; i += 2) bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);

        string str;
        if (bytes.Length == 1) str = char.ConvertFromUtf32(bytes[0]);
        else if (bytes.Length == 2 && bytes[0] == 0) str = char.ConvertFromUtf32(bytes[1]);
        else str = Encoding.UTF8.GetString(bytes);

        return str;
    }

    //  |^~\&
    public override string ToString() => $"{FieldDelimiter}{ComponentDelimiter}{RepeatDelimiter}{EscapeCharacter}{SubComponentDelimiter}";
}

public static class HL7EncodingExtensions {
    public static string GetDelimiter(this Hl7Encoding encoding, Hl7Structure structure) => encoding.GetDelimiter(structure);
}

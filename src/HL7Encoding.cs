using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7;

public record Hl7Encoding {
    public char FieldDelimiter { get; init; }
    public char ComponentDelimiter { get; init; }
    public char RepeatDelimiter { get; init; }
    public char EscapeCharacter { get; init; }
    public char SubComponentDelimiter { get; init; }
    public char? TruncationDelimiter { get; init; }
    public string SegmentDelimiter { get; init; }

    private static readonly string[] SegmentDelimiters = ["\r\n", "\n\r", "\r", "\n"];

    public Hl7Encoding(char fieldDelimiter, char componentDelimiter, char repeatDelimiter, char escapeCharacter,
        char subComponentDelimiter, string segmentDelimiter = "\r",  char? truncationDelimiter = null) {
        FieldDelimiter = fieldDelimiter;
        ComponentDelimiter = componentDelimiter;
        RepeatDelimiter = repeatDelimiter;
        EscapeCharacter = escapeCharacter;
        SubComponentDelimiter = subComponentDelimiter;
        SegmentDelimiter = segmentDelimiter;
        TruncationDelimiter = truncationDelimiter;
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
        var truncationDelimiter = (delimiters.Length >= 6) ? delimiters[5] : (char?)null;
        var segmentDelimiter = SegmentDelimiters.FirstOrDefault(delimiters.Contains) ?? "\r\n";
        return new Hl7Encoding(delimiters[0], delimiters[1], delimiters[2], delimiters[3], delimiters[4], segmentDelimiter, truncationDelimiter: truncationDelimiter);
    }

    public string Encode(string? val) {
        if (string.IsNullOrEmpty(val)) return "";

        var sb = new StringBuilder();

        for (var i = 0; i < val.Length; i++) {
            var c = val[i];

            if (isEscapeSequence(val, i, out int end)) {
                sb.Append(val, i, end - i + 1);
                i = end;
                continue;
            }

            if (tryEncodeSpecialTag(val, i, sb, out int skip)) {
                i += skip;
                continue;
            }

            if (tryEncodeDelimiter(c, sb)) continue;
            if (tryEncodeControlChar(c, sb)) continue;
            if (tryEncodeNonAscii(c, sb)) continue;
            sb.Append(c);
        }

        return sb.ToString();

        bool isEscapeSequence(string val, int index, out int end) {
            end = -1;
            if (val[index] == EscapeCharacter) {
                end = val.IndexOf(EscapeCharacter, index + 1);
                return end > index + 1;
            }
            return false;
        }

        bool tryEncodeSpecialTag(string val, int index, StringBuilder sb, out int skip) {
            skip = 0;
            if (val[index] != '<') return false;

            if (val.Length >= index + 3 && val[index + 1] == 'B' && val[index + 2] == '>') {
                appendUsingEscape(sb, "H");
                skip = 2;
                return true;
            }
            if (val.Length >= index + 4 && val[index + 1] == '/' && val[index + 2] == 'B' && val[index + 3] == '>') {
                appendUsingEscape(sb, "N");
                skip = 3;
                return true;
            }
            if (val.Length >= index + 4 && val[index + 1] == 'B' && val[index + 2] == 'R' && val[index + 3] == '>') {
                appendUsingEscape(sb, ".br");
                skip = 3;
                return true;
            }
            return false;
        }

        bool tryEncodeDelimiter(char c, StringBuilder sb) {
            if (c == ComponentDelimiter) { appendUsingEscape(sb, "S"); return true; }
            if (c == EscapeCharacter)    { appendUsingEscape(sb, "E"); return true; }
            if (c == FieldDelimiter)     { appendUsingEscape(sb, "F"); return true; }
            if (c == RepeatDelimiter)    { appendUsingEscape(sb, "R"); return true; }
            if (c == SubComponentDelimiter) { appendUsingEscape(sb, "T"); return true; }
            return false;
        }

        bool tryEncodeControlChar(char c, StringBuilder sb) {
            if (c == 10 || c == 13) {
                var v = $"{(int)c:X2}";
                if ((v.Length % 2) != 0) v = "0" + v;
                sb.Append($"{EscapeCharacter}X{v}{EscapeCharacter}");
                return true;
            }
            return false;
        }

        bool tryEncodeNonAscii(char c, StringBuilder sb) {
            if (c < 32 || c > 126) {
                var bytes = Encoding.UTF8.GetBytes(new[] { c });
                var hex = BitConverter.ToString(bytes).Replace("-", "");
                appendUsingEscape(sb, "X" + hex);
                return true;
            }
            return false;
        }

        void appendUsingEscape(StringBuilder sb, string code) {
            sb.Append(EscapeCharacter);
            sb.Append(code);
            sb.Append(EscapeCharacter);
        }
    }

    public string? Decode(string? encodedValue) {
        if (string.IsNullOrWhiteSpace(encodedValue) || !encodedValue.Contains(EscapeCharacter))
            return encodedValue;

        var result = new StringBuilder(encodedValue.Length);
        var i = 0;

        while (i < encodedValue.Length) {
            var c = encodedValue[i];

            if (c != EscapeCharacter) {
                result.Append(c);
                i++;
                continue;
            }

            var end = encodedValue.IndexOf(EscapeCharacter, i + 1);
            if (end == -1) {
                result.Append(encodedValue, i, encodedValue.Length - i);
                break;
            }

            var seq = encodedValue.Substring(i + 1, end - i - 1);
            i = end + 1;

            if (seq.Length == 0) continue;

            if (!tryHandleEscapeSequence(seq, result)) {
                // Unknown escape sequence, append as-is
                result.Append(EscapeCharacter).Append(seq).Append(EscapeCharacter);
            }
        }

        return result.ToString();
    }

    private bool tryHandleEscapeSequence(string seq, StringBuilder result) {
        // Dictionary for simple escape codes
        var escapeActions = new Dictionary<string, Action> {
            ["H"]    = () => result.Append("<B>"),
            ["N"]    = () => result.Append("</B>"),
            ["F"]    = () => result.Append(FieldDelimiter),
            ["S"]    = () => result.Append(ComponentDelimiter),
            ["T"]    = () => result.Append(SubComponentDelimiter),
            ["R"]    = () => result.Append(RepeatDelimiter),
            ["E"]    = () => result.Append(EscapeCharacter),
            [".br"]  = () => result.Append("<BR>")
        };

        if (escapeActions.TryGetValue(seq, out var action)) {
            action();
            return true;
        }

        if (seq.Length > 1 && seq[0] == 'X') {
            result.Append(DecodeHexString(seq.Substring(1)));
            return true;
        }

        return false;
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
    public override string ToString() => $"{FieldDelimiter}{ComponentDelimiter}{RepeatDelimiter}{EscapeCharacter}{SubComponentDelimiter}{(TruncationDelimiter is null ? "" : TruncationDelimiter)}";
}

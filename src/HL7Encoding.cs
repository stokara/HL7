using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7;

public record Hl7Encoding(
    char FieldDelimiter,
    char ComponentDelimiter,
    char RepeatDelimiter,
    char EscapeCharacter,
    char SubComponentDelimiter,
    string SegmentDelimiter = "\r",
    char? TruncationDelimiter = null) {
    private static readonly string[] SegmentDelimiters = ["\r\n", "\n\r", "\r", "\n"];

    public Hl7Encoding(string delimiters) : this(delimiters[0], delimiters[1], delimiters[2], delimiters[3], delimiters[4], 
                                                SegmentDelimiters.FirstOrDefault(delimiters.Contains) ?? "\r\n", 
                                                (delimiters.Length >= 6) ? delimiters[5] : null) { }

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

    public string Encode(string? val) {
        if (string.IsNullOrEmpty(val)) return "";
        var sb = new StringBuilder();
        var index = 0;
        for (; index < val.Length; index++) {
            var c = val[index];

            if (isEscapeSequence(out int end)) {
                sb.Append(val, index, end - index + 1);
                index = end;
                continue;
            }
            if (tryEncodeSpecialTag(out int skip)) {
                index += skip;
                continue;
            }
            if (tryEncodeDelimiter(c)) continue;
            if (tryEncodeControlChar(c)) continue;
            if (tryEncodeNonAscii(c)) continue;

            sb.Append(c);
        }
        return sb.ToString();

        bool isEscapeSequence(out int end) {
            end = -1;
            if (val[index] == EscapeCharacter) {
                end = val.IndexOf(EscapeCharacter, index + 1);
                return end > index + 1;
            }
            return false;
        }

        bool tryEncodeSpecialTag(out int skip) {
            skip = 0;
            if (val[index] != '<') return false;

            if (val.Length >= index + 3 && val[index + 1] == 'B' && val[index + 2] == '>') {
                appendUsingEscape("H");
                skip = 2;
                return true;
            }

            if (val.Length >= index + 4 && val[index + 1] == '/' && val[index + 2] == 'B' && val[index + 3] == '>') {
                appendUsingEscape("N");
                skip = 3;
                return true;
            }

            if (val.Length >= index + 4 && val[index + 1] == 'B' && val[index + 2] == 'R' && val[index + 3] == '>') {
                appendUsingEscape(".br");
                skip = 3;
                return true;
            }
            return false;
        }

        bool tryEncodeDelimiter(char c) {
            if (c == ComponentDelimiter) {
                appendUsingEscape("S");
                return true;
            }

            if (c == EscapeCharacter) {
                appendUsingEscape("E");
                return true;
            }

            if (c == FieldDelimiter) {
                appendUsingEscape("F");
                return true;
            }

            if (c == RepeatDelimiter) {
                appendUsingEscape("R");
                return true;
            }

            if (c == SubComponentDelimiter) {
                appendUsingEscape("T");
                return true;
            }

            return false;
        }

        bool tryEncodeControlChar(char c) {
            if (c == 10 || c == 13) {
                var v = $"{(int)c:X2}";
                if ((v.Length % 2) != 0) v = "0" + v;
                sb.Append($"{EscapeCharacter}X{v}{EscapeCharacter}");
                return true;
            }

            return false;
        }

        bool tryEncodeNonAscii(char c) {
            if (c < 32 || c > 126) {
                var bytes = Encoding.UTF8.GetBytes(new[] { c });
                var hex = BitConverter.ToString(bytes).Replace("-", "");
                appendUsingEscape("X" + hex);
                return true;
            }
            return false;
        }

        void appendUsingEscape(string code) {
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
            ["H"] = () => result.Append("<B>"),
            ["N"] = () => result.Append("</B>"),
            ["F"] = () => result.Append(FieldDelimiter),
            ["S"] = () => result.Append(ComponentDelimiter),
            ["T"] = () => result.Append(SubComponentDelimiter),
            ["R"] = () => result.Append(RepeatDelimiter),
            ["E"] = () => result.Append(EscapeCharacter),
            [".br"] = () => result.Append("<BR>")
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
    public override string ToString() =>
        $"{FieldDelimiter}{ComponentDelimiter}{RepeatDelimiter}{EscapeCharacter}{SubComponentDelimiter}{(TruncationDelimiter is null ? "" : TruncationDelimiter)}";
}
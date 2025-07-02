using System;
using System.IO;

public static class SegmentLoader {
    public static object Load(Segment segment) {
        if (segment == null) throw new ArgumentNullException(nameof(segment));

        return segment.Name switch {
            "PID" => PID.Load(segment),
            "PV1" => PV1.Load(segment),
            "IN1" => IN1.Load(segment),
            "IN2" => IN2.Load(segment),
            "FT1" => FT1.Load(segment),
            "NTE" => NTE.Load(segment),
            "QBE" => QBE.Load(segment),
            "QRC" => QRC.Load(segment),
            _ => throw new InvalidDataException($"Unknown segment type: {segment.Name}")
        };
    }
}
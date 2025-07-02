using System;
using System.Collections.Generic;
using System.IO;

public static class SegmentLoader {
    private static readonly Dictionary<string, Func<Segment, HL7Data>> registry = new();

    public static void Register(string segmentName, Func<Segment, HL7Data> factory) {
        registry[segmentName] = factory;
    }

    public static HL7Data Create(Segment segment) {
        if (segment == null) throw new ArgumentNullException(nameof(segment));
        if (registry.TryGetValue(segment.Name, out var factory)) return factory(segment); 
        throw new InvalidDataException($"Unknown segment type: {segment.Name}");
    }
}
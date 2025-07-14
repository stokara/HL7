using System;
using System.IO;

namespace HL7;

public interface IHl7Segment {
    Type SegmentType { get; }
}

public abstract record Hl7Segment : IHl7Segment {
    public Type SegmentType { get; }
    protected Hl7Segment(Type segmentType, Segment segment) {
        SegmentType = segmentType;
        if (segment.Name != SegmentType.Name) {
            throw new InvalidDataException($"Invalid Segment when loading {segmentType.Name} using is {segment.Name}");
        }
    }
}
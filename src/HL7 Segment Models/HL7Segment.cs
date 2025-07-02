using System.IO;

public abstract record HL7Data  {
    public abstract string Name { get; }

    protected HL7Data(Segment segment) {
        if (segment.Name != Name) throw new InvalidDataException($"Invalid Segment - Secondary Insurance Data is in IN2 Segment, this is {segment.Name}");
    }
}

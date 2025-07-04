using System.IO;

namespace HL7;

public interface IHL7Data {}

public abstract record HL7Data<T> : IHL7Data {
    protected HL7Data(Segment segment) {
        if (segment.Name != typeof(T).Name) throw new InvalidDataException($"Invalid Segment when loading {typeof(T).Name}, this is {segment.Name}");
    }
}
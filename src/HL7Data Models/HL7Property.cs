using System;
using System.Collections.Generic;
using System.Linq;

namespace HL7;
#if false
//Property that can either be a single value T or a collection of values of T.
public record HL7Property<T> where T : IComposite {
    public T? SingleItem => Items.FirstOrDefault();
    public IReadOnlyList<T> Items { get; }
    public int Count => Items.Count;
    public bool IsEmpty => !Items.Any();

    public HL7Property(IEnumerable<T> Items) {
        this.Items = Items.ToList();
    }

    public HL7Property(T item) : this([item]) { }

    public static HL7Property<T> CreateHL7Property(Segment segment, int fieldNumber, Func<Field, T> factory, bool isRequired = false)  {
        var field = segment.GetField(fieldNumber, isRequired);
        if (field is null) return new HL7Property<T>([factory(null)]);
        return field.HasRepetitions
            ? new HL7Property<T>(field.Repetitions!.Select(factory).ToArray())
            : new HL7Property<T>([factory(field)]);
    }


    public static HL7Property<T> CreateHL7Component(Field field, int componentIndex, Func<Component, T> factory, bool isRequired = false) {
        var component = field.segment.GetField(fieldNumber, isRequired);
        if (field is null)
            return new HL7Property<T>([factory(null)]);
        return field.HasRepetitions
            ? new HL7Property<T>(field.Repetitions!.Select(factory).ToArray())
            : new HL7Property<T>([factory(field)]);
    }
}
#endif
using System.Collections.Generic;
using System.Linq;

namespace HL7;

public record HL7Property<T> where T : IComposite {
    public T? SingleItem => Items.FirstOrDefault();
    public IReadOnlyList<T> Items { get; }
    public int Count => Items.Count;
    public bool IsEmpty => !Items.Any();

    public HL7Property(IEnumerable<T> Items) {
        this.Items = Items.ToList();
    }

    public HL7Property(T item) : this([item]) { }
}
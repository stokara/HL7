using System;
using System.Collections.Generic;
using System.Linq;

namespace HL7;

public interface IHl7Value { }

public abstract record Hl7Value<T> : Hl7ComplexType, IHl7Value where T : class, IHl7DataType {
    public T Value { get; init; } = null!;
    protected Hl7Value(Hl7Structure structure) : base(structure) { }
    protected Hl7Value(T value, Hl7Structure structure) : this(structure) => Value = value;

    public override string Serialize(Hl7Encoding encoding, Hl7Structure? sourceStructure = null) {
        var props = this.GetProperties().Select(p => p.GetValue(this)).ToArray();
        if (props.Select(v => (v as Hl7DataType)?.Complexity).Any(c => c == HL7.Complexity.Simple)) {
            var nonEmpty = props.Select(v => (v as Hl7DataType)?.StringValue).Where(s=> !string.IsNullOrEmpty(s)).ToArray();
            if (nonEmpty.Length == 0) return string.Empty;
            if (nonEmpty.Length == 1) return nonEmpty.Single();
        }
        return string.Join(encoding.ComponentDelimiter, props.Select(v => (v as Hl7DataType)?.Serialize(encoding, Hl7Structure.Hl7Field) ?? string.Empty));
    }
}

public sealed record Hl7RepField<T> : Hl7Value<T> where T : class, IHl7DataType {
    public IReadOnlyList<T> Repetitions { get; }
    public bool HasRepetitions => Repetitions.Count > 0;

    public Hl7RepField(IReadOnlyList<T> repetitions) : base(Hl7Structure.Hl7Field) {
        Repetitions = repetitions ?? throw new ArgumentNullException(nameof(repetitions));
    }
    
    public override string Serialize(Hl7Encoding encoding, Hl7Structure? _) {
        if (Repetitions.Count == 0) return string.Empty;
        return string.Join(encoding.RepeatDelimiter.ToString(), Repetitions.Select(r => r.Serialize(encoding, Hl7Structure.Hl7Field)));
    }
}


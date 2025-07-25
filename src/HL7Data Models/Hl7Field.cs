﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HL7;

public interface IHl7Value { }

public abstract record Hl7Value<T> : Hl7ComplexType, IHl7Value where T : Hl7DataType {
    public T Value { get; init; } = null!;
    protected Hl7Value()  { }
    protected Hl7Value(T value) => Value = value;

    public override string Serialize(Hl7Encoding encoding, Hl7Structure structure) {
        var props = this.GetProperties()
            .Select(p => (Hl7DataType)p.GetValue(this)!)
            .ToArray();
        if (tryGetSimpleResult(props, out var simpleResult)) return simpleResult;
       
        var strings = props.Select(v => v.Serialize(encoding, Hl7Structure.Hl7Field));
        return string.Join(encoding.ComponentDelimiter, strings );
        
        static bool tryGetSimpleResult(Hl7DataType[] props, out string simpleResult) {
            var nonEmptyCount = 0;
            simpleResult = string.Empty;
            foreach (var item in props) {
                if (item.Complexity == HL7.Complexity.Complex) return false;
                if (!string.IsNullOrEmpty(item.StringValue)) {
                    if (nonEmptyCount++ > 1) return false;
                    simpleResult = item.StringValue!;
                }
            }
            return true;
        }
    }
}

public sealed record Hl7RepField<T> : Hl7Value<T> where T : Hl7DataType {
    public IReadOnlyList<T> Repetitions { get; }
    public bool HasRepetitions => Repetitions.Count > 0;

    public Hl7RepField(IReadOnlyList<T> repetitions) {
        Repetitions = repetitions ?? throw new ArgumentNullException(nameof(repetitions));
    }
    
    public override string Serialize(Hl7Encoding encoding, Hl7Structure structure) {
        if (Repetitions.Count == 0) return string.Empty;
        return string.Join(encoding.RepeatDelimiter.ToString(), Repetitions.Select(r => r.Serialize(encoding, Hl7Structure.Hl7Field)));
    }
}


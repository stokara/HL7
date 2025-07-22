using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HL7;

public enum Hl7Structure {
    Hl7Segment,
    Hl7RepField,
    Hl7Field,
    Hl7Component,
    Hl7SubComponent,
    Hl7None
}

public enum Complexity {
    Complex,
    Simple,
}

public abstract record Hl7DataType {
    public string? StringValue { get; init; }

    public Complexity? Complexity { get; protected init; }

    public abstract string Serialize(Hl7Encoding encoding, Hl7Structure structure);
    protected static Hl7Structure GetChildStructure(Hl7Structure structure) {
        var next = (int)structure + 1;
        return Enum.IsDefined(typeof(Hl7Structure), next) ? (Hl7Structure)next : Hl7Structure.Hl7None;
    }
}

public abstract record Hl7SimpleType : Hl7DataType {
    protected Hl7SimpleType() {
        Complexity = HL7.Complexity.Simple;
    }

    public override string Serialize(Hl7Encoding encoding, Hl7Structure structure ) => StringValue ?? "";
}

public abstract record Hl7ComplexType : Hl7DataType {
    protected Hl7ComplexType() {
        Complexity = HL7.Complexity.Complex;
    }

    public override string Serialize(Hl7Encoding encoding, Hl7Structure structure) {
        if (this.Complexity == HL7.Complexity.Simple) return StringValue ?? "";
        
        var delimiter = encoding.GetDelimiter(structure);
        var childStructure = GetChildStructure(structure);
        var props = this.GetProperties().Select(p => p.GetValue(this)).ToArray();
        return string.Join(delimiter, props.Select(v => (v as Hl7DataType)?.Serialize(encoding, childStructure) ?? string.Empty));
    }

    public override int GetHashCode() {
        var components = GetProperties();
        return components.Aggregate(0, (current, prop) => HashCode.Combine(current, prop.GetValue(this)?.GetHashCode() ?? 0));
    }

    private static readonly Dictionary<Type, PropertyInfo[]> PropertyCache = new();

    internal PropertyInfo[] GetProperties() {
        var type = GetType();
        if (!PropertyCache.TryGetValue(type, out var props)) {
            props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            PropertyCache[type] = props;
        }

        return props;
    }
}
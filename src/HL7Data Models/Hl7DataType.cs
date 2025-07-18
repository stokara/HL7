using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HL7;

public enum Hl7Structure {
    Hl7Message,
    Hl7Segment,
    Hl7Field,
    Hl7RepField,
    Hl7Component,
    Hl7SubComponent,
    Hl7None
}

public enum Complexity {
    Complex,
    Simple,
    Primitive
}

public interface IHl7DataType {
    Hl7Structure? Structure { get; }
    Complexity? Complexity { get; }
    public string Serialize(Hl7Encoding encoding, Hl7Structure sourceStructure);
    public static Hl7Structure GetChildStructure(Hl7Structure structure) {
        var next = (int)structure + 1;
        return Enum.IsDefined(typeof(Hl7Structure), next) ? (Hl7Structure)next : Hl7Structure.Hl7None;
    }
}

public abstract record Hl7DataType : IHl7DataType {
    public string? StringValue { get; init; }

    public Hl7Structure? Structure { get; protected init; }
    public Complexity? Complexity { get; protected init; }

    protected Hl7DataType(Hl7Structure structure) {
        Structure = structure;
    }

    protected Hl7DataType() { }

    public abstract string Serialize(Hl7Encoding encoding, Hl7Structure hl7Structure);

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

public abstract record Hl7SimpleType : Hl7DataType {
    protected Hl7SimpleType(Hl7Structure structure) : base(structure) {
        Complexity = HL7.Complexity.Simple;
    }

    public override string Serialize(Hl7Encoding encoding, Hl7Structure _ ) => StringValue ?? "";
}

public abstract record Hl7ComplexType : Hl7DataType {
    protected Hl7ComplexType(Hl7Structure structure) : base(structure) {
        Complexity = HL7.Complexity.Complex;
    }

    protected Hl7ComplexType() { }

    public override string Serialize(Hl7Encoding encoding, Hl7Structure sourceStructure) {
        if (this.Complexity == HL7.Complexity.Simple) return StringValue ?? "";
        
        var delimiter = encoding.GetDelimiter(sourceStructure);
        var childStructure = IHl7DataType.GetChildStructure(sourceStructure);
        var props = this.GetProperties().Select(p => p.GetValue(this)).ToArray();
        return string.Join(delimiter, props.Select(v => (v as Hl7DataType)?.Serialize(encoding, childStructure) ?? string.Empty));
    }

    public override int GetHashCode() {
        var components = GetProperties();
        return components.Aggregate(0, (current, prop) => HashCode.Combine(current, prop.GetValue(this)?.GetHashCode() ?? 0));
    }
}
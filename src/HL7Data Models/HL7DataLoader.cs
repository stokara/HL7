using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
// ReSharper disable HeuristicUnreachableCode
#pragma warning disable CS0162 // Unreachable code detected

namespace HL7;

public static class HL7DataLoader {
    private const bool IsUseRegistrationScanning = true;
    private static readonly Dictionary<string, Func<Segment, IHL7Data>> registry = new();

    static HL7DataLoader() {
        if (IsUseRegistrationScanning) ScanAndRegisterSegmentFactories();
        else RegisterHL7Factories();
    }

    public static void Register(string segmentType, Func<Segment, IHL7Data> factory) => registry[segmentType] = factory;

    public static IHL7Data Create(Segment segment) {
        if (segment is null) throw new ArgumentNullException(nameof(segment));
        if (registry.TryGetValue(segment.Name, out var factory)) return factory(segment);
        throw new InvalidDataException($"Unknown segment type: {segment.Name}");
    }

    public static void RegisterHL7Factories() {
        Register("IN1", seg => new IN1(seg));
        Register("IN2", seg => new IN2(seg));
        Register("FT1", seg => new FT1(seg));
        Register("PID", seg => new PID(seg));
        Register("PV1", seg => new PV1(seg));
        Register("NTE", seg => new NTE(seg));
        Register("QBE", seg => new QBE(seg));
        Register("QRC", seg => new QRC(seg));
    }

    public static void ScanAndRegisterSegmentFactories() {
        var types = getAllHl7DataTypes();

        foreach (var type in types) {
            const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var ctor = type.GetConstructor(bindingFlags, null, [typeof(Segment)], null);
            if (ctor == null)
                continue;

            registry[type.Name] = segment => (IHL7Data)ctor.Invoke([segment]);
        }
    }

    public static IReadOnlyCollection<string> GetUnregisteredSegmentTypes() {
        var types = getAllHl7DataTypes();
        return (from type in types where !registry.ContainsKey(type.Name) select type.Name).ToArray().AsReadOnly();
    }

    private static IEnumerable<Type> getAllHl7DataTypes() {
        var baseGenericType = typeof(HL7Data<>);
        var types = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t =>
                t.BaseType is { IsGenericType: true } &&
                t.BaseType.GetGenericTypeDefinition() == baseGenericType &&
                t != baseGenericType);
        return types;
    }
}
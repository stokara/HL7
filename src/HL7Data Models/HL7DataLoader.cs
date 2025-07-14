using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

// ReSharper disable HeuristicUnreachableCode

namespace HL7;

public static class Hl7DataLoader {
    private static readonly bool IsUseRegistrationScanning = true;
    private static readonly Dictionary<string, Func<Segment, Hl7Segment>> registry = new();

    static Hl7DataLoader() {
        if (IsUseRegistrationScanning) {
            ScanAndRegisterSegmentFactories();
        } else {
            RegisterHL7Factories();
            var missing = GetUnregisteredSegmentTypes();
            if (missing.Count > 0) {
                var message = "The following segment types are not registered: " + string.Join(", ", missing);
                throw new InvalidDataException(message);
            }
        }
    }

    public static void Register(string segmentType, Func<Segment, Hl7Segment> factory) {
        registry[segmentType] = factory;
    }

    public static Hl7Segment Create(Segment segment) {
        if (segment is null) throw new ArgumentNullException(nameof(segment), new Hl7Exception("segment null"));
        if (registry.TryGetValue(segment.Name, out var factory)) return factory(segment);
        throw new InvalidDataException($"Unknown segment type: {segment.Name}");
    }

    public static void RegisterHL7Factories() {
        Register("IN1", seg => new IN1(seg));
        Register("IN2", seg => new IN2(seg));
        Register("IN3", seg => new IN3(seg));
        Register("FT1", seg => new FT1(seg));
        Register("PID", seg => new PID(seg));
        Register("PV1", seg => new PV1(seg));
        Register("PV2", seg => new PV2(seg));
        Register("NTE", seg => new NTE(seg));
        Register("PD1", seg => new PD1(seg));
        Register("FHS", seg => new FHS(seg));
        Register("BHS", seg => new BHS(seg));
        Register("NK1", seg => new NK1(seg));
        Register("RXA", seg => new RXA(seg));
        Register("RXR", seg => new RXR(seg));
        Register("RXE", seg => new RXE(seg));
        Register("RXC", seg => new RXC(seg));
        Register("RXO", seg => new RXO(seg));
        Register("RXD", seg => new RXD(seg));
        Register("BTS", seg => new BTS(seg));
        Register("FTS", seg => new FTS(seg));
        Register("EVN", seg => new EVN(seg));
        Register("AL1", seg => new AL1(seg));
        Register("ORC", seg => new ORC(seg));
        Register("OBR", seg => new OBR(seg));
        Register("SFT", seg => new SFT(seg));
        Register("PRB", seg => new PRB(seg));
        Register("PR1", seg => new PR1(seg));
        Register("TXA", seg => new TXA(seg));
        Register("MFI", seg => new MFI(seg));
        Register("MFE", seg => new MFE(seg));
        Register("MRG", seg => new MRG(seg));
        Register("DG1", seg => new DG1(seg));
        Register("PRT", seg => new PRT(seg));
        Register("OBX", seg => new OBX(seg));
        Register("TQ1", seg => new TQ1(seg));
        Register("SPM", seg => new SPM(seg));
        Register("SCH", seg => new SCH(seg));
        Register("RGS", seg => new RGS(seg));
        Register("AIG", seg => new AIG(seg));
        Register("AIL", seg => new AIL(seg));
        Register("AIP", seg => new AIP(seg));
        Register("STF", seg => new STF(seg));
        Register("PRA", seg => new PRA(seg));
    }

    public static void ScanAndRegisterSegmentFactories() {
        var types = getAllHl7DataTypes();

        foreach (var type in types) {
            const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var ctor = type.GetConstructor(bindingFlags, null, [typeof(Segment)], null);
            if (ctor == null) {
                continue;
            }

            registry[type.Name] = segment => (Hl7Segment)ctor.Invoke([segment]);
        }
    }

    public static IReadOnlyCollection<string> GetUnregisteredSegmentTypes() {
        var types = getAllHl7DataTypes();
        return types.Where(type => !registry.ContainsKey(type.Name)).Select(type => type.Name).ToArray().AsReadOnly();
    }

    private static IEnumerable<Type> getAllHl7DataTypes() =>
         typeof(Hl7Segment).Assembly
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Hl7Segment)) && t is { IsSealed: true, IsPublic: true });
 
}
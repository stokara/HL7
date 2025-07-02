using System.Collections.Generic;
using System.Linq;

public sealed record Component {
    public bool HasSubComponents => SubComponents.Count > 0;
    public IReadOnlyCollection<SubComponent> SubComponents { get;  }
    public string Value { get; }
    
    private Component(IReadOnlyCollection<SubComponent> SubComponents, string Value) {
        this.SubComponents = SubComponents;
        this.Value = Value;
    }

    public static Component Parse(Hl7Encoding encoding, string value) {
        var subComponents = value.Split(encoding.SubComponentDelimiter);
        var components = subComponents.Select(strSubComponent => new SubComponent(strSubComponent)).ToList().AsReadOnly();
        return new Component(components, value);
    }

    public static Component CreateDelimiterComponent(string value) => new([], value);
}


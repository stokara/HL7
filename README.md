# HL7

A modern, robust C# library for parsing, serializing, and working with HL7 v2.x messages. Built with .NET 9 and C# 13, this library provides strong typing, extensibility, and comprehensive error handling for healthcare data exchange scenarios.

---

## Features

- **HL7 Message Parsing & Serialization**  
  Parse HL7 messages into strongly-typed objects and serialize them back to HL7 format.

- **Custom Encoding Support**  
  Handles standard and custom HL7 delimiters and escape sequences.

- **Domain Models**  
  Includes models for HL7 segments (e.g., `FT1` for Financial Transaction Information).

- **Error Handling**  
  Custom exceptions (`HL7Exception`) for granular error reporting.

- **Immutability & Modern C#**  
  Uses records and immutable data structures for safety and clarity.

---

## Getting Started

### Requirements

- .NET 9 or later
- C# 13.0

### Installation

Add the project to your solution or reference the compiled DLL.

### Usage

#### Parse an HL7 Message

```
using HL7;

string hl7Text = "MSH|^~\\&|..."; // your HL7 message
var message = Message.Parse(hl7Text);

// Access segments and fields
var msh = message.Segments.FirstOrDefault(s => s.Name == "MSH");
string sendingApp = msh?.Fields[2].Value;
```

#### Serialize a Message

```
string serialized = message.SerializeMessage();
```

#### Converts HL7 to c# classes (e.g., FT1)

```
var isSuccess = HL7Message.TryCreate(message, out var hl7Message);
if (isSuccess) {
  var msh = hl7Message.MSH;
  var versionId = msh.VersionId;
 var FT1s = hl7Message.GetRecords<FT1>();
}
```

#### Encode/Decode HL7 Values

```
var encoding = new HL7Encoding('|', '^', '~', '\\', '&');
string encoded = encoding.Encode("A|B^C");
string decoded = encoding.Decode(encoded);
```

---

## Testing

Unit tests are provided in the `HL7Test` project.  
Run with your preferred test runner (e.g., `dotnet test`).

---

## Extending

- Add new segment models by inheriting from `HL7Data<T>`.
- Customize encoding by creating new `HL7Encoding` instances.

---

---

## Contributing

Pull requests and issues are welcome!

---

## Acknowledgments

- HL7  and Health Level Seven  are registered trademarks of Health Level Seven International.
- Started from Fork of Efferent.HL7.V2 but rewrote close to 100% of the code.

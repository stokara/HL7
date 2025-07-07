using System.Collections.Generic;
using System.Linq;
using HL7.Address;
using HL7.PatientIdentifier;
using HL7.PersonName;
using HL7.Phone;

namespace HL7;

public sealed record PID : HL7Data<PID> {
    public string SetId { get; }
    public string PatientId { get; }
    public IReadOnlyList<IPatientIdentifier>? PatientIdentifierList { get; }
    public IPersonName PatientName { get; }
    public string DateOfBirth { get; }
    public string Sex { get; }
    public IReadOnlyList<IAddress>? Addresses { get; }
    public IReadOnlyList<IPhone>? PhoneNumbers { get; }
    public string MaritalStatus { get; }
    public string SSN { get; }

    public PID(Segment segment) : base(segment) {
        SetId = segment.Fields.Count > 1 ? segment.Fields[1].Value : string.Empty;
        PatientId = segment.Fields.Count > 2 ? segment.Fields[2].Value : string.Empty;

        // PID-3: Patient Identifier List (repetition or single value)
        if (segment.Fields.Count > 3) {
            PatientIdentifierList = segment.Fields[3].HasRepetitions
                ? segment.Fields[3].Repetitions!.Select(fieldRep => PatientIdentifierFactory.Create(fieldRep)).ToArray()
                : new List<IPatientIdentifier> { PatientIdentifierFactory.Create(segment.GetField(3)) };
        }

        if (segment.Fields.Count > 5) {
            PatientName = PersonNameFactory.Create(segment.GetField(5));
        }

        DateOfBirth = segment.Fields.Count > 7 ? segment.Fields[7].Value : string.Empty;
        Sex = segment.Fields.Count > 8 ? segment.Fields[8].Value : string.Empty;

        if (segment.Fields.Count > 11) {
            Addresses = segment.Fields[11].HasRepetitions
                ? segment.Fields[11].Repetitions!.Select(fieldRep => AddressFactory.Create(fieldRep)).ToArray()
                : new List<IAddress> { AddressFactory.Create(segment.GetField(11)) };
        }

        if (segment.Fields.Count > 13) {
            PhoneNumbers = segment.Fields[13].HasRepetitions
                ? segment.Fields[13].Repetitions!.Select(fieldRep => PhoneFactory.Create(fieldRep)).ToArray()
                : new List<IPhone> { PhoneFactory.Create(segment.GetField(13)) };
        }

        MaritalStatus = segment.Fields.Count > 16 ? segment.Fields[16].Value : string.Empty;
        SSN = segment.Fields.Count > 19 ? segment.Fields[19].Value : string.Empty;
    }
}
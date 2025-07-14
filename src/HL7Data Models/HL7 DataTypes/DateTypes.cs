using System.Collections.Generic;

namespace HL7;

public sealed record AD : Hl7DataType {
    public ST? StreetAddress { get; }
    public ST? OtherDesignation { get; }
    public ST? City { get; }
    public ST? StateorProvince { get; }
    public ST? ZiporPostalCode { get; }
    public ID? Country { get; }
    public ID? AddressType { get; }
    public ST? OtherGeographicDesignation { get; }

    public AD(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        StreetAddress = components.Get<ST>(1, subComponentDelimiter);
        OtherDesignation = components.Get<ST>(2, subComponentDelimiter);
        City = components.Get<ST>(3, subComponentDelimiter);
        StateorProvince = components.Get<ST>(4, subComponentDelimiter);
        ZiporPostalCode = components.Get<ST>(5, subComponentDelimiter);
        Country = components.Get<ID>(6, subComponentDelimiter);
        AddressType = components.Get<ID>(7, subComponentDelimiter);
        OtherGeographicDesignation = components.Get<ST>(8, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(StreetAddress,encoding),
            SerializePropertyValue(OtherDesignation,encoding),
            SerializePropertyValue(City,encoding),
            SerializePropertyValue(StateorProvince,encoding),
            SerializePropertyValue(ZiporPostalCode,encoding),
            SerializePropertyValue(Country,encoding),
            SerializePropertyValue(AddressType,encoding),
            SerializePropertyValue(OtherGeographicDesignation,encoding)
        });
}

public sealed record AUI : Hl7DataType {
    public ST? AuthorizationNumber { get; }
    public DT? Date { get; }
    public ST? Source { get; }

    public AUI(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        AuthorizationNumber = components.Get<ST>(1, subComponentDelimiter);
        Date = components.Get<DT>(2, subComponentDelimiter);
        Source = components.Get<ST>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(AuthorizationNumber,encoding),
            SerializePropertyValue(Date,encoding),
            SerializePropertyValue(Source,encoding)
        });
}

public sealed record CCD : Hl7DataType {
    public ID? InvocationEvent { get; }
    public DTM? Datetime { get; }

    public CCD(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        InvocationEvent = components.Get<ID>(1, subComponentDelimiter);
        Datetime = components.Get<DTM>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(InvocationEvent,encoding),
            SerializePropertyValue(Datetime,encoding)
        });
}

public sealed record CCP : Hl7DataType {
    public NM? ChannelCalibrationSensitivityCorrectionFactor { get; }
    public NM? ChannelCalibrationBaseline { get; }
    public NM? ChannelCalibrationTimeSkew { get; }

    public CCP(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        ChannelCalibrationSensitivityCorrectionFactor = components.Get<NM>(1, subComponentDelimiter);
        ChannelCalibrationBaseline = components.Get<NM>(2, subComponentDelimiter);
        ChannelCalibrationTimeSkew = components.Get<NM>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(ChannelCalibrationSensitivityCorrectionFactor,encoding),
            SerializePropertyValue(ChannelCalibrationBaseline,encoding),
            SerializePropertyValue(ChannelCalibrationTimeSkew,encoding)
        });
}

public sealed record CD : Hl7DataType {
    public WVI? ChannelIdentifier { get; }
    public WVS? WaveformSource { get; }
    public CSU? ChannelSensitivityandUnits { get; }
    public CCP? ChannelCalibrationParameters { get; }
    public NM? ChannelSamplingFrequency { get; }
    public NR? MinimumandMaximumDataValues { get; }

    public CD(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        ChannelIdentifier = components.Get<WVI>(1, subComponentDelimiter);
        WaveformSource = components.Get<WVS>(2, subComponentDelimiter);
        ChannelSensitivityandUnits = components.Get<CSU>(3, subComponentDelimiter);
        ChannelCalibrationParameters = components.Get<CCP>(4, subComponentDelimiter);
        ChannelSamplingFrequency = components.Get<NM>(5, subComponentDelimiter);
        MinimumandMaximumDataValues = components.Get<NR>(6, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(ChannelIdentifier,encoding),
            SerializePropertyValue(WaveformSource,encoding),
            SerializePropertyValue(ChannelSensitivityandUnits,encoding),
            SerializePropertyValue(ChannelCalibrationParameters,encoding),
            SerializePropertyValue(ChannelSamplingFrequency,encoding),
            SerializePropertyValue(MinimumandMaximumDataValues,encoding)
        });
}

public sealed record CF : Hl7DataType {
    public ST? Identifier { get; }
    public FT? FormattedText { get; }
    public ID? NameofCodingSystem { get; }
    public ST? AlternateIdentifier { get; }
    public FT? AlternateFormattedText { get; }
    public ID? NameofAlternateCodingSystem { get; }
    public ST? CodingSystemVersionID { get; }
    public ST? AlternateCodingSystemVersionID { get; }
    public ST? OriginalText { get; }
    public ST? SecondAlternateIdentifier { get; }
    public FT? SecondAlternateFormattedText { get; }
    public ID? NameofSecondAlternateCodingSystem { get; }
    public ST? SecondAlternateCodingSystemVersionID { get; }
    public ST? CodingSystemOID { get; }
    public ST? ValueSetOID { get; }
    public DTM? ValueSetVersionID { get; }
    public ST? AlternateCodingSystemOID { get; }
    public ST? AlternateValueSetOID { get; }
    public DTM? AlternateValueSetVersionID { get; }
    public ST? SecondAlternateCodingSystemOID { get; }
    public ST? SecondAlternateValueSetOID { get; }
    public DTM? SecondAlternateValueSetVersionID { get; }

    public CF(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Identifier = components.Get<ST>(1, subComponentDelimiter);
        FormattedText = components.Get<FT>(2, subComponentDelimiter);
        NameofCodingSystem = components.Get<ID>(3, subComponentDelimiter);
        AlternateIdentifier = components.Get<ST>(4, subComponentDelimiter);
        AlternateFormattedText = components.Get<FT>(5, subComponentDelimiter);
        NameofAlternateCodingSystem = components.Get<ID>(6, subComponentDelimiter);
        CodingSystemVersionID = components.Get<ST>(7, subComponentDelimiter);
        AlternateCodingSystemVersionID = components.Get<ST>(8, subComponentDelimiter);
        OriginalText = components.Get<ST>(9, subComponentDelimiter);
        SecondAlternateIdentifier = components.Get<ST>(10, subComponentDelimiter);
        SecondAlternateFormattedText = components.Get<FT>(11, subComponentDelimiter);
        NameofSecondAlternateCodingSystem = components.Get<ID>(12, subComponentDelimiter);
        SecondAlternateCodingSystemVersionID = components.Get<ST>(13, subComponentDelimiter);
        CodingSystemOID = components.Get<ST>(14, subComponentDelimiter);
        ValueSetOID = components.Get<ST>(15, subComponentDelimiter);
        ValueSetVersionID = components.Get<DTM>(16, subComponentDelimiter);
        AlternateCodingSystemOID = components.Get<ST>(17, subComponentDelimiter);
        AlternateValueSetOID = components.Get<ST>(18, subComponentDelimiter);
        AlternateValueSetVersionID = components.Get<DTM>(19, subComponentDelimiter);
        SecondAlternateCodingSystemOID = components.Get<ST>(20, subComponentDelimiter);
        SecondAlternateValueSetOID = components.Get<ST>(21, subComponentDelimiter);
        SecondAlternateValueSetVersionID = components.Get<DTM>(22, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(Identifier,encoding),
            SerializePropertyValue(FormattedText,encoding),
            SerializePropertyValue(NameofCodingSystem,encoding),
            SerializePropertyValue(AlternateIdentifier,encoding),
            SerializePropertyValue(AlternateFormattedText,encoding),
            SerializePropertyValue(NameofAlternateCodingSystem,encoding),
            SerializePropertyValue(CodingSystemVersionID,encoding),
            SerializePropertyValue(AlternateCodingSystemVersionID,encoding),
            SerializePropertyValue(OriginalText,encoding),
            SerializePropertyValue(SecondAlternateIdentifier,encoding),
            SerializePropertyValue(SecondAlternateFormattedText,encoding),
            SerializePropertyValue(NameofSecondAlternateCodingSystem,encoding),
            SerializePropertyValue(SecondAlternateCodingSystemVersionID,encoding),
            SerializePropertyValue(CodingSystemOID,encoding),
            SerializePropertyValue(ValueSetOID,encoding),
            SerializePropertyValue(ValueSetVersionID,encoding),
            SerializePropertyValue(AlternateCodingSystemOID,encoding),
            SerializePropertyValue(AlternateValueSetOID,encoding),
            SerializePropertyValue(AlternateValueSetVersionID,encoding),
            SerializePropertyValue(SecondAlternateCodingSystemOID,encoding),
            SerializePropertyValue(SecondAlternateValueSetOID,encoding),
            SerializePropertyValue(SecondAlternateValueSetVersionID,encoding)
        });
}

public sealed record CNE : Hl7DataType {
    public ST? Identifier { get; }
    public ST? Text { get; }
    public ID? NameofCodingSystem { get; }
    public ST? AlternateIdentifier { get; }
    public ST? AlternateText { get; }
    public ID? NameofAlternateCodingSystem { get; }
    public ST? CodingSystemVersionID { get; }
    public ST? AlternateCodingSystemVersionID { get; }
    public ST? OriginalText { get; }
    public ST? SecondAlternateIdentifier { get; }
    public ST? SecondAlternateText { get; }
    public ID? NameofSecondAlternateCodingSystem { get; }
    public ST? SecondAlternateCodingSystemVersionID { get; }
    public ST? CodingSystemOID { get; }
    public ST? ValueSetOID { get; }
    public DTM? ValueSetVersionID { get; }
    public ST? AlternateCodingSystemOID { get; }
    public ST? AlternateValueSetOID { get; }
    public DTM? AlternateValueSetVersionID { get; }
    public ST? SecondAlternateCodingSystemOID { get; }
    public ST? SecondAlternateValueSetOID { get; }
    public DTM? SecondAlternateValueSetVersionID { get; }

    public CNE(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Identifier = components.Get<ST>(1, subComponentDelimiter);
        Text = components.Get<ST>(2, subComponentDelimiter);
        NameofCodingSystem = components.Get<ID>(3, subComponentDelimiter);
        AlternateIdentifier = components.Get<ST>(4, subComponentDelimiter);
        AlternateText = components.Get<ST>(5, subComponentDelimiter);
        NameofAlternateCodingSystem = components.Get<ID>(6, subComponentDelimiter);
        CodingSystemVersionID = components.Get<ST>(7, subComponentDelimiter);
        AlternateCodingSystemVersionID = components.Get<ST>(8, subComponentDelimiter);
        OriginalText = components.Get<ST>(9, subComponentDelimiter);
        SecondAlternateIdentifier = components.Get<ST>(10, subComponentDelimiter);
        SecondAlternateText = components.Get<ST>(11, subComponentDelimiter);
        NameofSecondAlternateCodingSystem = components.Get<ID>(12, subComponentDelimiter);
        SecondAlternateCodingSystemVersionID = components.Get<ST>(13, subComponentDelimiter);
        CodingSystemOID = components.Get<ST>(14, subComponentDelimiter);
        ValueSetOID = components.Get<ST>(15, subComponentDelimiter);
        ValueSetVersionID = components.Get<DTM>(16, subComponentDelimiter);
        AlternateCodingSystemOID = components.Get<ST>(17, subComponentDelimiter);
        AlternateValueSetOID = components.Get<ST>(18, subComponentDelimiter);
        AlternateValueSetVersionID = components.Get<DTM>(19, subComponentDelimiter);
        SecondAlternateCodingSystemOID = components.Get<ST>(20, subComponentDelimiter);
        SecondAlternateValueSetOID = components.Get<ST>(21, subComponentDelimiter);
        SecondAlternateValueSetVersionID = components.Get<DTM>(22, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(Identifier,encoding),
            SerializePropertyValue(Text,encoding),
            SerializePropertyValue(NameofCodingSystem,encoding),
            SerializePropertyValue(AlternateIdentifier,encoding),
            SerializePropertyValue(AlternateText,encoding),
            SerializePropertyValue(NameofAlternateCodingSystem,encoding),
            SerializePropertyValue(CodingSystemVersionID,encoding),
            SerializePropertyValue(AlternateCodingSystemVersionID,encoding),
            SerializePropertyValue(OriginalText,encoding),
            SerializePropertyValue(SecondAlternateIdentifier,encoding),
            SerializePropertyValue(SecondAlternateText,encoding),
            SerializePropertyValue(NameofSecondAlternateCodingSystem,encoding),
            SerializePropertyValue(SecondAlternateCodingSystemVersionID,encoding),
            SerializePropertyValue(CodingSystemOID,encoding),
            SerializePropertyValue(ValueSetOID,encoding),
            SerializePropertyValue(ValueSetVersionID,encoding),
            SerializePropertyValue(AlternateCodingSystemOID,encoding),
            SerializePropertyValue(AlternateValueSetOID,encoding),
            SerializePropertyValue(AlternateValueSetVersionID,encoding),
            SerializePropertyValue(SecondAlternateCodingSystemOID,encoding),
            SerializePropertyValue(SecondAlternateValueSetOID,encoding),
            SerializePropertyValue(SecondAlternateValueSetVersionID,encoding)
        });
}

public sealed record CNN : Hl7DataType {
    public ST? IDNumber { get; }
    public ST? FamilyName { get; }
    public ST? GivenName { get; }
    public ST? SecondandFurtherGivenNamesorInitialsThereof { get; }
    public ST? Suffix { get; }
    public ST? Prefix { get; }
    public IS? Degree { get; }
    public IS? SourceTable { get; }
    public IS? AssigningAuthorityNamespaceID { get; }
    public ST? AssigningAuthorityUniversalID { get; }
    public ID? AssigningAuthorityUniversalIDType { get; }

    public CNN(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        IDNumber = components.Get<ST>(1, subComponentDelimiter);
        FamilyName = components.Get<ST>(2, subComponentDelimiter);
        GivenName = components.Get<ST>(3, subComponentDelimiter);
        SecondandFurtherGivenNamesorInitialsThereof = components.Get<ST>(4, subComponentDelimiter);
        Suffix = components.Get<ST>(5, subComponentDelimiter);
        Prefix = components.Get<ST>(6, subComponentDelimiter);
        Degree = components.Get<IS>(7, subComponentDelimiter);
        SourceTable = components.Get<IS>(8, subComponentDelimiter);
        AssigningAuthorityNamespaceID = components.Get<IS>(9, subComponentDelimiter);
        AssigningAuthorityUniversalID = components.Get<ST>(10, subComponentDelimiter);
        AssigningAuthorityUniversalIDType = components.Get<ID>(11, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(IDNumber,encoding),
            SerializePropertyValue(FamilyName,encoding),
            SerializePropertyValue(GivenName,encoding),
            SerializePropertyValue(SecondandFurtherGivenNamesorInitialsThereof,encoding),
            SerializePropertyValue(Suffix,encoding),
            SerializePropertyValue(Prefix,encoding),
            SerializePropertyValue(Degree,encoding),
            SerializePropertyValue(SourceTable,encoding),
            SerializePropertyValue(AssigningAuthorityNamespaceID,encoding),
            SerializePropertyValue(AssigningAuthorityUniversalID,encoding),
            SerializePropertyValue(AssigningAuthorityUniversalIDType,encoding)
        });
}

public sealed record CP : Hl7DataType {
    public MO? Price { get; }
    public ID? PriceType { get; }
    public NM? FromValue { get; }
    public NM? ToValue { get; }
    public CWE? RangeUnits { get; }
    public ID? RangeType { get; }

    public CP(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Price = components.Get<MO>(1, subComponentDelimiter);
        PriceType = components.Get<ID>(2, subComponentDelimiter);
        FromValue = components.Get<NM>(3, subComponentDelimiter);
        ToValue = components.Get<NM>(4, subComponentDelimiter);
        RangeUnits = components.Get<CWE>(5, subComponentDelimiter);
        RangeType = components.Get<ID>(6, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(Price,encoding),
            SerializePropertyValue(PriceType,encoding),
            SerializePropertyValue(FromValue,encoding),
            SerializePropertyValue(ToValue,encoding),
            SerializePropertyValue(RangeUnits,encoding),
            SerializePropertyValue(RangeType,encoding)
        });
}

public sealed record CQ : Hl7DataType {
    public NM? Quantity { get; }
    public CWE? Units { get; }

    public CQ(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Quantity = components.Get<NM>(1, subComponentDelimiter);
        Units = components.Get<CWE>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(Quantity,encoding),
            SerializePropertyValue(Units,encoding)
        });
}

public sealed record CSU : Hl7DataType {
    public NM? ChannelSensitivity { get; }
    public ST? UnitofMeasureIdentifier { get; }
    public ST? UnitofMeasureDescription { get; }
    public ID? UnitofMeasureCodingSystem { get; }
    public ST? AlternateUnitofMeasureIdentifier { get; }
    public ST? AlternateUnitofMeasureDescription { get; }
    public ID? AlternateUnitofMeasureCodingSystem { get; }
    public ST? UnitofMeasureCodingSystemVersionID { get; }
    public ST? AlternateUnitofMeasureCodingSystemVersionID { get; }
    public ST? OriginalText { get; }
    public ST? SecondAlternateUnitofMeasureIdentifier { get; }
    public ST? SecondAlternateUnitofMeasureText { get; }
    public ID? NameofSecondAlternateUnitofMeasureCodingSystem { get; }
    public ST? SecondAlternateUnitofMeasureCodingSystemVersionID { get; }
    public ST? UnitofMeasureCodingSystemOID { get; }
    public ST? UnitofMeasureValueSetOID { get; }
    public DTM? UnitofMeasureValueSetVersionID { get; }
    public ST? AlternateUnitofMeasureCodingSystemOID { get; }
    public ST? AlternateUnitofMeasureValueSetOID { get; }
    public DTM? AlternateUnitofMeasureValueSetVersionID { get; }
    public ST? AlternateUnitofMeasureCodingSystemOID2 { get; }
    public ST? AlternateUnitofMeasureValueSetOID2 { get; }
    public ST? AlternateUnitofMeasureValueSetVersionID2 { get; }

    public CSU(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        ChannelSensitivity = components.Get<NM>(1, subComponentDelimiter);
        UnitofMeasureIdentifier = components.Get<ST>(2, subComponentDelimiter);
        UnitofMeasureDescription = components.Get<ST>(3, subComponentDelimiter);
        UnitofMeasureCodingSystem = components.Get<ID>(4, subComponentDelimiter);
        AlternateUnitofMeasureIdentifier = components.Get<ST>(5, subComponentDelimiter);
        AlternateUnitofMeasureDescription = components.Get<ST>(6, subComponentDelimiter);
        AlternateUnitofMeasureCodingSystem = components.Get<ID>(7, subComponentDelimiter);
        UnitofMeasureCodingSystemVersionID = components.Get<ST>(8, subComponentDelimiter);
        AlternateUnitofMeasureCodingSystemVersionID = components.Get<ST>(9, subComponentDelimiter);
        OriginalText = components.Get<ST>(10, subComponentDelimiter);
        SecondAlternateUnitofMeasureIdentifier = components.Get<ST>(11, subComponentDelimiter);
        SecondAlternateUnitofMeasureText = components.Get<ST>(12, subComponentDelimiter);
        NameofSecondAlternateUnitofMeasureCodingSystem = components.Get<ID>(13, subComponentDelimiter);
        SecondAlternateUnitofMeasureCodingSystemVersionID = components.Get<ST>(14, subComponentDelimiter);
        UnitofMeasureCodingSystemOID = components.Get<ST>(15, subComponentDelimiter);
        UnitofMeasureValueSetOID = components.Get<ST>(16, subComponentDelimiter);
        UnitofMeasureValueSetVersionID = components.Get<DTM>(17, subComponentDelimiter);
        AlternateUnitofMeasureCodingSystemOID = components.Get<ST>(18, subComponentDelimiter);
        AlternateUnitofMeasureValueSetOID = components.Get<ST>(19, subComponentDelimiter);
        AlternateUnitofMeasureValueSetVersionID = components.Get<DTM>(20, subComponentDelimiter);
        AlternateUnitofMeasureCodingSystemOID2 = components.Get<ST>(21, subComponentDelimiter);
        AlternateUnitofMeasureValueSetOID2 = components.Get<ST>(22, subComponentDelimiter);
        AlternateUnitofMeasureValueSetVersionID2 = components.Get<ST>(23, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(ChannelSensitivity,encoding),
            SerializePropertyValue(UnitofMeasureIdentifier,encoding),
            SerializePropertyValue(UnitofMeasureDescription,encoding),
            SerializePropertyValue(UnitofMeasureCodingSystem,encoding),
            SerializePropertyValue(AlternateUnitofMeasureIdentifier,encoding),
            SerializePropertyValue(AlternateUnitofMeasureDescription,encoding),
            SerializePropertyValue(AlternateUnitofMeasureCodingSystem,encoding),
            SerializePropertyValue(UnitofMeasureCodingSystemVersionID,encoding),
            SerializePropertyValue(AlternateUnitofMeasureCodingSystemVersionID,encoding),
            SerializePropertyValue(OriginalText,encoding),
            SerializePropertyValue(SecondAlternateUnitofMeasureIdentifier,encoding),
            SerializePropertyValue(SecondAlternateUnitofMeasureText,encoding),
            SerializePropertyValue(NameofSecondAlternateUnitofMeasureCodingSystem,encoding),
            SerializePropertyValue(SecondAlternateUnitofMeasureCodingSystemVersionID,encoding),
            SerializePropertyValue(UnitofMeasureCodingSystemOID,encoding),
            SerializePropertyValue(UnitofMeasureValueSetOID,encoding),
            SerializePropertyValue(UnitofMeasureValueSetVersionID,encoding),
            SerializePropertyValue(AlternateUnitofMeasureCodingSystemOID,encoding),
            SerializePropertyValue(AlternateUnitofMeasureValueSetOID,encoding),
            SerializePropertyValue(AlternateUnitofMeasureValueSetVersionID,encoding),
            SerializePropertyValue(AlternateUnitofMeasureCodingSystemOID2,encoding),
            SerializePropertyValue(AlternateUnitofMeasureValueSetOID2,encoding),
            SerializePropertyValue(AlternateUnitofMeasureValueSetVersionID2,encoding)
        });
}

public sealed record CWE : Hl7DataType {
    public ST? Identifier { get; }
    public ST? Text { get; }
    public ID? NameofCodingSystem { get; }
    public ST? AlternateIdentifier { get; }
    public ST? AlternateText { get; }
    public ID? NameofAlternateCodingSystem { get; }
    public ST? CodingSystemVersionID { get; }
    public ST? AlternateCodingSystemVersionID { get; }
    public ST? OriginalText { get; }
    public ST? SecondAlternateIdentifier { get; }
    public ST? SecondAlternateText { get; }
    public ID? NameofSecondAlternateCodingSystem { get; }
    public ST? SecondAlternateCodingSystemVersionID { get; }
    public ST? CodingSystemOID { get; }
    public ST? ValueSetOID { get; }
    public DTM? ValueSetVersionID { get; }
    public ST? AlternateCodingSystemOID { get; }
    public ST? AlternateValueSetOID { get; }
    public DTM? AlternateValueSetVersionID { get; }
    public ST? SecondAlternateCodingSystemOID { get; }
    public ST? SecondAlternateValueSetOID { get; }
    public DTM? SecondAlternateValueSetVersionID { get; }

    public CWE(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Identifier = components.Get<ST>(1, subComponentDelimiter);
        Text = components.Get<ST>(2, subComponentDelimiter);
        NameofCodingSystem = components.Get<ID>(3, subComponentDelimiter);
        AlternateIdentifier = components.Get<ST>(4, subComponentDelimiter);
        AlternateText = components.Get<ST>(5, subComponentDelimiter);
        NameofAlternateCodingSystem = components.Get<ID>(6, subComponentDelimiter);
        CodingSystemVersionID = components.Get<ST>(7, subComponentDelimiter);
        AlternateCodingSystemVersionID = components.Get<ST>(8, subComponentDelimiter);
        OriginalText = components.Get<ST>(9, subComponentDelimiter);
        SecondAlternateIdentifier = components.Get<ST>(10, subComponentDelimiter);
        SecondAlternateText = components.Get<ST>(11, subComponentDelimiter);
        NameofSecondAlternateCodingSystem = components.Get<ID>(12, subComponentDelimiter);
        SecondAlternateCodingSystemVersionID = components.Get<ST>(13, subComponentDelimiter);
        CodingSystemOID = components.Get<ST>(14, subComponentDelimiter);
        ValueSetOID = components.Get<ST>(15, subComponentDelimiter);
        ValueSetVersionID = components.Get<DTM>(16, subComponentDelimiter);
        AlternateCodingSystemOID = components.Get<ST>(17, subComponentDelimiter);
        AlternateValueSetOID = components.Get<ST>(18, subComponentDelimiter);
        AlternateValueSetVersionID = components.Get<DTM>(19, subComponentDelimiter);
        SecondAlternateCodingSystemOID = components.Get<ST>(20, subComponentDelimiter);
        SecondAlternateValueSetOID = components.Get<ST>(21, subComponentDelimiter);
        SecondAlternateValueSetVersionID = components.Get<DTM>(22, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(Identifier,encoding),
            SerializePropertyValue(Text,encoding),
            SerializePropertyValue(NameofCodingSystem,encoding),
            SerializePropertyValue(AlternateIdentifier,encoding),
            SerializePropertyValue(AlternateText,encoding),
            SerializePropertyValue(NameofAlternateCodingSystem,encoding),
            SerializePropertyValue(CodingSystemVersionID,encoding),
            SerializePropertyValue(AlternateCodingSystemVersionID,encoding),
            SerializePropertyValue(OriginalText,encoding),
            SerializePropertyValue(SecondAlternateIdentifier,encoding),
            SerializePropertyValue(SecondAlternateText,encoding),
            SerializePropertyValue(NameofSecondAlternateCodingSystem,encoding),
            SerializePropertyValue(SecondAlternateCodingSystemVersionID,encoding),
            SerializePropertyValue(CodingSystemOID,encoding),
            SerializePropertyValue(ValueSetOID,encoding),
            SerializePropertyValue(ValueSetVersionID,encoding),
            SerializePropertyValue(AlternateCodingSystemOID,encoding),
            SerializePropertyValue(AlternateValueSetOID,encoding),
            SerializePropertyValue(AlternateValueSetVersionID,encoding),
            SerializePropertyValue(SecondAlternateCodingSystemOID,encoding),
            SerializePropertyValue(SecondAlternateValueSetOID,encoding),
            SerializePropertyValue(SecondAlternateValueSetVersionID,encoding)
        });
}

public sealed record CX : Hl7DataType {
    public ST? IDNumber { get; }
    public ST? IdentifierCheckDigit { get; }
    public ID? CheckDigitScheme { get; }
    public HD? AssigningAuthority { get; }
    public ID? IdentifierTypeCode { get; }
    public HD? AssigningFacility { get; }
    public DT? EffectiveDate { get; }
    public DT? ExpirationDate { get; }
    public CWE? AssigningJurisdiction { get; }
    public CWE? AssigningAgencyorDepartment { get; }
    public ST? SecurityCheck { get; }
    public ID? SecurityCheckScheme { get; }

    public CX(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        IDNumber = components.Get<ST>(1, subComponentDelimiter);
        IdentifierCheckDigit = components.Get<ST>(2, subComponentDelimiter);
        CheckDigitScheme = components.Get<ID>(3, subComponentDelimiter);
        AssigningAuthority = components.Get<HD>(4, subComponentDelimiter);
        IdentifierTypeCode = components.Get<ID>(5, subComponentDelimiter);
        AssigningFacility = components.Get<HD>(6, subComponentDelimiter);
        EffectiveDate = components.Get<DT>(7, subComponentDelimiter);
        ExpirationDate = components.Get<DT>(8, subComponentDelimiter);
        AssigningJurisdiction = components.Get<CWE>(9, subComponentDelimiter);
        AssigningAgencyorDepartment = components.Get<CWE>(10, subComponentDelimiter);
        SecurityCheck = components.Get<ST>(11, subComponentDelimiter);
        SecurityCheckScheme = components.Get<ID>(12, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(IDNumber,encoding),
            SerializePropertyValue(IdentifierCheckDigit,encoding),
            SerializePropertyValue(CheckDigitScheme,encoding),
            SerializePropertyValue(AssigningAuthority,encoding),
            SerializePropertyValue(IdentifierTypeCode,encoding),
            SerializePropertyValue(AssigningFacility,encoding),
            SerializePropertyValue(EffectiveDate,encoding),
            SerializePropertyValue(ExpirationDate,encoding),
            SerializePropertyValue(AssigningJurisdiction,encoding),
            SerializePropertyValue(AssigningAgencyorDepartment,encoding),
            SerializePropertyValue(SecurityCheck,encoding),
            SerializePropertyValue(SecurityCheckScheme,encoding)
        });
}

public sealed record DDI : Hl7DataType {
    public NM? DelayDays { get; }
    public MO? MonetaryAmount { get; }
    public NM? NumberofDays { get; }

    public DDI(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        DelayDays = components.Get<NM>(1, subComponentDelimiter);
        MonetaryAmount = components.Get<MO>(2, subComponentDelimiter);
        NumberofDays = components.Get<NM>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(DelayDays,encoding),
            SerializePropertyValue(MonetaryAmount,encoding),
            SerializePropertyValue(NumberofDays,encoding)
        });
}

public sealed record DIN : Hl7DataType {
    public DTM? Date { get; }
    public CWE? InstitutionName { get; }

    public DIN(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Date = components.Get<DTM>(1, subComponentDelimiter);
        InstitutionName = components.Get<CWE>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(Date,encoding),
            SerializePropertyValue(InstitutionName,encoding)
        });
}

public sealed record DLD : Hl7DataType {
    public CWE? DischargetoLocation { get; }
    public DTM? EffectiveDate { get; }

    public DLD(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        DischargetoLocation = components.Get<CWE>(1, subComponentDelimiter);
        EffectiveDate = components.Get<DTM>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(DischargetoLocation,encoding),
            SerializePropertyValue(EffectiveDate,encoding)
        });
}

public sealed record DLN : Hl7DataType {
    public ST? DriversLicenseNumber { get; }
    public CWE? IssuingStateProvinceCountry { get; }
    public DT? ExpirationDate { get; }

    public DLN(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        DriversLicenseNumber = components.Get<ST>(1, subComponentDelimiter);
        IssuingStateProvinceCountry = components.Get<CWE>(2, subComponentDelimiter);
        ExpirationDate = components.Get<DT>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(DriversLicenseNumber,encoding),
            SerializePropertyValue(IssuingStateProvinceCountry,encoding),
            SerializePropertyValue(ExpirationDate,encoding)
        });
}

public sealed record DLT : Hl7DataType {
    public NR? NormalRange { get; }
    public NM? NumericThreshold { get; }
    public ID? ChangeComputation { get; }
    public NM? DaysRetained { get; }

    public DLT(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        NormalRange = components.Get<NR>(1, subComponentDelimiter);
        NumericThreshold = components.Get<NM>(2, subComponentDelimiter);
        ChangeComputation = components.Get<ID>(3, subComponentDelimiter);
        DaysRetained = components.Get<NM>(4, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(NormalRange,encoding),
            SerializePropertyValue(NumericThreshold,encoding),
            SerializePropertyValue(ChangeComputation,encoding),
            SerializePropertyValue(DaysRetained,encoding)
        });
}

public sealed record DR : Hl7DataType {
    public DTM? RangeStartDateTime { get; }
    public DTM? RangeEndDateTime { get; }

    public DR(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        RangeStartDateTime = components.Get<DTM>(1, subComponentDelimiter);
        RangeEndDateTime = components.Get<DTM>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(RangeStartDateTime,encoding),
            SerializePropertyValue(RangeEndDateTime,encoding)
        });
}

public sealed record DTN : Hl7DataType {
    public CWE? DayType { get; }
    public NM? NumberofDays { get; }

    public DTN(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        DayType = components.Get<CWE>(1, subComponentDelimiter);
        NumberofDays = components.Get<NM>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(DayType,encoding),
            SerializePropertyValue(NumberofDays,encoding)
        });
}

public sealed record ED : Hl7DataType {
    public HD? SourceApplication { get; }
    public ID? TypeofData { get; }
    public ID? DataSubtype { get; }
    public ID? Encoding { get; }
    public TX? Data { get; }

    public ED(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        SourceApplication = components.Get<HD>(1, subComponentDelimiter);
        TypeofData = components.Get<ID>(2, subComponentDelimiter);
        DataSubtype = components.Get<ID>(3, subComponentDelimiter);
        Encoding = components.Get<ID>(4, subComponentDelimiter);
        Data = components.Get<TX>(5, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(SourceApplication,encoding),
            SerializePropertyValue(TypeofData,encoding),
            SerializePropertyValue(DataSubtype,encoding),
            SerializePropertyValue(Encoding,encoding),
            SerializePropertyValue(Data,encoding)
        });
}

public sealed record EI : Hl7DataType {
    public ST? EntityIdentifier { get; }
    public IS? NamespaceID { get; }
    public ST? UniversalID { get; }
    public ID? UniversalIDType { get; }

    public EI(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        EntityIdentifier = components.Get<ST>(1, subComponentDelimiter);
        NamespaceID = components.Get<IS>(2, subComponentDelimiter);
        UniversalID = components.Get<ST>(3, subComponentDelimiter);
        UniversalIDType = components.Get<ID>(4, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(EntityIdentifier,encoding),
            SerializePropertyValue(NamespaceID,encoding),
            SerializePropertyValue(UniversalID,encoding),
            SerializePropertyValue(UniversalIDType,encoding)
        });
}

public sealed record EIP : Hl7DataType {
    public EI? PlacerAssignedIdentifier { get; }
    public EI? FillerAssignedIdentifier { get; }

    public EIP(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        PlacerAssignedIdentifier = components.Get<EI>(1, subComponentDelimiter);
        FillerAssignedIdentifier = components.Get<EI>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(PlacerAssignedIdentifier,encoding),
            SerializePropertyValue(FillerAssignedIdentifier,encoding)
        });
}

public sealed record ERL : Hl7DataType {
    public ST? SegmentID { get; }
    public SI? SegmentSequence { get; }
    public SI? FieldPosition { get; }
    public SI? FieldRepetition { get; }
    public SI? ComponentNumber { get; }
    public SI? SubComponentNumber { get; }

    public ERL(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        SegmentID = components.Get<ST>(1, subComponentDelimiter);
        SegmentSequence = components.Get<SI>(2, subComponentDelimiter);
        FieldPosition = components.Get<SI>(3, subComponentDelimiter);
        FieldRepetition = components.Get<SI>(4, subComponentDelimiter);
        ComponentNumber = components.Get<SI>(5, subComponentDelimiter);
        SubComponentNumber = components.Get<SI>(6, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(SegmentID,encoding),
            SerializePropertyValue(SegmentSequence,encoding),
            SerializePropertyValue(FieldPosition,encoding),
            SerializePropertyValue(FieldRepetition,encoding),
            SerializePropertyValue(ComponentNumber,encoding),
            SerializePropertyValue(SubComponentNumber,encoding)
        });
}

public sealed record FC : Hl7DataType {
    public CWE? FinancialClassCode { get; }
    public DTM? EffectiveDate { get; }

    public FC(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        FinancialClassCode = components.Get<CWE>(1, subComponentDelimiter);
        EffectiveDate = components.Get<DTM>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(FinancialClassCode,encoding),
            SerializePropertyValue(EffectiveDate,encoding)
        });
}

public sealed record FN : Hl7DataType {
    public ST? Surname { get; }
    public ST? OwnSurnamePrefix { get; }
    public ST? OwnSurname { get; }
    public ST? SurnamePrefixfromPartnerSpouse { get; }
    public ST? SurnamefromPartnerSpouse { get; }

    public FN(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Surname = components.Get<ST>(1, subComponentDelimiter);
        OwnSurnamePrefix = components.Get<ST>(2, subComponentDelimiter);
        OwnSurname = components.Get<ST>(3, subComponentDelimiter);
        SurnamePrefixfromPartnerSpouse = components.Get<ST>(4, subComponentDelimiter);
        SurnamefromPartnerSpouse = components.Get<ST>(5, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(Surname,encoding),
            SerializePropertyValue(OwnSurnamePrefix,encoding),
            SerializePropertyValue(OwnSurname,encoding),
            SerializePropertyValue(SurnamePrefixfromPartnerSpouse,encoding),
            SerializePropertyValue(SurnamefromPartnerSpouse,encoding)
        });
}

public sealed record HD : Hl7DataType {
    public IS? NamespaceID { get; }
    public ST? UniversalID { get; }
    public ID? UniversalIDType { get; }

    public HD(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        NamespaceID = components.Get<IS>(1, subComponentDelimiter);
        UniversalID = components.Get<ST>(2, subComponentDelimiter);
        UniversalIDType = components.Get<ID>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(NamespaceID,encoding),
            SerializePropertyValue(UniversalID,encoding),
            SerializePropertyValue(UniversalIDType,encoding)
        });
}

public sealed record ICD : Hl7DataType {
    public CWE? CertificationPatientType { get; }
    public ID? CertificationRequired { get; }
    public DTM? DateTimeCertificationRequired { get; }

    public ICD(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        CertificationPatientType = components.Get<CWE>(1, subComponentDelimiter);
        CertificationRequired = components.Get<ID>(2, subComponentDelimiter);
        DateTimeCertificationRequired = components.Get<DTM>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(CertificationPatientType,encoding),
            SerializePropertyValue(CertificationRequired,encoding),
            SerializePropertyValue(DateTimeCertificationRequired,encoding)
        });
}

public sealed record JCC : Hl7DataType {
    public CWE? JobCode { get; }
    public CWE? JobClass { get; }
    public TX? JobDescriptionText { get; }

    public JCC(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        JobCode = components.Get<CWE>(1, subComponentDelimiter);
        JobClass = components.Get<CWE>(2, subComponentDelimiter);
        JobDescriptionText = components.Get<TX>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(JobCode,encoding),
            SerializePropertyValue(JobClass,encoding),
            SerializePropertyValue(JobDescriptionText,encoding)
        });
}

public sealed record MA : Hl7DataType {
    public NM? SampleYFromChannel1 { get; }
    public NM? SampleYFromChannel2 { get; }
    public NM? SampleYFromChannel3 { get; }
    public NM? SampleYFromChannel4 { get; }

    public MA(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        SampleYFromChannel1 = components.Get<NM>(1, subComponentDelimiter);
        SampleYFromChannel2 = components.Get<NM>(2, subComponentDelimiter);
        SampleYFromChannel3 = components.Get<NM>(3, subComponentDelimiter);
        SampleYFromChannel4 = components.Get<NM>(4, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(SampleYFromChannel1,encoding),
            SerializePropertyValue(SampleYFromChannel2,encoding),
            SerializePropertyValue(SampleYFromChannel3,encoding),
            SerializePropertyValue(SampleYFromChannel4,encoding)
        });
}

public sealed record MO : Hl7DataType {
    public NM? Quantity { get; }
    public ID? Denomination { get; }

    public MO(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Quantity = components.Get<NM>(1, subComponentDelimiter);
        Denomination = components.Get<ID>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(Quantity,encoding),
            SerializePropertyValue(Denomination,encoding)
        });
}

public sealed record MOC : Hl7DataType {
    public MO? MonetaryAmount { get; }
    public CWE? ChargeCode { get; }

    public MOC(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        MonetaryAmount = components.Get<MO>(1, subComponentDelimiter);
        ChargeCode = components.Get<CWE>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(MonetaryAmount,encoding),
            SerializePropertyValue(ChargeCode,encoding)
        });
}

public sealed record MOP : Hl7DataType {
    public ID? MoneyorPercentageIndicator { get; }
    public NM? MoneyorPercentageQuantity { get; }
    public ID? MonetaryDenomination { get; }

    public MOP(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        MoneyorPercentageIndicator = components.Get<ID>(1, subComponentDelimiter);
        MoneyorPercentageQuantity = components.Get<NM>(2, subComponentDelimiter);
        MonetaryDenomination = components.Get<ID>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(MoneyorPercentageIndicator,encoding),
            SerializePropertyValue(MoneyorPercentageQuantity,encoding),
            SerializePropertyValue(MonetaryDenomination,encoding)
        });
}

public sealed record MSG : Hl7DataType {
    public ID? MessageCode { get; }
    public ID? TriggerEvent { get; }
    public ID? MessageStructure { get; }

    public MSG(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        MessageCode = components.Get<ID>(1, subComponentDelimiter);
        TriggerEvent = components.Get<ID>(2, subComponentDelimiter);
        MessageStructure = components.Get<ID>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(MessageCode,encoding),
            SerializePropertyValue(TriggerEvent,encoding),
            SerializePropertyValue(MessageStructure,encoding)
        });
}

public sealed record NA : Hl7DataType {
    public NM? Value1 { get; }
    public NM? Value2 { get; }
    public NM? Value3 { get; }
    public NM? Value4 { get; }

    public NA(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Value1 = components.Get<NM>(1, subComponentDelimiter);
        Value2 = components.Get<NM>(2, subComponentDelimiter);
        Value3 = components.Get<NM>(3, subComponentDelimiter);
        Value4 = components.Get<NM>(4, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(Value1,encoding),
            SerializePropertyValue(Value2,encoding),
            SerializePropertyValue(Value3,encoding),
            SerializePropertyValue(Value4,encoding)
        });
}

public sealed record NDL : Hl7DataType {
    public CNN? Name { get; }
    public DTM? StartDateTime { get; }
    public DTM? EndDateTime { get; }
    public IS? PointofCare { get; }
    public IS? Room { get; }
    public IS? Bed { get; }
    public HD? Facility { get; }
    public IS? LocationStatus { get; }
    public IS? PatientLocationType { get; }
    public IS? Building { get; }
    public IS? Floor { get; }

    public NDL(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Name = components.Get<CNN>(1, subComponentDelimiter);
        StartDateTime = components.Get<DTM>(2, subComponentDelimiter);
        EndDateTime = components.Get<DTM>(3, subComponentDelimiter);
        PointofCare = components.Get<IS>(4, subComponentDelimiter);
        Room = components.Get<IS>(5, subComponentDelimiter);
        Bed = components.Get<IS>(6, subComponentDelimiter);
        Facility = components.Get<HD>(7, subComponentDelimiter);
        LocationStatus = components.Get<IS>(8, subComponentDelimiter);
        PatientLocationType = components.Get<IS>(9, subComponentDelimiter);
        Building = components.Get<IS>(10, subComponentDelimiter);
        Floor = components.Get<IS>(11, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(Name,encoding),
            SerializePropertyValue(StartDateTime,encoding),
            SerializePropertyValue(EndDateTime,encoding),
            SerializePropertyValue(PointofCare,encoding),
            SerializePropertyValue(Room,encoding),
            SerializePropertyValue(Bed,encoding),
            SerializePropertyValue(Facility,encoding),
            SerializePropertyValue(LocationStatus,encoding),
            SerializePropertyValue(PatientLocationType,encoding),
            SerializePropertyValue(Building,encoding),
            SerializePropertyValue(Floor,encoding)
        });
}

public sealed record NR : Hl7DataType {
    public NM? LowValue { get; }
    public NM? HighValue { get; }

    public NR(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        LowValue = components.Get<NM>(1, subComponentDelimiter);
        HighValue = components.Get<NM>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(LowValue,encoding),
            SerializePropertyValue(HighValue,encoding)
        });
}

public sealed record OCD : Hl7DataType {
    public CNE? OccurrenceCode { get; }
    public DT? OccurrenceDate { get; }

    public OCD(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        OccurrenceCode = components.Get<CNE>(1, subComponentDelimiter);
        OccurrenceDate = components.Get<DT>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(OccurrenceCode,encoding),
            SerializePropertyValue(OccurrenceDate,encoding)
        });
}

public sealed record OG : Hl7DataType {
    public ST? OriginalSubIdentifier { get; }
    public NM? Group { get; }
    public NM? Sequence { get; }
    public ST? Identifier { get; }

    public OG(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        OriginalSubIdentifier = components.Get<ST>(1, subComponentDelimiter);
        Group = components.Get<NM>(2, subComponentDelimiter);
        Sequence = components.Get<NM>(3, subComponentDelimiter);
        Identifier = components.Get<ST>(4, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(OriginalSubIdentifier,encoding),
            SerializePropertyValue(Group,encoding),
            SerializePropertyValue(Sequence,encoding),
            SerializePropertyValue(Identifier,encoding)
        });
}

public sealed record OSP : Hl7DataType {
    public CNE? OccurrenceSpanCode { get; }
    public DT? OccurrenceSpanStartDate { get; }
    public DT? OccurrenceSpanStopDate { get; }

    public OSP(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        OccurrenceSpanCode = components.Get<CNE>(1, subComponentDelimiter);
        OccurrenceSpanStartDate = components.Get<DT>(2, subComponentDelimiter);
        OccurrenceSpanStopDate = components.Get<DT>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(OccurrenceSpanCode,encoding),
            SerializePropertyValue(OccurrenceSpanStartDate,encoding),
            SerializePropertyValue(OccurrenceSpanStopDate,encoding)
        });
}

public sealed record PIP : Hl7DataType {
    public CWE? Privilege { get; }
    public CWE? PrivilegeClass { get; }
    public DT? ExpirationDate { get; }
    public DT? ActivationDate { get; }
    public EI? Facility { get; }

    public PIP(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Privilege = components.Get<CWE>(1, subComponentDelimiter);
        PrivilegeClass = components.Get<CWE>(2, subComponentDelimiter);
        ExpirationDate = components.Get<DT>(3, subComponentDelimiter);
        ActivationDate = components.Get<DT>(4, subComponentDelimiter);
        Facility = components.Get<EI>(5, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(Privilege,encoding),
            SerializePropertyValue(PrivilegeClass,encoding),
            SerializePropertyValue(ExpirationDate,encoding),
            SerializePropertyValue(ActivationDate,encoding),
            SerializePropertyValue(Facility,encoding)
        });
}

public sealed record PL : Hl7DataType {
    public HD? PointofCare { get; }
    public HD? Room { get; }
    public HD? Bed { get; }
    public HD? Facility { get; }
    public IS? LocationStatus { get; }
    public IS? PersonLocationType { get; }
    public HD? Building { get; }
    public HD? Floor { get; }
    public ST? LocationDescription { get; }
    public EI? ComprehensiveLocationIdentifier { get; }
    public HD? AssigningAuthorityforLocation { get; }

    public PL(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        PointofCare = components.Get<HD>(1, subComponentDelimiter);
        Room = components.Get<HD>(2, subComponentDelimiter);
        Bed = components.Get<HD>(3, subComponentDelimiter);
        Facility = components.Get<HD>(4, subComponentDelimiter);
        LocationStatus = components.Get<IS>(5, subComponentDelimiter);
        PersonLocationType = components.Get<IS>(6, subComponentDelimiter);
        Building = components.Get<HD>(7, subComponentDelimiter);
        Floor = components.Get<HD>(8, subComponentDelimiter);
        LocationDescription = components.Get<ST>(9, subComponentDelimiter);
        ComprehensiveLocationIdentifier = components.Get<EI>(10, subComponentDelimiter);
        AssigningAuthorityforLocation = components.Get<HD>(11, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(PointofCare,encoding),
            SerializePropertyValue(Room,encoding),
            SerializePropertyValue(Bed,encoding),
            SerializePropertyValue(Facility,encoding),
            SerializePropertyValue(LocationStatus,encoding),
            SerializePropertyValue(PersonLocationType,encoding),
            SerializePropertyValue(Building,encoding),
            SerializePropertyValue(Floor,encoding),
            SerializePropertyValue(LocationDescription,encoding),
            SerializePropertyValue(ComprehensiveLocationIdentifier,encoding),
            SerializePropertyValue(AssigningAuthorityforLocation,encoding)
        });
}

public sealed record PLN : Hl7DataType {
    public ST? IDNumber { get; }
    public CWE? TypeofIDNumber { get; }
    public ST? StateotherQualifyingInformation { get; }
    public DT? ExpirationDate { get; }

    public PLN(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        IDNumber = components.Get<ST>(1, subComponentDelimiter);
        TypeofIDNumber = components.Get<CWE>(2, subComponentDelimiter);
        StateotherQualifyingInformation = components.Get<ST>(3, subComponentDelimiter);
        ExpirationDate = components.Get<DT>(4, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(IDNumber,encoding),
            SerializePropertyValue(TypeofIDNumber,encoding),
            SerializePropertyValue(StateotherQualifyingInformation,encoding),
            SerializePropertyValue(ExpirationDate,encoding)
        });
}

public sealed record PPN : Hl7DataType {
    public ST? PersonIdentifier { get; }
    public FN? FamilyName { get; }
    public ST? GivenName { get; }
    public ST? SecondandFurtherGivenNamesorInitialsThereof { get; }
    public ST? Suffix { get; }
    public ST? Prefix { get; }
    public CWE? SourceTable { get; }
    public HD? AssigningAuthority { get; }
    public ID? NameTypeCode { get; }
    public ST? IdentifierCheckDigit { get; }
    public ID? CheckDigitScheme { get; }
    public ID? IdentifierTypeCode { get; }
    public HD? AssigningFacility { get; }
    public DTM? DateTimeActionPerformed { get; }
    public ID? NameRepresentationCode { get; }
    public CWE? NameContext { get; }
    public ID? NameAssemblyOrder { get; }
    public DTM? EffectiveDate { get; }
    public DTM? ExpirationDate { get; }
    public ST? ProfessionalSuffix { get; }
    public CWE? AssigningJurisdiction { get; }
    public CWE? AssigningAgencyorDepartment { get; }
    public ST? SecurityCheck { get; }
    public ID? SecurityCheckScheme { get; }

    public PPN(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        PersonIdentifier = components.Get<ST>(1, subComponentDelimiter);
        FamilyName = components.Get<FN>(2, subComponentDelimiter);
        GivenName = components.Get<ST>(3, subComponentDelimiter);
        SecondandFurtherGivenNamesorInitialsThereof = components.Get<ST>(4, subComponentDelimiter);
        Suffix = components.Get<ST>(5, subComponentDelimiter);
        Prefix = components.Get<ST>(6, subComponentDelimiter);
        SourceTable = components.Get<CWE>(7, subComponentDelimiter);
        AssigningAuthority = components.Get<HD>(8, subComponentDelimiter);
        NameTypeCode = components.Get<ID>(9, subComponentDelimiter);
        IdentifierCheckDigit = components.Get<ST>(10, subComponentDelimiter);
        CheckDigitScheme = components.Get<ID>(11, subComponentDelimiter);
        IdentifierTypeCode = components.Get<ID>(12, subComponentDelimiter);
        AssigningFacility = components.Get<HD>(13, subComponentDelimiter);
        DateTimeActionPerformed = components.Get<DTM>(14, subComponentDelimiter);
        NameRepresentationCode = components.Get<ID>(15, subComponentDelimiter);
        NameContext = components.Get<CWE>(16, subComponentDelimiter);
        NameAssemblyOrder = components.Get<ID>(17, subComponentDelimiter);
        EffectiveDate = components.Get<DTM>(18, subComponentDelimiter);
        ExpirationDate = components.Get<DTM>(19, subComponentDelimiter);
        ProfessionalSuffix = components.Get<ST>(20, subComponentDelimiter);
        AssigningJurisdiction = components.Get<CWE>(21, subComponentDelimiter);
        AssigningAgencyorDepartment = components.Get<CWE>(22, subComponentDelimiter);
        SecurityCheck = components.Get<ST>(23, subComponentDelimiter);
        SecurityCheckScheme = components.Get<ID>(24, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(PersonIdentifier,encoding),
            SerializePropertyValue(FamilyName,encoding),
            SerializePropertyValue(GivenName,encoding),
            SerializePropertyValue(SecondandFurtherGivenNamesorInitialsThereof,encoding),
            SerializePropertyValue(Suffix,encoding),
            SerializePropertyValue(Prefix,encoding),
            SerializePropertyValue(SourceTable,encoding),
            SerializePropertyValue(AssigningAuthority,encoding),
            SerializePropertyValue(NameTypeCode,encoding),
            SerializePropertyValue(IdentifierCheckDigit,encoding),
            SerializePropertyValue(CheckDigitScheme,encoding),
            SerializePropertyValue(IdentifierTypeCode,encoding),
            SerializePropertyValue(AssigningFacility,encoding),
            SerializePropertyValue(DateTimeActionPerformed,encoding),
            SerializePropertyValue(NameRepresentationCode,encoding),
            SerializePropertyValue(NameContext,encoding),
            SerializePropertyValue(NameAssemblyOrder,encoding),
            SerializePropertyValue(EffectiveDate,encoding),
            SerializePropertyValue(ExpirationDate,encoding),
            SerializePropertyValue(ProfessionalSuffix,encoding),
            SerializePropertyValue(AssigningJurisdiction,encoding),
            SerializePropertyValue(AssigningAgencyorDepartment,encoding),
            SerializePropertyValue(SecurityCheck,encoding),
            SerializePropertyValue(SecurityCheckScheme,encoding)
        });
}

public sealed record PRL : Hl7DataType {
    public CWE? ParentObservationIdentifier { get; }
    public ST? ParentObservationSubidentifier { get; }
    public TX? ParentObservationValueDescriptor { get; }

    public PRL(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        ParentObservationIdentifier = components.Get<CWE>(1, subComponentDelimiter);
        ParentObservationSubidentifier = components.Get<ST>(2, subComponentDelimiter);
        ParentObservationValueDescriptor = components.Get<TX>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(ParentObservationIdentifier,encoding),
            SerializePropertyValue(ParentObservationSubidentifier,encoding),
            SerializePropertyValue(ParentObservationValueDescriptor,encoding)
        });
}

public sealed record PT : Hl7DataType {
    public ID? ProcessingID { get; }
    public ID? ProcessingMode { get; }

    public PT(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        ProcessingID = components.Get<ID>(1, subComponentDelimiter);
        ProcessingMode = components.Get<ID>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(ProcessingID,encoding),
            SerializePropertyValue(ProcessingMode,encoding)
        });
}

public sealed record PTA : Hl7DataType {
    public CWE? PolicyType { get; }
    public CWE? AmountClass { get; }
    public MOP? MoneyorPercentage { get; }

    public PTA(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        PolicyType = components.Get<CWE>(1, subComponentDelimiter);
        AmountClass = components.Get<CWE>(2, subComponentDelimiter);
        MoneyorPercentage = components.Get<MOP>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(PolicyType,encoding),
            SerializePropertyValue(AmountClass,encoding),
            SerializePropertyValue(MoneyorPercentage,encoding)
        });
}

public sealed record QIP : Hl7DataType {
    public ST? SegmentFieldName { get; }
    public ST? Values { get; }

    public QIP(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        SegmentFieldName = components.Get<ST>(1, subComponentDelimiter);
        Values = components.Get<ST>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(SegmentFieldName,encoding),
            SerializePropertyValue(Values,encoding)
        });
}

public sealed record QSC : Hl7DataType {
    public ST? SegmentFieldName { get; }
    public ID? RelationalOperator { get; }
    public ST? Value { get; }
    public ID? RelationalConjunction { get; }

    public QSC(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        SegmentFieldName = components.Get<ST>(1, subComponentDelimiter);
        RelationalOperator = components.Get<ID>(2, subComponentDelimiter);
        Value = components.Get<ST>(3, subComponentDelimiter);
        RelationalConjunction = components.Get<ID>(4, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(SegmentFieldName,encoding),
            SerializePropertyValue(RelationalOperator,encoding),
            SerializePropertyValue(Value,encoding),
            SerializePropertyValue(RelationalConjunction,encoding)
        });
}

public sealed record RCD : Hl7DataType {
    public ST? SegmentFieldName { get; }
    public ID? HL7DataType { get; }
    public NM? MaximumColumnWidth { get; }

    public RCD(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        SegmentFieldName = components.Get<ST>(1, subComponentDelimiter);
        HL7DataType = components.Get<ID>(2, subComponentDelimiter);
        MaximumColumnWidth = components.Get<NM>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(SegmentFieldName,encoding),
            SerializePropertyValue(HL7DataType,encoding),
            SerializePropertyValue(MaximumColumnWidth,encoding)
        });
}

public sealed record RFR : Hl7DataType {
    public NR? NumericRange { get; }
    public CWE? AdministrativeSex { get; }
    public NR? AgeRange { get; }
    public NR? GestationalAgeRange { get; }
    public ST? Species { get; }
    public ST? Racesubspecies { get; }
    public TX? Conditions { get; }

    public RFR(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        NumericRange = components.Get<NR>(1, subComponentDelimiter);
        AdministrativeSex = components.Get<CWE>(2, subComponentDelimiter);
        AgeRange = components.Get<NR>(3, subComponentDelimiter);
        GestationalAgeRange = components.Get<NR>(4, subComponentDelimiter);
        Species = components.Get<ST>(5, subComponentDelimiter);
        Racesubspecies = components.Get<ST>(6, subComponentDelimiter);
        Conditions = components.Get<TX>(7, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(NumericRange,encoding),
            SerializePropertyValue(AdministrativeSex,encoding),
            SerializePropertyValue(AgeRange,encoding),
            SerializePropertyValue(GestationalAgeRange,encoding),
            SerializePropertyValue(Species,encoding),
            SerializePropertyValue(Racesubspecies,encoding),
            SerializePropertyValue(Conditions,encoding)
        });
}

public sealed record RI : Hl7DataType {
    public CWE? RepeatPattern { get; }
    public ST? ExplicitTimeInterval { get; }

    public RI(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        RepeatPattern = components.Get<CWE>(1, subComponentDelimiter);
        ExplicitTimeInterval = components.Get<ST>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(RepeatPattern,encoding),
            SerializePropertyValue(ExplicitTimeInterval,encoding)
        });
}

public sealed record RMC : Hl7DataType {
    public CWE? RoomType { get; }
    public CWE? AmountType { get; }
    public MOP? MoneyorPercentage { get; }

    public RMC(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        RoomType = components.Get<CWE>(1, subComponentDelimiter);
        AmountType = components.Get<CWE>(2, subComponentDelimiter);
        MoneyorPercentage = components.Get<MOP>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(RoomType,encoding),
            SerializePropertyValue(AmountType,encoding),
            SerializePropertyValue(MoneyorPercentage,encoding)
        });
}

public sealed record RP : Hl7DataType {
    public ST? Pointer { get; }
    public HD? ApplicationID { get; }
    public ID? TypeofData { get; }
    public ID? Subtype { get; }

    public RP(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Pointer = components.Get<ST>(1, subComponentDelimiter);
        ApplicationID = components.Get<HD>(2, subComponentDelimiter);
        TypeofData = components.Get<ID>(3, subComponentDelimiter);
        Subtype = components.Get<ID>(4, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(Pointer,encoding),
            SerializePropertyValue(ApplicationID,encoding),
            SerializePropertyValue(TypeofData,encoding),
            SerializePropertyValue(Subtype,encoding)
        });
}

public sealed record RPT : Hl7DataType {
    public CWE? RepeatPatternCode { get; }
    public ID? CalendarAlignment { get; }
    public NM? PhaseRangeBeginValue { get; }
    public NM? PhaseRangeEndValue { get; }
    public NM? PeriodQuantity { get; }
    public CWE? PeriodUnits { get; }
    public ID? InstitutionSpecifiedTime { get; }
    public ID? Event { get; }
    public NM? EventOffsetQuantity { get; }
    public CWE? EventOffsetUnits { get; }
    public GTS? GeneralTimingSpecification { get; }

    public RPT(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        RepeatPatternCode = components.Get<CWE>(1, subComponentDelimiter);
        CalendarAlignment = components.Get<ID>(2, subComponentDelimiter);
        PhaseRangeBeginValue = components.Get<NM>(3, subComponentDelimiter);
        PhaseRangeEndValue = components.Get<NM>(4, subComponentDelimiter);
        PeriodQuantity = components.Get<NM>(5, subComponentDelimiter);
        PeriodUnits = components.Get<CWE>(6, subComponentDelimiter);
        InstitutionSpecifiedTime = components.Get<ID>(7, subComponentDelimiter);
        Event = components.Get<ID>(8, subComponentDelimiter);
        EventOffsetQuantity = components.Get<NM>(9, subComponentDelimiter);
        EventOffsetUnits = components.Get<CWE>(10, subComponentDelimiter);
        GeneralTimingSpecification = components.Get<GTS>(11, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(RepeatPatternCode,encoding),
            SerializePropertyValue(CalendarAlignment,encoding),
            SerializePropertyValue(PhaseRangeBeginValue,encoding),
            SerializePropertyValue(PhaseRangeEndValue,encoding),
            SerializePropertyValue(PeriodQuantity,encoding),
            SerializePropertyValue(PeriodUnits,encoding),
            SerializePropertyValue(InstitutionSpecifiedTime,encoding),
            SerializePropertyValue(Event,encoding),
            SerializePropertyValue(EventOffsetQuantity,encoding),
            SerializePropertyValue(EventOffsetUnits,encoding),
            SerializePropertyValue(GeneralTimingSpecification,encoding)
        });
}

public sealed record SAD : Hl7DataType {
    public ST? StreetorMailingAddress { get; }
    public ST? StreetName { get; }
    public ST? DwellingNumber { get; }

    public SAD(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        StreetorMailingAddress = components.Get<ST>(1, subComponentDelimiter);
        StreetName = components.Get<ST>(2, subComponentDelimiter);
        DwellingNumber = components.Get<ST>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(StreetorMailingAddress,encoding),
            SerializePropertyValue(StreetName,encoding),
            SerializePropertyValue(DwellingNumber,encoding)
        });
}

public sealed record SCV : Hl7DataType {
    public CWE? ParameterClass { get; }
    public ST? ParameterValue { get; }

    public SCV(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        ParameterClass = components.Get<CWE>(1, subComponentDelimiter);
        ParameterValue = components.Get<ST>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(ParameterClass,encoding),
            SerializePropertyValue(ParameterValue,encoding)
        });
}

public sealed record SN : Hl7DataType {
    public ST? Comparator { get; }
    public NM? Num1 { get; }
    public ST? SeparatorSuffix { get; }
    public NM? Num2 { get; }

    public SN(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        Comparator = components.Get<ST>(1, subComponentDelimiter);
        Num1 = components.Get<NM>(2, subComponentDelimiter);
        SeparatorSuffix = components.Get<ST>(3, subComponentDelimiter);
        Num2 = components.Get<NM>(4, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(Comparator,encoding),
            SerializePropertyValue(Num1,encoding),
            SerializePropertyValue(SeparatorSuffix,encoding),
            SerializePropertyValue(Num2,encoding)
        });
}

public sealed record SPD : Hl7DataType {
    public ST? SpecialtyName { get; }
    public ST? GoverningBoard { get; }
    public ID? EligibleorCertified { get; }
    public DT? DateofCertification { get; }

    public SPD(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        SpecialtyName = components.Get<ST>(1, subComponentDelimiter);
        GoverningBoard = components.Get<ST>(2, subComponentDelimiter);
        EligibleorCertified = components.Get<ID>(3, subComponentDelimiter);
        DateofCertification = components.Get<DT>(4, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(SpecialtyName,encoding),
            SerializePropertyValue(GoverningBoard,encoding),
            SerializePropertyValue(EligibleorCertified,encoding),
            SerializePropertyValue(DateofCertification,encoding)
        });
}

public sealed record SRT : Hl7DataType {
    public ST? SortbyField { get; }
    public ID? Sequencing { get; }

    public SRT(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        SortbyField = components.Get<ST>(1, subComponentDelimiter);
        Sequencing = components.Get<ID>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(SortbyField,encoding),
            SerializePropertyValue(Sequencing,encoding)
        });
}

public sealed record UVC : Hl7DataType {
    public CWE? ValueCode { get; }
    public MO? ValueAmount { get; }
    public NM? NonMonetaryValueAmountQuantity { get; }
    public CWE? NonMonetaryValueAmountUnits { get; }

    public UVC(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        ValueCode = components.Get<CWE>(1, subComponentDelimiter);
        ValueAmount = components.Get<MO>(2, subComponentDelimiter);
        NonMonetaryValueAmountQuantity = components.Get<NM>(3, subComponentDelimiter);
        NonMonetaryValueAmountUnits = components.Get<CWE>(4, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(ValueCode,encoding),
            SerializePropertyValue(ValueAmount,encoding),
            SerializePropertyValue(NonMonetaryValueAmountQuantity,encoding),
            SerializePropertyValue(NonMonetaryValueAmountUnits,encoding)
        });
}

public sealed record VH : Hl7DataType {
    public ID? StartDayRange { get; }
    public ID? EndDayRange { get; }
    public TM? StartHourRange { get; }
    public TM? EndHourRange { get; }

    public VH(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        StartDayRange = components.Get<ID>(1, subComponentDelimiter);
        EndDayRange = components.Get<ID>(2, subComponentDelimiter);
        StartHourRange = components.Get<TM>(3, subComponentDelimiter);
        EndHourRange = components.Get<TM>(4, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(StartDayRange,encoding),
            SerializePropertyValue(EndDayRange,encoding),
            SerializePropertyValue(StartHourRange,encoding),
            SerializePropertyValue(EndHourRange,encoding)
        });
}

public sealed record VID : Hl7DataType {
    public ID? VersionID { get; }
    public CWE? InternationalizationCode { get; }
    public CWE? InternationalVersionID { get; }

    public VID(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        VersionID = components.Get<ID>(1, subComponentDelimiter);
        InternationalizationCode = components.Get<CWE>(2, subComponentDelimiter);
        InternationalVersionID = components.Get<CWE>(3, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(VersionID,encoding),
            SerializePropertyValue(InternationalizationCode,encoding),
            SerializePropertyValue(InternationalVersionID,encoding)
        });
}

public sealed record VR : Hl7DataType {
    public ST? FirstDataCodeValue { get; }
    public ST? LastDataCodeValue { get; }

    public VR(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        FirstDataCodeValue = components.Get<ST>(1, subComponentDelimiter);
        LastDataCodeValue = components.Get<ST>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(FirstDataCodeValue,encoding),
            SerializePropertyValue(LastDataCodeValue,encoding)
        });
}

public sealed record WVI : Hl7DataType {
    public NM? ChannelNumber { get; }
    public ST? ChannelName { get; }

    public WVI(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        ChannelNumber = components.Get<NM>(1, subComponentDelimiter);
        ChannelName = components.Get<ST>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(ChannelNumber,encoding),
            SerializePropertyValue(ChannelName,encoding)
        });
}

public sealed record WVS : Hl7DataType {
    public ST? SourceOneName { get; }
    public ST? SourceTwoName { get; }

    public WVS(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        SourceOneName = components.Get<ST>(1, subComponentDelimiter);
        SourceTwoName = components.Get<ST>(2, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(SourceOneName,encoding),
            SerializePropertyValue(SourceTwoName,encoding)
        });
}

public sealed record XAD : Hl7DataType {
    public SAD? StreetAddress { get; }
    public ST? OtherDesignation { get; }
    public ST? City { get; }
    public ST? StateorProvince { get; }
    public ST? ZiporPostalCode { get; }
    public ID? Country { get; }
    public ID? AddressType { get; }
    public ST? OtherGeographicDesignation { get; }
    public CWE? CountyParishCode { get; }
    public CWE? CensusTract { get; }
    public ID? AddressRepresentationCode { get; }
    public DTM? EffectiveDate { get; }
    public DTM? ExpirationDate { get; }
    public CWE? ExpirationReason { get; }
    public ID? TemporaryIndicator { get; }
    public ID? BadAddressIndicator { get; }
    public ID? AddressUsage { get; }
    public ST? Addressee { get; }
    public ST? Comment { get; }
    public NM? PreferenceOrder { get; }
    public CWE? ProtectionCode { get; }
    public EI? AddressIdentifier { get; }

    public XAD(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        StreetAddress = components.Get<SAD>(1, subComponentDelimiter);
        OtherDesignation = components.Get<ST>(2, subComponentDelimiter);
        City = components.Get<ST>(3, subComponentDelimiter);
        StateorProvince = components.Get<ST>(4, subComponentDelimiter);
        ZiporPostalCode = components.Get<ST>(5, subComponentDelimiter);
        Country = components.Get<ID>(6, subComponentDelimiter);
        AddressType = components.Get<ID>(7, subComponentDelimiter);
        OtherGeographicDesignation = components.Get<ST>(8, subComponentDelimiter);
        CountyParishCode = components.Get<CWE>(9, subComponentDelimiter);
        CensusTract = components.Get<CWE>(10, subComponentDelimiter);
        AddressRepresentationCode = components.Get<ID>(11, subComponentDelimiter);
        EffectiveDate = components.Get<DTM>(12, subComponentDelimiter);
        ExpirationDate = components.Get<DTM>(13, subComponentDelimiter);
        ExpirationReason = components.Get<CWE>(14, subComponentDelimiter);
        TemporaryIndicator = components.Get<ID>(15, subComponentDelimiter);
        BadAddressIndicator = components.Get<ID>(16, subComponentDelimiter);
        AddressUsage = components.Get<ID>(17, subComponentDelimiter);
        Addressee = components.Get<ST>(18, subComponentDelimiter);
        Comment = components.Get<ST>(19, subComponentDelimiter);
        PreferenceOrder = components.Get<NM>(20, subComponentDelimiter);
        ProtectionCode = components.Get<CWE>(21, subComponentDelimiter);
        AddressIdentifier = components.Get<EI>(22, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(StreetAddress,encoding),
            SerializePropertyValue(OtherDesignation,encoding),
            SerializePropertyValue(City,encoding),
            SerializePropertyValue(StateorProvince,encoding),
            SerializePropertyValue(ZiporPostalCode,encoding),
            SerializePropertyValue(Country,encoding),
            SerializePropertyValue(AddressType,encoding),
            SerializePropertyValue(OtherGeographicDesignation,encoding),
            SerializePropertyValue(CountyParishCode,encoding),
            SerializePropertyValue(CensusTract,encoding),
            SerializePropertyValue(AddressRepresentationCode,encoding),
            SerializePropertyValue(EffectiveDate,encoding),
            SerializePropertyValue(ExpirationDate,encoding),
            SerializePropertyValue(ExpirationReason,encoding),
            SerializePropertyValue(TemporaryIndicator,encoding),
            SerializePropertyValue(BadAddressIndicator,encoding),
            SerializePropertyValue(AddressUsage,encoding),
            SerializePropertyValue(Addressee,encoding),
            SerializePropertyValue(Comment,encoding),
            SerializePropertyValue(PreferenceOrder,encoding),
            SerializePropertyValue(ProtectionCode,encoding),
            SerializePropertyValue(AddressIdentifier,encoding)
        });
}

public sealed record XCN : Hl7DataType {
    public ST? PersonIdentifier { get; }
    public FN? FamilyName { get; }
    public ST? GivenName { get; }
    public ST? SecondandFurtherGivenNamesorInitialsThereof { get; }
    public ST? Suffix { get; }
    public ST? Prefix { get; }
    public CWE? SourceTable { get; }
    public HD? AssigningAuthority { get; }
    public ID? NameTypeCode { get; }
    public ST? IdentifierCheckDigit { get; }
    public ID? CheckDigitScheme { get; }
    public ID? IdentifierTypeCode { get; }
    public HD? AssigningFacility { get; }
    public ID? NameRepresentationCode { get; }
    public CWE? NameContext { get; }
    public ID? NameAssemblyOrder { get; }
    public DTM? EffectiveDate { get; }
    public DTM? ExpirationDate { get; }
    public ST? ProfessionalSuffix { get; }
    public CWE? AssigningJurisdiction { get; }
    public CWE? AssigningAgencyorDepartment { get; }
    public ST? SecurityCheck { get; }
    public ID? SecurityCheckScheme { get; }

    public XCN(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        PersonIdentifier = components.Get<ST>(1, subComponentDelimiter);
        FamilyName = components.Get<FN>(2, subComponentDelimiter);
        GivenName = components.Get<ST>(3, subComponentDelimiter);
        SecondandFurtherGivenNamesorInitialsThereof = components.Get<ST>(4, subComponentDelimiter);
        Suffix = components.Get<ST>(5, subComponentDelimiter);
        Prefix = components.Get<ST>(6, subComponentDelimiter);
        SourceTable = components.Get<CWE>(7, subComponentDelimiter);
        AssigningAuthority = components.Get<HD>(8, subComponentDelimiter);
        NameTypeCode = components.Get<ID>(9, subComponentDelimiter);
        IdentifierCheckDigit = components.Get<ST>(10, subComponentDelimiter);
        CheckDigitScheme = components.Get<ID>(11, subComponentDelimiter);
        IdentifierTypeCode = components.Get<ID>(12, subComponentDelimiter);
        AssigningFacility = components.Get<HD>(13, subComponentDelimiter);
        NameRepresentationCode = components.Get<ID>(14, subComponentDelimiter);
        NameContext = components.Get<CWE>(15, subComponentDelimiter);
        NameAssemblyOrder = components.Get<ID>(16, subComponentDelimiter);
        EffectiveDate = components.Get<DTM>(17, subComponentDelimiter);
        ExpirationDate = components.Get<DTM>(18, subComponentDelimiter);
        ProfessionalSuffix = components.Get<ST>(19, subComponentDelimiter);
        AssigningJurisdiction = components.Get<CWE>(20, subComponentDelimiter);
        AssigningAgencyorDepartment = components.Get<CWE>(21, subComponentDelimiter);
        SecurityCheck = components.Get<ST>(22, subComponentDelimiter);
        SecurityCheckScheme = components.Get<ID>(23, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(PersonIdentifier,encoding),
            SerializePropertyValue(FamilyName,encoding),
            SerializePropertyValue(GivenName,encoding),
            SerializePropertyValue(SecondandFurtherGivenNamesorInitialsThereof,encoding),
            SerializePropertyValue(Suffix,encoding),
            SerializePropertyValue(Prefix,encoding),
            SerializePropertyValue(SourceTable,encoding),
            SerializePropertyValue(AssigningAuthority,encoding),
            SerializePropertyValue(NameTypeCode,encoding),
            SerializePropertyValue(IdentifierCheckDigit,encoding),
            SerializePropertyValue(CheckDigitScheme,encoding),
            SerializePropertyValue(IdentifierTypeCode,encoding),
            SerializePropertyValue(AssigningFacility,encoding),
            SerializePropertyValue(NameRepresentationCode,encoding),
            SerializePropertyValue(NameContext,encoding),
            SerializePropertyValue(NameAssemblyOrder,encoding),
            SerializePropertyValue(EffectiveDate,encoding),
            SerializePropertyValue(ExpirationDate,encoding),
            SerializePropertyValue(ProfessionalSuffix,encoding),
            SerializePropertyValue(AssigningJurisdiction,encoding),
            SerializePropertyValue(AssigningAgencyorDepartment,encoding),
            SerializePropertyValue(SecurityCheck,encoding),
            SerializePropertyValue(SecurityCheckScheme,encoding)
        });
}

public sealed record XON : Hl7DataType {
    public ST? OrganizationName { get; }
    public CWE? OrganizationNameTypeCode { get; }
    public HD? AssigningAuthority { get; }
    public ID? IdentifierTypeCode { get; }
    public HD? AssigningFacility { get; }
    public ID? NameRepresentationCode { get; }
    public ST? OrganizationIdentifier { get; }

    public XON(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        OrganizationName = components.Get<ST>(1, subComponentDelimiter);
        OrganizationNameTypeCode = components.Get<CWE>(2, subComponentDelimiter);
        AssigningAuthority = components.Get<HD>(3, subComponentDelimiter);
        IdentifierTypeCode = components.Get<ID>(4, subComponentDelimiter);
        AssigningFacility = components.Get<HD>(5, subComponentDelimiter);
        NameRepresentationCode = components.Get<ID>(6, subComponentDelimiter);
        OrganizationIdentifier = components.Get<ST>(7, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(OrganizationName,encoding),
            SerializePropertyValue(OrganizationNameTypeCode,encoding),
            SerializePropertyValue(AssigningAuthority,encoding),
            SerializePropertyValue(IdentifierTypeCode,encoding),
            SerializePropertyValue(AssigningFacility,encoding),
            SerializePropertyValue(NameRepresentationCode,encoding),
            SerializePropertyValue(OrganizationIdentifier,encoding)
        });
}

public sealed record XPN : Hl7DataType {
    public FN? FamilyName { get; }
    public ST? GivenName { get; }
    public ST? SecondandFurtherGivenNamesorInitialsThereof { get; }
    public ST? Suffix { get; }
    public ST? Prefix { get; }
    public ID? NameTypeCode { get; }
    public ID? NameRepresentationCode { get; }
    public CWE? NameContext { get; }
    public ID? NameAssemblyOrder { get; }
    public DTM? EffectiveDate { get; }
    public DTM? ExpirationDate { get; }
    public ST? ProfessionalSuffix { get; }
    public ST? CalledBy { get; }

    public XPN(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        FamilyName = components.Get<FN>(1, subComponentDelimiter);
        GivenName = components.Get<ST>(2, subComponentDelimiter);
        SecondandFurtherGivenNamesorInitialsThereof = components.Get<ST>(3, subComponentDelimiter);
        Suffix = components.Get<ST>(4, subComponentDelimiter);
        Prefix = components.Get<ST>(5, subComponentDelimiter);
        NameTypeCode = components.Get<ID>(6, subComponentDelimiter);
        NameRepresentationCode = components.Get<ID>(7, subComponentDelimiter);
        NameContext = components.Get<CWE>(8, subComponentDelimiter);
        NameAssemblyOrder = components.Get<ID>(9, subComponentDelimiter);
        EffectiveDate = components.Get<DTM>(10, subComponentDelimiter);
        ExpirationDate = components.Get<DTM>(11, subComponentDelimiter);
        ProfessionalSuffix = components.Get<ST>(12, subComponentDelimiter);
        CalledBy = components.Get<ST>(13, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(FamilyName,encoding),
            SerializePropertyValue(GivenName,encoding),
            SerializePropertyValue(SecondandFurtherGivenNamesorInitialsThereof,encoding),
            SerializePropertyValue(Suffix,encoding),
            SerializePropertyValue(Prefix,encoding),
            SerializePropertyValue(NameTypeCode,encoding),
            SerializePropertyValue(NameRepresentationCode,encoding),
            SerializePropertyValue(NameContext,encoding),
            SerializePropertyValue(NameAssemblyOrder,encoding),
            SerializePropertyValue(EffectiveDate,encoding),
            SerializePropertyValue(ExpirationDate,encoding),
            SerializePropertyValue(ProfessionalSuffix,encoding),
            SerializePropertyValue(CalledBy,encoding)
        });
}

public sealed record XTN : Hl7DataType {
    public ID? TelecommunicationUseCode { get; }
    public ID? TelecommunicationEquipmentType { get; }
    public ST? CommunicationAddress { get; }
    public SNM? CountryCode { get; }
    public SNM? AreaCityCode { get; }
    public SNM? LocalNumber { get; }
    public SNM? Extension { get; }
    public ST? AnyText { get; }
    public ST? ExtensionPrefix { get; }
    public ST? SpeedDialCode { get; }
    public ST? UnformattedTelephoneNumber { get; }
    public DTM? EffectiveStartDate { get; }
    public DTM? ExpirationDate { get; }
    public CWE? ExpirationReason { get; }
    public CWE? ProtectionCode { get; }
    public EI? SharedTelecommunicationIdentifier { get; }
    public NM? PreferenceOrder { get; }

    public XTN(IReadOnlyList<string> components, char subComponentDelimiter = '^') {
        TelecommunicationUseCode = components.Get<ID>(1, subComponentDelimiter);
        TelecommunicationEquipmentType = components.Get<ID>(2, subComponentDelimiter);
        CommunicationAddress = components.Get<ST>(3, subComponentDelimiter);
        CountryCode = components.Get<SNM>(4, subComponentDelimiter);
        AreaCityCode = components.Get<SNM>(5, subComponentDelimiter);
        LocalNumber = components.Get<SNM>(6, subComponentDelimiter);
        Extension = components.Get<SNM>(7, subComponentDelimiter);
        AnyText = components.Get<ST>(8, subComponentDelimiter);
        ExtensionPrefix = components.Get<ST>(9, subComponentDelimiter);
        SpeedDialCode = components.Get<ST>(10, subComponentDelimiter);
        UnformattedTelephoneNumber = components.Get<ST>(11, subComponentDelimiter);
        EffectiveStartDate = components.Get<DTM>(12, subComponentDelimiter);
        ExpirationDate = components.Get<DTM>(13, subComponentDelimiter);
        ExpirationReason = components.Get<CWE>(14, subComponentDelimiter);
        ProtectionCode = components.Get<CWE>(15, subComponentDelimiter);
        SharedTelecommunicationIdentifier = components.Get<EI>(16, subComponentDelimiter);
        PreferenceOrder = components.Get<NM>(17, subComponentDelimiter);
    }

    public override string Serialize(Hl7Encoding encoding) =>
        string.Join(encoding.ComponentDelimiter, new[] {
            SerializePropertyValue(TelecommunicationUseCode,encoding),
            SerializePropertyValue(TelecommunicationEquipmentType,encoding),
            SerializePropertyValue(CommunicationAddress,encoding),
            SerializePropertyValue(CountryCode,encoding),
            SerializePropertyValue(AreaCityCode,encoding),
            SerializePropertyValue(LocalNumber,encoding),
            SerializePropertyValue(Extension,encoding),
            SerializePropertyValue(AnyText,encoding),
            SerializePropertyValue(ExtensionPrefix,encoding),
            SerializePropertyValue(SpeedDialCode,encoding),
            SerializePropertyValue(UnformattedTelephoneNumber,encoding),
            SerializePropertyValue(EffectiveStartDate,encoding),
            SerializePropertyValue(ExpirationDate,encoding),
            SerializePropertyValue(ExpirationReason,encoding),
            SerializePropertyValue(ProtectionCode,encoding),
            SerializePropertyValue(SharedTelecommunicationIdentifier,encoding),
            SerializePropertyValue(PreferenceOrder,encoding)
        });
}
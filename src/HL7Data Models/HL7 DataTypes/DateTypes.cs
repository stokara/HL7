namespace HL7;

public sealed record AD : Hl7ComplexType {
    public ST? StreetAddress { get; }
    public ST? OtherDesignation { get; }
    public ST? City { get; }
    public ST? StateorProvince { get; }
    public ST? ZiporPostalCode { get; }
    public ID? Country { get; }
    public ID? AddressType { get; }
    public ST? OtherGeographicDesignation { get; }

    public AD(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        StreetAddress = rawComponent.Get<ST>(1);
        OtherDesignation = rawComponent.Get<ST>(2);
        City = rawComponent.Get<ST>(3);
        StateorProvince = rawComponent.Get<ST>(4);
        ZiporPostalCode = rawComponent.Get<ST>(5);
        Country = rawComponent.Get<ID>(6);
        AddressType = rawComponent.Get<ID>(7);
        OtherGeographicDesignation = rawComponent.Get<ST>(8);
    }
}

public sealed record AUI : Hl7ComplexType {
    public ST? AuthorizationNumber { get; }
    public DT? Date { get; }
    public ST? Source { get; }

    public AUI(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        AuthorizationNumber = rawComponent.Get<ST>(1);
        Date = rawComponent.Get<DT>(2);
        Source = rawComponent.Get<ST>(3);
    }
}

public sealed record CCD : Hl7ComplexType {
    public ID? InvocationEvent { get; }
    public DTM? Datetime { get; }

    public CCD(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        InvocationEvent = rawComponent.Get<ID>(1);
        Datetime = rawComponent.Get<DTM>(2);
    }
}

public sealed record CCP : Hl7ComplexType {
    public NM? ChannelCalibrationSensitivityCorrectionFactor { get; }
    public NM? ChannelCalibrationBaseline { get; }
    public NM? ChannelCalibrationTimeSkew { get; }

    public CCP(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        ChannelCalibrationSensitivityCorrectionFactor = rawComponent.Get<NM>(1);
        ChannelCalibrationBaseline = rawComponent.Get<NM>(2);
        ChannelCalibrationTimeSkew = rawComponent.Get<NM>(3);
    }
}

public sealed record CD : Hl7ComplexType {
    public WVI? ChannelIdentifier { get; }
    public WVS? WaveformSource { get; }
    public CSU? ChannelSensitivityandUnits { get; }
    public CCP? ChannelCalibrationParameters { get; }
    public NM? ChannelSamplingFrequency { get; }
    public NR? MinimumandMaximumDataValues { get; }

    public CD(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        ChannelIdentifier = rawComponent.Get<WVI>(1);
        WaveformSource = rawComponent.Get<WVS>(2);
        ChannelSensitivityandUnits = rawComponent.Get<CSU>(3);
        ChannelCalibrationParameters = rawComponent.Get<CCP>(4);
        ChannelSamplingFrequency = rawComponent.Get<NM>(5);
        MinimumandMaximumDataValues = rawComponent.Get<NR>(6);
    }
}

public sealed record CF : Hl7ComplexType {
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

    public CF(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        Identifier = rawComponent.Get<ST>(1);
        FormattedText = rawComponent.Get<FT>(2);
        NameofCodingSystem = rawComponent.Get<ID>(3);
        AlternateIdentifier = rawComponent.Get<ST>(4);
        AlternateFormattedText = rawComponent.Get<FT>(5);
        NameofAlternateCodingSystem = rawComponent.Get<ID>(6);
        CodingSystemVersionID = rawComponent.Get<ST>(7);
        AlternateCodingSystemVersionID = rawComponent.Get<ST>(8);
        OriginalText = rawComponent.Get<ST>(9);
        SecondAlternateIdentifier = rawComponent.Get<ST>(10);
        SecondAlternateFormattedText = rawComponent.Get<FT>(11);
        NameofSecondAlternateCodingSystem = rawComponent.Get<ID>(12);
        SecondAlternateCodingSystemVersionID = rawComponent.Get<ST>(13);
        CodingSystemOID = rawComponent.Get<ST>(14);
        ValueSetOID = rawComponent.Get<ST>(15);
        ValueSetVersionID = rawComponent.Get<DTM>(16);
        AlternateCodingSystemOID = rawComponent.Get<ST>(17);
        AlternateValueSetOID = rawComponent.Get<ST>(18);
        AlternateValueSetVersionID = rawComponent.Get<DTM>(19);
        SecondAlternateCodingSystemOID = rawComponent.Get<ST>(20);
        SecondAlternateValueSetOID = rawComponent.Get<ST>(21);
        SecondAlternateValueSetVersionID = rawComponent.Get<DTM>(22);
    }
}

public sealed record CNE : Hl7ComplexType {
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

    public CNE(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        Identifier = rawComponent.Get<ST>(1);
        Text = rawComponent.Get<ST>(2);
        NameofCodingSystem = rawComponent.Get<ID>(3);
        AlternateIdentifier = rawComponent.Get<ST>(4);
        AlternateText = rawComponent.Get<ST>(5);
        NameofAlternateCodingSystem = rawComponent.Get<ID>(6);
        CodingSystemVersionID = rawComponent.Get<ST>(7);
        AlternateCodingSystemVersionID = rawComponent.Get<ST>(8);
        OriginalText = rawComponent.Get<ST>(9);
        SecondAlternateIdentifier = rawComponent.Get<ST>(10);
        SecondAlternateText = rawComponent.Get<ST>(11);
        NameofSecondAlternateCodingSystem = rawComponent.Get<ID>(12);
        SecondAlternateCodingSystemVersionID = rawComponent.Get<ST>(13);
        CodingSystemOID = rawComponent.Get<ST>(14);
        ValueSetOID = rawComponent.Get<ST>(15);
        ValueSetVersionID = rawComponent.Get<DTM>(16);
        AlternateCodingSystemOID = rawComponent.Get<ST>(17);
        AlternateValueSetOID = rawComponent.Get<ST>(18);
        AlternateValueSetVersionID = rawComponent.Get<DTM>(19);
        SecondAlternateCodingSystemOID = rawComponent.Get<ST>(20);
        SecondAlternateValueSetOID = rawComponent.Get<ST>(21);
        SecondAlternateValueSetVersionID = rawComponent.Get<DTM>(22);
    }
}

public sealed record CNN : Hl7ComplexType {
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

    public CNN(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        IDNumber = rawComponent.Get<ST>(1);
        FamilyName = rawComponent.Get<ST>(2);
        GivenName = rawComponent.Get<ST>(3);
        SecondandFurtherGivenNamesorInitialsThereof = rawComponent.Get<ST>(4);
        Suffix = rawComponent.Get<ST>(5);
        Prefix = rawComponent.Get<ST>(6);
        Degree = rawComponent.Get<IS>(7);
        SourceTable = rawComponent.Get<IS>(8);
        AssigningAuthorityNamespaceID = rawComponent.Get<IS>(9);
        AssigningAuthorityUniversalID = rawComponent.Get<ST>(10);
        AssigningAuthorityUniversalIDType = rawComponent.Get<ID>(11);
    }
}

public sealed record CP : Hl7ComplexType {
    public MO? Price { get; }
    public ID? PriceType { get; }
    public NM? FromValue { get; }
    public NM? ToValue { get; }
    public CWE? RangeUnits { get; }
    public ID? RangeType { get; }

    public CP(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        Price = rawComponent.Get<MO>(1);
        PriceType = rawComponent.Get<ID>(2);
        FromValue = rawComponent.Get<NM>(3);
        ToValue = rawComponent.Get<NM>(4);
        RangeUnits = rawComponent.Get<CWE>(5);
        RangeType = rawComponent.Get<ID>(6);
    }
}

public sealed record CQ : Hl7ComplexType {
    public NM? Quantity { get; }
    public CWE? Units { get; }

    public CQ(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        Quantity = rawComponent.Get<NM>(1);
        Units = rawComponent.Get<CWE>(2);
    }
}

public sealed record CSU : Hl7ComplexType {
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

    public CSU(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        ChannelSensitivity = rawComponent.Get<NM>(1);
        UnitofMeasureIdentifier = rawComponent.Get<ST>(2);
        UnitofMeasureDescription = rawComponent.Get<ST>(3);
        UnitofMeasureCodingSystem = rawComponent.Get<ID>(4);
        AlternateUnitofMeasureIdentifier = rawComponent.Get<ST>(5);
        AlternateUnitofMeasureDescription = rawComponent.Get<ST>(6);
        AlternateUnitofMeasureCodingSystem = rawComponent.Get<ID>(7);
        UnitofMeasureCodingSystemVersionID = rawComponent.Get<ST>(8);
        AlternateUnitofMeasureCodingSystemVersionID = rawComponent.Get<ST>(9);
        OriginalText = rawComponent.Get<ST>(10);
        SecondAlternateUnitofMeasureIdentifier = rawComponent.Get<ST>(11);
        SecondAlternateUnitofMeasureText = rawComponent.Get<ST>(12);
        NameofSecondAlternateUnitofMeasureCodingSystem = rawComponent.Get<ID>(13);
        SecondAlternateUnitofMeasureCodingSystemVersionID = rawComponent.Get<ST>(14);
        UnitofMeasureCodingSystemOID = rawComponent.Get<ST>(15);
        UnitofMeasureValueSetOID = rawComponent.Get<ST>(16);
        UnitofMeasureValueSetVersionID = rawComponent.Get<DTM>(17);
        AlternateUnitofMeasureCodingSystemOID = rawComponent.Get<ST>(18);
        AlternateUnitofMeasureValueSetOID = rawComponent.Get<ST>(19);
        AlternateUnitofMeasureValueSetVersionID = rawComponent.Get<DTM>(20);
        AlternateUnitofMeasureCodingSystemOID2 = rawComponent.Get<ST>(21);
        AlternateUnitofMeasureValueSetOID2 = rawComponent.Get<ST>(22);
        AlternateUnitofMeasureValueSetVersionID2 = rawComponent.Get<ST>(23);
    }
}

public sealed record CWE : Hl7ComplexType {
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

    public CWE(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        Identifier = rawComponent.Get<ST>(1);
        Text = rawComponent.Get<ST>(2);
        NameofCodingSystem = rawComponent.Get<ID>(3);
        AlternateIdentifier = rawComponent.Get<ST>(4);
        AlternateText = rawComponent.Get<ST>(5);
        NameofAlternateCodingSystem = rawComponent.Get<ID>(6);
        CodingSystemVersionID = rawComponent.Get<ST>(7);
        AlternateCodingSystemVersionID = rawComponent.Get<ST>(8);
        OriginalText = rawComponent.Get<ST>(9);
        SecondAlternateIdentifier = rawComponent.Get<ST>(10);
        SecondAlternateText = rawComponent.Get<ST>(11);
        NameofSecondAlternateCodingSystem = rawComponent.Get<ID>(12);
        SecondAlternateCodingSystemVersionID = rawComponent.Get<ST>(13);
        CodingSystemOID = rawComponent.Get<ST>(14);
        ValueSetOID = rawComponent.Get<ST>(15);
        ValueSetVersionID = rawComponent.Get<DTM>(16);
        AlternateCodingSystemOID = rawComponent.Get<ST>(17);
        AlternateValueSetOID = rawComponent.Get<ST>(18);
        AlternateValueSetVersionID = rawComponent.Get<DTM>(19);
        SecondAlternateCodingSystemOID = rawComponent.Get<ST>(20);
        SecondAlternateValueSetOID = rawComponent.Get<ST>(21);
        SecondAlternateValueSetVersionID = rawComponent.Get<DTM>(22);
    }
}

public sealed record CX : Hl7ComplexType {
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

    public CX(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        IDNumber = rawComponent.Get<ST>(1);
        IdentifierCheckDigit = rawComponent.Get<ST>(2);
        CheckDigitScheme = rawComponent.Get<ID>(3);
        AssigningAuthority = rawComponent.Get<HD>(4);
        IdentifierTypeCode = rawComponent.Get<ID>(5);
        AssigningFacility = rawComponent.Get<HD>(6);
        EffectiveDate = rawComponent.Get<DT>(7);
        ExpirationDate = rawComponent.Get<DT>(8);
        AssigningJurisdiction = rawComponent.Get<CWE>(9);
        AssigningAgencyorDepartment = rawComponent.Get<CWE>(10);
        SecurityCheck = rawComponent.Get<ST>(11);
        SecurityCheckScheme = rawComponent.Get<ID>(12);
    }
}

public sealed record DDI : Hl7ComplexType {
    public NM? DelayDays { get; }
    public MO? MonetaryAmount { get; }
    public NM? NumberofDays { get; }

    public DDI(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        DelayDays = rawComponent.Get<NM>(1);
        MonetaryAmount = rawComponent.Get<MO>(2);
        NumberofDays = rawComponent.Get<NM>(3);
    }
}

public sealed record DIN : Hl7ComplexType {
    public DTM? Date { get; }
    public CWE? InstitutionName { get; }

    public DIN(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        Date = rawComponent.Get<DTM>(1);
        InstitutionName = rawComponent.Get<CWE>(2);
    }
}

public sealed record DLD : Hl7ComplexType {
    public CWE? DischargetoLocation { get; }
    public DTM? EffectiveDate { get; }

    public DLD(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        DischargetoLocation = rawComponent.Get<CWE>(1);
        EffectiveDate = rawComponent.Get<DTM>(2);
    }
}

public sealed record DLN : Hl7ComplexType {
    public ST? DriversLicenseNumber { get; }
    public CWE? IssuingStateProvinceCountry { get; }
    public DT? ExpirationDate { get; }

    public DLN(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        DriversLicenseNumber = rawComponent.Get<ST>(1);
        IssuingStateProvinceCountry = rawComponent.Get<CWE>(2);
        ExpirationDate = rawComponent.Get<DT>(3);
    }
}

public sealed record DLT : Hl7ComplexType {
    public NR? NormalRange { get; }
    public NM? NumericThreshold { get; }
    public ID? ChangeComputation { get; }
    public NM? DaysRetained { get; }

    public DLT(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        NormalRange = rawComponent.Get<NR>(1);
        NumericThreshold = rawComponent.Get<NM>(2);
        ChangeComputation = rawComponent.Get<ID>(3);
        DaysRetained = rawComponent.Get<NM>(4);
    }
}

public sealed record DR : Hl7ComplexType {
    public DTM? RangeStartDateTime { get; }
    public DTM? RangeEndDateTime { get; }

    public DR(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        RangeStartDateTime = rawComponent.Get<DTM>(1);
        RangeEndDateTime = rawComponent.Get<DTM>(2);
    }
}

public sealed record DTN : Hl7ComplexType {
    public CWE? DayType { get; }
    public NM? NumberofDays { get; }

    public DTN(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        DayType = rawComponent.Get<CWE>(1);
        NumberofDays = rawComponent.Get<NM>(2);
    }
}

public sealed record ED : Hl7ComplexType {
    public HD? SourceApplication { get; }
    public ID? TypeofData { get; }
    public ID? DataSubtype { get; }
    public ID? Encoding { get; }
    public TX? Data { get; }

    public ED(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        SourceApplication = rawComponent.Get<HD>(1);
        TypeofData = rawComponent.Get<ID>(2);
        DataSubtype = rawComponent.Get<ID>(3);
        Encoding = rawComponent.Get<ID>(4);
        Data = rawComponent.Get<TX>(5);
    }
}

public sealed record EI : Hl7ComplexType {
    public ST? EntityIdentifier { get; }
    public IS? NamespaceID { get; }
    public ST? UniversalID { get; }
    public ID? UniversalIDType { get; }

    public EI(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        EntityIdentifier = rawComponent.Get<ST>(1);
        NamespaceID = rawComponent.Get<IS>(2);
        UniversalID = rawComponent.Get<ST>(3);
        UniversalIDType = rawComponent.Get<ID>(4);
    }
}

public sealed record EIP : Hl7ComplexType {
    public EI? PlacerAssignedIdentifier { get; }
    public EI? FillerAssignedIdentifier { get; }

    public EIP(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        PlacerAssignedIdentifier = rawComponent.Get<EI>(1);
        FillerAssignedIdentifier = rawComponent.Get<EI>(2);
    }
}

public sealed record ERL : Hl7ComplexType {
    public ST? SegmentID { get; }
    public SI? SegmentSequence { get; }
    public SI? FieldPosition { get; }
    public SI? FieldRepetition { get; }
    public SI? ComponentNumber { get; }
    public SI? SubComponentNumber { get; }

    public ERL(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        SegmentID = rawComponent.Get<ST>(1);
        SegmentSequence = rawComponent.Get<SI>(2);
        FieldPosition = rawComponent.Get<SI>(3);
        FieldRepetition = rawComponent.Get<SI>(4);
        ComponentNumber = rawComponent.Get<SI>(5);
        SubComponentNumber = rawComponent.Get<SI>(6);
    }
}

public sealed record FC : Hl7ComplexType {
    public CWE? FinancialClassCode { get; }
    public DTM? EffectiveDate { get; }

    public FC(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        FinancialClassCode = rawComponent.Get<CWE>(1);
        EffectiveDate = rawComponent.Get<DTM>(2);
    }
}

public sealed record FN : Hl7ComplexType {
    public ST? Surname { get; }
    public ST? OwnSurnamePrefix { get; }
    public ST? OwnSurname { get; }
    public ST? SurnamePrefixfromPartnerSpouse { get; }
    public ST? SurnamefromPartnerSpouse { get; }

    public FN(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        Surname = rawComponent.Get<ST>(1);
        OwnSurnamePrefix = rawComponent.Get<ST>(2);
        OwnSurname = rawComponent.Get<ST>(3);
        SurnamePrefixfromPartnerSpouse = rawComponent.Get<ST>(4);
        SurnamefromPartnerSpouse = rawComponent.Get<ST>(5);
    }
}

public sealed record HD : Hl7ComplexType {
    public IS? NamespaceID { get; }
    public ST? UniversalID { get; }
    public ID? UniversalIDType { get; }

    public HD(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        NamespaceID = rawComponent.Get<IS>(1);
        UniversalID = rawComponent.Get<ST>(2);
        UniversalIDType = rawComponent.Get<ID>(3);
    }
}

public sealed record ICD : Hl7ComplexType {
    public CWE? CertificationPatientType { get; }
    public ID? CertificationRequired { get; }
    public DTM? DateTimeCertificationRequired { get; }

    public ICD(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        CertificationPatientType = rawComponent.Get<CWE>(1);
        CertificationRequired = rawComponent.Get<ID>(2);
        DateTimeCertificationRequired = rawComponent.Get<DTM>(3);
    }
}

public sealed record JCC : Hl7ComplexType {
    public CWE? JobCode { get; }
    public CWE? JobClass { get; }
    public TX? JobDescriptionText { get; }

    public JCC(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        JobCode = rawComponent.Get<CWE>(1);
        JobClass = rawComponent.Get<CWE>(2);
        JobDescriptionText = rawComponent.Get<TX>(3);
    }
}

public sealed record MA : Hl7ComplexType {
    public NM? SampleYFromChannel1 { get; }
    public NM? SampleYFromChannel2 { get; }
    public NM? SampleYFromChannel3 { get; }
    public NM? SampleYFromChannel4 { get; }

    public MA(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        SampleYFromChannel1 = rawComponent.Get<NM>(1);
        SampleYFromChannel2 = rawComponent.Get<NM>(2);
        SampleYFromChannel3 = rawComponent.Get<NM>(3);
        SampleYFromChannel4 = rawComponent.Get<NM>(4);
    }
}

public sealed record MO : Hl7ComplexType {
    public NM? Quantity { get; }
    public ID? Denomination { get; }

    public MO(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        Quantity = rawComponent.Get<NM>(1);
        Denomination = rawComponent.Get<ID>(2);
    }
}

public sealed record MOC : Hl7ComplexType {
    public MO? MonetaryAmount { get; }
    public CWE? ChargeCode { get; }

    public MOC(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        MonetaryAmount = rawComponent.Get<MO>(1);
        ChargeCode = rawComponent.Get<CWE>(2);
    }
}

public sealed record MOP : Hl7ComplexType {
    public ID? MoneyorPercentageIndicator { get; }
    public NM? MoneyorPercentageQuantity { get; }
    public ID? MonetaryDenomination { get; }

    public MOP(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        MoneyorPercentageIndicator = rawComponent.Get<ID>(1);
        MoneyorPercentageQuantity = rawComponent.Get<NM>(2);
        MonetaryDenomination = rawComponent.Get<ID>(3);
    }
}

public sealed record MSG : Hl7ComplexType {
    public ID? MessageCode { get; }
    public ID? TriggerEvent { get; }
    public ID? MessageStructure { get; }

    public MSG(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        MessageCode = rawComponent.Get<ID>(1);
        TriggerEvent = rawComponent.Get<ID>(2);
        MessageStructure = rawComponent.Get<ID>(3);
    }
}

public sealed record NA : Hl7ComplexType {
    public NM? Value1 { get; }
    public NM? Value2 { get; }
    public NM? Value3 { get; }
    public NM? Value4 { get; }

    public NA(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        Value1 = rawComponent.Get<NM>(1);
        Value2 = rawComponent.Get<NM>(2);
        Value3 = rawComponent.Get<NM>(3);
        Value4 = rawComponent.Get<NM>(4);
    }
}

public sealed record NDL : Hl7ComplexType {
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

    public NDL(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        Name = rawComponent.Get<CNN>(1);
        StartDateTime = rawComponent.Get<DTM>(2);
        EndDateTime = rawComponent.Get<DTM>(3);
        PointofCare = rawComponent.Get<IS>(4);
        Room = rawComponent.Get<IS>(5);
        Bed = rawComponent.Get<IS>(6);
        Facility = rawComponent.Get<HD>(7);
        LocationStatus = rawComponent.Get<IS>(8);
        PatientLocationType = rawComponent.Get<IS>(9);
        Building = rawComponent.Get<IS>(10);
        Floor = rawComponent.Get<IS>(11);
    }
}

public sealed record NR : Hl7ComplexType {
    public NM? LowValue { get; }
    public NM? HighValue { get; }

    public NR(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        LowValue = rawComponent.Get<NM>(1);
        HighValue = rawComponent.Get<NM>(2);
    }
}

public sealed record OCD : Hl7ComplexType {
    public CNE? OccurrenceCode { get; }
    public DT? OccurrenceDate { get; }

    public OCD(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        OccurrenceCode = rawComponent.Get<CNE>(1);
        OccurrenceDate = rawComponent.Get<DT>(2);
    }
}

public sealed record OG : Hl7ComplexType {
    public ST? OriginalSubIdentifier { get; }
    public NM? Group { get; }
    public NM? Sequence { get; }
    public ST? Identifier { get; }

    public OG(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        OriginalSubIdentifier = rawComponent.Get<ST>(1);
        Group = rawComponent.Get<NM>(2);
        Sequence = rawComponent.Get<NM>(3);
        Identifier = rawComponent.Get<ST>(4);
    }
}

public sealed record OSP : Hl7ComplexType {
    public CNE? OccurrenceSpanCode { get; }
    public DT? OccurrenceSpanStartDate { get; }
    public DT? OccurrenceSpanStopDate { get; }

    public OSP(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        OccurrenceSpanCode = rawComponent.Get<CNE>(1);
        OccurrenceSpanStartDate = rawComponent.Get<DT>(2);
        OccurrenceSpanStopDate = rawComponent.Get<DT>(3);
    }
}

public sealed record PIP : Hl7ComplexType {
    public CWE? Privilege { get; }
    public CWE? PrivilegeClass { get; }
    public DT? ExpirationDate { get; }
    public DT? ActivationDate { get; }
    public EI? Facility { get; }

    public PIP(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        Privilege = rawComponent.Get<CWE>(1);
        PrivilegeClass = rawComponent.Get<CWE>(2);
        ExpirationDate = rawComponent.Get<DT>(3);
        ActivationDate = rawComponent.Get<DT>(4);
        Facility = rawComponent.Get<EI>(5);
    }
}

public sealed record PL : Hl7ComplexType {
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

    public PL(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        PointofCare = rawComponent.Get<HD>(1);
        Room = rawComponent.Get<HD>(2);
        Bed = rawComponent.Get<HD>(3);
        Facility = rawComponent.Get<HD>(4);
        LocationStatus = rawComponent.Get<IS>(5);
        PersonLocationType = rawComponent.Get<IS>(6);
        Building = rawComponent.Get<HD>(7);
        Floor = rawComponent.Get<HD>(8);
        LocationDescription = rawComponent.Get<ST>(9);
        ComprehensiveLocationIdentifier = rawComponent.Get<EI>(10);
        AssigningAuthorityforLocation = rawComponent.Get<HD>(11);
    }
}

public sealed record PLN : Hl7ComplexType {
    public ST? IDNumber { get; }
    public CWE? TypeofIDNumber { get; }
    public ST? StateotherQualifyingInformation { get; }
    public DT? ExpirationDate { get; }

    public PLN(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        IDNumber = rawComponent.Get<ST>(1);
        TypeofIDNumber = rawComponent.Get<CWE>(2);
        StateotherQualifyingInformation = rawComponent.Get<ST>(3);
        ExpirationDate = rawComponent.Get<DT>(4);
    }
}

public sealed record PPN : Hl7ComplexType {
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

    public PPN(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        PersonIdentifier = rawComponent.Get<ST>(1);
        FamilyName = rawComponent.Get<FN>(2);
        GivenName = rawComponent.Get<ST>(3);
        SecondandFurtherGivenNamesorInitialsThereof = rawComponent.Get<ST>(4);
        Suffix = rawComponent.Get<ST>(5);
        Prefix = rawComponent.Get<ST>(6);
        SourceTable = rawComponent.Get<CWE>(7);
        AssigningAuthority = rawComponent.Get<HD>(8);
        NameTypeCode = rawComponent.Get<ID>(9);
        IdentifierCheckDigit = rawComponent.Get<ST>(10);
        CheckDigitScheme = rawComponent.Get<ID>(11);
        IdentifierTypeCode = rawComponent.Get<ID>(12);
        AssigningFacility = rawComponent.Get<HD>(13);
        DateTimeActionPerformed = rawComponent.Get<DTM>(14);
        NameRepresentationCode = rawComponent.Get<ID>(15);
        NameContext = rawComponent.Get<CWE>(16);
        NameAssemblyOrder = rawComponent.Get<ID>(17);
        EffectiveDate = rawComponent.Get<DTM>(18);
        ExpirationDate = rawComponent.Get<DTM>(19);
        ProfessionalSuffix = rawComponent.Get<ST>(20);
        AssigningJurisdiction = rawComponent.Get<CWE>(21);
        AssigningAgencyorDepartment = rawComponent.Get<CWE>(22);
        SecurityCheck = rawComponent.Get<ST>(23);
        SecurityCheckScheme = rawComponent.Get<ID>(24);
    }
}

public sealed record PRL : Hl7ComplexType {
    public CWE? ParentObservationIdentifier { get; }
    public ST? ParentObservationSubidentifier { get; }
    public TX? ParentObservationValueDescriptor { get; }

    public PRL(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        ParentObservationIdentifier = rawComponent.Get<CWE>(1);
        ParentObservationSubidentifier = rawComponent.Get<ST>(2);
        ParentObservationValueDescriptor = rawComponent.Get<TX>(3);
    }
}

public sealed record PT : Hl7ComplexType {
    public ID? ProcessingID { get; }
    public ID? ProcessingMode { get; }

    public PT(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        ProcessingID = rawComponent.Get<ID>(1);
        ProcessingMode = rawComponent.Get<ID>(2);
    }
}

public sealed record PTA : Hl7ComplexType {
    public CWE? PolicyType { get; }
    public CWE? AmountClass { get; }
    public MOP? MoneyorPercentage { get; }

    public PTA(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        PolicyType = rawComponent.Get<CWE>(1);
        AmountClass = rawComponent.Get<CWE>(2);
        MoneyorPercentage = rawComponent.Get<MOP>(3);
    }
}

public sealed record QIP : Hl7ComplexType {
    public ST? SegmentFieldName { get; }
    public ST? Values { get; }

    public QIP(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        SegmentFieldName = rawComponent.Get<ST>(1);
        Values = rawComponent.Get<ST>(2);
    }
}

public sealed record QSC : Hl7ComplexType {
    public ST? SegmentFieldName { get; }
    public ID? RelationalOperator { get; }
    public ST? Value { get; }
    public ID? RelationalConjunction { get; }

    public QSC(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        SegmentFieldName = rawComponent.Get<ST>(1);
        RelationalOperator = rawComponent.Get<ID>(2);
        Value = rawComponent.Get<ST>(3);
        RelationalConjunction = rawComponent.Get<ID>(4);
    }
}

public sealed record RCD : Hl7ComplexType {
    public ST? SegmentFieldName { get; }
    public ID? HL7DataType { get; }
    public NM? MaximumColumnWidth { get; }

    public RCD(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        SegmentFieldName = rawComponent.Get<ST>(1);
        HL7DataType = rawComponent.Get<ID>(2);
        MaximumColumnWidth = rawComponent.Get<NM>(3);
    }
}

public sealed record RFR : Hl7ComplexType {
    public NR? NumericRange { get; }
    public CWE? AdministrativeSex { get; }
    public NR? AgeRange { get; }
    public NR? GestationalAgeRange { get; }
    public ST? Species { get; }
    public ST? Racesubspecies { get; }
    public TX? Conditions { get; }

    public RFR(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        NumericRange = rawComponent.Get<NR>(1);
        AdministrativeSex = rawComponent.Get<CWE>(2);
        AgeRange = rawComponent.Get<NR>(3);
        GestationalAgeRange = rawComponent.Get<NR>(4);
        Species = rawComponent.Get<ST>(5);
        Racesubspecies = rawComponent.Get<ST>(6);
        Conditions = rawComponent.Get<TX>(7);
    }
}

public sealed record RI : Hl7ComplexType {
    public CWE? RepeatPattern { get; }
    public ST? ExplicitTimeInterval { get; }

    public RI(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        RepeatPattern = rawComponent.Get<CWE>(1);
        ExplicitTimeInterval = rawComponent.Get<ST>(2);
    }
}

public sealed record RMC : Hl7ComplexType {
    public CWE? RoomType { get; }
    public CWE? AmountType { get; }
    public MOP? MoneyorPercentage { get; }

    public RMC(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        RoomType = rawComponent.Get<CWE>(1);
        AmountType = rawComponent.Get<CWE>(2);
        MoneyorPercentage = rawComponent.Get<MOP>(3);
    }
}

public sealed record RP : Hl7ComplexType {
    public ST? Pointer { get; }
    public HD? ApplicationID { get; }
    public ID? TypeofData { get; }
    public ID? Subtype { get; }

    public RP(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        Pointer = rawComponent.Get<ST>(1);
        ApplicationID = rawComponent.Get<HD>(2);
        TypeofData = rawComponent.Get<ID>(3);
        Subtype = rawComponent.Get<ID>(4);
    }
}

public sealed record RPT : Hl7ComplexType {
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

    public RPT(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        RepeatPatternCode = rawComponent.Get<CWE>(1);
        CalendarAlignment = rawComponent.Get<ID>(2);
        PhaseRangeBeginValue = rawComponent.Get<NM>(3);
        PhaseRangeEndValue = rawComponent.Get<NM>(4);
        PeriodQuantity = rawComponent.Get<NM>(5);
        PeriodUnits = rawComponent.Get<CWE>(6);
        InstitutionSpecifiedTime = rawComponent.Get<ID>(7);
        Event = rawComponent.Get<ID>(8);
        EventOffsetQuantity = rawComponent.Get<NM>(9);
        EventOffsetUnits = rawComponent.Get<CWE>(10);
        GeneralTimingSpecification = rawComponent.Get<GTS>(11);
    }
}

public sealed record SAD : Hl7ComplexType {
    public ST? StreetorMailingAddress { get; }
    public ST? StreetName { get; }
    public ST? DwellingNumber { get; }

    public SAD(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        StreetorMailingAddress = rawComponent.Get<ST>(1);
        StreetName = rawComponent.Get<ST>(2);
        DwellingNumber = rawComponent.Get<ST>(3);
    }
}

public sealed record SCV : Hl7ComplexType {
    public CWE? ParameterClass { get; }
    public ST? ParameterValue { get; }

    public SCV(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        ParameterClass = rawComponent.Get<CWE>(1);
        ParameterValue = rawComponent.Get<ST>(2);
    }
}

public sealed record SN : Hl7ComplexType {
    public ST? Comparator { get; }
    public NM? Num1 { get; }
    public ST? SeparatorSuffix { get; }
    public NM? Num2 { get; }

    public SN(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        Comparator = rawComponent.Get<ST>(1);
        Num1 = rawComponent.Get<NM>(2);
        SeparatorSuffix = rawComponent.Get<ST>(3);
        Num2 = rawComponent.Get<NM>(4);
    }
}

public sealed record SPD : Hl7ComplexType {
    public ST? SpecialtyName { get; }
    public ST? GoverningBoard { get; }
    public ID? EligibleorCertified { get; }
    public DT? DateofCertification { get; }

    public SPD(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        SpecialtyName = rawComponent.Get<ST>(1);
        GoverningBoard = rawComponent.Get<ST>(2);
        EligibleorCertified = rawComponent.Get<ID>(3);
        DateofCertification = rawComponent.Get<DT>(4);
    }
}

public sealed record SRT : Hl7ComplexType {
    public ST? SortbyField { get; }
    public ID? Sequencing { get; }

    public SRT(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        SortbyField = rawComponent.Get<ST>(1);
        Sequencing = rawComponent.Get<ID>(2);
    }
}

public sealed record UVC : Hl7ComplexType {
    public CWE? ValueCode { get; }
    public MO? ValueAmount { get; }
    public NM? NonMonetaryValueAmountQuantity { get; }
    public CWE? NonMonetaryValueAmountUnits { get; }

    public UVC(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        ValueCode = rawComponent.Get<CWE>(1);
        ValueAmount = rawComponent.Get<MO>(2);
        NonMonetaryValueAmountQuantity = rawComponent.Get<NM>(3);
        NonMonetaryValueAmountUnits = rawComponent.Get<CWE>(4);
    }
}

public sealed record VH : Hl7ComplexType {
    public ID? StartDayRange { get; }
    public ID? EndDayRange { get; }
    public TM? StartHourRange { get; }
    public TM? EndHourRange { get; }

    public VH(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        StartDayRange = rawComponent.Get<ID>(1);
        EndDayRange = rawComponent.Get<ID>(2);
        StartHourRange = rawComponent.Get<TM>(3);
        EndHourRange = rawComponent.Get<TM>(4);
    }
}

public sealed record VID : Hl7ComplexType {
    public ID? VersionID { get; }
    public CWE? InternationalizationCode { get; }
    public CWE? InternationalVersionID { get; }

    public VID(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        VersionID = rawComponent.Get<ID>(1);
        InternationalizationCode = rawComponent.Get<CWE>(2);
        InternationalVersionID = rawComponent.Get<CWE>(3);
    }
}

public sealed record VR : Hl7ComplexType {
    public ST? FirstDataCodeValue { get; }
    public ST? LastDataCodeValue { get; }

    public VR(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        FirstDataCodeValue = rawComponent.Get<ST>(1);
        LastDataCodeValue = rawComponent.Get<ST>(2);
    }
}

public sealed record WVI : Hl7ComplexType {
    public NM? ChannelNumber { get; }
    public ST? ChannelName { get; }

    public WVI(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        ChannelNumber = rawComponent.Get<NM>(1);
        ChannelName = rawComponent.Get<ST>(2);
    }
}

public sealed record WVS : Hl7ComplexType {
    public ST? SourceOneName { get; }
    public ST? SourceTwoName { get; }

    public WVS(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        SourceOneName = rawComponent.Get<ST>(1);
        SourceTwoName = rawComponent.Get<ST>(2);
    }
}

public sealed record XAD : Hl7ComplexType {
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

    public XAD(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        StreetAddress = rawComponent.Get<SAD>(1);
        OtherDesignation = rawComponent.Get<ST>(2);
        City = rawComponent.Get<ST>(3);
        StateorProvince = rawComponent.Get<ST>(4);
        ZiporPostalCode = rawComponent.Get<ST>(5);
        Country = rawComponent.Get<ID>(6);
        AddressType = rawComponent.Get<ID>(7);
        OtherGeographicDesignation = rawComponent.Get<ST>(8);
        CountyParishCode = rawComponent.Get<CWE>(9);
        CensusTract = rawComponent.Get<CWE>(10);
        AddressRepresentationCode = rawComponent.Get<ID>(11);
        EffectiveDate = rawComponent.Get<DTM>(12);
        ExpirationDate = rawComponent.Get<DTM>(13);
        ExpirationReason = rawComponent.Get<CWE>(14);
        TemporaryIndicator = rawComponent.Get<ID>(15);
        BadAddressIndicator = rawComponent.Get<ID>(16);
        AddressUsage = rawComponent.Get<ID>(17);
        Addressee = rawComponent.Get<ST>(18);
        Comment = rawComponent.Get<ST>(19);
        PreferenceOrder = rawComponent.Get<NM>(20);
        ProtectionCode = rawComponent.Get<CWE>(21);
        AddressIdentifier = rawComponent.Get<EI>(22);
    }
}

public sealed record XCN : Hl7ComplexType {
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

    public XCN(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        PersonIdentifier = rawComponent.Get<ST>(1);
        FamilyName = rawComponent.Get<FN>(2);
        GivenName = rawComponent.Get<ST>(3);
        SecondandFurtherGivenNamesorInitialsThereof = rawComponent.Get<ST>(4);
        Suffix = rawComponent.Get<ST>(5);
        Prefix = rawComponent.Get<ST>(6);
        SourceTable = rawComponent.Get<CWE>(7);
        AssigningAuthority = rawComponent.Get<HD>(8);
        NameTypeCode = rawComponent.Get<ID>(9);
        IdentifierCheckDigit = rawComponent.Get<ST>(10);
        CheckDigitScheme = rawComponent.Get<ID>(11);
        IdentifierTypeCode = rawComponent.Get<ID>(12);
        AssigningFacility = rawComponent.Get<HD>(13);
        NameRepresentationCode = rawComponent.Get<ID>(14);
        NameContext = rawComponent.Get<CWE>(15);
        NameAssemblyOrder = rawComponent.Get<ID>(16);
        EffectiveDate = rawComponent.Get<DTM>(17);
        ExpirationDate = rawComponent.Get<DTM>(18);
        ProfessionalSuffix = rawComponent.Get<ST>(19);
        AssigningJurisdiction = rawComponent.Get<CWE>(20);
        AssigningAgencyorDepartment = rawComponent.Get<CWE>(21);
        SecurityCheck = rawComponent.Get<ST>(22);
        SecurityCheckScheme = rawComponent.Get<ID>(23);
    }
}

public sealed record XON : Hl7ComplexType {
    public ST? OrganizationName { get; }
    public CWE? OrganizationNameTypeCode { get; }
    public HD? AssigningAuthority { get; }
    public ID? IdentifierTypeCode { get; }
    public HD? AssigningFacility { get; }
    public ID? NameRepresentationCode { get; }
    public ST? OrganizationIdentifier { get; }

    public XON(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        OrganizationName = rawComponent.Get<ST>(1);
        OrganizationNameTypeCode = rawComponent.Get<CWE>(2);
        AssigningAuthority = rawComponent.Get<HD>(3);
        IdentifierTypeCode = rawComponent.Get<ID>(4);
        AssigningFacility = rawComponent.Get<HD>(5);
        NameRepresentationCode = rawComponent.Get<ID>(6);
        OrganizationIdentifier = rawComponent.Get<ST>(7);
    }
}

public sealed record XPN : Hl7ComplexType {
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

    public XPN(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        FamilyName = rawComponent.Get<FN>(1);
        GivenName = rawComponent.Get<ST>(2);
        SecondandFurtherGivenNamesorInitialsThereof = rawComponent.Get<ST>(3);
        Suffix = rawComponent.Get<ST>(4);
        Prefix = rawComponent.Get<ST>(5);
        NameTypeCode = rawComponent.Get<ID>(6);
        NameRepresentationCode = rawComponent.Get<ID>(7);
        NameContext = rawComponent.Get<CWE>(8);
        NameAssemblyOrder = rawComponent.Get<ID>(9);
        EffectiveDate = rawComponent.Get<DTM>(10);
        ExpirationDate = rawComponent.Get<DTM>(11);
        ProfessionalSuffix = rawComponent.Get<ST>(12);
        CalledBy = rawComponent.Get<ST>(13);
    }
}

public sealed record XTN : Hl7ComplexType {
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

    public XTN(string? rawComponentString, Hl7Encoding encoding, Hl7Structure sourceStructure) {
        var rawComponent = new RawComponent(rawComponentString, encoding, sourceStructure);
        if (rawComponent.SubComponents.Length == 0) {
            this.StringValue = rawComponent.ComponentValue;
            this.Complexity = HL7.Complexity.Simple;
            return;
        }
        TelecommunicationUseCode = rawComponent.Get<ID>(1);
        TelecommunicationEquipmentType = rawComponent.Get<ID>(2);
        CommunicationAddress = rawComponent.Get<ST>(3);
        CountryCode = rawComponent.Get<SNM>(4);
        AreaCityCode = rawComponent.Get<SNM>(5);
        LocalNumber = rawComponent.Get<SNM>(6);
        Extension = rawComponent.Get<SNM>(7);
        AnyText = rawComponent.Get<ST>(8);
        ExtensionPrefix = rawComponent.Get<ST>(9);
        SpeedDialCode = rawComponent.Get<ST>(10);
        UnformattedTelephoneNumber = rawComponent.Get<ST>(11);
        EffectiveStartDate = rawComponent.Get<DTM>(12);
        ExpirationDate = rawComponent.Get<DTM>(13);
        ExpirationReason = rawComponent.Get<CWE>(14);
        ProtectionCode = rawComponent.Get<CWE>(15);
        SharedTelecommunicationIdentifier = rawComponent.Get<EI>(16);
        PreferenceOrder = rawComponent.Get<NM>(17);
    }
}


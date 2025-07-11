﻿using HL7;
using Xunit;

namespace HL7test;

public class SegmentBuilderTests {
    private readonly HL7Encoding defaultEncoder = new(
        fieldDelimiter: '|',
        componentDelimiter: '^',
        repeatDelimiter: '~',
        escapeCharacter: '\\',
        subComponentDelimiter: '&'
    );

    [Fact]
    public void SegmentLoaderLoadsFT1Segment() {
        var segment = Segment.Parse(defaultEncoder, "FT1|1|202507021200|202507021200||CG|12345^XR CHEST 2 VIEWS^CPT|1|100.00|||1234^Smith^John^A");
        var ft1 = HL7DataLoader.Create(segment);
        Assert.Equal(typeof(FT1), ft1.GetType());
    }


    [Fact]
    public void PV1Segment_ConstructorWorks() {
        var segment = Segment.Parse(defaultEncoder, "PV1|1|E|ED^^^UNV|C|||999-99-9999^MUNCHER^CHANDRA^ANDRIA^MD^DR|888-88-8888^SMETHERS^ANNETTA^JONI^MD^DR||||||7||||REF||||||||||||||||||||||||||20180301010000\r\n");
        var pv1 = new PV1(segment);
        Assert.Equal(1, pv1.SetId);
    }

    [Fact]
    public void IN1Segment_ConstructorWorks() {
        var segment = Segment.Parse(defaultEncoder, "IN1|1|BLUECROSS|BLUE CROSS|PO BOX 5678^CITY^ST^67890||(800)555-1111|987654321|WHITE^CAROL^E|SELF|19780322|F|||987654321|123-45-6789\r\n");
        var in1 = new IN1(segment);
        Assert.Equal("BLUECROSS", in1.InsurancePlanId.SingleItem.Text);
    }


    [Fact]
    public void IN2Segment_ConstructorWorks() {
        var segment = Segment.Parse(defaultEncoder, "IN2|1|SECONDARY|SECONDARY INSURANCE|PO BOX 9999^CITY^ST^99999||(800)555-2222|555555555|WHITE^CAROL^E|SELF|19780322|F|||555555555|321-54-9876");
        var in2 = new IN2(segment);
        Assert.Equal("SECONDARY INSURANCE", in2.InsuranceCompanyId.SingleItem.Id);
    }
    

}
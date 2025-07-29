namespace Omi.Fix.Txt.Tests;

using NUnit.Framework;

/// <summary>
///  Regression tests for fix txt enums
/// </summary>

public class EnumTests
{
    [Test]
    public void VerifyEnumsFromTxt()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples", "Enums.txt");

        var expected = "N";
        var actual = Enums.From(path)["Bool"].Values[1].Data;

        Assert.That(actual, Is.EqualTo(expected), "Verify enums correctly parsed from file");
    }

    [Test]
    public void VerifyEnumValuesFromRecord()
    {
        var expected = "0";
        var actual = Enums.From(["ExecTransType:enum:New=0,Cancel=1,Correct=2,Status=3"])["ExecTransType"].Values[0].Data;

        Assert.That(actual, Is.EqualTo(expected), "Verify enums from record");
    }

    [Test]
    public void VerifyEnumValueNameFromRecordMacroCase()
    {
        var format = new PascalFormatter();
        var expected = "MacroCase";
        var actual = Enums.From(["ENUM:enum:MACRO_CASE=2"], format)["ENUM"].Values[0].Name;

        Assert.That(actual, Is.EqualTo(expected), "Verify enums from record");
    }

    [Test]
    public void VerifyEnumNameFromRecordPascalCase()
    {
        var expected = "ExecTransType";
        var actual = Enum.From("ExecTransType:enum:New=0,Cancel=1,Correct=2,Status=3").Name;

        Assert.That(actual, Is.EqualTo(expected), "Verify enum name correctly parsed from record");
    }

    [Test]
    public void VerifyEnumsExcludesComments()
    {
        var actual = Enums.From(["# This is a comment"]);

        Assert.That(actual, Is.Empty, "Verify comments do not get read");
    }

    [Test]
    public void VerifyEnumValueFromLine()
    {
        var expected = "2";
        var actual = Enum.From("ExecTransType:enum:New=0,Cancel=1,Correct=2,Status=3").Values[2].Data;

        Assert.That(actual, Is.EqualTo(expected), "Verify enum value correctly parsed from record");
    }
}
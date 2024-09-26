namespace Omi.Fix.Txt.Test;
    using NUnit.Framework;

/// <summary>
///  Regression tests for fix text field records
/// </summary>

public class FieldTests
{
    [Test]
    public void VerifyFieldNumberFromLine()
    {
        var field = Field.From("1:Account:string");

        var expected = "1";
        var actual = field.Number;

        Assert.That(actual, Is.EqualTo(expected), "Verify field tag number from FIX text field line");
    }

    [Test]
    public void VerifyFieldNameFromLine()
    {
        var field = Field.From("1:Account:string");

        var expected = "Account";
        var actual = field.Name;

        Assert.That(actual, Is.EqualTo(expected), "Verify field name from FIX text field line");
    }

    [Test]
    public void VerifyFieldTypeStringFromLine()
    {
        var field = Field.From("1:Account:string");

        var expected = "string";
        var actual = field.Type;

        Assert.That(actual, Is.EqualTo(expected), "Verify string field type for FIX text field line");
    }

    [Test]
    public void VerifyFieldTypeCommentFromLine()
    {
        var expected = Field.From("1:Account:string").ToString();
        var actual = Field.From("1:Account:string #Comment").ToString();

        Assert.That(actual, Is.EqualTo(expected), "Verify field comments are trimmed for FIX text field line");
    }

    [Test]
    public void VerifyInvalidLineThrowsError()
        => Assert.Throws<ArgumentException>(() => Field.From("1:Account:"), "Verify Line missing type is invalid");
}
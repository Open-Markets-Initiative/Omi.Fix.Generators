namespace Omi.Fix.Specification.Test;
    using NUnit.Framework;

/// <summary>
///  Regression tests for normalized fix specification merge
/// </summary>

public class SpecificationTests
{
    [Test]
    public void VerifyEnumToString()
    {
        var @enum = new Enum
        {
            Name = "Name",
            Value = "VALUE",
            Description = "Description"
        };

        var expected = "Name [VALUE] Description";
        var actual = @enum.ToString();

        Assert.That(actual, Is.EqualTo(expected), "Verify Enum ToString() Method");
    }

    [Test]
    public void MessageAddFieldTest()
    {
        Message message = new Message();
        message.AddField("newField", new Kind());
        message.AddField("newField", new Kind());

        var actual = message.Fields.Count;

        Assert.That(actual, Is.EqualTo(2), "Verify Message AddField() Method");
    }

    // TYPES TESTS

    [Test]
    public void TypeToFieldTest()
    {
        Type type = new Type();
        type.Name = "typeName";
        Field field = type.ToField();

        Field field2 = new Field();
        field2.Name = "typeName";

        var actual = field.ToString();
        var expected = field2.ToString();

        Assert.That(actual, Is.EqualTo(expected), "Verify Type ToField() Method");
    }

    [Test]
    public void VerifyRequiredComponentsTest()
    {
        Field parent = new()
        {
            Name = "parent",
            Required = true,
        };
        Field field = new()
        {
            Name = "field",
            Required = false
        };
        Field component = new()
        {
            Name = "component",
            Kind = Kind.Component
        };
        parent.Children = [field, component];

        HashSet<string> set = [];
        Gather.RequiredComponentsIn(parent, set);

        var actual = set.Count;
        var expected = 1;

        Assert.That(actual, Is.EqualTo(expected), "Verify Gather RequiredComponentsIn() Method");
    }

    [Test]
    public void NormalizeUnderLyingTypesTest()
    {
        Type type = new Type { Tag = 1, Name = "One" };
        type.Underlying = "Qty";
        var specifications = new Fix.Specification.Document{Types = new Types(new[] {type})};

        Normalize.UnderlyingTypes(specifications);

        var actual = specifications.Types.ToList()[0].Underlying;
        var expected = "FLOAT";

        Assert.That(actual, Is.EqualTo(expected), "Verify Normalize UnderlyingTypes() Method");
    }

    [Test]
    public void VerifyCleanComponentsTest()
    {
        // this is a strange test
        Components components = [
            new Component() { Name = "one" }, 
            new Component() { Name = "required" }];

        HashSet<string> required = ["required"];
        Document document = new Document() {Components = components };

        Clean.Components(document, required);

        var actual = "";
        foreach(var comp in document.Components)
        {
            actual += comp.Name + ", ";
        }
        var expected = "required, ";

        Assert.That(actual, Is.EqualTo(expected), "Verify Clean Components() Method");
    }
}
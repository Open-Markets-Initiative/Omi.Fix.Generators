namespace Omi.Fix.Specification.Test;
    using NUnit.Framework;
using System.Collections;
using System.Security.Cryptography;

/// <summary>
///  Regression tests for normalized fix specification merge
/// </summary>

public class SpecTests
{

    // ENUM TESTS

    [Test]
    public void EnumToStringTest()
    {
        Enum e = new Enum();
        e.Name = "NAME";
        e.Value = "VALUE";
        e.Description = "DESC";

        var actual = e.ToString();
        var expected = "NAME [VALUE] DESC";

        Assert.That(actual, Is.EqualTo(expected), "Verify Enum ToString() Method");
    }


    // MESSAGE TESTS

    [Test]
    public void MessageAddFieldTest()
    {
        Message message = new Message();
        message.AddField("newField", new Kind());
        message.AddField("newField", new Kind());

        var actual = message.Fields.Count();

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


    // GATHER TESTS

    [Test]
    public void GatherRequiredComponentsTest()
    {
        Field field1 = new Field {
            Name = "testing1",
            Kind = Kind.Component,
            Required = true
        };
        Field field2 = new Field
        {
            Name = "testing2",
            Kind = Kind.Component,
            Required = false
        };
        Field field3 = new Field
        {
            Name = "testing3",
            Kind = Kind.Component,
            Required = true
        };
        Field field4 = new Field
        {
            Name = "testing4",
            Kind = Kind.Component,
            Required = false
        };

        List<Field> children = new List<Field>();
        children.Add(field2);
        children.Add(field3);
        children.Add(field4);
        field1.Children = children;

        HashSet<string> set = new HashSet<string>();
        Gather.RequiredComponentsIn(field1, set);

        var actual = set.Count();
        var expected = 2;

        Assert.That(actual, Is.EqualTo(expected), "Verify Gather RequiredComponentsIn() Method");
    }


    //  NORMALIZE TESTS

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


    //  CLEAN TESTS

    [Test]
    public void CleanComponentsTest()
    {
        Components components = new Fix.Specification.Components();
        components.Add(new Component() { Name = "field1" });
        components.Add(new Component() { Name = "field2" });

        HashSet<string> required = new HashSet<string>();
        required.Add("field2");
        Document document = new Document() {Components = components };

        Clean.Components(document, required);

        var actual = "";
        foreach(var comp in document.Components)
        {
            actual += comp.Name + ", ";
        }
        var expected = "field2, ";

        Assert.That(actual, Is.EqualTo(expected), "Verify Clean Components() Method");
    }
}
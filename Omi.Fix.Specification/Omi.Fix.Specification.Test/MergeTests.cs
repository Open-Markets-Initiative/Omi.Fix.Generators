namespace Omi.Fix.Specification.Test;
    using NUnit.Framework;

/// <summary>
///  Regression tests for normalized fix specification merge
/// </summary>

public class MergeTests
{

    [Test]
    public void VerifySpecificationsMerged()
    {
        // this is garbage...do better
        var specifications = new[] {
            new Fix.Specification.Document {
                Types = new Types(new[] {
                    new Type { Tag = 1, Name = "One" },
                    new Type { Tag = 2, Name = "Two" } }
                )
            },
            new Fix.Specification.Document {
                Types = new Types(new[] {
                    new Type { Tag = 3, Name = "Three" },
                    new Type { Tag = 2, Name = "Two" } }
                )
            }
            };

        var specification = Merge.All(specifications);

        var expected = 3;
        var actual = specification.Types.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify specification types merge");
    }
}
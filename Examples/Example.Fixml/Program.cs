using Omi.Fix.Specification;

// Load fixml from library

var fixml = Omi.Fixml.Document.From(@"Library\Fixml\Fix.v4.2.xml");

// Convert to normalized specification
var specification = fixml.ToSpecification();

// make a few edits
specification.Information.Organization = "Omi";
specification.SetNotRequired("ExecInst");

fixml.WriteTo("Example.xml");
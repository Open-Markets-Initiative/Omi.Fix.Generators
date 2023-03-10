// Load fixml from library
var fixml = Omi.Fixml.Document.From(@"Library\Fixml\Fix.v4.2.xml");

// Convert to normalized specification
var specification = fixml.ToSpecification();

// make a few edits



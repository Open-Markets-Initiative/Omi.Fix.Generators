// Load example fix types xml
var xml = Omi.Fix.Types.Library.Fix42;
var specification = xml.ToSpecification();
var types = Omi.Fix.Types.Document.From(specification);

// Write fix types
types.WriteTo("Example.xml");
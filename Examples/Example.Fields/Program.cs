// Load example fix fields xml
var fields = Omi.Fix.Fields.Library.Fix42;
var specification = fields.ToSpecification();
var types = Omi.Fix.Fields.Document.From(specification);

// Write fix types
types.WriteTo("Example.xml");
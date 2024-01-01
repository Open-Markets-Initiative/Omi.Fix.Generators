var specification = Omi.Fixml.Library.Fix44.ToSpecification();

// only use admin messages
specification.Filter(Omi.Fix.Specification.Include.Admin);

// reduce to required fields/components
specification.Normalize();

// write fixml 
var fixml = Omi.Fixml.Document.From(specification);
fixml.WriteTo("Example.xml");
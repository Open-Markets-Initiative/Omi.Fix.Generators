using Omi.Fix.Specification.FixXml;

var specification = Omi.Fix.Xml.Library.Fix44.ToSpecification();

// only use admin messages
specification.Filter(Omi.Fix.Specification.Include.Admin);

// reduce to required fields/components
specification.Normalize();

// write fixml
var fixml = specification.ToXml();
fixml.WriteTo("Example.xml");
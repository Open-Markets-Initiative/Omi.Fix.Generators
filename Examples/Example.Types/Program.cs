// Load example fix types xml
using System.Globalization;
using System.Text;

var xml = Omi.Fix.Types.Library.Fix42;
var specification = xml.ToSpecification();
var types = Omi.Fix.Types.Document.From(specification);

// Write fix types
types.WriteTo("Example.xml");

// Load example fix types xml
var xml2 = Omi.Fix.Types.Document.FromTypesXml("Example.xml");
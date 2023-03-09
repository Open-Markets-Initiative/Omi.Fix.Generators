// Load standard fixml
var fix42 = Omi.Fixml.Document.From(@"Library\Fixml\Fix.v4.2.xml");

var specification = fix42.ToSpecification();
var fixml = Omi.Fixml.Document.From(specification);

fixml.WriteTo(@"test.xml");
// makes this a library
var fix42 = Omi.Fixml.Document.From(@"Fixml\Fix.v4.2.xml");

var specification = fix42.ToSpecification();
var fixml = Omi.Fixml.Document.From(specification);

fixml.WriteTo(@"test.xml");
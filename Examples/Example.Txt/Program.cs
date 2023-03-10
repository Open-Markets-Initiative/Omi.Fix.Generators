// Load example fix txt
var fixtxt = Omi.Fix.Txt.Document.From(@"Example.txt");
var specification = fixtxt.ToSpecification();

// Convert to fixml (set version manually) 
var fixml = Omi.Fixml.Document.From(specification);
  fixml.Major = "4";
  fixml.Minor = "2";

fixml.WriteTo("Example.xml");

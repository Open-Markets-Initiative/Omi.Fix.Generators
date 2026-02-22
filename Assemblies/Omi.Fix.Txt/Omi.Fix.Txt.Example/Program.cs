using Omi.Fix.Specification.FixXml;

 // Load example fix txt
var txt = Omi.Fix.Txt.Document.From(@"Example.txt");
var specification = txt.ToSpecification();

// Convert to fixml (set version manually)
var fixml = specification.ToXml();
  fixml.Information.Major = "4";
  fixml.Information.Minor = "2";

fixml.WriteTo("Example.xml");
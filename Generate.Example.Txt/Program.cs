// Load example fix txt
var file = @"D:\git_users\Sophia\fixgenerators\Omi.Fix.Txt\SampleDefinition.txt";
var document = Omi.Fix.Txt.Document.From(file);
var specification = document.ToSpecification();

// Convert to fixml (set version manually) 
var fixml = Omi.Fixml.Document.From(specification);
  fixml.Major = "4";
  fixml.Minor = "2";

fixml.WriteTo("example.xml");

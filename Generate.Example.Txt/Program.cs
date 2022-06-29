
// Creates a fixml document from two seperate text files


// read in lines into an superlist from desired files, and then create the spec 

var Lines = File.ReadLines(@"D:\git_users\Sophia\fixgenerators\Omi.Fix.Txt\SampleDefinition.txt");

var fixtext = Omi.Fix.Txt.Document.From(Lines);
var texttoSpec = fixtext.ToSpecification();


// specify document header manually 
var specFIX = Omi.Fixml.Document.From(texttoSpec);
specFIX.Major = "4";
specFIX.Minor = "2";

// write to fixml file format
specFIX.WriteTo("fixfromtxt.xml");

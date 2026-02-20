// Load fixml from library
var fixml = Omi.Fix.Xml.Library.Fix42;

// Filter to admin messages
fixml.Filter(message => message.Category == "admin");

// Write out new fixml
fixml.WriteTo("Example.xml");

// Read in manipulated fixml
var example = Omi.Fix.Xml.Document.From("Example.xml");
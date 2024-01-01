// Load fixml from library
var fixml = Omi.Fixml.Library.Fix44;

// Filter to admin messages
fixml.Filter(message => message.Category == "admin");

fixml.WriteTo("Example.xml");
// Load fix intermediate from library
var fixml = Omi.Fix.Sbe.Library.OptiqOrderEntry.Combined();

// Filter to admin messages
fixml.Filter(message => message.Category == "admin");

// Load fix intermediate from library
var Optiq = Omi.Fix.Sbe.Library.OptiqOrderEntry.Combined();

// Load fix intermediate from library
var iLink3 = Omi.Fix.Sbe.Library.iLink3.Combined();

// Filter to admin messages
iLink3.Filter(message => message.Category == "admin");

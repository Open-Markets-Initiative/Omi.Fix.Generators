// Load OptiqOrderGateway combined FIX intermediate from library
var Optiq = Omi.Fix.Sbe.Library.OptiqOrderEntry.Combined();

// Load latest 2 iLink3 FIX specs
var iLink3 = Omi.Fix.Sbe.Library.iLink3.Active();

// Filter to admin messages
iLink3.Filter(message => message.Category == "admin");

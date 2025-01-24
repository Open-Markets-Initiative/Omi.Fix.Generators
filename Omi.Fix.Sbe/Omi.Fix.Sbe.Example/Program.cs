// Load OptiqOrderGateway FIX intermediate from library
var Optiq = Omi.Fix.Sbe.Library.OptiqOrderEntry.Combined();

// Load iLink3 FIX intermediate
var iLink3 = Omi.Fix.Sbe.Library.iLink3.Combined();

// Filter to admin messages
iLink3.Filter(message => message.Category == "admin");

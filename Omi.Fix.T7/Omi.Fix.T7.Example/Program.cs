// Load Eti combined FIX intermediate from library
var eti = Omi.Fix.T7.Library.EtiDerivatives.Combined();

// Filter to admin messages
eti.Filter(message => message.Category == "admin");

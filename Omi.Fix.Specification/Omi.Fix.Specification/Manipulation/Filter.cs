namespace Omi.Fix.Specification {
    using System.Collections.Generic;
    using System.Linq;

    public partial class Include {

        /// <summary>
        ///  RInclude only admin messages
        /// </summary>
        public static bool Admin(Omi.Fix.Specification.Message message)
            => message.Category != "admin"; // need to figure out - this looks backwards
}}

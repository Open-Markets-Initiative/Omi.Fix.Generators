namespace Omi.Fix.Specification {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///  Normalized Fix Specification Enum List
    /// </summary>

    public class Enums : List<Enum> {

        /// <summary>
        ///  Does fix type have any enumerated values
        /// </summary>
        public bool Exist
            => this.Any();
    }
}
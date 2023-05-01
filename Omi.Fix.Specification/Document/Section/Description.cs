namespace Omi.Fix.Specification {

    /// <summary>
    ///  Normalized Fix Specification Information
    /// </summary>

    public class Description {

        // Need to add a bunch more (organization, category, etc)

        /// <summary>
        ///  Fix Specification Major Version
        /// </summary>
        public string Major = string.Empty;

        /// <summary>
        ///  Fix Specification Minor Version
        /// </summary>
        public string Minor = string.Empty;

        /// <summary>
        ///  Display Fix Specification Information
        /// </summary>
        public override string ToString()
            => $" Version {Major}.{Minor}";
    }
}
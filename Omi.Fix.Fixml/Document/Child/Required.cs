namespace Omi.Fixml {
    using System;

    /// <summary>
    ///  Child Field Traits
    /// </summary>

    public static class Is {

        /// <summary>
        ///  Load classes from file path
        /// </summary>
        public static bool Required(string value)
        {
            if (value  == "Y")
            {
                return true;
            }
            if (value == "N")
            {
                return false;
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}
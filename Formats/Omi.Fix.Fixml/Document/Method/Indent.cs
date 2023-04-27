namespace Omi.Fixml {

    /// <summary>
    ///  Indent methods
    /// </summary>

    public static class Indent {

        /// <summary>
        ///  Number of 2 spaces indents
        /// </summary>
        public static string Count(int count)
            => new string(' ', 2*count);   
    }
}
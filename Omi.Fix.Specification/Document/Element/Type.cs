namespace Omi.Fix.Specification {

    /// <summary>
    ///  Fix Field Type Declaration
    /// </summary>

    public class Type
    {
        /// <summary>
        ///  Fix Field Tag/Number
        /// </summary>
        public uint Tag;

        public string Name;

        /// <summary>
        ///  Fix Field Underlying Type
        /// </summary>
        public string Underlying;

        public Enums Enums = new Enums();



        public bool IsEnum
            => Enums.Exist;

    }
}
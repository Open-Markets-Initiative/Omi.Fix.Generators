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

        public string Description;

        public bool Required;

        public string Version;

        /// <summary>
        ///  Fix Field Underlying Type
        /// </summary>
        public string Underlying;

        public Enums Enums = new Enums();

        public override string ToString()
        => $"{Tag} => {Name}, {Underlying}";

    }
}
namespace Omi.Fix.Specification {

    /// <summary>
    ///  Normalized Fix Field Type Declaration
    /// </summary>

    public class Type {

        /// <summary>
        ///  Fix Field Tag/Number
        /// </summary>
        public uint Tag = 0;

        public string Name = string.Empty;

        public string Description = string.Empty;

        public bool Required;

        public string Version = string.Empty;

        /// <summary>
        ///  Fix Field Underlying Type
        /// </summary>
        public string Underlying = string.Empty;

        public Enums Enums = new Enums();

        /// <summary>
        ///  Convert type to field
        /// </summary>
        public Field ToField()
            => new () { 
                Name = Name, 
                Kind = Kind.Field, 
                Required = Required 
            };

        public override string ToString()
        => $"{Tag} => {Name}, {Underlying}";

    }
}
namespace Omi.Fixml {
    using System.Linq;

    /// <summary>
    ///  Fix Field Declaration
    /// </summary>

    public class Field {

        #region Properties
        ///////////////////////////////////////////////////

        /// <summary>
        ///  Fix Field Tag/Number
        /// </summary>
        public uint Number;

        /// <summary>
        ///  Fix Field Name (PascalCase)
        /// </summary>
        public string Name;

        /// <summary>
        ///  Fix Field Underlying Type (int/string/etc)
        /// </summary>
        public string Type;

        /// <summary>
        ///  Enum Values for this fix field type
        /// </summary>
        public Enums Enums = new Enums();

        /// <summary>
        /// Description of field 
        /// </summary>
        public string Description;

        /// <summary>
        /// Is field required?
        /// </summary>
        public bool Required;

        /// <summary>
        /// Fix version of associated field
        /// </summary>
        public string Version;

        #endregion

        /// <summary>
        /// Writes fixml field to stream
        /// </summary>
        public void Write(StreamWriter stream) {
            if (IsEnum) {
                stream.WriteLine($"    <field number=\"{Number}\" name=\"{Name}\" type=\"{Type.ToUpper()}\">");

                foreach (var @enum in Enums) // move to enums
                {
                    stream.WriteLine($"      <value enum=\"{@enum.Value}\" description=\"{@enum.Description}\"/>");
                }

                stream.WriteLine("    </field>");
            }
            else
            {
                stream.WriteLine($"    <field number=\"{Number}\" name=\"{Name}\" type=\"{Type.ToUpper()}\"/>");
            }
        }

        /// <summary>
        ///  Is field type an enum?
        /// </summary>
        public bool IsEnum
            => Enums.Any();

        /// <summary>
        /// Convert fixml Field to specification Type
        /// </summary>
        public Fix.Specification.Type ToSpecification()
            => new () {
                Tag = Number, 
                Name = Name, 
                Underlying = Type,
                Enums = Enums.ToSpecification(),
                Description = Description,
                Required = Required,    
                Version = Version
            };

        /// <summary>
        /// Display Fixml Field as string
        /// </summary>
        public override string ToString()
            => $"{Number} {Name} : {Type}"; // need enums
    }
}
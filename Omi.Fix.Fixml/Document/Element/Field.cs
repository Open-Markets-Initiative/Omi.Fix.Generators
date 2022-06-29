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

        #endregion

        /// <summary>
        /// Writes fixml field to stream
        /// </summary>
        public void Write(System.IO.StreamWriter stream)
        {
            if (IsEnum)
            {
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

        public bool IsEnum
            => Enums.Any();

        /// <summary>
        /// convert fixml Field to specification Type
        /// </summary>
        public Fix.Specification.Type ToSpecification()
            => new Fix.Specification.Type {
                Tag = Number, 
                Name = Name, 
                Underlying = Type,
                Enums = Enums.ToSpecification()
            };


        /// <summary>
        /// Display Fixml Field as string
        /// </summary>
        public override string ToString()
            => $"{Number} {Name} : {Type}"; // need enums
    }
}
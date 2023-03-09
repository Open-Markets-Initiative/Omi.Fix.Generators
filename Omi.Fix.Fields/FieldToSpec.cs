namespace Omi.Fix.Fields.Xml {

#pragma warning disable CS8618

    /// <summary>
    ///  Load fixml field elements into generated object classes
    /// </summary>

    public partial class ArrayOfFixFieldSpec
    {
        /// <summary>
        /// Convert field fixml file to Specification Types.
        /// </summary>
        public Specification.Types ToSpecification()
        {
            var types = new Fix.Specification.Types();
            var help = this.fixFieldSpecField;

            foreach (var field in help)
            {
                var type = new Fix.Specification.Type();

                type.Tag = field.Tag;
                type.Name = field.Name;
                type.Description = field.Description;
                type.Version = field.Version;

                var enums = new Fix.Specification.Enums();

                foreach (var pair in field.EnumPairs )
                {
                    var @enum = pair.ToSpecification();
                    enums.Add(@enum);
                }

                type.Enums = enums;

                type.Required = field.IsRequired;
                type.Underlying = field.DataType;

                types.Add(type.Name, type);
            }

            return types;
        }
    }
}
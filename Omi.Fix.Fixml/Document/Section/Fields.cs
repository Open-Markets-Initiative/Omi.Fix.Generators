namespace Omi.Fixml {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///  Fixml Fields Xml Element (Fields Section)
    /// </summary>

    public class Fields : Dictionary<string, Field> {

        /// <summary>
        /// Obtain fields from xml
        /// </summary>
        public static Fields From(Xml.fix xml)
        {
            var section = new Fields(); 

            foreach (var field in xml.fields) // need ??
            {
                // verify field name exists // format
                section[field.name] = new Field
                {
                    Name = field.name,
                    Number = field.number,
                    Type = field.type,
                    Enums = Enums.From(field)
                };
            }

            return section;
        }

        /// <summary>
        /// Convert from specification Types to Xml Fields
        /// </summary>
        public static Fields From(Fix.Specification.Types fields)
        {
            var section = new Fields();

            foreach (var field in fields) // need ??
            {
                // verify field name exists // format
                section[field.Name] = new Field
                {
                    Name = field.Name,
                    Number = field.Tag,
                    Type = field.Underlying,
                    Enums = Enums.From(field)
                };
            }

            return section;
        }

        /// <summary>
        /// Write fields to stream
        /// </summary>
        public void Write(System.IO.StreamWriter stream)
        {
            if (Values.Any())
            {
                stream.WriteLine("  <fields>");

                // need sort by tag

                foreach (var field in Values)
                {
                    field.Write(stream);
                }

                stream.WriteLine("  </fields>");
            }
            else
            {
                stream.WriteLine("  <fields/>");
            }
        }

        /// <summary>
        ///  Convert fixml field declarations to normalized fix specification types
        /// </summary>
        public Fix.Specification.Types ToSpecification()
        {
            var types = new Fix.Specification.Types();

            foreach (var pair in this)
            {
                types.Add(pair.Value.ToSpecification());
            }
            
            return types;
        }
    }
}
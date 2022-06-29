namespace Omi.Fixml {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Omi.Fix.Specification;

    public class Trailer: List<Child.Field>
    {
        /// <summary>
        /// Trailer from xml file
        /// </summary>
        public static Trailer From(Xml.fix xml)
        {
            var section = new Trailer();

            foreach (var field in xml.trailer) // need ??
            {
                // verify format

                var name = field.name;
                bool required;

                if (field.required == "Y")
                {
                    required = true;
                }
                else if (field.required == "N")
                {
                    required = false;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }

                section.Add(new Child.Field
                {
                    Name = name,
                    Required = required,
                });
            }

            return section;
        }

        /// <summary>
        /// fixml trailer from specification trailer
        /// </summary>
        public static Trailer From(Fix.Specification.Trailer trailer)
        {
            var section = new Trailer();

            foreach (var field in trailer)
            {
                // verify format

                section.Add(new Child.Field
                {
                    Name = field.Name,
                    Required = field.Required,
                });
            }

            return section;
        }

        /// <summary>
        ///  Write header out to Fixml
        /// </summary>
        public void Write(System.IO.StreamWriter stream)
        {
            if (this.Any())
            {
                stream.WriteLine("  <trailer>");

                foreach (var field in this)
                {
                    field.Write(stream);
                }

                stream.WriteLine("  </trailer>");
            }
            else
            {
                stream.WriteLine("  <trailer/>");
            }
        }


        /// <summary>
        ///  Convert fixml trailer to normalized fix specification trailer
        /// </summary>
        public Fix.Specification.Trailer ToSpecification()
        {
            var trailer = new Fix.Specification.Trailer();

            foreach (var field in this)
            {
                trailer.Add(field.ToSpecification());
            }
            
            return trailer;
        }
    }
}
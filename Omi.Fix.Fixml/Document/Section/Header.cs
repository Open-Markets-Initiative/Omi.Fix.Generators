namespace Omi.Fixml {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Omi.Fix.Specification;

    public class Header : List<Child.Field>
    {
        /// <summary>
        /// Heaader components from xml file
        /// </summary>
        public static Header From(Xml.fix xml)
        {
            var section = new Header();

            foreach (var field in xml.header) // need ??
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
        /// Fix Header from Specification Header
        /// </summary>
        public static Header From(Fix.Specification.Header header)
        {
            var section = new Header();

            foreach (var field in header)
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
                stream.WriteLine("  <header>");

                foreach (var field in this)
                {
                    field.Write(stream);
                }

                stream.WriteLine("  </header>");
            }
            else
            {
                stream.WriteLine("  <header/>");
            }
        }

        /// <summary>
        ///  Convert fixml trailer to normalized fix specification trailer
        /// </summary>
        public Fix.Specification.Header ToSpecification()
        {
            var header = new Fix.Specification.Header();

            foreach (var field in this)
            {
                header.Add(field.ToSpecification());
            }
            
            return header;
        }
    }
}
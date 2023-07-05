namespace Omi.Fix.Fields {
    using System.Collections.Generic;

    /// <summary>
    ///  Fix Fields Xml Element (Fields Section)
    /// </summary>

    public class Fields : Dictionary<string, Field> {

        /// <summary>
        ///  Load Fields from xml
        /// </summary>
        public static Fields From(Xml.FixFields xml) {
            var fields = new Fields(); 
            foreach (var element in xml.FixFieldSpec) {
                var field = Field.From(element);
                fields[field.Name] = field; 
            }

            return fields;
        }

        /// <summary>
        ///  Load Fields from xml
        /// </summary>
        public static Fields From(Fix.Specification.Types types) {
            var fields = new Fields();
            foreach (var element in types.Values) {
                var field = Field.From(element);
                fields[field.Name] = field;
            }

            return fields;
        }

        /// <summary>
        ///  Convert fix field declarations to normalized fix specification types
        /// </summary>
        public Fix.Specification.Types ToSpecification() {
            var types = new Fix.Specification.Types();

            foreach (var field in Values) {
                types.Add(field.Name, field.ToSpecification());
            }
            
            return types;
        }

        /// <summary>
        /// Write fields to stream
        /// </summary>
        public void Write(StreamWriter stream) {
            if (Values.Any()) {
                stream.WriteLine("<FixTypes>");

                foreach (var type in Values) {
                    type.Write(stream);
                }

                stream.WriteLine("</FixTypes>");
            }
            else {
                stream.WriteLine("<FixTypes/>");
            }
        }
    }
}
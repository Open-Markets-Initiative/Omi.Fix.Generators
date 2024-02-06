namespace Omi.Fixml {
    using System.IO;

    /// <summary>
    ///  Financial Information eXchange Fixml C# Document
    /// </summary>

    public class Document {

        /// <summary>
        ///  Fixml Document Information
        /// </summary>
        public Information Information = new();

        /// <summary>
        ///  Fixml Header Fields
        /// </summary>
        public Header Header = new();

        /// <summary>
        /// Fixml Trailer Fields
        /// </summary>
        public Trailer Trailer = new();

        /// <summary>
        /// Fixml Messages
        /// </summary>
        public Messages Messages = new();

        /// <summary>
        /// Fixml components
        /// </summary>
        public Components Components = new();

        /// <summary>
        /// Fixml Fields
        /// </summary>
        public Fields Fields = new();

        /// <summary>
        /// Fixml Errors
        /// </summary>
        public List<string> Errors { get {
            var errors = new List<string>();

            // fixmls require version information
            if (string.IsNullOrWhiteSpace(Information.Major)) {
                errors.Add("Missing Major Information");
            }

            Header.Error(Fields, Components, errors);
            Trailer.Error(Fields, Components, errors);

            // verify that all elements in Messages
            foreach (var message in Messages) {
                message.Error(Fields, Components, errors);
            }

            return errors;
        }}

        /// <summary>
        ///  Apply filter (predicate) to messages and normalize
        /// </summary>
        public Document Filter(Predicate<Message> predicate) {
            // filter messages
            Messages.RemoveAll(message => !predicate(message));

            var msgtypes = new HashSet<string>();
            foreach (var message in Messages) {
                msgtypes.Add(message.Type);
            }

            // filter message types
            if (Fields.TryGetValue("MsgType", out var msgtype)) {
                var enums = new Enums();

                foreach(var value in msgtype.Enums) {
                    if (msgtypes.Contains(value.Value)) {
                        enums.Add(value);
                    }
                }

                msgtype.Enums = enums;
            }

            // filter fields
            Normalize();

            return this;
        }

        /// <summary>
        ///  Gather all required in fields in fixml document
        /// </summary>
        public HashSet<string> GatherFields() {
            var fields = new HashSet<string>();

            // Gather included fields in header
            foreach (var header in Header.Elements) {
                FieldsIn(header, fields);
            }

            // Gather included fields in trailer
            foreach (var trailer in Trailer.Elements) {
                FieldsIn(trailer, fields);
            }

            // Gather included fields in messages
            foreach (var message in Messages) {
                foreach (var element in message.Elements) {
                    FieldsIn(element, fields);
                }
            }

            // Gather included fields
            foreach (var component in Components.Values) {
                foreach (var element in component.Elements) {
                    FieldsIn(element, fields);
                }
            }

            return fields;
        }

        /// <summary>
        ///  Gather all in use components 
        /// </summary>
        public HashSet<string> GatherComponents() {
            var components = new HashSet<string>();

            // Gather included components in header
            foreach (var header in Header.Elements) {
                ComponentsIn(header, components);
            }

            // Gather included components in trailer
            foreach (var trailer in Trailer.Elements) {
                ComponentsIn(trailer, components);
            }

            // Gather included components in messages
            foreach (var message in Messages) {
                foreach (var element in message.Elements) {
                    ComponentsIn(element, components);
                }
            }

            // Gather nested included components
            var nested = new HashSet<string>();

            foreach (var name in components) {
                if (Components.TryGetValue(name, out var component)) {
                    foreach (var element in component.Elements) {
                        ComponentsIn(element, nested);
                    }             
                }
            }

            components.UnionWith(nested);
            return components;
        }

        /// <summary>
        /// Recursively gather required components
        /// </summary>
        public static void ComponentsIn(IChild element, HashSet<string> components) {
            switch (element) {
                case Child.Group group:
                    foreach (var child in group.Elements) {
                        ComponentsIn(child, components);
                    }
                    break;

                case Child.Component component:
                    components.Add(component.Name);
                    break;
            }
        }

        /// <summary>
        ///  Recursively gather required fields
        /// </summary>
        public static void FieldsIn(IChild element, HashSet<string> fields) {
            switch(element) {
                case Child.Field field:
                    fields.Add(field.Name);
                    break;
                case Child.Group group:
                    fields.Add(group.Name);

                    foreach (var child in group.Elements) {
                        FieldsIn(child, fields);
                    }
                    break;
            }
        }

        /// <summary>
        ///  Normalize/clean Fix Specification
        /// </summary>
        public void Normalize() {
            // Reduce to only used components
            var components = GatherComponents();
            Components.ReduceTo(components);

            // Reduce to only used fields
            var fields = GatherFields();
            Fields.ReduceTo(fields);
        }

        /// <summary>
        ///  Convert fixml document from specification document
        /// </summary>
        public static Document From(Fix.Specification.Document specification)
          => new () {
                Information = Information.From(specification.Information),
                Header = Header.From(specification.Header),
                Trailer = Trailer.From(specification.Trailer),
                Messages = Messages.From(specification.Messages),
                Components = Components.From(specification.Components),
                Fields = Fields.From(specification.Types),
            };

        /// <summary>
        /// Obtain fixml document from xml file 
        /// </summary>
        public static Document From(Xml.fix xml)
            => new () {
                Information = Information.From(xml),
                Header = Header.From(xml),
                Trailer = Trailer.From(xml),
                Messages = Messages.From(xml),
                Components = Components.From(xml),
                Fields = Fields.From(xml)
            };

        /// <summary>
        ///  Load fixml file from path 
        /// </summary>
        public static Document From(string path) {
            var xml = Load.From(path);
            return From(xml);
        }

        /// <summary>
        ///  Write fixml file to stream
        /// </summary>
        public void WriteTo(StreamWriter stream)
            => WriteTo(stream, new Indent { });

        /// <summary>
        ///  Write fixml file to stream
        /// </summary>
        public void WriteTo(StreamWriter stream, Indent indent) {
            Information.Write(stream);          
            Header.Write(stream, indent); 
            Trailer.Write(stream, indent);   
            Messages.Write(stream, indent);
            Components.Write(stream, indent);
            Fields.Write(stream, indent);

            stream.WriteLine("</fix>");
        }

        /// <summary>
        ///  Write fixml to path
        /// </summary>
        public string WriteTo(string path) {
            using var file = File.Create(path);
            using var stream = new StreamWriter(file);

            WriteTo(stream);

            return file.Name;
        }

        /// <summary>
        ///  Convert fixml to normalized fix specification
        /// </summary>
        public Fix.Specification.Document ToSpecification()
            => new () {
                Information = Information.ToSpecification(), 
                Header = Header.ToSpecification(),
                Trailer = Trailer.ToSpecification(),
                Messages = Messages.ToSpecification(),
                Components = Components.ToSpecification(),
                Types = Fields.ToSpecification(),
            };

        /// <summary>
        ///  Verify fixml
        /// </summary>
        public void Verify() {
            // fixmls require version information
            if (string.IsNullOrWhiteSpace(Information.Major)) {
                throw new Exception("Missing Information");
            }

            // verify that all elements in Messages
            foreach (var message in Messages) {
                message.Verify(Fields, Components);
            }
        }

        /// <summary>
        ///  Fixml as string
        /// </summary>
        public override string ToString()
            => $"{Information} Fixml";
    }
}

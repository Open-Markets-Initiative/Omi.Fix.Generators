namespace Omi.Fix.Sbe {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
        #pragma warning disable CS8618
    /// <summary>
    ///  Load fixml field elements into generated object classes
    /// </summary>
    public static class Load {

        /// <summary>
        /// Load fixml messages from xml file
        /// </summary>
        public static Xml.messageSchema XmlFrom(string xml)
        => iLink.Read.MessageSchema.As<Xml.messageSchema>(xml);

            /// <summary>
            ///  Load fields from file path and generate a specification document 
            /// </summary>
            public static Specification.Document From(string xml)
            {
                var schema = iLink.Read.MessageSchema.As<Xml.messageSchema>(xml);


                return new Specification.Document
                {
                    Description = new Specification.Description(),
                    Header = new Specification.Header(),
                    Trailer = new Specification.Trailer(),
                    Messages = MessageFrom(schema),
                    Components = new Specification.Components(),
                    Fields = FieldsFrom(schema)
                };
            }

        /// <summary>
        /// Obtain message from xml
        /// </summary>
        public static Specification.Messages MessageFrom(Xml.messageSchema xml)
        {
            var messages = new Specification.Messages(); 

            foreach (var message in xml.message)
            {
                messages.Add(new Fix.Specification.Message
                {
                    Name = message.description, 
                    Type = message.semanticType,
                    Types = FieldsFrom(message.field), 
                    Category = message.id.ToString(), 

                });
            }
            return messages;
        }

        /// <summary>
        /// Obtain Specification fields from iLink fields
        /// </summary>
        public static Specification.Types FieldsFrom(Xml.field[] fields)
        {
            var messageFields = new Specification.Types();
            foreach (var field in fields)
            {
                if (field.id != null)
                {
                    messageFields.Add(field.name, new Specification.Type
                    {
                        Name = field.name,
                        Tag = field.id,
                        Description = field.description,
                        Underlying = field.semanticType,
                    });
                }
            }
            return messageFields;
        }
            /// <summary>
            ///  Load fields from file
            /// </summary>
            public static Specification.Types FieldsFrom(Xml.messageSchema xml)
        {
            var fields = new Specification.Types();
            var ids = new HashSet<int>();

            // pull fields from messages

            foreach (var message in xml.message) 
            {
                foreach (var field in message.field) 
                {

                    if (!ids.Contains(field.id))  
                    {
                        ids.Add(field.id);
                        fields.Add(field.name, new Fix.Specification.Type
                        {
                            Name = field.name,
                            Tag = field.id,
                            Description = field.description,
                            Underlying = field.semanticType,
                        });

                    }
                    // repeating group fields  
                    if (message.group != null)
                    {
                        foreach (var group in message.group)
                        {
                            if (!ids.Contains(group.id))
                            {
                                ids.Add(group.id);
                                fields.Add(group.name, new Specification.Type
                                {
                                    Name = group.name,
                                    Tag = group.id,
                                    Description = group.description,
                                    Underlying = group.dimensionType,
                                });

                                foreach (var subfield in group.field)
                                {
                                    if (!ids.Contains(subfield.id))
                                    {
                                        ids.Add(subfield.id);
                                        fields.Add(subfield.name, new Fix.Specification.Type
                                        {
                                            Name = subfield.name,
                                            Tag = subfield.id,
                                            Description = subfield.description,
                                            Underlying = subfield.semanticType,
                                        }); ;
                                    }

                                }
                            }

                        }
                    }
                }
            }
                return fields;
            }

        /// <summary>
        /// obtains and concats all fields from the given xml files 
        /// </summary>
        public static Specification.Types ConcatenateFields(string xml2, string xml3, string xml4, string xml5, string xml6, string xml7, string xml8)
        {
            var types = new Specification.Types();
            var fields2 = From(xml2).Fields;
            var fields3 = From(xml3).Fields;
            var fields4 = From(xml4).Fields;
            var fields5 = From(xml5).Fields;
            var fields6 = From(xml6).Fields;
            var fields7 = From(xml7).Fields;
            var fields8 = From(xml8).Fields;

            var fieldmap = fields2.Concat(fields3.Concat(fields4.Concat(fields5.Concat(fields6.Concat(fields7.Concat(fields8)))))).OrderBy(x => x.Value.Description.Length).ToList();

            foreach ( var field in fieldmap)
            {
                if (types.ContainsKey(field.Key))
                {
                    if (field.Value.Description.Length > types[field.Key].Description.Length)
                    {
                        types[field.Key] = field.Value; 
                    }
                }
                else
                {
                    types.Add(field.Key, field.Value);
                }
            }
            return types;
        }

    }

}
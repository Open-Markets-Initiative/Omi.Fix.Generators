namespace Omi.Fix.Sbe {
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///  Load sbe xml elements into generated object classes
    /// </summary>

    public static class Load {

        /// <summary>
        ///  Load sbe xml file
        /// </summary>
        public static Xml.messageSchema SbeXmlFrom(string xml)
            => Fix.Load.From<Xml.messageSchema>(xml);

        /// <summary>
        ///  Load fix specification document from sbe xml path
        /// </summary>
        public static Specification.Document From(string xml) {
            var schema = SbeXmlFrom(xml);

            return From(schema);
        }

        /// <summary>
        ///  Load fix specification document from sbe xml
        /// </summary>
        public static Specification.Document From(Xml.messageSchema schema)
            => new Specification.Document {
                Description = new Specification.Description(),
                Header = new Specification.Header(),
                Trailer = new Specification.Trailer(),
                Messages = MessagesFrom(schema),
                Components = new Specification.Components(),
                Types = FieldsFrom(schema)
            };

        /// <summary>
        ///  Obtain sbe fix message from xml
        /// </summary>
        public static Specification.Messages MessagesFrom(Xml.messageSchema xml) {
            var messages = new Specification.Messages(); 

            foreach (var message in xml.message ?? Array.Empty<Xml.messageSchemaMessage>())
            {
                messages.Add(new Fix.Specification.Message
                {
                    Name = message.description, // make a method for this
                    Type = message.semanticType,
                    Types = FieldsFrom(message.field), 
                    Category = message.id.ToString(), 
                });
            }

            return messages;
        }

        /// <summary>
        ///  Obtain Specification types from iLink fields
        /// </summary>
        public static Specification.Types FieldsFrom(Xml.field[] fields)
        {
            var messageFields = new Specification.Types();
            foreach (var field in fields ?? Array.Empty<Xml.field>())
            {
                if (field != null)
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

            // Pull fields from messages
            foreach (var message in xml.message ?? Array.Empty<Xml.messageSchemaMessage>()) 
            {
                foreach (var field in message.field ?? Array.Empty<Xml.field>()) 
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
                    // Repeating group fields  
                    if (message.group != null)
                    {
                        foreach (var group in message.group ?? Array.Empty<Xml.group>())
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
                            }

                            foreach (var subfield in group.field ?? Array.Empty<Xml.groupField>())
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

            return fields;
        }
    }
}
namespace Omi.Fix.Sbe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

#pragma warning disable CS8618

    public enum SortDirection
    {
        Ascending,
        Descending
    }

    /// <summary>
    ///  Load fixml field elements into generated object classes
    /// </summary>
    public static class Load {

        /// <summary>
        ///  Load fixml messages from xml file
        /// </summary>
        public static Xml.messageSchema XmlFrom(string xml)
            => iLink.Read.MessageSchema.As<Xml.messageSchema>(xml);

        /// <summary>
        ///  Load fields from schema and generate a specification document 
        /// </summary>
        public static Specification.Document From(Xml.messageSchema schema)
        {
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
        ///  Load fields from file path and generate a specification document 
        /// </summary>
        public static Specification.Document From(string xml)
        {
            var schema = iLink.Read.MessageSchema.As<Xml.messageSchema>(xml);

            return new Specification.Document {
                Description = new Specification.Description(),
                Header = new Specification.Header(),
                Trailer = new Specification.Trailer(),
                Messages = MessageFrom(schema),
                Components = new Specification.Components(),
                Fields = FieldsFrom(schema)
            };
        }

        /// <summary>
        ///  Generate specification documents for all stored xml files 
        /// </summary>
        public static List<Specification.Document> iLink3Specifications()
        {
            var xmlFiles = XmlIO.iLink3();
            
            var specifications = new List<Specification.Document>(xmlFiles.Length);

            foreach (var xmlFile in xmlFiles ?? Array.Empty<string>())
            {
                specifications.Add(From(xmlFile));
            }

            return specifications; 
        }

        /// <summary>
        ///  Generate specification documents for all stored xml files sorted by version
        /// </summary>
        public static List<Specification.Document> iLink3Specifications(SortDirection sortDirection)
        {
            var xmlFiles = XmlIO.iLink3();

            var schemas = new List<Xml.messageSchema>(xmlFiles.Length);
            foreach (var xmlFile in xmlFiles ?? Array.Empty<string>())
            {
                schemas.Add(XmlFrom(xmlFile));
            }

            // sort schemas
            List<Xml.messageSchema> sortedSchemas = new();
            if (sortDirection == SortDirection.Ascending)
            {
                sortedSchemas = schemas.OrderBy(schema => schema.id).ThenBy(schema => schema.version).ToList();
            }
            else
            {
                sortedSchemas = schemas.OrderByDescending(schema => schema.id).ThenByDescending(schema => schema.version).ToList();
            }

            var specifications = new List<Specification.Document>(sortedSchemas.Count);
            foreach (var schema in sortedSchemas)
            {
                specifications.Add(From(schema));
            }

            return specifications;
        }

        /// <summary>
        ///  Obtain message from xml
        /// </summary>
        public static Specification.Messages MessageFrom(Xml.messageSchema xml)
        {
            var messages = new Specification.Messages(); 

            foreach (var message in xml.message ?? Array.Empty<Xml.messageSchemaMessage>())
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
        ///  Obtain Specification fields from iLink fields
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
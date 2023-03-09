namespace Omi.Fix.Specification {
    using System.Collections.Generic;
    using System.Linq;

    public partial class Clean {

        /// <summary>
        /// Obtain a list of the components which are found in the messages
        /// </summary>
        public static List<string> Components(Document specification) {
            var components = new List<string>();

            foreach (var message in specification.Messages) {
                foreach (var field in message.Fields) { 
                    components = CheckChildrenComponents(field, components);
                }
            }

            return components;
        }

        /// <summary>
        /// Clean up any unnecessary fields and components in fixml file
        /// </summary>
        public static void Fields(Omi.Fix.Specification.Document fixml, List<string> components)
        {
            var newComponents = new Omi.Fix.Specification.Components();
            
            // Only add components that exist in messages to specification
            foreach (var component in fixml.Components)
            {
                if (components.Contains(component.Name))
                {
                    newComponents.Add(component);
                }

            }
            fixml.Components = newComponents;

            // Repeat same process with fields that appear in header, trailer, messages, and components
            var saveFields = new List<string>();

            saveFields.Add("Text");
            saveFields.Add("PutOrCall");
            saveFields.Add("CustomerOrFirm");

            foreach (var message in fixml.Messages)
            {
              foreach (var field in message.Fields)
                {

                    saveFields = CheckChildrenFields(field, saveFields);
                    
                }
              
            }
            foreach (var field in fixml.Header)
            {
                saveFields.Add(field.Name);
            }
            foreach (var field in fixml.Trailer)
            {
                saveFields.Add(field.Name);
            }
            foreach (var component in fixml.Components)
            {
                foreach ( var field in component.Fields)
                {
                    saveFields.Add(field.Name);

                    saveFields = CheckChildrenFields(field, saveFields);
                  
                }
            }

            var newFields = new Omi.Fix.Specification.Types();
            foreach (var field in fixml.Fields.OrderBy(tag => tag.Value.Tag))
            {
                if (saveFields.Contains(field.Key))
                {
                    var description = FixFieldType(field.Value.Underlying.ToUpper());
                    field.Value.Underlying = description;
                    newFields.Add(field.Key, field.Value);
                }
            }

            fixml.Fields = newFields;
            
        }

        /// <summary>
        /// ChangeFix field type to be valid FIX
        /// </summary>
        public static string FixFieldType(string type)
        {

            if (type == "AMT" || type == "PERCENTAGE" || type == "QTY" || type == "PRICE" || type == "PRICEOFFSET")
            {
               type = "FLOAT";
            }
            if (type == "DAY-OF-MONTH" || type == "DAYOFMONTH" || type == "SEQNUM" || type == "LENGTH" || type == "NUMINGROUP" || type == "GROUPSIZE" )
            {
                type = "INT";
            }
            if (type == "CHAR" || type == "BOOLEAN")
            {
                type = "CHAR";
            }
            if (type == "LANGUAGE" || type == "MULTIPLESTRINGVALUE" || type == "TZTIMESTAMP" || type == "TZTIMEONLY" || type == "QUANTITY" || type == "CURRENCY" || type == "MULTIPLECHARVALUE" || type == "COUNTRY" || type == "UTCDATEONLY" || type == "MONTH-YEAR" || type == "MULTIPLEVALUESTRING" || type == "UTCTIMESTAMP" || type == "UTCTIMEONLY" || type == "LOCALMKTDATE" || type == "MONTHYEAR" || type == "EXCHANGE" || type == "LONG")
            {
                type = "STRING";
            }
            if (type == "XMLDATA")
            {
                type = "DATA";
            }

            return type;
        }

        /// <summary>
        /// Recursively identify each child field of a fixml item
        /// </summary>
        public static List<string> CheckChildrenFields(Omi.Fix.Specification.Field specification, List<string> elements)
        {
           
          elements.Add(specification.Name);

          foreach ( var child in specification.Children)
            {
                elements = (CheckChildrenFields(child, elements));
            }

            return elements;
        }

        /// <summary>
        /// Recursively identify each child component of a component
        /// </summary>
        public static List<string> CheckChildrenComponents(Omi.Fix.Specification.Field specification, List<string> elements)  
        {
            if(specification.Kind == Omi.Fix.Specification.Kind.Component)
            {
                elements.Add(specification.Name);   
            }

            foreach (var child in specification.Children)
            {
                elements = (CheckChildrenFields(child, elements));
            }

            return elements;
        }
    }
}

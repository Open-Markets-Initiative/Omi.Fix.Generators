namespace Omi.Fix.Specification {
    using System.Collections.Generic;
    using System.Linq;

    public partial class Clean {

        /// <summary>
        ///  Remove unused types and components
        /// </summary>
        public static void Document(Document specification) {
            var components = Gather.RequiredComponentsIn(specification);
            Clean.Components(specification, components);

            var fields = Gather.RequiredFieldsIn(specification);
            Clean.Types(specification, fields);
        }

        /// <summary>
        ///  Remove unused components in fix specification file
        /// </summary>
        public static void Components(Document specification, HashSet<string> required) {
            var components = new Components();
            foreach (var component in specification.Components) {
                if (required.Contains(component.Name)) {
                    components.Add(component);
                }
            }

            specification.Components = components;
        }

        /*
        saveFields.Add("Text");
            saveFields.Add("PutOrCall");
            saveFields.Add("CustomerOrFirm");
        */

        /// <summary>
        ///  Normalize values and remove unused types in specification
        /// </summary>
        public static void Types(Document specification, HashSet<string> required) {
            var types = new Types();
            foreach (var type in specification.Types.Values.OrderBy(fix => fix.Tag)) {
                if (required.Contains(type.Name)) {
                    type.Underlying = FixFieldType(type.Underlying.ToUpper()); // refactor this

                    types.Add(type.Name, type);
                }
            }

            specification.Types = types;        
        }

        /// <summary>
        /// ChangeFix field type to be valid FIX
        /// </summary>
        public static string FixFieldType(string type) {

            if (type == "AMT" || type == "PERCENTAGE" || type == "QTY" || type == "PRICE" || type == "PRICEOFFSET")
            {
               return "FLOAT";
            }
            if (type == "DAY-OF-MONTH" || type == "DAYOFMONTH" || type == "SEQNUM" || type == "LENGTH" || type == "NUMINGROUP" || type == "GROUPSIZE" )
            {
                return "INT";
            }
            if (type == "CHAR" || type == "BOOLEAN")
            {
               return "CHAR";
            }
            if (type == "LANGUAGE" || type == "MULTIPLESTRINGVALUE" || type == "TZTIMESTAMP" || type == "TZTIMEONLY" || type == "QUANTITY" || type == "CURRENCY" || type == "MULTIPLECHARVALUE" || type == "COUNTRY" || type == "UTCDATEONLY" || type == "MONTH-YEAR" || type == "MULTIPLEVALUESTRING" || type == "UTCTIMESTAMP" || type == "UTCTIMEONLY" || type == "LOCALMKTDATE" || type == "MONTHYEAR" || type == "EXCHANGE" || type == "LONG")
            {
                return "STRING";
            }
            if (type == "XMLDATA")
            {
                return "DATA";
            }

            return type;
        }
    }
}

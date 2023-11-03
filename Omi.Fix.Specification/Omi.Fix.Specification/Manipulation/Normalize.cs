namespace Omi.Fix.Specification {
    using System.Collections.Generic;
    using System.Linq;

    public partial class Normalize {

        /// <summary>
        ///  Normalize underlying types in specification
        /// </summary>
        public static void UnderlyingTypes(Document specification) {
            var types = new Types();
            foreach (var type in specification.Types.Values.OrderBy(fix => fix.Tag)) {
                type.Underlying = ConvertType(type.Underlying);
                types.Add(type.Name, type);
            }

            specification.Types = types;        
        }

        /// <summary>
        /// Convert underlying type to be valid FIX
        /// </summary>
        public static string ConvertType(string type) {
            switch (type.Trim().ToUpper()) {
                case "AMT":
                case "PERCENTAGE":
                case "QTY":
                case "PRICE":
                case "PRICEOFFSET":
                    return "FLOAT";

                case "DAY-OF-MONTH":
                case "DAYOFMONTH":
                case "SEQNUM":
                case "LENGTH":
                case "NUMINGROUP":
                case "GROUPSIZE":
                    return "INT";

                case "CHAR":
                case "BOOLEAN":
                    return "CHAR";

                case "LANGUAGE":
                case "MULTIPLESTRINGVALUE":
                case "TZTIMESTAMP":
                case "TZTIMEONLY":
                case "QUANTITY":
                case "CURRENCY":
                case "MULTIPLECHARVALUE":
                case "COUNTRY":
                case "UTCDATEONLY":
                case "MONTH-YEAR":
                case "MULTIPLEVALUESTRING":
                case "UTCTIMESTAMP":
                case "UTCTIMEONLY":
                case "LOCALMKTDATE":
                case "MONTHYEAR":
                case "EXCHANGE":
                case "LONG": // ??
                case "STRING":
                    return "STRING";

                case "XMLDATA":
                case "DATA":
                    return "DATA";

                default:
                    return type; // is this right
            }
        }
    }
}

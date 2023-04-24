namespace Omi.Fix.Specification {
    using System.Collections.Generic;

    /// <summary>
    ///  Normalized Fix Specification Field Types List
    /// </summary>

    public class Types : Dictionary<string , Type> {

        public Types() 
        { }

        /// <summary>
        ///  Intialize IEnumerable types 
        /// </summary>
        public Types (IEnumerable<Type> types) {
            foreach (var type in types) {
                Add(type.Name, type);    
            }
        }

        /// <summary>
        ///  Convert Dictionary of types to Specification
        /// </summary>
        public static Types ToTypes(Dictionary<string, Type> type) {
            var types = new Types();

            foreach (var pair in type) {
                types.Add(pair.Key, pair.Value);
            }

            return types;
        }

        /// <summary>
        ///  Add Types, overwrite in case of same name
        /// </summary>
        public void AddOverwrite(Types types) {
            foreach (var type in types.Values) {
                // how to handle enums?

                this[type.Name] = type;
            }
        }

        /// <summary>
        ///  Convert types to fields list
        /// </summary>
        public List<Field> ToFields() {
            var fields = new List<Field>();
            foreach (var type in Values) {
                fields.Add(type.ToField());
            }

            return fields;
        }

        /// <summary>
        /// Convert Dictionary of types to Specification
        /// </summary>
        public static Types ToTypes(IEnumerable<KeyValuePair<string , Type> > type) {
            var types = new Types();

            foreach (var pair in type)
            {
                if (types.ContainsKey(pair.Key))
                {
                    continue;
                }
                types.Add(pair.Key, pair.Value);
            }

            return types;
        }

        /// <summary>
        /// 
        /// </summary>
        public  List<Type> ToList()
            => Values.OrderBy(field => field.Tag).ToList();
    }
}
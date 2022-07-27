namespace Omi.Fix.Specification {
    using System.Collections.Generic;

    /// <summary>
    ///  Normalized Fix Specification Field Types List
    /// </summary>

    public class Types : Dictionary< string , Type> 
    {
        public Types() 
        { }

        /// <summary>
        /// Convert IEnumerable types to Dictionary 
        /// </summary>
        public Types (IEnumerable<Type> types)
        {
            var types_ = new Types();
            foreach (var type in types)
            {
                types_.Add(type.Name, type);    
            }
        }

        /// <summary>
        /// Convert Dictionary of types to Specification
        /// </summary>
        public static Types ToTypes( Dictionary<string, Type> type)
        {
            var types = new Types();

            foreach (var pair in type)
            {
                types.Add(pair.Key, pair.Value);
            }

            return types;
        }

        /// <summary>
        /// Convert Dictionary of types to Specification
        /// </summary>
        public static Types ToTypes(IEnumerable<KeyValuePair<string , Type> > type)
        {
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

        public  List<Type> ToList()
        => Values.OrderBy(field => field.Tag).ToList();


    }
}
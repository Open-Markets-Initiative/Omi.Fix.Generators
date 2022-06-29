namespace Omi.Fix.Specification {
    using System.Collections.Generic;

    /// <summary>
    ///  Normalized Fix Specification Component
    /// </summary>

    public class Component {

        /// <summary>
        ///  name of Componenet
        /// </summary>
        public string Name { get; set;}

        /// <summary>
        ///  Fields assoc iated with component name
        /// </summary>
        public List<Field> Fields = new List<Field>();

    }
}
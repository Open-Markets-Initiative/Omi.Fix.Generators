namespace Omi.Fix.Specification {
    using System.Collections.Generic;

    /// <summary>
    ///  Normalized Fix Specification Component
    /// </summary>

    public class Component {

        /// <summary>
        ///  Name of Componenet
        /// </summary>
        public string Name { get; set;}

        /// <summary>
        ///  Fields associated with component name
        /// </summary>
        public List<Field> Fields = new List<Field>();

    }
}
namespace Omi.Fix.Specification {
    using System.Collections.Generic;

    /// <summary>
    ///  Normalized Fix Specification Component
    /// </summary>

    public class Component {

        /// <summary>
        ///  
        /// </summary>
        public string Name { get; set;}

        /// <summary>
        ///  
        /// </summary>
        public List<Field> Fields = new List<Field>();

    }
}
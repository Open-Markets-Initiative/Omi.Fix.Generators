namespace Omi.Fix.Specification {
    using System.Collections.Generic;

    /// <summary>
    ///  Normalized Fix Specification Message
    /// </summary>
    public class Message
    {

        public string Name { get; set;}

        public string Type { get; set;}

        public string Category { get; set;}

        public List<Field> Fields = new List<Field>();

    }
}
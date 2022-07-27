namespace Omi.Fix.Specification {
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///  Normalized Fix Specification Child Field Element
    /// </summary>
    public class Field 
    {
        public string Name { get; set;}

        public bool Required { get; set;}

        public Kind Kind { get; set;}

        public List<Field> Children = new List<Field>();

        /// <summary>
        /// Convert field to string 
        /// </summary>
        public override string ToString()
        {
            switch (Kind)
            {
                case Kind.Field:
                    return $"{Name} : {(Required ? "Required" : "")}";
                case Kind.Component:
                    return $"Component";
                case Kind.Group:
                    return $"Group";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
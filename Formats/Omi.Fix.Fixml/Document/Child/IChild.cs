namespace Omi.Fixml {
    using System;

    /// <summary>
    ///  Fixml Child Element
    /// </summary>

    public interface IChild
    {
        string Name { get; }

        void Write(StreamWriter stream);

        void Write(StreamWriter stream, IChild child);
    }

    public static partial class Extensions {

        /// <summary>
        /// Put child in specification, dependant of object type
        /// </summary>
        public static Fix.Specification.Field ToSpecification(this IChild child)
        {
            switch (child)
            {
                case Child.Field field:
                    return field.ToSpecification();
                case Child.Component component:
                    return component.ToSpecification();
                case Child.Group group:
                    return group.ToSpecification();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }
}
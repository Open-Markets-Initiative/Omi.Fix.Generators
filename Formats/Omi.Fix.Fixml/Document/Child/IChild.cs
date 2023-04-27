namespace Omi.Fixml {

    /// <summary>
    ///  Fixml Child Element
    /// </summary>

    public interface IChild {

        /// <summary>
        ///  Element name
        /// </summary>
        string Name { get; }

        /// <summary>
        ///  Element parent
        /// </summary>
        IParent Parent { get; }

        /// <summary>
        ///  Verify fixml child element properties
        /// </summary>
        void Verify(Fields fields, Components components);

        /// <summary>
        ///  Number of levels deep in element tree
        /// </summary>
        int Depth();

        /// <summary>
        ///  Convert to specification field
        /// </summary>
        Fix.Specification.Field ToSpecification();

        /// <summary>
        ///  Write element to stream
        /// </summary>
        void Write(StreamWriter stream, int spaces);
    }
}
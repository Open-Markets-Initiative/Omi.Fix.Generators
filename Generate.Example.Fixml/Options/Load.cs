namespace Fixml.Generator {

    /// <summary>
    ///  Load fixml generator options into generated object classes
    /// </summary>

    public static class Load {

        /// <summary>
        ///  Load classes from file path
        /// </summary>
        public static Fixml.Generator.Xml.Options From(string xml) 
            => Omi.Fix.Load.From<Xml.Options>(xml);
    }
}
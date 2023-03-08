namespace Omi.Fix.Sbe {
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    ///  Load xml elements into generated object classes
    /// </summary>
    public static class Read {

        /// <summary>
        ///  Load classes from file path
        /// </summary>
        public static T As<T>(string xml) {
            using var reader = XmlReader.Create(xml);

            var serializer = XmlSerializer.FromTypes(new[] { typeof(T) })[0];
            return (T)serializer.Deserialize(reader);
        }

        /// <summary>
        ///  Load classes from file info
        /// </summary>
        public static T As<T>(FileInfo info) {
            using var reader = info.OpenRead();

            var serializer = XmlSerializer.FromTypes(new[] { typeof(T) })[0];
            return (T)serializer.Deserialize(reader);
        }
    }
}
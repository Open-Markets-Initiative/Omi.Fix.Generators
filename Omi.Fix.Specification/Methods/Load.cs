namespace Omi.Fix {
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    ///  Load fixml elements into generated object classes
    /// </summary>

    public static class Load { 

        /// <summary>
        ///  Load classes from file path
        /// </summary>
        public static T From<T>(string xml) {
            using (var reader = XmlReader.Create(xml)) {
                var serializer = XmlSerializer.FromTypes(new[] { typeof(T) })[0];
                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        ///  Load classes from file info
        /// </summary>
        public static T From<T>(FileInfo info) {
            using (var reader = info.OpenRead()) {
                var serializer = XmlSerializer.FromTypes(new[] { typeof(T) })[0];
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
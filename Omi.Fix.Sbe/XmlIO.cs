using System.IO;

namespace Omi.Fix.Sbe
{
    public static class XmlIO
    {
        public static string[] iLink3()
        {
            var DocumentDirectoryName = "CME.iLink3";

            var currentDirectory = Directory.GetCurrentDirectory();

            var DocumentDirectory = Path.Combine(currentDirectory, DocumentDirectoryName);

            return Directory.GetFiles(DocumentDirectory, "*.xml");
        }
    }
}

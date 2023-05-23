namespace Omi.Fix.Txt {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// FIX major and minor
    /// </summary>
    public class Information {

        /// <summary>
        /// 
        /// </summary>
        public string Major = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Minor = string.Empty;

        /// <summary>
        ///  Category
        /// </summary>
        public string Category = string.Empty;

        /// <summary>
        /// Set FIX major and minor version from string input
        /// </summary>
        public static Information From(string major, string minor)
            => new Information() {
                Major = major,
                Minor = minor
            };

        /// <summary>
        /// Returns major and minor from path
        /// </summary>
        public static Information From(string path) {
            var lines = File.ReadLines(path);
            return From(lines);
        }

        /// <summary>
        /// Return major and minor from lines in text file
        /// </summary>
        public static Information From(IEnumerable<string> lines) {
            // Default description 
            var major = "4";
            var minor = "2";

            string line = "";

            // Parse lines for description
            foreach (var descriptionline in lines)
            {
                if (descriptionline.StartsWith("#") || string.IsNullOrWhiteSpace(descriptionline))
                {
                    continue;
                }

                if (descriptionline.Contains("Major") && descriptionline.Contains("Minor"))
                {
                    line = descriptionline;
                }
            }

            // Clean up line to obtain major and minor versions
            if (string.IsNullOrWhiteSpace(line))
            {
                return From(major, minor);
            }

            if (line.Contains("#") && !string.IsNullOrEmpty(line))
            {
                line = line.Substring(0, line.IndexOf("#"));
            }

            line = String.Concat(line.Where(c => !Char.IsWhiteSpace(c)));    

            major = line.Substring(line.IndexOf("Major=") + 6, 1);
            minor = line.Substring(line.IndexOf("Minor=") + 6, 1);

            return From(major, minor);
        }

        /// <summary>
        /// Converts fix txt description to specification
        /// </summary>
        public Specification.Information ToSpecification()
            => new () {
                Major = Major,
                Minor = Minor
            };

        /// <summary>
        /// Display fix txt description information
        /// </summary>
        public override string ToString()
            => $"v{Major}.{Minor}"; // do better with ifs
    }
}
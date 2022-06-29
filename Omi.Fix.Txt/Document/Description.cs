namespace Omi.Fix.Txt
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// FIX major and minor
    /// </summary>
    public class Description
    {
        public string Major;

        public string Minor;

        /// <summary>
        /// Set FIX major and minor version from string input
        /// </summary>
        public static Description From(string major, string minor)
        => new Description()
        {
            Major = major,
            Minor = minor
        };

        /// <summary>
        /// Returns major and minor from path
        /// </summary>
        public static Description From(string path)
        {
            var lines = File.ReadLines(path);

            return From(lines);
        }

        /// <summary>
        /// Return major and minor from lines in text file
        /// </summary>
        public static Description From(IEnumerable<string> lines)
        {
            // default description 
            var major = "4";
            var minor = "2";

            string line = "";

            //parse lines for description
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

            //clean up line to obtain major and minor versions
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
        /// Converts description to specification
        /// </summary>
        public Fix.Specification.Description ToSpecification()
        {
            var desc = new Fix.Specification.Description();

            desc.Major = this.Major;
            desc.Minor = this.Minor;

            return desc;
        }
    }
}
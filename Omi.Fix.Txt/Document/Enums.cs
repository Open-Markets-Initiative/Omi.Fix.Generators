namespace Omi.Fix.Txt {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// dictionary of the Enum(s) found in a file, with its name as the index
    /// </summary>
    public class Enums : Dictionary<string, Enum>
    {
        /// <summary>
        ///  Default constructor
        /// </summary>
        public Enums()
        { }

        /// <summary>
        /// Constructor with enum list as input
        /// </summary>
        public Enums(IEnumerable<Enum> enums)
        { }

        /// <summary>
        /// Returns enums from a text file
        /// </summary>
        public static Enums From(string path)
        {
            var lines = File.ReadLines(path);

            return From(lines);
        }

        /// <summary>
        /// Returns enums from a list of lines
        /// </summary>
        public static Enums From(IEnumerable<string> lines) {

            var enums = new List<string>();

            // check that line contains enums
            foreach (var line in lines)
            {
                if (line.Contains(":enum:") && !line[0].Equals("#"))
                {
                    enums.Add(line);    
                }
            }

            return Process(enums);
        }

        /// <summary>
        /// Process each enum line and return enums
        /// </summary>
        public static Enums Process(IEnumerable<string> lines)
        {
            var enums = new Enums();
            var validlines = lines.ToList().Where( l => !l.StartsWith("#"));

            // build enum from each valid line and add to list of enums
            foreach (var line in validlines)
            {
                Enum enumerator = Enum.From(line);
                enums.Add( enumerator.Name, enumerator); 
            }

            return enums;
        }
        
        /// <summary>
        ///  Convert fixml enums to normalized fix specification enums for a given field name
        /// </summary>
        public Fix.Specification.Enums ToSpecification(string key)
        {
            var enums = new Fix.Specification.Enums();
                
            // different names for beginstring and fixversion
            if (key.Contains("BeginString"))
            {
                key = "FixVersion";
            }

            // check for field name in enums
            if (!this.ContainsKey(key))
            {
                return enums;
            }

            var enumerator = this[key].Values; 

            if (enumerator == null)
            {
                return enums;
            }

            // if enums exist, return in correct specification
            foreach (var line in enumerator)
            {
                var enumline = Enum.ToSpecification(line);
                enums.Add(enumline);   
            }

            return enums;
        }

        
    }
}
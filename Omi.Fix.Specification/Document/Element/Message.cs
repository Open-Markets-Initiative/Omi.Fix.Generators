namespace Omi.Fix.Specification {
    using System.Collections.Generic;

    /// <summary>
    ///  Normalized Fix Specification Message
    /// </summary>

    public class Message {

        /// <summary>
        ///  Normalized Fix Specification Message Name
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        ///  Normalized Fix Specification Message Type
        /// </summary>
        public string Type = string.Empty;

        public string Category = string.Empty;

        public string Description = string.Empty;

        public List<Field> Fields = new ();

        public Types Types = new ();    // used for sbe? (need to redo)

        /// <summary>
        /// 
        /// </summary>
        public void SetNotRequired(string name) {
            foreach (var field in Fields)
            {
                field.SetNotRequired(name); 
            }
        }

        /// <summary>
        ///  Add basic field to end of fields list
        /// </summary>
        public void AddField(string name, Kind kind = Kind.Field, bool required = false) {
            var field = new Field {
                Name = name,
                Kind = kind,
                Required = required
            };

            Fields.Add(field);
        }

        /// <summary>
        ///  Add fields to message end
        /// </summary>
        public void Add(List<Field> fields)
            => Fields.AddRange(fields); // should we remove duplicates?

        /// <summary>
        ///  Display normalized fix specification message as string
        /// </summary>
        public override string ToString()
            => $"{Name} : {Type} [{Category}] ";
    }
}
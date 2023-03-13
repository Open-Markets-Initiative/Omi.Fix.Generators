namespace Omi.Fix.Specification {
    using System.Collections.Generic;

    /// <summary>
    ///  Normalized Fix Specification Message
    /// </summary>
    public class Message
    {
        public string Name { get; set;}

        public string Type { get; set;}

        public string Category { get; set;}

        public string Description { get; set; }

        public List<Field> Fields = new List<Field>();

        public Types Types = new Types();    // used for sbe? (need to redo)

        /// <summary>
        /// 
        /// </summary>
        public void SetNotRequired(string name)
        {
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
        ///  Add every type in a list to message
        /// </summary>
        public void AddFields(Types types, Kind kind = Kind.Field, bool required = false) {
            foreach (var type in types.Values) { // this is kind of a hack (maybe should make a ToFields)
                AddField(type.Name, kind, required);
            }
        }

        /// <summary>
        ///  Display normalized fix specification message as string
        /// </summary>
        public override string ToString()
            => $"{Name} : {Type} [{Category}] ";
    }
}
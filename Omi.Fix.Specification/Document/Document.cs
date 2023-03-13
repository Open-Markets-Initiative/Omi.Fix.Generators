namespace Omi.Fix.Specification {

    /// <summary>
    ///  Normalized Fix Specification
    /// </summary>

    public class Document {

        /// <summary>
        ///  Normalized Fix Specification Identifing Information
        /// </summary>
        public Description Description = new Description();

        /// <summary>
        ///  Normalized Fix Specification Header fields
        /// </summary>
        public Header Header = new Header();

        /// <summary>
        ///  Normalized Fix Specification Trailers
        /// </summary>
        public Trailer Trailer = new Trailer();

        /// <summary>
        ///  Normalized Fix Specification Messages
        /// </summary>
        public Messages Messages = new Messages();

        /// <summary>
        ///  Normalized Fix Specification Components
        /// </summary>
        public Components Components = new Components();

        /// <summary>
        ///  Normalized Fix Specification Field Types
        /// </summary>
        public Types Types = new Types();

        /// <summary>
        ///  Filter
        /// </summary>
        public void Filter(Predicate<Message> predicate)
            => Messages.RemoveAll(predicate);

        /// <summary>
        /// 
        /// </summary>
        public void Set(string name, uint tag, string type)
        {
            // add some checks?

            Types.Add(name, new Type { Name = name, Tag = tag, Underlying = type });
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetNotRequired(string name)
        {
            // add some checks?
            foreach(var message in Messages)
            {
                message.SetNotRequired(name);
            }
        }

        /// <summary>
        ///  Add field to message (need one with placement)
        /// </summary>
        public void AddField(string message, string name, bool required)
        {
            // add some checks?

   
        }

        /// <summary>
        ///  Try Get Message
        /// </summary>
        public bool TryGetMessage(string name, out Message message)
        {
            message = Messages.FirstOrDefault(current => current.Name == name);

            return message != null;
        }

        /// <summary>
        ///  Get Message by Name
        /// </summary>
        public Message GetMessage(string name)
            => Messages.First(current => current.Name == name);


        /// <summary>
        ///  Add Types
        /// </summary>
        public void AddOverwrite(Types types)
            => Types.AddOverwrite(types);


        /// <summary>
        ///  Display Fix Specification Information
        /// </summary>
        public override string ToString()
            => $"{Description}";
    }
}

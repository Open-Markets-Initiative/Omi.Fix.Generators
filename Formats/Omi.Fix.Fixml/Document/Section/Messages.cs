using System.Collections.Generic;
using System.Linq;

namespace Omi.Fixml {

    /// <summary>
    ///  List of messsages in fixml file
    /// </summary>

    public class Messages : List<Message>
    {
        /// <summary>
        ///  Default constructor
        /// </summary>
        public Messages()
        { }

        /// <summary>
        /// Messages from IEnumerable
        /// </summary>
        public Messages(IEnumerable<Message> messages)
        { 
            AddRange(messages);
        }

        /// <summary>
        ///  Gather messages from fixml xml
        /// </summary>
        public static Messages From(Xml.fix xml)
            => new Messages(ListFrom(xml).Select(Message.From));

        /// <summary>
        ///  Gather message xml elements from fixml
        /// </summary>
        public static Xml.fixMessage[] ListFrom(Xml.fix xml)
            => xml.messages ?? new Xml.fixMessage[0];

        /// <summary>
        ///  Gather fixml components list from normalized fix specification 
        /// </summary>
        public static Messages From(Fix.Specification.Messages messages)
            => new Messages(messages.Select(Message.From));


        /// <summary>
        ///  Write header out to Fixml
        /// </summary>
        public void Write(System.IO.StreamWriter stream)
        {
            if (!this.Any())
            {
                stream.WriteLine("  <messages/>");
                return;
            }

            stream.WriteLine("  <messages>");

            foreach (var message in this)
            {
                message.Write(stream);
            }

            stream.WriteLine("  </messages>");
        }

        /// <summary>
        ///  Convert fixml trailer to normalized fix specification trailer
        /// </summary>
        public Fix.Specification.Messages ToSpecification()
        {
            var messages = new Fix.Specification.Messages();

            foreach (var message in this)
            {
                messages.Add(message.ToSpecification());
            }
            
            return messages;
        }
    }
}
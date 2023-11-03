namespace Omi.Fixml {

    using System.Text;
    using static System.Net.Mime.MediaTypeNames;

    /// <summary>
    ///  Indent methods
    /// </summary>

    public class Indent {

        public string Text ="  ";

        public int Count = 1;

        /// <summary>
        ///  Default
        /// </summary>
        public override string ToString()
            => new StringBuilder(Text.Length * Count).Insert(0, Text, Count).ToString();

        public Indent Increment()
        => new(){ Text = Text, Count = Count+1 };


    }
}
namespace Omi.Fix.Specification {

    /// <summary>
    ///  Normalized Fix Specification Enumerated Value
    /// </summary>
    public class Enum
    {
        public string Value;

        public string Description;

        public override string ToString()
         => $"{Value} = {Description}";

    }
}
namespace Omi.Fix.Specification {

    /// <summary>
    ///  Normalized Fix Specification Components List
    /// </summary>

    public class Components : List<Component> {

        /// <summary>
        ///  Is 
        /// </summary>
        public bool IsIncluded(Component component)
            => this.Any(current => current.Name == component.Name);

        /// <summary>
        ///  Is 
        /// </summary>
        public bool IsMissing(Component component)
            => !IsIncluded(component);


        /// <summary>
        /// Add a fix specification to a another
        /// </summary>
        public void Add(Components components) {
            // is there a better way to do this (without altering order)
            var missing = components.Where(IsMissing).ToList();

            AddRange(missing);
        }


    }
}
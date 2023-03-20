namespace Omi.Fix.Txt {
    using System.Collections.Generic;
    using System.Linq;
    using Omi.Fix.Specification;

    /// <summary>
    /// List of the groups associated with a section 
    /// </summary>
    public class Children : List<Group>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Children()
        { }

        /// <summary>
        /// Returns all the children associated with a field
        /// </summary>
        public static Children From(string groups)
        {
            // Split a comma seperated list of groups
            var grouplist = groups.Split(",");
            var children = new Children();

            // Convert each string to group
            foreach (var group in grouplist)
            {
                var child = Group.From(group);
                children.Add(child);  
            }

            return children;  
        }
        
        /// <summary>
        /// Convert children to fix specificiation
        /// </summary>
        public List<Specification.Field> ToSpecification()
        {
            var fields = new List<Specification.Field>(); 

            foreach (var field in this)
            {
                fields.Add(field.ToSpecification());
            }

            return fields;
        }
    }
}
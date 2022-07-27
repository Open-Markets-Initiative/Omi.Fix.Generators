namespace Omi.Fix.Txt{
    using System.Collections.Generic;
    using System.Linq;
    using Omi.Fix.Specification;
    
    /// <summary>
    /// A list of the fields associated with a message
    /// </summary>
    public class Groups : List<Group>
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public Groups()
        { }

        /// <summary>
        /// constructs groups from string
        /// </summary>
        public static Groups From(string groups)
        {
            // parse string for each individual group
            var netgroups = groups.Split(",");
            var grouplist = new List<string>();
            int delindex;

            // if string had square bracket, children exist
            // parse individual groups for children and attach to parent string
            for (var count = 0; count < netgroups.Length; count += delindex)
            {
                delindex = 1;
                var tempGroup = netgroups[count];

                if (netgroups[count].Contains("["))
                {
                    // assume no group has morethan 1 million children, near-infinite loop
                    for (var i = 1; i < 1000000; i++) 
                    {
                        // keep adding to parent until end of repeating groups is found
                        tempGroup = string.Concat(tempGroup, "," + netgroups[count + i]);

                        //skip groups that were added as children, break from loop
                        if (netgroups[count + i].Contains("]"))
                        {
                            delindex += i;
                            break;
                        }
                    }
                }
                
                grouplist.Add(tempGroup);
            }

            var grupos = new Groups();

            //create group from each group in list
            foreach (var group in grouplist)
            {
                var grupo = Group.From(group);
                grupos.Add(grupo);  
            }

            return grupos;  
        }
        
        /// <summary>
        /// Obtain specification for fields associated with message
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
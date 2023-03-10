namespace Omi.Fix.Specification {
    using System.Collections.Generic;
    using System.Linq;

    public partial class Gather {

        /// <summary>
        ///  Obtain a list of the components which are found in the messages
        /// </summary>
        public static HashSet<string> RequiredComponentsIn(Document specification) {
            var set = new HashSet<string>();

            // Add components in messages
            foreach (var message in specification.Messages) {
                foreach (var field in message.Fields) {
                    RequiredComponentsIn(field, set);
                }
            }

            var required = set.ToHashSet();

            // Add components in components
            foreach (var component in specification.Components) {
                if (required.Contains(component.Name)) {
                    foreach (var field in component.Fields) {
                        RequiredComponentsIn(field, set);
                    }
                }
            }

            return set;
        }

        /// <summary>
        ///  Recursively check for components
        /// </summary>
        public static void RequiredComponentsIn(Field field, HashSet<string> set) {
            // gather 
            if (field.Kind == Kind.Component) {
                set.Add(field.Name);
            }

            foreach (var child in field.Children) {
                RequiredComponentsIn(child, set);
            }
        }

        /// <summary>
        ///  Obtain a list of the fields which are found in the messages
        /// </summary>
        public static HashSet<string> RequiredFieldsIn(Document specification) {
            var set = new HashSet<string>();

            // add required header
            foreach (var header in specification.Header) {
                set.Add(header.Name);
            }

            // add required trailer
            foreach (var trailer in specification.Trailer) {
                set.Add(trailer.Name);
            }

            // add fields in messages
            foreach (var message in specification.Messages) {
                foreach (var field in message.Fields) {
                    RequiredFieldsIn(field, set);
                }
            }

            // add fields in components
            foreach (var component in specification.Components) {
                foreach (var field in component.Fields) {
                    RequiredFieldsIn(field, set);
                }
            }

            return set;
        }

        /// <summary>
        ///  Recursively check for fields
        /// </summary>
        public static void RequiredFieldsIn(Field field, HashSet<string> set) {
            // gather 
            if (field.Kind == Kind.Field) {
                set.Add(field.Name);
            }

            foreach (var child in field.Children) {
                RequiredFieldsIn(child, set);
            }
        }
    }
}

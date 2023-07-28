using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MendiGames.Utils
{
    // Abstract class to create custom 'enums' with string associated
    // Comparations are made by ID
    public abstract class EnumString : IComparable
    {
        public int id { get; private set; }
        public string value { get; private set; }

        protected EnumString(int id, string value) => (this.id, this.value) = (id, value);

        public override string ToString() => this.value;

        public static IEnumerable<T> GetAll<T>() where T : EnumString =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();

        public override bool Equals(object obj)
        {
            if (obj is EnumString otherValue)
            {
                bool typeMatches = GetType().Equals(obj.GetType());
                bool valueMatches = id.Equals(otherValue.id);

                return typeMatches && valueMatches;
            }

            return false;
        }

        public int CompareTo(object other) => id.CompareTo(((EnumString)other).id);
        public override int GetHashCode() => -1584136870 + EqualityComparer<string>.Default.GetHashCode(value);

        /* -------------------- 👇 Leave below your custom utilities 👇 ------------------- */

    }

}

/* ########################################################################## */
/*                              Example of use                                */
/* ########################################################################## */

/*

    public class RestMethod : EnumString {
        public RestMethod(int id, string name) : base(id, name) {}

        public static RestMethod Add    => new RestMethod(1, "POST");
        public static RestMethod Update => new RestMethod(2, "PUT");
        public static RestMethod Get    => new RestMethod(3, "GET");
        public static RestMethod Delete => new RestMethod(4, "DELETE");
    }

*/

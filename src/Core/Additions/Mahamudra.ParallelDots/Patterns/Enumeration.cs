using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mahamudra.ParallelDots.Patterns
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; } 
        public int Id { get; private set; } 
        protected Enumeration(int id, string name) => (Id, Name) = (id, name); 
        public override string ToString() => Name; 
        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();

        public override bool Equals(object obj)
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Enumeration))
            {
                return false;
            } 

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(((Enumeration)obj).Id);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Id.GetHashCode();
        }  
    }
}

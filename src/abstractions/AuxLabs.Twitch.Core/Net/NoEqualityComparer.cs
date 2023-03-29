using System.Collections.Generic;

namespace AuxLabs.Twitch
{
    public class NoEqualityComparer : IEqualityComparer<string>
    {
        public static readonly NoEqualityComparer Instance;

        static NoEqualityComparer()
        {
            Instance = new NoEqualityComparer();
        }

        public bool Equals(string x, string y)
        {
            return false;
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}

using System;
using System.Linq;

namespace AuxLabs.SimpleTwitch
{
    public static class Require
    {
        #region Objects

        public static void NotNull(object obj, string name, string msg = null) 
        { 
            if (obj == null) throw new ArgumentNullException(name, msg ?? "Argument cannot be null"); 
        }

        #endregion
        #region Strings

        public static void NotEmpty(string obj, string name, string msg = null)
        {
            if (obj == null) throw new ArgumentException(msg ?? "Argument cannot be blank", name);
        }
        public static void NotNullOrEmpty(string obj, string name, string msg = null)
        {
            NotNull(obj, name, msg);
            NotEmpty(obj, name, msg);
        }
        public static void NotNullOrWhitespace(string obj, string name, string msg = null)
        {
            NotNullOrEmpty(obj, name, msg);
            if (obj.Trim().Length == 0) throw new ArgumentException(msg ?? "Argument cannot be blank", name);
        }

        #endregion
        #region Numbers

        public static void AtLeast(int obj, int value, string name, string msg = null)
        {
            if (obj < value) throw new ArgumentException(msg ?? $"Value must be at least {value}", name);
        }
        public static void GreaterThan(int obj, int value, string name, string msg = null)
        {
            if (obj <= value) throw new ArgumentException(msg ?? $"Value must be greater than {value}", name);
        }
        public static void AtMost(int obj, int value, string name, string msg = null)
        {
            if (obj > value) throw new ArgumentException(msg ?? $"Value must be at most {value}", name);
        }
        public static void LessThan(int obj, int value, string name, string msg = null)
        {
            if (obj >= value) throw new ArgumentException(msg ?? $"Value must be less than {value}", name);
        }

        #endregion
        #region Identity

        public static void Scopes(string[] has, string[] value)
        {
            if (has.Any(x => value.Contains(x))) throw new MissingScopeException(value);
        }

        #endregion
    }
}

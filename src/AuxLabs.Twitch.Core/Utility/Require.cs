using System;
using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.Twitch
{
    public static class Require
    {
        #region Identity

        public static void Scopes(IEnumerable<string> has, string[] value)
        {
            if (!has.Any(x => value.Contains(x))) throw new MissingScopeException(value);
        }

        #endregion
        #region Objects

        public static void Equal(object obj, object value, string name, string msg = null)
        {
            if (!obj.Equals(value)) throw new ArgumentException(msg ?? "Arguments must be equal", name);
        }

        public static void NotNull(object obj, string name, string msg = null) 
        { 
            if (obj == null) throw new ArgumentNullException(name, msg ?? "Argument cannot be null");
        }

        #endregion
        #region Strings

        public static void NotEmpty(string obj, string name, string msg = null)
        {
            if (obj != null && obj.Length == 0) throw new ArgumentException(msg ?? "Argument cannot be blank", name);
        }
        public static void NotEmptyOrWhitespace(string obj, string name, string msg = null)
        {
            if (obj != null && obj.Trim().Length == 0) throw new ArgumentException(msg ?? "Argument cannot be blank", name);
        }
        public static void NotNullOrEmpty(string obj, string name, string msg = null)
        {
            NotNull(obj, name, msg);
            NotEmpty(obj, name, msg);
        }
        public static void NotNullOrWhitespace(string obj, string name, string msg = null)
        {
            NotNull(obj, name, msg);
            NotEmptyOrWhitespace(obj, name, msg);
        }

        public static void LengthAtLeast(string obj, int value, string name, string msg = null)
        {
            if (obj?.Length < value) throw new ArgumentException(msg ?? $"Length must be at least {value}", name);
        }
        public static void LengthAtMost(string obj, int value, string name, string msg = null)
        {
            if (obj?.Length > value) throw new ArgumentException(msg ?? $"Length must be at most {value}", name);
        }
        public static void LengthGreaterThan(string obj, int value, string name, string msg = null)
        {
            if (obj?.Length <= value) throw new ArgumentException(msg ?? $"Length must be greater than {value}", name);
        }
        public static void LengthLessThan(string obj, int value, string name, string msg = null)
        {
            if (obj?.Length >= value) throw new ArgumentException(msg ?? $"Length must be less than {value}", name);
        }

        #endregion
        #region DateTimes

        public static void Before(DateTime obj, DateTime value, string name, string msg = null)
        {
            if (obj < value) throw new ArgumentException(msg ?? $"Value must be before {value}", name);
        }
        public static void Before(DateTime? obj, DateTime value, string name, string msg = null)
        {
            if (obj != null && obj < value) throw new ArgumentException(msg ?? $"Value must be before {value}", name);
        }

        public static void OnOrBefore(DateTime obj, DateTime value, string name, string msg = null)
        {
            if (obj <= value) throw new ArgumentException(msg ?? $"Value must be on or before {value}", name);
        }
        public static void OnOrBefore(DateTime? obj, DateTime value, string name, string msg = null)
        {
            if (obj != null && obj <= value) throw new ArgumentException(msg ?? $"Value must be on or before {value}", name);
        }

        public static void After(DateTime obj, DateTime value, string name, string msg = null)
        {
            if (obj > value) throw new ArgumentException(msg ?? $"Value must be after {value}", name);
        }
        public static void After(DateTime? obj, DateTime value, string name, string msg = null)
        {
            if (obj != null && obj > value) throw new ArgumentException(msg ?? $"Value must be after {value}", name);
        }

        public static void OnOrAfter(DateTime obj, DateTime value, string name, string msg = null)
        {
            if (obj > value) throw new ArgumentException(msg ?? $"Value must be on or after {value}", name);
        }
        public static void OnOrAfter(DateTime? obj, DateTime value, string name, string msg = null)
        {
            if (obj != null && obj > value) throw new ArgumentException(msg ?? $"Value must be on or after {value}", name);
        }

        #endregion
        #region Arrays

        public static void Exclusive(object[] objs, string[] names, bool requireOne = false, string msg = null)
        {
            int count = 0;
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i] != null)
                    count++;
            }
            if (count > 1)
                throw new ArgumentException(msg ?? $"[{string.Join(", ", names)}] are exclusive parameters and may not be used together");
            if (count == 0 && requireOne)
                throw new ArgumentException(msg ?? $"At least one of [{string.Join(", ", names)}] must be specified");
        }

        #endregion
        #region Enumerables

        public static void HasAtMost<T>(IEnumerable<T> obj, int value, string name, string msg = null)
        {
            if (obj != null && obj.Count() > value) throw new ArgumentException(msg ?? $"Collection can have at most {value} item(s)", name);
        }
        public static void HasGreaterThan<T>(IEnumerable<T> obj, int value, string name, string msg = null)
        {
            if (obj != null && obj.Count() >= value) throw new ArgumentException(msg ?? $"Collection cannot have greater than {value} item(s)", name);
        }
        public static void HasAtLeast<T>(IEnumerable<T> obj, int value, string name, string msg = null)
        {
            if (obj != null && obj.Count() < value) throw new ArgumentException(msg ?? $"Collection must have at least {value} item(s)", name);
        }
        public static void HasLessThan<T>(IEnumerable<T> obj, int value, string name, string msg = null)
        {
            if (obj != null && obj.Count() <= value) throw new ArgumentException(msg ?? $"Collection must have less than {value} item(s)", name);
        }

        #endregion
        #region Numbers

        public static void NotZero(int obj, string name, string msg = null) { if (obj == 0) throw CreateNonZeroException(name, msg); }
        public static void NotZero(int? obj, string name, string msg = null) { if (obj == 0) throw CreateNonZeroException(name, msg); }
        public static void NotZero(uint obj, string name, string msg = null) { if (obj == 0) throw CreateNonZeroException(name, msg); }
        public static void NotZero(uint? obj, string name, string msg = null) { if (obj == 0) throw CreateNonZeroException(name, msg); }
        private static ArgumentException CreateNonZeroException(string name, string msg) => new ArgumentException(msg ?? $"Value must be non-zero", name);

        public static void AtLeast(int obj, int value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, value, msg); }
        public static void AtLeast(int? obj, int value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, value, msg); }
        public static void AtLeast(uint obj, int value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, value, msg); }
        public static void AtLeast(uint? obj, int value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, value, msg); }
        private static ArgumentException CreateAtLeastException(string name, object value, string msg) => new ArgumentException(msg ?? $"Value must be at least {value}", name);

        public static void GreaterThan(int obj, int value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, value, msg); }
        public static void GreaterThan(int? obj, int value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, value, msg); }
        public static void GreaterThan(uint obj, int value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, value, msg); }
        public static void GreaterThan(uint? obj, int value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, value, msg); }
        private static ArgumentException CreateGreaterThanException(string name, object value, string msg) => new ArgumentException(msg ?? $"Value must be greater than {value}", name);

        public static void AtMost(int obj, int value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, value, msg); }
        public static void AtMost(int? obj, int value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, value, msg); }
        public static void AtMost(uint obj, int value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, value, msg); }
        public static void AtMost(uint? obj, int value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, value, msg); }
        private static ArgumentException CreateAtMostException(string name, object value, string msg) => new ArgumentException(msg ?? $"Value must be at most {value}", name);

        public static void LessThan(int obj, int value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, value, msg); }
        public static void LessThan(int? obj, int value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, value, msg); }
        public static void LessThan(uint obj, int value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, value, msg); }
        public static void LessThan(uint? obj, int value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, value, msg); }
        private static ArgumentException CreateLessThanException(string name, object value, string msg) => new ArgumentException(msg ?? $"Value must be less than {value}", name);

        #endregion
    }
}

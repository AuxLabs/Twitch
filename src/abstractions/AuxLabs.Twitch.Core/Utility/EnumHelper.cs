using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace AuxLabs.Twitch
{
    public static class EnumHelper
    {
        public static string GetStringValue<T>(this T value)
            where T : Enum
        {
            return typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }

        public static T GetEnumValue<T>(string value)
            where T : Enum
        {
            var type = typeof(T);
            foreach (var member in Enum.GetValues(type))
            {
                var info = type.GetField(member.ToString());
                var attr = info.GetCustomAttribute<EnumMemberAttribute>();
                if (attr != null && attr.Value == value)
                {
                    return (T)member;
                }
            }
            return default;
        }
    }
}

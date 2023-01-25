using System;

namespace AuxLabs.SimpleTwitch
{
    public static class ActionHelper
    {
        public static T InvokeReturn<T>(this Action<T> action)
        {
            var args = (T)Activator.CreateInstance(typeof(T));
            action(args);
            return args;
        }
    }
}

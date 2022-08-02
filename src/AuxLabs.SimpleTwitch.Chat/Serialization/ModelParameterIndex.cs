﻿namespace AuxLabs.SimpleTwitch.Chat.Serialization
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ModelParameterIndex : Attribute
    {
        public int Index { get; }

        public ModelParameterIndex(int index)
            => Index = index;
    }
}

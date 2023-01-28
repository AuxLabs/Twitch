﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch
{
    public class MismatchedTagsException : TwitchException
    {
        public Type ModelType { get; }
        public SortedDictionary<string, string> Expected { get; }
        public SortedDictionary<string, string> Provided { get; }
        public SortedDictionary<string, string> Unique { get; }

        public MismatchedTagsException(Type type, IDictionary<string, string> expected, Dictionary<string, string> provided)
            : base($"{type.FullName} had a different amount of properties than tags in map") 
        {
            ModelType = type;
            Expected = new SortedDictionary<string, string>(expected);
            Provided = new SortedDictionary<string, string>(provided);

            var distinctKeys = Provided.Keys.Except(Expected.Keys);
            Unique = new SortedDictionary<string, string>(Provided.Where(x => distinctKeys.Contains(x.Key)).ToDictionary(x => x.Key, x => x.Value));
        }
    }
}

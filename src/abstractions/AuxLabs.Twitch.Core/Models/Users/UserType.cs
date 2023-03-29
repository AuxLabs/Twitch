﻿using System.Runtime.Serialization;

namespace AuxLabs.Twitch
{
    public enum UserType
    {
        [EnumMember(Value = "")]
        None = 0,

        [EnumMember(Value = "staff")]
        Staff,
        [EnumMember(Value = "admin")]
        Admin,
        [EnumMember(Value = "global_mod")]
        GlobalModerator
    }
}
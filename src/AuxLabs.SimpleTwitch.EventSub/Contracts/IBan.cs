﻿namespace AuxLabs.SimpleTwitch.EventSub
{
    public interface IBan
    {
        public IUser User { get; }
        public IUser Broadcaster { get;  }
        public IUser Moderator { get; }
    }
}

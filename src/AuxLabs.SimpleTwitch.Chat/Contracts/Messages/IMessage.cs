﻿using System.Collections.Generic;
using System.Drawing;

namespace AuxLabs.SimpleTwitch.Chat
{
    public interface IMessage
    {
        string Id { get; }
        string AuthorId { get; }
        string AuthorName { get; }
        string AuthorDisplayName { get; }
        UserType AuthorType { get; }
        Color AuthorColor { get; }
        string Content { get; }
        string Action { get; }
        bool IsTurbo { get; }

        IReadOnlyCollection<Badge> Badges { get; }
        IReadOnlyCollection<EmotePosition> Emotes { get; }
    }
}

﻿using System.Collections.Generic;
using System.Drawing;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PutUserChatColorArgs : QueryMap, IScoped
    {
        public string[] Scopes { get; } = { "user:manage:chat_color" };

        /// <summary> The ID of the user whose chat color you want to update. </summary>
        public string UserId { get; set; }

        /// <summary> The color to use for the user’s name in chat. </summary>
        public ChatColor? Color { get; set; }

        /// <summary> Turbo and Prime users may specify a custom color. </summary>
        public Color? CustomColor { get; set; }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(UserId, nameof(UserId));
            Require.Exclusive(new object[] { Color, CustomColor }, new[] { nameof(Color), nameof(CustomColor) });
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();

            if (UserId != null) 
                map["user_id"] = UserId;
            if (Color != null)
                map["color"] = Color.Value.GetEnumMemberValue();
            if (CustomColor != null)
                map["color"] = ColorTranslator.ToHtml(CustomColor.Value);

            return map;
        }
    }
}

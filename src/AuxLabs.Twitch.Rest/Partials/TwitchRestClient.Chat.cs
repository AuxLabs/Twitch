using AuxLabs.Twitch.Rest.Entities;
using AuxLabs.Twitch.Rest.Models;
using AuxLabs.Twitch.Rest.Requests;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest
{
    public partial class TwitchRestClient
    {
        public async Task ModifyMyColorAsync(ChatColor color, CancellationToken? cancelToken = null)
        {
            IsUserAuthorized(out var identity);
            await API.PutUserChatColorAsync(new PutUserChatColorArgs
            {
                UserId = identity.UserId,
                Color = color
            }, cancelToken);
        }
        public async Task ModifyMyColorAsync(Color color, CancellationToken? cancelToken = null)
        {
            IsUserAuthorized(out var identity);
            await API.PutUserChatColorAsync(new PutUserChatColorArgs
            {
                UserId = identity.UserId,
                CustomColor = color
            }, cancelToken);
        }

        // Paginate
        public IAsyncEnumerable<IReadOnlyCollection<RestSimpleUser>> GetChattersAsync(string channelId, int count = 20, CancellationToken? cancelToken = null)
        {
            IsUserAuthorized(out var identity);
            return new PagedAsyncEnumerable<RestSimpleUser>(
                TwitchConstants.DefaultMaxPerPage,
                async (info, ct) =>
                {
                    var response = await API.GetChattersAsync(new GetChattersArgs
                    {
                        BroadcasterId = channelId,
                        ModeratorId = identity.UserId,
                        After = info.Cursor,
                        First = info.PageSize
                    }, cancelToken);
                    return (response.Data.Select(x => RestSimpleUser.Create(this, x)).ToImmutableArray(), response.Pagination.Value.Cursor);
                },
                count: count);
        }

        public async Task<IReadOnlyCollection<RestGlobalEmote>> GetEmotesAsync(CancellationToken? cancelToken = null)
        {
            var response = await API.GetEmotesAsync(cancelToken);
            return response.Data.Select(x => RestGlobalEmote.Create(this, x)).ToImmutableArray();
        }

        public async Task<IReadOnlyCollection<RestEmote>> GetEmotesAsync(string channelId, CancellationToken? cancelToken = null)
        {
            var response = await API.GetEmotesAsync(channelId, cancelToken);
            return response.Data.Select(x => RestEmote.Create(this, x)).ToImmutableArray();
        }

        public async Task<IReadOnlyCollection<RestEmote>> GetEmoteSetAsync(string emoteSetId, CancellationToken? cancelToken = null)
            => (await GetEmoteSetsAsync(new[] { emoteSetId }, cancelToken)).ToImmutableArray();
        public Task<IReadOnlyCollection<RestEmote>> GetEmoteSetsAsync(params string[] emoteSetIds)
            => GetEmoteSetsAsync(emoteSetIds, null);
        public async Task<IReadOnlyCollection<RestEmote>> GetEmoteSetsAsync(string[] emoteSetIds, CancellationToken? cancelToken = null)
        {
            var response = await API.GetEmoteSetsAsync(emoteSetIds, cancelToken);
            return response.Data.Select(x => RestEmote.Create(this, x)).ToImmutableArray();
        }

        // Get Badges
        // Get Badges Global

        public async Task<ChatSettings> GetChatSettingsAsync(string channelId, CancellationToken? cancelToken = null)
        {
            IsUserAuthorized(out var identity);
            var response = await API.GetChatSettingsAsync(new GetChatSettingsArgs
            {
                BroadcasterId = channelId,
                ModeratorId = identity.UserId
            }, cancelToken);
            return response.Data.SingleOrDefault();
        }

        public async Task<ChatSettings> ModifyChatSettingsAsync(string channelId, Action<PatchChatSettingsBody> func, CancellationToken? cancelToken = null)
        {
            IsUserAuthorized(out var identity);

            var args = new PatchChatSettingsBody();
            func(args);

            var response = await API.PatchChatSettingsAsync(new PatchChatSettingsArgs
            {
                BroadcasterId = channelId,
                ModeratorId = identity.UserId
            }, args, cancelToken);
            return response.Data.SingleOrDefault();
        }

        public async Task SendAnnouncementAsync(string channelId, string message, AnnouncementColor? color = null, CancellationToken? cancelToken = null)
        {
            IsUserAuthorized(out var identity);

            await API.PostChatAnnouncementAsync(new PostAnnouncementArgs
            {
                BroadcasterId = channelId,
                ModeratorId = identity.UserId
            }, new PostAnnouncementBody
            {
                Message = message,
                Color = color
            }, cancelToken);
        }

        public async Task SendShoutoutAsync(string fromChannelId, string toChannelId, CancellationToken? cancelToken = null)
        {
            IsUserAuthorized(out var identity);

            await API.PostShoutoutAsync(new PostShoutoutArgs
            {
                FromBroadcasterId = fromChannelId,
                ToBroadcasterId = toChannelId,
                ModeratorId = identity.UserId
            }, cancelToken);
        }

        public async Task<RestChatUser> GetUserChatColorAsync(string userId, CancellationToken? cancelToken = null)
            => (await GetUserChatColorsAsync(new[] { userId }))?.SingleOrDefault();
        public Task<IReadOnlyCollection<RestChatUser>> GetUserChatColorsAsync(params string[] userIds)
            => GetUserChatColorsAsync(userIds, null);
        public async Task<IReadOnlyCollection<RestChatUser>> GetUserChatColorsAsync(string[] userIds, CancellationToken? cancelToken = null)
        {
            var response = await API.GetUserChatColorsAsync(userIds, cancelToken);
            return response.Data.Select(x => RestChatUser.Create(this, x)).ToImmutableArray();
        }
    }
}

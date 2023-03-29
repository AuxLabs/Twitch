using System.Runtime.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public enum EventSubStatus
    {
        Unknown = 0,

        /// <summary> The subscription is enabled. </summary>
        [EnumMember(Value = "enabled")]
        Enabled,

        /// <summary> The subscription is pending verification of the specified callback URL. </summary>
        [EnumMember(Value = "webhook_callback_verification_pending")]
        CallbackVerificationPending,

        /// <summary> The specified callback URL failed verification. </summary>
        [EnumMember(Value = "webhook_callback_verification_failed")]
        CallbackVerificationFailed,

        /// <summary> The notification delivery failure rate was too high. </summary>
        [EnumMember(Value = "notification_failures_exceeded")]
        FailuresExceeded,

        /// <summary> The authorization was revoked for one or more users specified in the Condition object. </summary>
        [EnumMember(Value = "authorization_revoked")]
        AuthorizationRevoked,

        /// <summary> The moderator that authorized the subscription is no longer one of the broadcaster's moderators. </summary>
        [EnumMember(Value = "moderator_removed")]
        ModeratorRemoved,

        /// <summary> One of the users specified in the Condition object was removed. </summary>
        [EnumMember(Value = "user_removed")]
        UserRemoved,

        /// <summary> The subscribed to subscription type and version is no longer supported. </summary>
        [EnumMember(Value = "version_removed")]
        VersionRemoved,

        /// <summary> The client closed the connection. </summary>
        [EnumMember(Value = "websocket_disconnected")]
        WebSocketDisconnected,

        /// <summary> The client failed to respond to a ping message. </summary>
        [EnumMember(Value = "websocket_failed_ping_pong")]
        WebSocketFailedHeartbeat,

        /// <summary> The client sent a non-pong message. </summary>
        /// <remarks> Clients may only send pong messages (and only in response to a ping message). </remarks>
        [EnumMember(Value = "webhook_callback_verification_pending")]
        WebSocketInboundTraffic,

        /// <summary> The client failed to subscribe to events within the required time. </summary>
        [EnumMember(Value = "websocket_connection_unused")]
        WebSocketUnused,

        /// <summary> The Twitch WebSocket server experienced an unexpected error. </summary>
        [EnumMember(Value = "websocket_internal_error ")]
        WebSocketInternalError,

        /// <summary> The Twitch WebSocket server timed out writing the message to the client. </summary>
        [EnumMember(Value = "websocket_network_timeout ")]
        WebSocketTimeout,

        /// <summary> The Twitch WebSocket server experienced a network error writing the message to the client. </summary>
        [EnumMember(Value = "websocket_network_error ")]
        WebSocketNetworkError
    }
}

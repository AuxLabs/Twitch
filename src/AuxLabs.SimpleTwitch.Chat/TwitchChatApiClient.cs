using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class TwitchChatApiClient : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private void HandleEvent(IrcMessage msg)
        {
            switch (msg.Command)
            {
                case IrcCommand.ClearChat: 
                    break;
                case IrcCommand.ClearMessage: 
                    break;
                case IrcCommand.HostTarget: 
                    break;
                case IrcCommand.Message: 
                    break;

                case IrcCommand.Pong: 
                    break;
                case IrcCommand.Mode: 
                    break;
                case IrcCommand.Names: 
                    break;
                case IrcCommand.Notice: 
                    break;
                case IrcCommand.Reconnect: 
                    break;
                case IrcCommand.RoomState: 
                    break;
                case IrcCommand.UserNotice: 
                    break;
                case IrcCommand.UserState: 
                    break;
                case IrcCommand.CapabilityAcknowledge: 
                    break;

                case IrcCommand.Join: 
                    break;
                case IrcCommand.Part: 
                    break;
                default:
                    break;
            };
        }
    }
}

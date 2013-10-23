using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComCon.Shared.Classes;
using System.ServiceModel;

namespace ComCon.Server
{
    public class ServerFunctions : IServerFunctions
    {
        public static readonly List<IUser> ConnectedUsers = new List<IUser>();

        public void ConnectToServer()
        {
            IUser user = OperationContext.Current.GetCallbackChannel<IUser>();
            if (!ConnectedUsers.Contains(user))
            {
                ConnectedUsers.Add(user);
            }
            
        }

        public void DisconnectFromServer()
        {
            IUser user = OperationContext.Current.GetCallbackChannel<IUser>();
            if (ConnectedUsers.Contains(user))
            {
                ConnectedUsers.Remove(user);
            }
        }

        public void Send(ChatMessage cm)
        {
            List<IUser> subscribersToDelete = new List<IUser>();
            IUser callback = OperationContext.Current.GetCallbackChannel<IUser>();
            foreach (IUser client in ConnectedUsers)
            {
                try
                {
                    client.ShowMessage(String.Format("[{0}]<{1}> {2}",cm.TimeStamp, cm.User, cm.Message));
                }
                catch (Exception e)
                {
                    subscribersToDelete.Add(client);
                }
            }
            foreach (IUser client in subscribersToDelete)
            {
                if (ConnectedUsers.Contains(client))
                {
                    ConnectedUsers.Remove(client);
                }
            }
        }

        public void ConnectToChannel()
        {
            throw new NotImplementedException();
        }

        public void DisconnectFromChannel()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetChannels()
        {
            List<string> ChannelList = new List<string>();
            ChannelList.Add("Testchannel");
            ChannelList.Add("Testchannel 2");
            return ChannelList;
        }
    }
}

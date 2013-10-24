using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComCon.Shared.Classes;
using System.ServiceModel;

namespace ComCon.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
    public class ServerFunctions : IServerFunctions
    {
        private ChatUser Server;

        public ServerFunctions()
        {
            if (Server == null)
            {
                ChatUser u = new ChatUser();
                u.Username = "Server";
                Users.Add(u);
                Server = u;
            }
            
        }

        public static readonly List<IUser> ConnectedUsers = new List<IUser>();
        public static readonly List<ChatUser> Users = new List<ChatUser>();

        public void ConnectToServer(string pName)
        {
            if (Users.SingleOrDefault(x => x.Username == pName) != null)
            {
                throw new InvalidOperationException("Dieser Username ist schon vorhanden!");
            }
            IUser user = OperationContext.Current.GetCallbackChannel<IUser>();
            ChatUser u = new ChatUser();
            u.Username = pName;
            u.Callback = user;
            if (!ConnectedUsers.Contains(user))
            {
                Users.Add(u);
                ConnectedUsers.Add(user);
            }
            foreach (IUser us in ConnectedUsers)
            {
                if (us != user)
                    us.UpdateUserList();
            }
            SendServerMessage(u.Username + " hat den Server betreten");
            
        }

        private void SendServerMessage(string pMessage)
        {
            foreach (IUser connected in ConnectedUsers)
            {
                connected.ShowMessage(new ChatMessage() { Message = pMessage, User = new ChatUser() { Username = "Server" } });

            }
        }

        public void DisconnectFromServer()
        {
            IUser user = OperationContext.Current.GetCallbackChannel<IUser>();
            ChatUser u = Users.SingleOrDefault(x => x.Callback == user);
            if (ConnectedUsers.Contains(user))
            {
                Users.Remove(u);
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
                    client.ShowMessage(cm);
                }
                catch (Exception e)
                {
                    subscribersToDelete.Add(client);
                }
            }
            foreach (IUser client in subscribersToDelete)
            {
                ChatUser u = Users.SingleOrDefault(x => x.Callback == client);
                if (ConnectedUsers.Contains(client))
                {
                    ConnectedUsers.Remove(client);
                    Users.Remove(u);
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

        public List<ChatUser> GetUsers()
        {
            return Users;
        }



        public ChatUser GetUser(string pName)
        {
            return (Users.SingleOrDefault(x => x.Username == pName));
        }
    }
}

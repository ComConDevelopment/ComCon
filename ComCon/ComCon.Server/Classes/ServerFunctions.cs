using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComCon.Shared.Classes;
using System.ServiceModel;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ComCon.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, AutomaticSessionShutdown = false, UseSynchronizationContext = false, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class ChatServerFunctions : IChatServerFunctions
    {


        #region Deklaration

        private ChatUser Server;
        private static object locker = new object();


        public static readonly List<IChatUser> ConnectedUsers = new List<IChatUser>();
        public static readonly List<ChatUser> Users = new List<ChatUser>();

        #endregion

        #region IServerFunctionsImplementations

        public void ConnectToServer(Credentials credentials)
        {
            IChatUser user = OperationContext.Current.GetCallbackChannel<IChatUser>();

        }


        public void ConnectToServer(string pName)
        {
            if (Users.SingleOrDefault(x => x.Username == pName) != null)
            {
                throw new InvalidOperationException("Dieser Username ist schon vorhanden!");
            }
            IChatUser user = OperationContext.Current.GetCallbackChannel<IChatUser>();
            ChatUser u = new ChatUser();
            u.Username = pName;
            u.Callback = user;
            if (!ConnectedUsers.Contains(user))
            {
                Users.Add(u);
                ConnectedUsers.Add(user);
            }

            SendServerMessage(u.Username + " hat den Server betreten");
            //UpdateAllUserLists();
        }


        public void DisconnectFromServer()
        {
            IChatUser user = OperationContext.Current.GetCallbackChannel<IChatUser>();
            ChatUser u = Users.SingleOrDefault(x => x.Callback == user);
            if (ConnectedUsers.Contains(user))
            {
                SendServerMessage(u.Username + " hat den Server verlassen");
                Users.Remove(u);
                ConnectedUsers.Remove(user);
            }
        }

        public void Send(ChatMessage cm)
        {
            List<IChatUser> subscribersToDelete = new List<IChatUser>();
            IChatUser callback = OperationContext.Current.GetCallbackChannel<IChatUser>();
            foreach (IChatUser client in ConnectedUsers)
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
            foreach (IChatUser client in subscribersToDelete)
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




        public ChatUser GetUser(Credentials pCredentials)
        {
            return (Users.SingleOrDefault(x => x.Credentials == pCredentials));
        }



        public List<ChatUser> LoggedInUsers
        {
            get { return Users; }
        }

        #endregion

        #region Konstruktor

        public ChatServerFunctions()
        {
            if (Server == null)
            {
                ChatUser u = new ChatUser();
                u.Username = "Server";
                Users.Add(u);
                Server = u;
            }

        }

        #endregion

        #region Diverses


        private void SendServerMessage(string pMessage)
        {
            foreach (IChatUser connected in ConnectedUsers)
            {
                connected.ShowMessage(new ChatMessage() { Message = pMessage, User = Server });
            }
        }

        #endregion


        


        
        

    }
}

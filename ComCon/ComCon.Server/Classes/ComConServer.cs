using ComCon.Server.Classes;
using ComCon.Shared.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ComCon.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, AutomaticSessionShutdown = false, UseSynchronizationContext = false, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class ComConServer : IMainServerFunctions, IChatServerFunctions
    {
        #region IMainServerFunctionsImplementation

        public User Authenticate(Credentials pCredentials)
        {
            return LoginService.AuthenticateUser(pCredentials);
        }

        #endregion

        #region IChatServerFunctionsImplementation

        

        #region Deklaration

        private User Server;
        private static object locker = new object();

        private static List<User> Users
        {
            get 
            {
                if (Global.Users == null)
                    Global.Users = new List<User>();
                return Global.Users;
                    
            }
        }
        public static readonly List<IChatUser> ConnectedUsers = new List<IChatUser>();
        

        #endregion

        #region IServerFunctionsImplementations

        public User ConnectToServer(Credentials credentials)
        {
            IChatUser user = OperationContext.Current.GetCallbackChannel<IChatUser>();
            User m = LoginService.AuthenticateUser(credentials);
            if (m != null)
            {
                m.Callback = user;
                Users.Add(m);
                ConnectedUsers.Add(user);
            }
            LoggingService.Log(m.Username + " connected", LogStatus.INFO);
            SendServerMessage(m.Username + " hat den Server betreten");
            return m;
        }

        public User GetUser(string pMail)
        {
            return null;
        }


        public void ConnectToServer(string pName)
        {
            if (Users.SingleOrDefault(x => x.Username == pName) != null)
            {
                throw new InvalidOperationException("Dieser Username ist schon vorhanden!");
            }
            IChatUser user = OperationContext.Current.GetCallbackChannel<IChatUser>();
            User u = new User();
            u.Username = pName;
            u.Callback = user;
            if (!ConnectedUsers.Contains(user))
            {
                Users.Add(u);
                ConnectedUsers.Add(user);
            }
            LoggingService.Log(u.Username + " connected", LogStatus.INFO);
            SendServerMessage(u.Username + " hat den Server betreten");
            //UpdateAllUserLists();
        }


        public void DisconnectFromServer()
        {
            IChatUser user = OperationContext.Current.GetCallbackChannel<IChatUser>();
            User u = Users.SingleOrDefault(x => x.Callback == user);
            if (ConnectedUsers.Contains(user))
            {
                LoggingService.Log(u.Username + " disconnected", LogStatus.INFO);
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
                User u = Users.SingleOrDefault(x => x.Callback == client);
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


        public List<User> LoggedInUsers
        {
            get { return Users; }
        }

        #endregion

        #region Konstruktor

        public ComConServer()
        {
            if (Server == null)
            {
                User u = new User();
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

        #endregion

    }
}

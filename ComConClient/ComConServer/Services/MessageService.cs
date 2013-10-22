using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComCon.Shared.Classes;
using System.ServiceModel;
using System.ServiceModel.Channels;
using ComConServer.Helper;

namespace ComConServer
{
    public class MessageService : IServerFunctions
    {

        public static readonly List<ChatUser> UserList = new List<ChatUser>();


        public void Send(ChatMessage cm)
        {
            foreach (ChatUser u in UserList)
            {
                try
                {
                    u.ShowMessage(String.Format("[{0:T}]<{1}> {2}", cm.TimeStamp, cm.User.Username, cm.Message));
                }
                catch (Exception e)
                {
                    SendServerMessage(u.Username + " hat die Verbindung zum Server verloren");
                    UserList.Remove(u);
                    Logger.Log(e);
                    
                }
            }
               

        }

        public void SendServerMessage(string pMessage)
        {
            foreach (ChatUser u in UserList)
            {
                try
                {
                    u.ShowMessage(String.Format("[{0:T}]<{1}> {2}", DateTime.Now, "Server", pMessage));
                }
                catch (Exception e)
                {
                    UserList.Remove(u);
                    Logger.Log(e);
                }
            }
        }

        public void ConnectToChannel()
        {

        }

        public void DisconnectFromChannel()
        {

        }

        public void ConnectToServer(string pName, string pPassword)
        {
            IClientFunctions callback = GetCallback();


            OperationContext context = OperationContext.Current;
            MessageProperties messageProperties = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpointProperty = messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            if (!UserList.Contains(callback))
            {
                ChatUser u = new ChatUser();
                u.Username = pName;
                u.IP = System.Net.IPAddress.Parse(endpointProperty.Address);
                UserList.Add(u);
                Logger.Log(String.Format("{0} ({1}) hat sich eingeloggt", u.Username, u.IP));
            }
            
        }


        public void DisconnectFromServer()
        {
            IClientFunctions callback = GetCallback();
            try
            {
                SendServerMessage((callback as ChatUser).Username + " hat sich ausgeloggt");
                UserList.Remove(callback as ChatUser);
                
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
           
        }

        private IClientFunctions GetCallback()
        {
            return OperationContext.Current.GetCallbackChannel<IClientFunctions>(); 

        }
    }
}

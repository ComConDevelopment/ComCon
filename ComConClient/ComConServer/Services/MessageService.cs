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

        public static readonly List<IClientFunctions> subscribers = new List<IClientFunctions>();


        public void ConnectToServer(string pName, string pPassword)
        {
            IClientFunctions callback = OperationContext.Current.GetCallbackChannel<IClientFunctions>();
            if (!subscribers.Contains(callback))
            {
                subscribers.Add(callback);
            }
        }

        public void DisconnectFromServer()
        {
            
        }

        public void Send(ChatMessage cm)
        {
            List<IClientFunctions> subscribersToDelete = new List<IClientFunctions>();
            IClientFunctions callback = OperationContext.Current.GetCallbackChannel<IClientFunctions>();
            foreach (IClientFunctions client in subscribers)
            {

                    try
                    {
                        client.ShowMessage(cm.User + ": " + cm.Message);
                    }
                    catch (Exception e)
                    {
                        subscribersToDelete.Add(client);
                    }
                
            }
            foreach (IClientFunctions client in subscribersToDelete)
            {
                if (subscribers.Contains(client))
                {
                    subscribers.Remove(client);
                }
            }
        }

        public void ConnectToChannel()
        {
           
        }

        public void DisconnectFromChannel()
        {
            
        }
    }
}

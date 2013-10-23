using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ComCon.Shared.Classes
{
    [ServiceContract(CallbackContract = typeof(IClientFunctions))]
    public interface IServerFunctions
    {

        [OperationContract]
        void ConnectToServer(string pName, string pPassword);

        [OperationContract]
        void DisconnectFromServer();

        [OperationContract]
        void Send(ChatMessage cm);

        [OperationContract]
        void ConnectToChannel();

        [OperationContract]
        void DisconnectFromChannel();

    }
}

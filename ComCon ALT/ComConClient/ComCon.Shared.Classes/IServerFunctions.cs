using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ComCon.Shared.Classes
{
    [ServiceContract(CallbackContract = typeof(IUser))]
    public interface IServerFunctions
    {

        [OperationContract]
        void ConnectToServer();

        [OperationContract]
        void DisconnectFromServer();

        [OperationContract]
        void Send(ChatMessage cm);

        [OperationContract]
        void ConnectToChannel();

        [OperationContract]
        void DisconnectFromChannel();

        [OperationContract]
        IEnumerable<string> GetChannels();

    }
}

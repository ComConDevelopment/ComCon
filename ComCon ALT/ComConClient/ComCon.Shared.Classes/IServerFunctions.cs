using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Net.Security;

namespace ComCon.Shared.Classes
{
    [ServiceContract(CallbackContract = typeof(IUser), ProtectionLevel = ProtectionLevel.None, SessionMode = SessionMode.Allowed)]
    public interface IServerFunctions
    {

        [OperationContract]
        void ConnectToServer(string pName);

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

        [OperationContract]
        ChatUser GetUser(string pName);

        [OperationContract]
        List<ChatUser> GetUsers();

    }
}

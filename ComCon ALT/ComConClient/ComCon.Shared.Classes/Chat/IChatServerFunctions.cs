using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Net.Security;

namespace ComCon.Shared.Classes
{
    [ServiceContract(CallbackContract = typeof(IChatUser), ProtectionLevel = ProtectionLevel.None, SessionMode = SessionMode.Allowed)]
    public interface IChatServerFunctions
    {

        [OperationContract]
        User ConnectToServer(Credentials credentials);

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
        User GetUser(string pMail);

        List<User> LoggedInUsers
        {
            [OperationContract]
            get;
        }

    }
}

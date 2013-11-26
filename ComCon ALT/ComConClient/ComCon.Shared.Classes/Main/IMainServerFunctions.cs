using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.ServiceModel;
using System.Text;

namespace ComCon.Shared.Classes
{
    [ServiceContract(ProtectionLevel = ProtectionLevel.None, SessionMode = SessionMode.Allowed)]
    public interface IMainServerFunctions
    {
        [OperationContract]
        User Authenticate(Credentials pCredentials);

        [OperationContract]
        bool RegisterUser(Credentials pCredentials);
        
    }
}

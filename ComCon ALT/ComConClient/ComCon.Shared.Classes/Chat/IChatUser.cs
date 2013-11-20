using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ComCon.Shared.Classes
{    
    [ServiceContract]    
    public interface IChatUser
    {
        [OperationContract(IsOneWay = true)]
        void ShowMessage(ChatMessage cm);


    }
}

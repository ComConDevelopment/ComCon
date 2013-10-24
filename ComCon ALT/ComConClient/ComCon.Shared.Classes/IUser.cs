using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ComCon.Shared.Classes
{    
    [ServiceContract]
    public interface IUser
    {
        [OperationContract(IsOneWay = true)]
        void ShowMessage(ChatMessage cm);

        [OperationContract(IsOneWay = true)]
        void UpdateUserList();
    }
}

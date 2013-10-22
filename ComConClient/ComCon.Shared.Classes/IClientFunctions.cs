using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ComCon.Shared.Classes
{    
    public interface IClientFunctions
    {
        [OperationContract(IsOneWay = true)]
        void ShowMessage(string pMessage);
    }
}

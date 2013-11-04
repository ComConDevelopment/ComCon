using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ComCon.Shared.Classes
{
    [ServiceContract]
    public interface IUser
    {
        [OperationContract(IsOneWay = true)]
        void PublishDashboardMessage(DashboardMessage pMessage);
    }
}

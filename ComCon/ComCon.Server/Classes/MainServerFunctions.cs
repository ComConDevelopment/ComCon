using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComCon.Shared.Classes;
using System.ServiceModel;
using ComCon.Server.Classes;

namespace ComCon.Server
{
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, AutomaticSessionShutdown = false, UseSynchronizationContext = false, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class MainServerFunctions
    {
        public User Authenticate(Credentials pCredentials)
        {
            return LoginService.AuthenticateUser(pCredentials);
        }
    }
}

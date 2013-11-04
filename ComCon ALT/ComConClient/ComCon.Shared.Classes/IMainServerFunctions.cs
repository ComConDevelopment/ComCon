using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComCon.Shared.Classes
{
    public interface IMainServerFunctions
    {
        bool Authenticate(Credentials pCredentials);

        
    }
}

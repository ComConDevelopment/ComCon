using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComCon.Client.Modules.Login.Events
{
    class PasswordVerificationChangedEvent : CompositePresentationEvent<string>
    {
    }
}

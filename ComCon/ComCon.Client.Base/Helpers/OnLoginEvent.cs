using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Events;
using ComCon.Client.Base.ServerService;

namespace ComCon.Client.Base.Helpers
{
    public class OnLoginEvent : CompositePresentationEvent<ChatUser>
    {
    }
}

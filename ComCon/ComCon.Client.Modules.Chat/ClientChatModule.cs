using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using System.ComponentModel.Composition;
using ComCon.Client.Base;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition.Hosting;
using Microsoft.Practices.Prism.Events;
using ComCon.Client.Base.Classes;
using ComCon.Client.Base.Helpers;
using ComCon.Client.Base.ServerService;

namespace ComCon.Client.Modules.Chat
{
    [ModuleExport(typeof(ClientChatModule), InitializationMode = InitializationMode.OnDemand)]
    public class ClientChatModule : ClientBaseModule
    {
        [ImportingConstructor]
        public ClientChatModule(IRegionManager manager, IEventAggregator eventAggregator)
            : base(manager, eventAggregator)
        {
            if (Global.IsLoggedIn)
            {                
                RegionManager.RegisterViewWithRegion("MainRegion", typeof(ChatControl));
            }
            
        }

    }
}

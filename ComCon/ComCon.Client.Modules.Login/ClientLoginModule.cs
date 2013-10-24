using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using ComCon.Client.Base;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Events;
using ComCon.Client.Modules.Login.Views;

namespace ComCon.Client.Modules.Login
{
    [ModuleExport(typeof(ClientLoginModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class ClientLoginModule : ClientBaseModule
    {
        [ImportingConstructor]
        public ClientLoginModule(IRegionManager manager, IEventAggregator eventAggregator)
            :base(manager, eventAggregator)
        {
            RegionManager.RegisterViewWithRegion("DashboardRegion", typeof(LoginView));
        }
    }
}

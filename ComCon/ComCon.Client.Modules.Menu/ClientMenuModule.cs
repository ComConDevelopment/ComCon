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

namespace ComCon.Client.Modules.Menu
{
    [ModuleExport(typeof(ClientMenuModule), InitializationMode  = InitializationMode.WhenAvailable)]
    public class ClientMenuModule : ClientBaseModule
    {
        [ImportingConstructor]
        public ClientMenuModule(IRegionManager manager, IEventAggregator eventAggregator)
            : base(manager, eventAggregator)
            
        {
            RegionManager.RegisterViewWithRegion("MenuRegion", typeof(Menu));
        }
    }
}

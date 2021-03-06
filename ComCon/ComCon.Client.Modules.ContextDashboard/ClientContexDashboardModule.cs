﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Modularity;
using ComCon.Client.Base;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition.Hosting;
using Microsoft.Practices.Prism.Events;
using ComCon.Client.Base.Classes;

namespace ComCon.Client.Modules.ContextDashboard
{
    [ModuleExport(typeof(ClientContexDashboardModule), InitializationMode = InitializationMode.OnDemand)]
    public class ClientContexDashboardModule : ClientBaseModule
    {
        [ImportingConstructor]
        public ClientContexDashboardModule(IRegionManager manager, IEventAggregator eventAggregator)
            : base(manager, eventAggregator)
        {
            RegionManager.RegisterViewWithRegion("DashboardRegion", typeof(Views.Dashboard));
            
        }
    }
}

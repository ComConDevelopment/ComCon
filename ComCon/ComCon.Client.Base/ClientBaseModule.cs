using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition.Hosting;
using Microsoft.Practices.Prism.Events;

namespace ComCon.Client.Base
{
    [ModuleExport(typeof(ClientBaseModule), InitializationMode = InitializationMode.WhenAvailable)]
    public abstract class ClientBaseModule : IModule
    {

        public readonly IRegionManager RegionManager;
        public readonly IEventAggregator EventAggregator;

        [ImportingConstructor]
        public ClientBaseModule(IRegionManager manager, IEventAggregator eventAggregator)
        {
            this.RegionManager = manager;
            this.EventAggregator = eventAggregator;
        }



        public void Initialize()
        {
           
        }
    }
}

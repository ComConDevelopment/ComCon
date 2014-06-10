using ComCon.Client.Base;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMEFModule
{
    
    public class Module : ClientBaseModule
    {
        [Import]
        public Controller Controller { get; set; }

        [ImportingConstructor]
        public Module(IRegionManager pManager, IEventAggregator pAggregator)
            : base (pManager, pAggregator)
        {

        }
    }
}

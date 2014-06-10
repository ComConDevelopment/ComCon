using ComCon.Client.Contracts.Services;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Client.Base.Classes
{
    [Export]
    public abstract class BaseController
    {
        public IEventAggregator EventAggregator { get; set; }
        public IBaseService BaseService { get; set; }
        public IRegionManager RegionManager { get; set; }

        public BaseController(IEventAggregator pEventAggregator, IBaseService pService, IRegionManager pManager)
        {
            EventAggregator = pEventAggregator;
            BaseService = pService;
            
        }

        protected void RegisterViewWithRegion(string pRegionName, ViewModelBase pViewModel, Type pViewType)
        {
            pViewType.GetProperty("ViewModel").SetValue(pViewType.GetConstructor(Type.EmptyTypes), pViewModel);
            RegionManager.RegisterViewWithRegion(pRegionName, pViewType);

        }
    }
}

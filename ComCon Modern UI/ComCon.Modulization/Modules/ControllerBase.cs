using ComCon.Common.Events;
using ComCon.Contracts.Menu;
using ComCon.Contracts.Services;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Modulization.Modules
{
    public abstract class ControllerBase
    {
        private IEventAggregator mEventAggregator;
        private IBaseService mBaseService;

        [Import]
        public IMenuService MenuService { get; set; }

        public ControllerBase(IEventAggregator pAggregator, IBaseService pService)
        {
            this.mEventAggregator = pAggregator;
            this.mBaseService = pService;
        }

        public void Init()
        {
           
        }

        public IComConMenuItem AddMenuItem(string pHeader)
        {
            var item = MenuService.AddMenuItem(pHeader);
            item.ModuleName = Assembly.GetCallingAssembly().FullName;
            return item;
            
        }
    }
}

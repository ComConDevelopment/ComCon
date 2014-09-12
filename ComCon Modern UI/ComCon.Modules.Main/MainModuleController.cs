using ComCon.Contracts.Services;
using ComCon.Modulization.Modules;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Modules
{
    [Export(typeof(MainModuleController))]
    internal class MainModuleController : ControllerBase
    {
        [ImportingConstructor]
        public MainModuleController(IEventAggregator pAggregator, IBaseService pService)
            : base (pAggregator, pService)
        {
            var menuItem = base.AddMenuItem("Test");
            menuItem.AddSubMenuItem("ComCon", new Uri("/Login"));
            base.Init();
        }
    }
}

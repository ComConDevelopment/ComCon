using ComCon.Client.Base.Classes;
using ComCon.Client.Contracts.Services;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMEFModule
{
    public class Controller : BaseController
    {
        [ImportingConstructor]
        public Controller(IEventAggregator pAggregator, IBaseService pService)
            : base(pAggregator, pService)
        {

        }
    }
}

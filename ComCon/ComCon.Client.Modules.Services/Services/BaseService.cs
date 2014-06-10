using ComCon.Client.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Client.Modules.Services
{
    public abstract class BaseService : IBaseService
    {
        #region IBaseService Member

        public Microsoft.Practices.Prism.Events.IEventAggregator EventAggregator
        {
            get;
            set;
        }

        public ComConAPI.APIBase Api
        {
            get;
            set;
        }

        #endregion
    }
}

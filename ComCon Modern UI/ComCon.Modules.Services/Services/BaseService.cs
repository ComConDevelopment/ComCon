using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComCon.Contracts.Services;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Events;

namespace ComCon.Services
{
    internal abstract class BaseService : IBaseService
    {

        #region IBaseService Member

        [Import]
        public IMenuService MenuService
        {
            get;
            private set;
        }

        #endregion

        #region IBaseService Member

        [Import]
        public IEventAggregator EventAggregator
        {
            get;
            private set;
        }

        #endregion
    }
}

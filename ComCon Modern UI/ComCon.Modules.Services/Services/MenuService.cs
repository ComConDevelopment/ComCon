using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComCon.Contracts.Services;
using ComCon.Contracts.Menu;
using ComCon.Common.Menu;
using System.Collections.ObjectModel;
using ComCon.Common.Events;

namespace ComCon.Services
{
    internal class MenuService : BaseService, IMenuService
    {
        private ObservableCollection<IComConMenuItem> MenuItems = new ObservableCollection<IComConMenuItem>();

        public MenuService()
        {
        }


        #region IMenuService Member

        public IComConMenuItem AddMenuItem(string pHeader)
        {
            IComConMenuItem newItem = new ComConMenuItem(pHeader);
            MenuItems.Add(newItem);
            return newItem;
        }

        #endregion

        #region IMenuService Member


        public IComConMenuItem AddMenuItem(string pHeader, string pDisplayName)
        {
            IComConMenuItem newItem = new ComConMenuItem(pHeader, pDisplayName);
            MenuItems.Add(newItem);
            return newItem;
        }

        #endregion
    }
}

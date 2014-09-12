using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Contracts.Menu
{
    public interface IComConMenuItem
    {
        string GroupName
        {
            get;
            set;
        }

        string DisplayName
        {
            get;
            set;
        }

        string ModuleName
        {
            get;
            set;
        }

        List<IComConSubMenuItem> SubMenuItems
        {
            get;
        }

        void AddSubMenuItem(string pDisplayName, Uri pSource);
    }
}

using ComCon.Contracts.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Common.Menu
{
    public class ComConMenuItem : IComConMenuItem
    {
        private string mGroupName;

        public string GroupName
        {
            get { return mGroupName; }
            set { mGroupName = value; }
        }

        private string mDisplayName;

        public string DisplayName
        {
            get { return mDisplayName; }
            set { mDisplayName = value; }
        }

        private List<IComConSubMenuItem> mSubMenuItems;

        public List<IComConSubMenuItem> SubMenuItems
        {
            get { return mSubMenuItems; }
        }

        public void AddSubMenuItem(string pDisplayName, Uri pSource)
        {
            SubMenuItems.Add(new ComConSubMenuItem() { DisplayName = pDisplayName, Source = pSource });
        }

        public ComConMenuItem()
        {
            mSubMenuItems = new List<IComConSubMenuItem>();
        }

        public ComConMenuItem(string pHeader)
        {
            this.GroupName = pHeader;
            this.DisplayName = pHeader;
            mSubMenuItems = new List<IComConSubMenuItem>();
        }

        public ComConMenuItem(string pHeader, string pDisplayName)
        {
            this.GroupName = pHeader;
            this.DisplayName = pDisplayName;
            mSubMenuItems = new List<IComConSubMenuItem>();
        }


        #region IComConMenuItem Member


        public string ModuleName
        {
            get;
            set;
        }

        #endregion
    }
}

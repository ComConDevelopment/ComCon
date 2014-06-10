using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Modulization
{
    public class MenuItem
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

        private List<SubMenuItem> mSubMenuItems;

        public List<SubMenuItem> SubMenuItems
        {
            get { return mSubMenuItems; }
            set { mSubMenuItems = value; }
        }


    }
}

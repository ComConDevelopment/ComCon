using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Modulization
{
    public class SubMenuItem
    {
        private Uri mSource;

        public Uri Source
        {
            get { return mSource; }
            set { mSource = value; }
        }

        private string mDisplayName;

        public string DisplayName
        {
            get { return mDisplayName; }
            set { mDisplayName = value; }
        }


    }
}

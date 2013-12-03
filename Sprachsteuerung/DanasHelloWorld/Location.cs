using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spracherkennung
{
    public class Location : ILocation
    {

        public Location(string pName)
        {
            Name = pName;
        }

        private List<IItem> mItems = new List<IItem>();
        public List<IItem> Items
        {
            get
            {
                return mItems;
            }
            set
            {
                mItems = value;
            }
        }

        public string Name
        {
            get;
            set;
        }
    }
}

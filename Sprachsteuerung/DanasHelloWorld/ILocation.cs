using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spracherkennung
{
    public interface ILocation
    {

        List<IItem> Items
        {
            get;
            set;
        }
        string Name
        {
            get;
            set;
        }

        

    }
}

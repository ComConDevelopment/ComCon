using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spracherkennung
{
    public interface IItem
    {
        State ItemState
        {
            get;
        }
        void SetState(State pState);

        string Name { get; set; }
    }
}

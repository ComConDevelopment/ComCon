using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Common.Menu
{
    public class ComConLink : Link
    {
        public event EventHandler LinkClicked;

        public ComConLink()
        {
            

            if (this.LinkClicked != null)
            {
                this.LinkClicked(this, new EventArgs());
            }
        }

    }
}

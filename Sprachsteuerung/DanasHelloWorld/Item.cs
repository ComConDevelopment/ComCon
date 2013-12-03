using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spracherkennung
{
    public class Item : IItem
    {
        public Item(string pName)
        {
            Name = pName;
        }

        private State mItemState = State.OFF;
        public State ItemState
        {
            get { return mItemState; }
        }

        public string Name
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Name;
        }


        public void SetState(State pState)
        {
            mItemState = pState;
            switch (pState)
            {
                case State.ON:
                    Console.WriteLine("==> " + Name + " ist nun an");
                    break;
                case State.OFF:
                    Console.WriteLine("==> " + Name + " ist nun aus");
                    break;
            }
            
        }


    }
}

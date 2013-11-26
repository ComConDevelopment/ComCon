using ComCon.Client.Base.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ComCon.Client.Modules.Menu.Classes
{
    public class MenuItem : INotifyPropertyChanged
    {
        public delegate void MenuItemClickedHandler(object sender, MenuItemClickedEventArgs data);
        public event MenuItemClickedHandler MenuItemClicked;

        public void OnMenuItemClicked(object sender, MenuItemClickedEventArgs data)
        {
            if (MenuItemClicked != null)
            {
                MenuItemClicked(this, data);
            }
        }

        private string mCaption;
        public string Caption
        {
            get { return (mCaption); }
            set { mCaption = value; RaisePropertyChanged("Caption"); }
        }


        private string mCorrelatedView;
        public string CorrelatedView
        {
            get { return (mCorrelatedView); }
            set { mCorrelatedView = value; RaisePropertyChanged("CorrelatedView"); }
        }


        private Regions mCorrelatedRegion;
        public Regions CorrelatedRegion
        {
            get { return (mCorrelatedRegion); }
            set { mCorrelatedRegion = value; RaisePropertyChanged("CorrelatedRegion"); }
        }

        public MenuItem(string pCaption, string pCorrelatedView, Regions pRegion)
        {
            Caption = pCaption;
            CorrelatedRegion = pRegion;
            CorrelatedView = pCorrelatedView;
        }


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string pPropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
            }
        }

        #endregion
    }

    public class MenuItemClickedEventArgs : EventArgs
    {
        public string CorrelatedView { get; internal set; }
        public Regions CorrelatedRegion { get; internal set; }

        public MenuItemClickedEventArgs(string pCorrelatedModule, Regions pCorrelatedRegion)
        {
            CorrelatedView = pCorrelatedModule;
            CorrelatedRegion = pCorrelatedRegion;
        }
    }
}

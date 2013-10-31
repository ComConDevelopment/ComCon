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

        private string mCaption;
        public string Caption
        {
            get { return (mCaption); }
            set { mCaption = value; RaisePropertyChanged("Caption"); }
        }


        private string mCorrelatedView;
        public string CorrelatedModule
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
            CorrelatedModule = pCorrelatedView;
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
}

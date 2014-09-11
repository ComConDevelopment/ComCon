using FirstFloor.ModernUI.Presentation;
using System;
using System.ComponentModel;
using Microsoft.Practices.ServiceLocation;
namespace ComCon
{
    internal class ShellViewModel : INotifyPropertyChanged
    {
        #region Deklaration


        private LinkGroupCollection mMenuGroups = new LinkGroupCollection();
        private LinkCollection mTopMenuLinks = new LinkCollection();

        #endregion

        #region Properties

        public LinkGroupCollection MenuGroups
        {
            get { return (mMenuGroups); }
            set { mMenuGroups = value; RaisePropertyChanged("MenuGroups"); }
        }


        public LinkCollection TopMenuLinks
        {
            get { return (mTopMenuLinks); }
            set { mTopMenuLinks = value; RaisePropertyChanged("TopMenuLinks"); }
        }

        #endregion

        #region Konstruktor

        public ShellViewModel()
        {
            LoadMenu();

            //LinkGroup g = new LinkGroup();
            //g.GroupName = "ComCon";
            //g.DisplayName = "ComCon";

            //MenuGroups.Add(g);

            LinkGroup lg = new LinkGroup();
            lg.GroupKey = "Einstellungen";
            lg.DisplayName = "Einstellungen";
            lg.Links.Add(new Link() { DisplayName = "einstellungen", Source = new Uri("/Pages/Settings", UriKind.RelativeOrAbsolute) });

            MenuGroups.Add(lg);

            TopMenuLinks.Add(new Link() { DisplayName = "einstellungen", Source = new Uri("/Pages/Settings", UriKind.RelativeOrAbsolute) });
        }

        #endregion

        #region Events

        public void LoadMenu()
        {
            RaisePropertyChanged("MenuGroups");
        }       

        #endregion

        #region Diverses



        #endregion
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

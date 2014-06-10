using ComCon.Modulization;
using FirstFloor.ModernUI.Presentation;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon
{
    internal class ShellViewModel : INotifyPropertyChanged
    {
        #region Deklaration


        private LinkGroupCollection mMenuGroups = new LinkGroupCollection();
        private LinkCollection mTopMenuLinks = new LinkCollection();

        private IEnumerable<IModuleMetadata> Modules;
        private MenuLoader MenuLoader;

        private string mLoadedModule = "";

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

            LinkGroup g = new LinkGroup();
            g.GroupName = "ComCon";
            g.DisplayName = "ComCon";

            MenuGroups.Add(g);

            LinkGroup lg = new LinkGroup();
            lg.GroupName = "Einstellungen";
            lg.DisplayName = "Einstellungen";
            lg.Links.Add(new Link() { DisplayName = "einstellungen", Source = new Uri("/Pages/Settings", UriKind.RelativeOrAbsolute) });

            MenuGroups.Add(lg);

            TopMenuLinks.Add(new Link() { DisplayName = "einstellungen", Source = new Uri("/Pages/Settings", UriKind.RelativeOrAbsolute) });
        }

        #endregion

        #region Events

        public void LoadMenu()
        {


            Modules = (IEnumerable<IModuleMetadata>)ComCon.App.Current.Resources["Modules"];
            MenuLoader = (MenuLoader)ComCon.App.Current.Resources["MenuLoader"];

            foreach (IModuleMetadata i in Modules)
            {
                if (i.ShowInTopLinks)
                    TopMenuLinks.Add(new Link() { DisplayName = i.ModuleName, Source = new Uri(i.HomeSource, UriKind.RelativeOrAbsolute) });

                if (MenuLoader != null)
                {
                    var menuItems = MenuLoader.GetMenuItems(i.ModuleName);

                    foreach (MenuItem mi in menuItems)
                    {
                        LinkGroup g = new LinkGroup();
                        g.GroupName = mi.GroupName;
                        g.DisplayName = mi.DisplayName;
                        if (mi.SubMenuItems != null)
                        {
                            foreach (SubMenuItem smi in mi.SubMenuItems)
                            {
                                g.Links.Add(new Link() { Source = smi.Source, DisplayName = smi.DisplayName });
                            }
                        }

                        MenuGroups.Add(g);
                    }
                }
            }


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

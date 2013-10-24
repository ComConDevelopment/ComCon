using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;   

namespace ComCon
{
    public class Bootstrapper : MefBootstrapper
    {

        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Shell)this.Shell;
            Application.Current.MainWindow.Show();
        }


        protected override void ConfigureAggregateCatalog()
        {

            //Alle Module laden
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ComCon.Client.Base.ClientBaseModule).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Client.Modules.Login.ClientLoginModule).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Client.Modules.Chat.ClientChatModule).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Client.Modules.Menu.ClientMenuModule).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Client.Modules.ContextDashboard.ClientContexDashboardModule).Assembly));
            
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();            
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ModuleCatalog();
        }

        


    }
}

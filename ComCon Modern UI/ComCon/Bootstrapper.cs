using ComCon.Modulization;
using ComCon.Modulization.Content;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComCon
{
    public class Bootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<MainWindow>();
        }

        /// <summary>
        /// Erstellt eine neue Instanz des Shells, die die Regionen enthält in welche die Views injiziert werden
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();
        }

        /// <summary>
        /// Lädt alle Assemblies, die nicht im ModuleCatalog angegeben sind
        /// </summary>
        protected override void ConfigureAggregateCatalog()
        {

            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
        }

        /// <summary>
        /// Erstellt den Modulkatalog aus einem xaml-Modulkatalog
        /// </summary>
        /// <returns></returns>
        protected override Microsoft.Practices.Prism.Modularity.IModuleCatalog CreateModuleCatalog()
        {
            IModuleCatalog cat = new DirectoryModuleCatalog() { ModulePath = "Modules" };
            
            return cat;
        }

        /// <summary>
        /// Konfiguriert den Container (hier für den EventAggregator)
        /// </summary>
        protected override void ConfigureContainer()
        {

            base.ConfigureContainer();
            
        }

        protected override void RegisterBootstrapperProvidedTypes()
        {
            base.RegisterBootstrapperProvidedTypes();
            var loader = Container.GetExport<MefContentLoader>().Value;
            Application.Current.Resources.Add("MefContentLoader", loader);
        }
    }
}

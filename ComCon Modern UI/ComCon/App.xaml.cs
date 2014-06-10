using ComCon.Modulization;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace ComCon
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
                                    
            // bootstrap MEF composition

            var aggregateCatatlog = new AggregateCatalog();

            aggregateCatatlog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            aggregateCatatlog.Catalogs.Add(new DirectoryCatalog("Modules"));
            var container = new CompositionContainer(aggregateCatatlog);

            var contentLoader = container.GetExport<MefContentLoader>().Value;

            var menuLoader = container.GetExport<MenuLoader>().Value;

            var modules = menuLoader.GetModules();

            this.Resources.Add("Modules", modules);
            this.Resources.Add("MenuLoader", menuLoader);
            this.Resources.Add("MefContentLoader", contentLoader);


        }
    }
}

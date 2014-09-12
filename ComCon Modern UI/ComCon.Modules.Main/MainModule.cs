using ComCon.Modulization.Modules;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using System.ComponentModel.Composition;


namespace ComCon.Modules.Main
{
    [ModuleExport("ComCon Main Module", typeof(MainModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class MainModule : ModuleBase
    {
        [Import]
        MainModuleController Controller { get; set; }

        [ImportingConstructor]
        public MainModule()
        {
            
        }
    }
}

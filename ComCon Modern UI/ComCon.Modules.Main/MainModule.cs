using ComCon.Modulization.Module;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;


namespace ComCon.Modules.Main
{
    [ModuleExport(typeof(MainModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class MainModule : ModuleBase
    {

        public MainModule()
        {
            
        }
    }
}

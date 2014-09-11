using ComCon.Modulization.Module;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Modulization
{
    [ModuleExport(typeof(ModulizationModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class ModulizationModule : ModuleBase
    {
    }
}

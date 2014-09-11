using ComCon.Modulization.Module;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon
{
    [ModuleExport(typeof(ShellModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class ShellModule : ModuleBase
    {
    }
}

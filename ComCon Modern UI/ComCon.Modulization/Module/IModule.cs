using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Modulization
{
    public interface IModule
    {
        List<MenuItem> ModuleMenuItems { get; set; }
    }
}

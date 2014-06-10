using ComCon.Modulization;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon
{
    [Export]
    public class MenuLoader
    {

        [ImportMany]
        private Lazy<IModule, IModuleMetadata>[] Modules { get; set; }

        public IEnumerable<IModuleMetadata> GetModules()
        {
            return (from m in Modules select m.Metadata);
        }

        public IEnumerable<MenuItem> GetMenuItems(string pModuleName)
        {
            var module = (from m in Modules where m.Metadata.ModuleName == pModuleName select m.Value).FirstOrDefault();
            
            if (module != null)
            {
                return module.ModuleMenuItems;
            }
            throw new ArgumentException("There is no such module with this name: " + pModuleName + "!");
        }

        public Uri GetTopLinkSource(string pModuleName)
        {
            var module = (from m in Modules where m.Metadata.ModuleName == pModuleName select m.Metadata).FirstOrDefault();

            if (module != null)
            {
                return new Uri(module.HomeSource, UriKind.RelativeOrAbsolute) ;
            }
            throw new ArgumentException("There is no such module with this name: " + pModuleName + "!");
        }
    }
}

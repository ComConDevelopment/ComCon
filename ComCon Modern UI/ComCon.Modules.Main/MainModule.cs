using ComCon.Modulization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Modules.Main
{
    [Module("ComCon", "/Login", ShowInTopLinks = true)]
    public class MainModule : IModule
    {
        #region IModule Member

        public List<MenuItem> ModuleMenuItems
        {
            get;
            set;
        }

        #endregion

        public MainModule()
        {
            ModuleMenuItems = new List<MenuItem>();
            ModuleMenuItems.Add(new MenuItem()
            {
                GroupName = "ComCon",
                DisplayName = "ComCon",
                SubMenuItems = new List<SubMenuItem>()
                    {
                        new SubMenuItem() { Source = new Uri("/Login", UriKind.RelativeOrAbsolute), DisplayName = "Login"}
                        
                    }
            });


            
        }
    }
}

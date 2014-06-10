using ComCon.Modulization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjekt
{
    [Module("TestModule", "/Test")]
    public class ComConModule : IModule
    {
        #region IModule Member

        public List<MenuItem> ModuleMenuItems
        {
            get;
            set;
        }

        #endregion

        public ComConModule()
        {
            ModuleMenuItems = new List<MenuItem>();
            ModuleMenuItems.Add(new MenuItem()
            {
                DisplayName = "Test",
                GroupName = "TestModul",
                SubMenuItems = new List<SubMenuItem>()
                {
                    new SubMenuItem() { DisplayName = "Test", Source = new Uri("/Test", UriKind.RelativeOrAbsolute)}
                }


            });
        }
    }
}

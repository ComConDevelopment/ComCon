using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using ComCon.Modulization;

namespace ComCon.Modules.Chat
{
    [Module("ComCon Chat", "/Chat")]
    public class ChatModule : IModule
    {
        public List<MenuItem> ModuleMenuItems
        {
            get;
            set;
        }

        public ChatModule()
        {
            ModuleMenuItems = new List<MenuItem>()
            {
                new MenuItem() 
                { 
                    DisplayName = "Chat",
                    GroupName = "Chat", 
                    SubMenuItems = new List<SubMenuItem>() 
                    {
                        new SubMenuItem() { DisplayName = "Chat", Source = new Uri("/Chat", UriKind.RelativeOrAbsolute)}
                    }
                }

            };
        }
    }
}

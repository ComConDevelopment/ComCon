using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComCon
{
    class ModuleLoadException : Exception
    {
        public string ModuleName { get; set; }

        public ModuleLoadException(string pModuleName)
            : base("Loading of module \"" + pModuleName + "\" failed. This module does not exist!") 
        {
            ModuleName = pModuleName;
        }

        public ModuleLoadException(string pModuleName, string pMessage)
            : base(pMessage)
        {
            ModuleName = pModuleName;
        }

        public ModuleLoadException()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Modulization
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public class ModuleAttribute : ExportAttribute
    {
        public string ModuleName { get; private set; }
        public string HomeSource { get; private set; }
        public bool ShowInTopLinks { get; set; }

        public ModuleAttribute(string pModuleName, string pHomeSource)
            :base(typeof(IModule))
        {
            this.ModuleName = pModuleName;
            HomeSource = pHomeSource;
            ShowInTopLinks = true;
        }        
    }
}

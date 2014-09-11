using FirstFloor.ModernUI.Windows;
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
    public class ContentAttribute : ExportAttribute
    {
        public ContentAttribute(string contentUri, string pModuleName)
            : base(typeof(IContent))
        {
            this.ContentUri = contentUri;
            this.ModuleName = pModuleName;
        }
        public string ModuleName { get; private set; }
        public string ContentUri { get; private set; }
    }
}

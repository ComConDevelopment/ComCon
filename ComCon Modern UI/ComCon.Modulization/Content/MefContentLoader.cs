using ComCon.Modulization;
using FirstFloor.ModernUI.Windows;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Modulization.Content
{
    [Export]
    public class MefContentLoader : DefaultContentLoader
    {
        //[Import]
        //IModuleCatalog Catalog { get; set; }

        [ImportMany]
        private Lazy<IContent, IContentMetadata>[] Contents { get; set; }

        protected override object LoadContent(Uri uri)
        {
            // lookup the content based on the content uri in the content metadata             
            var content = (from c in this.Contents
                           where c.Metadata.ContentUri == uri.OriginalString
                           select c.Value).FirstOrDefault();

            if (content == null)
            {
                throw new ArgumentException("Invalid uri: " + uri);
            }

            var contentMetadata = (from c in this.Contents
                           where c.Metadata.ContentUri == uri.OriginalString
                           select c.Metadata).FirstOrDefault();

            //var mod = Catalog.Modules.SingleOrDefault(x => x.ModuleName == contentMetadata.ModuleName);

            //if (mod == null || mod.State != ModuleState.Initialized)
            //{
            //    throw new ArgumentException("The module was not loaded or not found!");
            //}

            return content;
        }  
    }
}

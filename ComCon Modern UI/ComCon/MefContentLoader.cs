﻿using ComCon.Modulization;
using FirstFloor.ModernUI.Windows;
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
    public class MefContentLoader : DefaultContentLoader
    {
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

            return content;
        }

        
    }
}

using FirstFloor.ModernUI.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Modulization.Content
{
    [InheritedExport]
    public interface IContentCatalog : IEnumerable<IContent>
    {
        
    }
}

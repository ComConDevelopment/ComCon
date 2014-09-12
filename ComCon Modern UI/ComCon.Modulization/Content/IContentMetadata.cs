using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Modulization.Content
{
    public interface IContentMetadata
    {
        string ContentUri { get; }
        string ModuleName { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Modulization
{
    public interface IModuleMetadata
    {
        string ModuleName { get; }
        string HomeSource { get; }
        bool ShowInTopLinks { get; }
    }
}

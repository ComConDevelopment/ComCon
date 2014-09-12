using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Contracts.Menu
{
    public interface IComConSubMenuItem
    {
        Uri Source { get; set; }
        string DisplayName { get; set; }
    }
}

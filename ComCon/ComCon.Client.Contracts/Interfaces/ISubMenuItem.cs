using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Client.Contracts.Interfaces
{
    public interface ISubMenuItem
    {
        string ImagePath { get; set; }
        string Caption { get; set; }
    }
}

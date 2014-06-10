using ComCon.Client.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Client.Contracts.Services
{
    public interface IMenuService
    {
        void AddMenuItem(IMenuItem pItem);
    }
}

using ComCon.Contracts.Menu;
using System.ComponentModel.Composition;

namespace ComCon.Contracts.Services
{
    [InheritedExport]
    public interface IMenuService : IBaseService
    {
        IComConMenuItem AddMenuItem(string pHeader);
        IComConMenuItem AddMenuItem(string pHeader, string pDisplayName);
    }
}

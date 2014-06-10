using ComCon.Shared.Classes;
using ComCon.Shared.Classes.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Client.Contracts.Services
{
    public interface ILoginService : IBaseService
    {
        Task<Profile> LoginAsync(Credentials pCredentials);
        void Login(Credentials pCredentials);
        void Logout();
    }
}

using ComCon.Client.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComConAPI;
using ComCon.Shared.Classes;
using ComCon.Shared.Classes.Main;

namespace ComCon.Client.Modules.Services
{
    public class LoginService : BaseService, ILoginService
        #region ILoginService Member
    {
        public LoginService()
        {
            this.Api = new ProfileAPI();
        }

        public async Task<Profile> LoginAsync(Credentials pCredentials)
        {
            return await (Api as ProfileAPI).SearchByMail(pCredentials.Email);
        }

        public void Login(Credentials pCredentials)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ILoginService Member

        #endregion
    }
}

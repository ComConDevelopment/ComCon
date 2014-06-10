using ComCon.Client.Base.Classes;
using ComCon.Client.Contracts.Services;
using ComCon.Client.Modules.Login.Models;
using ComCon.Client.Modules.Login.Views;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;

namespace ComCon.Client.Modules.Login
{
    [InheritedExport]
    public class LoginController : BaseController
    {
        [ImportingConstructor]
        public LoginController(IEventAggregator pAggregator, ILoginService pService, IRegionManager pManager)
            : base(pAggregator, pService, pManager)
        {
            RegisterViewWithRegion("MainRegion", new LoginModel(pAggregator, pService), typeof(LoginView));
            //RegionManager.RegisterViewWithRegion("MainRegion", typeof(LoginView));
        }
    }
}

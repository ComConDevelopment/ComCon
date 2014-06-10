using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ComConAPI
{
    public abstract class APIBase
    {
        protected WebClient Client = new WebClient();
        protected const string BASEURL = "http://www.comcondev.de/api.php";
        protected const string APIKEY = "8tYC56cwa6m5WOfPzKfaUFSZuFXHxLlX";


        protected string GetApiString(API pApi)
        {
            return Enum.GetName(typeof(API), pApi);
        }

        //protected virtual string BuildRequestString(API pApi, string pToken)
        //{

        //}

    }

    public enum API
    {
        profile,

    }
}

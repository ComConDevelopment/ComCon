using ComCon.Shared.Classes.Main;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ComConAPI
{
    public class ProfileAPI : APIBase
    {
        public async Task<Profile> SearchByMail(string pMail)
        {
            string encodedMail = pMail.Replace("@", "%40");

            string json = await Client.DownloadStringTaskAsync(new Uri(BASEURL + "?api=" + GetApiString(API.profile) + "&token=" + APIKEY + "&mail=" + encodedMail));
            json = json.Remove(0, 1);
            json = json.Remove(json.Length - 1);
            
            try
            {
                Profile p = JsonConvert.DeserializeObject<Profile>(json);
                return p;
            }
            catch (Exception)
            {
                return null;
            }
        }        
    }


}

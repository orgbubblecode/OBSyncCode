using OBSyncTool.Busines.AMB.Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSyncTool.Busines.CRM.ESPOCRM
{
    public class APIClient : HttpClient
    {
        public static HttpClient _httpClientInstance;
        private string _apiKey = "6537138c6f688bf2290449332e9a21ce";

        private APIClient()
        {
            Task.Run(() => this.AuthClient()).Wait();
        }
        public async Task AuthClient()
        {
            _httpClientInstance = new HttpClient();
            _httpClientInstance.DefaultRequestHeaders.Add("X-Api-Key", _apiKey);

        }
        public static APIClient GetInstance()
        {
            // If the instance is null, create a new instance
            if (_httpClientInstance == null)
            {
                _httpClientInstance = new APIClient();
            }
            return (APIClient)_httpClientInstance;
        }

    }
}

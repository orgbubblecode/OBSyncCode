using Newtonsoft.Json;
using OBSyncTool.Busines.AMB.Model_;
using OBSyncTool.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OBSyncTool.Busines.AMB
{
    public  class API
    {

        private HttpClient _httpClient;

        private Token _Token;

        public static string apiurl = "https://api.allmy.bio/";


        public API()
        {
            _httpClient = new HttpClient();
            _Token = Token.GetInstance();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _Token.TokenResponse.document.access_token);

        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string apiPath, TRequest data)
        {

            return await APIOperations.PostAsync<TRequest, TResponse>(string.Concat(apiurl, apiPath), data, this._httpClient);


            //// Serialize the request data to JSON
            //var jsonData = JsonConvert.SerializeObject(data);
            //var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            //// Add authorization header

            //// Post data to the API
            //var response = await _httpClient.PostAsync(string.Concat(apiurl, apiPath), content);

            //// Handle response
            //if (!response.IsSuccessStatusCode)
            //{
            //    throw new HttpRequestException($"Failed to post data to API. Status code: {response.StatusCode}");
            //}

            //// Deserialize the response JSON to the specified type
            //var responseContent = await response.Content.ReadAsStringAsync();
            //var responseObject = JsonConvert.DeserializeObject<TResponse>(responseContent);

            //return responseObject;
        }

        public async Task<TResponse> GetAsync<TResponse>(string apiPath)
        {

            return await APIOperations.GetAsync<TResponse>(string.Concat(apiurl, apiPath), this._httpClient);

            //// Perform GET request to the API
            //var response = await _httpClient.GetAsync(string.Concat(apiurl, apiPath));

            //// Handle response
            //if (!response.IsSuccessStatusCode)
            //{
            //    throw new HttpRequestException($"Failed to get data from API. Status code: {response.StatusCode}");
            //}

            //// Deserialize the response JSON to the specified type
            //var responseContent = await response.Content.ReadAsStringAsync();
            //var responseObject = JsonConvert.DeserializeObject<TResponse>(responseContent);

            //return responseObject;
        }



        public class SearhByColumnSearch
        {
            public SearhByColumnSearchArray[] SearchParams { get; set; }
        }

        public class SearhByColumnSearchArray
        {
            public string columnName { get; set; }
            public string columnLogic { get; set; }
            public object columnValue { get; set; }
        }



    }
}

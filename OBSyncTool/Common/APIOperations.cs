using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OBSyncTool.Common
{
    public class APIOperations
    {

        public static async Task<TResponse> PostAsync<TRequest, TResponse>(string apiPath, TRequest data, HttpClient _httpClient)
        {
            // Serialize the request data to JSON
            var jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Add authorization header

            // Post data to the API
            var response = await _httpClient.PostAsync(apiPath, content);

            // Handle response
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to post data to API. Status code: {response.StatusCode}, path: {apiPath}, data: {JsonConvert.SerializeObject(data)}");
            }
            else
            {
                if (response.Content != null)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var responseObject = JsonConvert.DeserializeObject<TResponse>(responseContent);
                        return responseObject;
                    }
                    catch (Exception)
                    {
                        return default(TResponse);
                        throw;
                    }
                }
            }
            // Deserialize the response JSON to the specified type

           
            return default(TResponse);
          
        }

        public static async Task<TResponse> PutAsync<TRequest, TResponse>(string apiPath, TRequest data, HttpClient _httpClient)
        {
            // Serialize the request data to JSON
            var jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Add authorization header

            // Post data to the API
            var response = await _httpClient.PutAsync(apiPath, content);

            // Handle response
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to put data to API. Status code: {response.StatusCode}, path: {apiPath}, data: {JsonConvert.SerializeObject(data)}");
            }
            else
            {
                // Deserialize the response JSON to the specified type

                if (response.Content != null)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var responseObject = JsonConvert.DeserializeObject<TResponse>(responseContent);
                        return responseObject;
                    }
                    catch (Exception)
                    {
                        return default(TResponse);
                        throw;
                    }
                }
            }
            return default(TResponse);

        }


        public static async Task<TResponse> GetAsync<TResponse>(string apiPath, HttpClient _httpClient)
        {

            // Perform GET request to the API
            var response = await _httpClient.GetAsync(apiPath);

            // Handle response
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to get data from API. Status code: {response.StatusCode}. Path: {apiPath}");
            }

            // Deserialize the response JSON to the specified type
            if (response.Content != null)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                try
                {
                    var responseObject = JsonConvert.DeserializeObject<TResponse>(responseContent);
                    return responseObject;
                }
                catch (Exception)
                {
                    return default(TResponse);
                    throw;
                }

             
            }
            return default(TResponse);
        }
    }
}

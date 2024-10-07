using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSyncTool.Busines.AMB.Model_
{
    public class Token
    {
        public static Token _instance;

        public TokenResponse TokenResponse { get; set; }

        public static string _apicredsPayLoad = @"{""username"":""ambapiusr"",""password"":""Th34AllmyB10!88""}";

        private Token()
        {
            Task.Run(() => this.Token2()).Wait();
        }

        private async Task Token2()
        {
            try
            {
                // Replace the API endpoint with your actual endpoint
                string apiUrl = API.apiurl + "token/generate.php";

                // Replace this with your JSON data that you want to post
                string jsonContent = _apicredsPayLoad;

                using (HttpClient client = new HttpClient())
                {
                    // Set the content type header to application/json
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Create a new StringContent object with the JSON data
                    var httpContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                    // Post the data to the API and get the response
                    HttpResponseMessage response = await client.PostAsync(apiUrl, httpContent);

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        string resStr = await response.Content.ReadAsStringAsync();
                        var stream = await response.Content.ReadAsStreamAsync();

                        this.TokenResponse = await System.Text.Json.JsonSerializer.DeserializeAsync<TokenResponse>(stream);

                        Console.WriteLine("Data posted successfully");
                    }
                    else
                    {
                        Console.WriteLine("Failed to post data. Status code: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public static Token GetInstance()
        {
            // If the instance is null, create a new instance
            if (_instance == null)
            {
                _instance = new Token();
            }
            return _instance;
        }

    }

    public class TokenResponse
    {
        public string status { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public Document document { get; set; }
    }

    public class Document
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
    }

}

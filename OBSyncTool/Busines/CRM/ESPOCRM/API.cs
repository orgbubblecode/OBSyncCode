using OBSyncTool.Busines.AMB.Model_;
using OBSyncTool.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace OBSyncTool.Busines.CRM.ESPOCRM
{


    public class EntityToRelate
    {
        public string id { get; set; }
    }

    public class EspoCrmApi
    {
        private readonly string _apiUrl;
        private readonly string _apiKey;
        private APIClient _httpClientInstance;

        public EspoCrmApi()
        {
            _apiKey = "6537138c6f688bf2290449332e9a21ce";
            _apiUrl = "https://crm.orgbubble.com/";
            _httpClientInstance = APIClient.GetInstance();
            _httpClientInstance.DefaultRequestHeaders.Add("X-Api-Key", _apiKey);
        }



        private async Task<TResponse> PostAsync<TRequest, TResponse>(string apiPath, TRequest data)
        {
            return await APIOperations.PostAsync<TRequest, TResponse>(string.Concat(_apiUrl, apiPath), data, this._httpClientInstance);
        }

        private async Task<TResponse> PutAsync<TRequest, TResponse>(string apiPath, TRequest data)
        {
            return await APIOperations.PutAsync<TRequest, TResponse>(string.Concat(_apiUrl, apiPath), data, this._httpClientInstance);
        }
        private async Task<TResponse> GetAsync<TResponse>(string apiPath)
        {
            return await APIOperations.GetAsync<TResponse>(string.Concat(_apiUrl, apiPath), this._httpClientInstance);
        }



        public async Task<string> AddOrUpdateAccountAsync(Account account)
        {
            string endpoint = "api/v1/Account";
            string accountid = await OBSyncTool.Busines.CRM.ESPOCRM.DataAccess.GetAccountIDFromAccountName(account.name);
            //var espoAct = await GetAsync<Account>(endpoint + "/" + accountid);
            if (!string.IsNullOrEmpty(accountid))
            {
                await this.PutAsync<Account, string>(endpoint + "/" + accountid, account);
            }
            else
            {
                await this.PostAsync<Account, string>(endpoint, account);
                accountid = await OBSyncTool.Busines.CRM.ESPOCRM.DataAccess.GetAccountIDFromAccountName(account.name);
            }


            endpoint = $"api/v1/Account/{accountid}/contacts";
            var contactSearchResult = await GetAsync<ContactsSearchResult>(endpoint);

            var theContact = new Contact()
            {
                name = account.name + "CT",
                emailAddress = account.emailAddress,
                createdAt = account.createdAt,
                firstName = account.accountTitle,
                lastName = account.name + "CT",
            };


            if (contactSearchResult.total == 0)
            {


                //find
                endpoint = $"api/v1/Contact?where[0][type]=equals&where[0][attribute]=emailAddress&where[0][value]={account.emailAddress}";
                contactSearchResult = await GetAsync<ContactsSearchResult>(endpoint);


                if (contactSearchResult.total == 0)
                {
                    //add
                    endpoint = "api/v1/Contact";
                    await this.PostAsync<Contact, string>(endpoint, theContact);
                    Console.WriteLine($"Contact created {theContact.emailAddress}");

                    endpoint = $"api/v1/Contact?where[0][type]=equals&where[0][attribute]=emailAddress&where[0][value]={HttpUtility.UrlEncode(account.emailAddress)}";
                    contactSearchResult = await GetAsync<ContactsSearchResult>(endpoint);

                    var oRel = new EntityToRelate() { id = contactSearchResult.list[0].id };
                    endpoint = $"api/v1/Account/{accountid}/contacts";
                    await this.PostAsync<EntityToRelate, string>(endpoint, oRel);
                    Console.WriteLine($"Contact {theContact.emailAddress} related to {account.name}");


                }
                else
                {
                    var oRel = new EntityToRelate() { id = contactSearchResult.list[0].id };
                    endpoint = $"api/v1/Account/{accountid}/contacts";
                    await this.PostAsync<EntityToRelate, string>(endpoint, oRel);
                    Console.WriteLine($"Contact {theContact.emailAddress} related to {account.name}");
                }


            }
            else
            {
                //update
                var contactID = contactSearchResult.list[0].id;
                endpoint = $"api/v1/Contact/{contactID}";
                await this.PutAsync<Contact, string>(endpoint, theContact);
                Console.WriteLine($"Contact updated {theContact.emailAddress}");
            }



            return "";




            //using (HttpClient client = new HttpClient())
            //{
            //    try
            //    {

            //        var content = new StringContent(accountData, Encoding.UTF8, "application/json");
            //        HttpResponseMessage response = await client.PostAsync(endpoint, content);

            //        if (response.IsSuccessStatusCode)
            //        {
            //            return await response.Content.ReadAsStringAsync();
            //        }
            //        else
            //        {
            //            throw new Exception($"Failed to add/update account. Status code: {response.StatusCode}");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception($"An error occurred: {ex.Message}");
            //    }
            //}
        }

        // Additional method to update account if needed
        // public async Task<string> UpdateAccountAsync(string accountId, string updatedAccountData)
        // {
        //     // Implement update logic similar to AddOrUpdateAccountAsync
        // }
    }

}

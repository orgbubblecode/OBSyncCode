using ApiCallerApp;
using Newtonsoft.Json.Linq;
using OBSyncTool.Busines.CRM.ESPOCRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using static OBSyncTool.Busines.AMB.API;
using static OBSyncTool.Busines.AMB.Model_.User;

namespace OBSyncTool.Busines.AMB.Jobs
{
    public class EspoCRM
    {

        public static string apiUsr = "maincrmapiusr";
        public static string apiKey = "6537138c6f688bf2290449332e9a21ce";
        public static string crmUrl = "https://crm.orgbubble.com/";

       



        public async static Task<bool> SyncAMBAccounts()
        {

            //string apiUrl = string.Format("{0}api/v1/Accounts",crmUrl); // Replace this with your ESPOCRM API URL
            string configFilePath = "D:\\WebProjects\\orgbubble.com\\CODE\\OBSync\\OBSyncTool\\localconfigfile_incontact.json";
            AppConfig config = AppConfig.Load(configFilePath);



            int pageSize = 35;
            int startPage = 1;
            bool hasMoreData = true;
            var SearchParams = new SearhByColumnSearchArray[] { 
                new SearhByColumnSearchArray() { columnLogic = "=", columnName = "status", columnValue = "1" },
                new SearhByColumnSearchArray() { columnLogic = ">", columnName = "user_id", columnValue = config.LastAMBIDRead }
            };
            API _api = new OBSyncTool.Busines.AMB.API();
            EspoCrmApi espoCrmApi = new EspoCrmApi();
            string searchPath = "/users/search_by_column.php?orAnd=And&pageno={0}&pagesize={1}";


            while (hasMoreData)
            {

                var path = string.Format(searchPath, startPage, pageSize);

                UserRootObject users = await _api.PostAsync<SearhByColumnSearchArray[], UserRootObject>(path, SearchParams); 

                if (users != null && users.status == "success" && users.message == "users found")
                {
                    startPage++;

                    var tasks = new List<Task>();
                    foreach (var user in users.document.records)
                    {

                        if (OBSyncTool.Common.Utilities.IsValidEmail(user.email))
                        {
                            string accountName = "AMB" + int.Parse(user.user_id).ToString("00000000");

                            var espoAcc = new OBSyncTool.Busines.CRM.ESPOCRM.Account()
                            {
                                name = accountName,
                                accountSystem = "AMB",
                                accountTitle = user.name,
                                emailAddress = user.email,
                                createdAt = user.datetime,
                                type = "Customer"
                            };


                            try
                            {
                                //await espoCrmApi.AddOrUpdateAccountAsync(espoAcc);
                                tasks.Add(Task.Run(() => espoCrmApi.AddOrUpdateAccountAsync(espoAcc)));


                                Console.WriteLine(accountName);
                            }
                            catch (Exception e)
                            {

                                Console.WriteLine(e.Message);
                            }


                            config.LastAMBIDRead = int.Parse(user.user_id);
                            config.LastTimeUpdated = DateTime.Now;
                            config.Save(configFilePath);


                        }
                        else
                        {
                            Console.WriteLine($"Invalid email {user.email}");
                        }

                    }


                    await Task.WhenAll(tasks);



                }
                else
                {
                    hasMoreData = false;
                }

            }

                return true;


        }

    }
}

using Newtonsoft.Json;
using OBSyncTool.Busines.AMB;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static OBSyncTool.Busines.AMB.Model_.User;

namespace ApiCallerApp
{
    class Program
    {
     

        static async Task Main(string[] args)
        {

           
            // Load configuration
          
            await OBSyncTool.Busines.AMB.Jobs.EspoCRM.SyncAMBAccounts();

            var t = 1;

        }
    }


    public class AppConfig
    {
        public int LastAMBIDRead { get; set; }
        public DateTime LastTimeUpdated { get; set; }

        // Default constructor
        public AppConfig()
        {
            LastAMBIDRead = 0;
            LastTimeUpdated = DateTime.MinValue;
        }

        // Load configuration from file
        public static AppConfig Load(string filePath)
        {
            if (!File.Exists(filePath))
                return new AppConfig();

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<AppConfig>(json);
        }

        // Save configuration to file
        public void Save(string filePath)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(filePath, json);
        }
    }

}

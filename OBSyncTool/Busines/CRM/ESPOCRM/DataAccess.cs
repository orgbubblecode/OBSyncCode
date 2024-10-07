using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace OBSyncTool.Busines.CRM.ESPOCRM
{
    public class DataAccess
    {

        public static async Task<string> GetAccountIDFromAccountName(string accountName)
        {
            string query = $"SELECT * FROM crm_orgbubble.account where name = '{accountName}'";
            string columnName = "id";
            return await GetSingleValueFromDB(query, columnName);

        }




        public static async Task<string> GetSingleValueFromDB(string query,string columnName)
        {
            string server = "obdevtoolsl4";
            string database = "crm_orgbubble";
            string username = "crm_orgbubble";
            string password = "MBkkp8LXcdySNc2C";
            string result = null;
            var connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
            //string columnName = "id";

            

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create command
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Execute the query and retrieve the result
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if there are any rows
                        {
                            // Retrieve the value from the specified column
                            result = reader[columnName].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return result;
        }


    }
}

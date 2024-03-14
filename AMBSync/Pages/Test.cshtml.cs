using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace AMBSync.Pages
{
    public class TestModel : PageModel
    {
        public void OnGet()
        {
            TestMySQLConn();
        }


        public void TestMySQLConn()
        {


            var sshServer = "209.59.181.201";
            var sshUserName = "root";
            var sshPassword = "Mzjj0)ffsd9moP";
            var databaseServer = "209.59.181.201";
            var databaseUserName = "allmy_usr_r";
            var databasePassword = "6HYhnReaderSfjRlfx";

            var (sshClient, localPort) = AMBSync.Classes.MySQLConn.ConnectSsh(sshServer, sshUserName, sshPassword, databaseServer: databaseServer);
            using (sshClient)
            {
                MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder
                {
                    Server = "127.0.0.1",
                    Port = localPort,
                    UserID = databaseUserName,
                    Password = databasePassword,
                };

                var connection = new MySqlConnection(csb.ConnectionString);
                connection.Open();
            }

        }

    }
}
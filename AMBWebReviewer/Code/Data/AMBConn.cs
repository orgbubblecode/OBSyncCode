using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AMBReviewerData
{
    class AMBConn
    {

        const string server = "209.59.181.201";
        const string sshUserName = "root";
        const string sshPassword = "Mzjj0)ffsd9moP";
        //var databaseServer = "209.59.181.201";
        const string databaseUserName = "allmy_usr";
        const string databasePassword = "6HYhnSfjRlfx";


        public static (SshClient SshClient, uint Port) ConnectSsh(string sshHostName, string sshUserName, string sshPassword = null,
    string sshKeyFile = null, string sshPassPhrase = null, int sshPort = 22, string databaseServer = "localhost", int databasePort = 3306)
        {
            // check arguments
            if (string.IsNullOrEmpty(sshHostName))
                throw new ArgumentException($"{nameof(sshHostName)} must be specified.", nameof(sshHostName));
            if (string.IsNullOrEmpty(sshHostName))
                throw new ArgumentException($"{nameof(sshUserName)} must be specified.", nameof(sshUserName));
            if (string.IsNullOrEmpty(sshPassword) && string.IsNullOrEmpty(sshKeyFile))
                throw new ArgumentException($"One of {nameof(sshPassword)} and {nameof(sshKeyFile)} must be specified.");
            if (string.IsNullOrEmpty(databaseServer))
                throw new ArgumentException($"{nameof(databaseServer)} must be specified.", nameof(databaseServer));

            // define the authentication methods to use (in order)
            var authenticationMethods = new List<AuthenticationMethod>();
            if (!string.IsNullOrEmpty(sshKeyFile))
            {
                authenticationMethods.Add(new PrivateKeyAuthenticationMethod(sshUserName,
                    new PrivateKeyFile(sshKeyFile, string.IsNullOrEmpty(sshPassPhrase) ? null : sshPassPhrase)));
            }
            if (!string.IsNullOrEmpty(sshPassword))
            {
                authenticationMethods.Add(new PasswordAuthenticationMethod(sshUserName, sshPassword));
            }

            // connect to the SSH server
            var sshClient = new SshClient(new ConnectionInfo(sshHostName, sshPort, sshUserName, authenticationMethods.ToArray()));
            sshClient.Connect();

            // forward a local port to the database server and port, using the SSH server
            var forwardedPort = new ForwardedPortLocal("127.0.0.1", databaseServer, (uint)databasePort);
            sshClient.AddForwardedPort(forwardedPort);
            forwardedPort.Start();

            return (sshClient, forwardedPort.BoundPort);
        }

        public static DataTable GetData(string SQL)
        {
            var (sshClient, localPort) = AMBConn.ConnectSsh(server, sshUserName, sshPassword);
            var dataTable = new DataTable();
            using (sshClient)
            {
                MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder
                {
                    Server = "127.0.0.1",
                    Port = localPort,
                    UserID = databaseUserName,
                    Password = databasePassword,
                    Database = "allmy_db",
                };

                using var connection = new MySqlConnection(csb.ConnectionString);
                {
                    connection.Open();
                    MySqlCommand cmdData = new MySqlCommand(SQL, connection);
                    MySqlDataReader rdrData = cmdData.ExecuteReader();
                    dataTable.Load(rdrData);
                }

            }
            return dataTable;

        }

        public static void ExecuteSQL(string SQL)
        {


            var (sshClient, localPort) = AMBConn.ConnectSsh(server, sshUserName, sshPassword);
            var dataTable = new DataTable();
            using (sshClient)
            {
                MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder
                {
                    Server = "127.0.0.1",
                    Port = localPort,
                    UserID = databaseUserName,
                    Password = databasePassword,
                    Database = "allmy_db",
                };

                using var connection = new MySqlConnection(csb.ConnectionString);
                {
                    connection.Open();
                    MySqlCommand cmdData = new MySqlCommand(SQL, connection);
                    cmdData.ExecuteNonQuery();
                }

            }
            


        }


        public static void DoJob()
        {




            var (sshClient, localPort) = AMBConn.ConnectSsh(server, sshUserName, sshPassword);
            using (sshClient)
            {
                MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder
                {
                    Server = "127.0.0.1",
                    Port = localPort,
                    UserID = databaseUserName,
                    Password = databasePassword,
                    Database = "allmy_db",
                };

                using var connection = new MySqlConnection(csb.ConnectionString);
                {

                    connection.Open();


                    string sqlPlans = "SELECT * FROM plans";
                    MySqlCommand cmdPlans = new MySqlCommand(sqlPlans, connection);

                    MySqlDataReader rdrPlans = cmdPlans.ExecuteReader();


                    while (rdrPlans.Read())
                    {
                        //Console.WriteLine("{0} {1} {2}", rdr.GetInt32(0), rdr.GetString(1),
                        //        rdr.GetString(3));


                        int planID = rdrPlans.GetInt32(0);
                        string sqlUsers = string.Format("select * from users where plan_id = '{0}'", planID.ToString());


                        MySqlCommand cmdUsers = new MySqlCommand(sqlUsers, connection);

                        MySqlDataReader rdrUsers = cmdUsers.ExecuteReader();


                        while (rdrPlans.Read())
                        {



                        }


                    }



                }





            }


        }

    }
}

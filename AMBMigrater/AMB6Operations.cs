extern alias MySqlConnectorAlias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMBMigrater;
using MySql.Data.MySqlClient;

namespace AMBMigrater
{
    class AMB6Operations
    {



        //       select*
        // from information_schema.columns
        //where table_schema = 'base_script_allmy_bio' 
        //  and table_name = 'users'




        //static private AMBDataSources.AMB4.AMB4Entities.AMB4EntitiesContext AMB4Source = new AMBDataSources.AMB4.AMB4Entities.AMB4EntitiesContext();
        static private AMBMigrater.AMBDataSources.AMB6.AMB6Entities AMB6Source = new AMBMigrater.AMBDataSources.AMB6.AMB6Entities();



        public static void MigrateUsers(int Limit = 0)
        {

            DataTable AMB4Users = AMB6Operations.AMB4SelectAllFrom("users", Limit);

            Wrt(string.Concat(AMB4Users.Rows.Count, " users found in AMB4!"));

            foreach (DataRow AMB4UserRow in AMB4Users.Rows)
            {

                try
                {



                    using (var AMB6 = new AMBMigrater.AMBDataSources.AMB6.AMB6Entities())
                    {

                        var user6 = new AMBDataSources.AMB6.user();


                        user6.email = AMB4UserRow["email"].ToString();
                        user6.password = AMB4UserRow["password"].ToString();
                        user6.name = AMB4UserRow["name"].ToString();
                        user6.api_key = ""; //AMB4UserRow["api_key"].ToString();
                        user6.billing = ""; //AMB4UserRow["billing"].ToString();
                        user6.token_code = AMB4UserRow["token_code"].ToString();
                        user6.twofa_secret = AMB4UserRow["twofa_secret"].ToString();
                        user6.pending_email = ""; //AMB4UserRow["pending_email"].ToString();
                        user6.email_activation_code = AMB4UserRow["email_activation_code"].ToString();
                        user6.lost_password_code = AMB4UserRow["lost_password_code"].ToString();
                        user6.facebook_id = !DBNull.Value.Equals(AMB4UserRow["facebook_id"]) ? long.Parse(AMB4UserRow["facebook_id"].ToString()) : (long?)null;
                        user6.type = int.Parse(AMB4UserRow["type"].ToString());
                        user6.active = int.Parse(AMB4UserRow["active"].ToString());
                        user6.plan_id = ""; //AMB4UserRow["plan_id"].ToString();
                        user6.plan_expiration_date = new DateTime(1900, 1, 1); // AMB4UserRow["plan_expiration_date"].ToString();
                        user6.plan_settings = ""; //AMB4UserRow["plan_settings"].ToString();
                        user6.plan_trial_done = 0; // AMB4UserRow["plan_trial_done"].ToString();
                        user6.payment_subscription_id = AMB4UserRow["payment_subscription_id"].ToString();
                        user6.language = AMB4UserRow["language"].ToString();
                        user6.timezone = AMB4UserRow["timezone"].ToString();
                        user6.date = DateTime.Parse(AMB4UserRow["date"].ToString());
                        user6.ip = AMB4UserRow["ip"].ToString();
                        user6.country = AMB4UserRow["country"].ToString();
                        user6.last_activity = !DBNull.Value.Equals(AMB4UserRow["last_activity"]) ? DateTime.Parse(AMB4UserRow["last_activity"].ToString()) : (DateTime?)null;
                        user6.last_user_agent = AMB4UserRow["last_user_agent"].ToString();
                        user6.total_logins = int.Parse(AMB4UserRow["total_logins"].ToString());

                        AMB6.users.Add(user6);
                        AMB6.Entry(user6).State = System.Data.Entity.EntityState.Added;
                        AMB6.SaveChanges();
                        AMB6.Entry(user6).State = System.Data.Entity.EntityState.Detached;

                        MapInstance(int.Parse(AMB4UserRow["user_id"].ToString()),
                                              user6.user_id,
                                              "user");

                        Wrt(string.Concat(user6.email, " added!"));








                    }


                }
                catch (Exception ex)
                {
                    WrtEr(ex.Message);
                    throw;
                }




            }

            Wrt(string.Concat("All users added!"));


            Wrt("Execute api_key all users");
            ExecuteNonQuery("UPDATE users SET api_key = concat(    lpad(conv(floor(rand()*pow(36,8)), 10, 36), 8, 0),    lpad(conv(floor(rand()*pow(36,8)), 10, 36), 8, 0),    lpad(conv(floor(rand()*pow(36,8)), 10, 36), 8, 0),    lpad(conv(floor(rand()*pow(36,8)), 10, 36), 8, 0));");


            Wrt("Execute delete all track_links");
            ExecuteNonQuery("DELETE FROM track_links WHERE user_id IS NULL OR user_id = '';");


            Wrt("Execute update track_links");
            ExecuteNonQuery("UPDATE track_links LEFT JOIN `projects` ON `track_links`.`project_id` = `projects`.`project_id` SET `track_links`.`user_id` = `projects`.`user_id`;");




        }


        public static void MigratePlansAKAPackages(int Limit = 0)
        {




            DataTable AMB4Package = AMB6Operations.AMB4SelectAllFrom("packages", Limit);

            Wrt(string.Concat(AMB4Package.Rows.Count, " packages found in AMB4!"));

            try
            {
                          


            foreach (DataRow AMB4PackRow in AMB4Package.Rows)
            {

                using (var AMB6 = new AMBMigrater.AMBDataSources.AMB6.AMB6Entities())
                {

                    var plan6 = new AMBDataSources.AMB6.plan();


                    plan6.name = AMB4PackRow["name"].ToString();
                    plan6.monthly_price = float.Parse(AMB4PackRow["monthly_price"].ToString());
                    plan6.annual_price = float.Parse(AMB4PackRow["annual_price"].ToString());
                    plan6.settings = AMB4PackRow["settings"].ToString();
                    plan6.status = SByte.Parse(AMB4PackRow["is_enabled"].ToString());
                    plan6.date = DateTime.Parse(AMB4PackRow["date"].ToString());
                    plan6.taxes_ids = "";


                    AMB6.plans.Add(plan6);
                    AMB6.Entry(plan6).State = System.Data.Entity.EntityState.Added;
                    AMB6.SaveChanges();
                    AMB6.Entry(plan6).State = System.Data.Entity.EntityState.Detached;

                    MapInstance(int.Parse(AMB4PackRow["package_id"].ToString()), 
                                plan6.plan_id, 
                                "plan-package");

                    Wrt(string.Concat(plan6.name, " plan added!"));
                }


            }



            }
            catch (Exception ex)
            {
                WrtEr(ex.Message);
                throw;
            }




        }


        public static void ProcessUserData()
        {

            List<AMBDataSources.AMB6.user> A6Users;
            using (var AMB6 = new AMBMigrater.AMBDataSources.AMB6.AMB6Entities())
            {
                A6Users = AMB6.users.Where(w => w.user_id > 1).ToList();
           
                
                if (A6Users != null)
            {

                foreach (var A6User in A6Users)
                {


                    var OldUserID = GetOldUserID(A6User.user_id);
                    /* Order or Data
                      - Domains
                      - UserLogs
                      - Projects 
                            - Links
                      */

                    #region Domains
                    DataTable Domains = GetUserDataFromOldDB(A6User.user_id, "domains");
                    if (Domains != null)
                    {
                        foreach (DataRow oldDomain in Domains.Rows)
                        {
                            var domain6 = new AMBDataSources.AMB6.domain();
                            domain6.user_id = A6User.user_id;

                            domain6.scheme = oldDomain["scheme"].ToString();
                            domain6.host  = oldDomain["host"].ToString();
                            domain6.custom_index_url = oldDomain["custom_index_url"].ToString();
                            domain6.type  =  sbyte.Parse(oldDomain["type"].ToString());
                            domain6.is_enabled = sbyte.Parse(oldDomain["is_enabled"].ToString());
                            domain6.date = DateTime.Parse (oldDomain["date"].ToString());
                            AMB6.domains.Add(domain6);
                            AMB6.Entry(domain6).State = System.Data.Entity.EntityState.Added;
                            AMB6.SaveChanges();
                            AMB6.Entry(domain6).State = System.Data.Entity.EntityState.Detached;
                            Wrt(string.Concat("Host ",domain6.host, " added for ", A6User.email.ToString()));
                        }

                    }
                        #endregion


                        #region UserLogs
                        DataTable UserLogs = GetUserDataFromOldDB(A6User.user_id, "users_logs");

                        //=================================
                        //AMB6.users_logs.RemoveRange(AMB6.users_logs.Where(w => w.user_id == A6User.user_id));
                        //AMB6.SaveChanges();
                        //=================================


                        if (UserLogs != null)
                        {
                            foreach (DataRow oldUserLogs in UserLogs.Rows)
                            {
                                var users_logs6 = new AMBDataSources.AMB6.users_logs();

                                users_logs6.user_id = A6User.user_id;

                                users_logs6.type = oldUserLogs["type"].ToString();
                                users_logs6.date = DateTime.Parse (oldUserLogs["date"].ToString());
                                users_logs6.ip = oldUserLogs["ip"].ToString();
                                users_logs6.@public = int.Parse (oldUserLogs["public"].ToString());

                                AMB6.users_logs.Add(users_logs6);
                                AMB6.Entry(users_logs6).State = System.Data.Entity.EntityState.Added;
                                AMB6.SaveChanges();
                                AMB6.Entry(users_logs6).State = System.Data.Entity.EntityState.Detached;
                                Wrt(string.Concat("UserLog ", users_logs6.type, " added for ", A6User.email.ToString()));
                            }
                        }
                        #endregion



                        #region ProjectsAndLinks
                        DataTable Projects = GetUserDataFromOldDB(A6User.user_id, "projects");
                        //=================================
                        //AMB6.track_links.RemoveRange(AMB6.track_links.Where(w => w.user_id == A6User.user_id));
                        //AMB6.links.RemoveRange(AMB6.links.Where(w => w.user_id == A6User.user_id));
                        //AMB6.projects.RemoveRange(AMB6.projects.Where(w => w.user_id == A6User.user_id));
                        //AMB6.SaveChanges();
                        //=================================

                        if (Projects != null)
                        {
                            foreach (DataRow oldProjects in Projects.Rows)
                            {

                                var project6 = new AMBDataSources.AMB6.project();

                                project6.user_id = A6User.user_id;
                                project6.name = oldProjects["name"].ToString();
                                project6.date = DateTime.Parse (oldProjects["date"].ToString());

                                AMB6.projects.Add(project6);
                                AMB6.Entry(project6).State = System.Data.Entity.EntityState.Added;
                                AMB6.SaveChanges();
                                AMB6.Entry(project6).State = System.Data.Entity.EntityState.Detached;
                                Wrt(string.Concat("Projects ", project6.name, " added for ", A6User.email.ToString()));
                                //Ger Project Links:

                                DataTable UserLinks = AMB4SelectAllFrom("links", 
                                                                              0, 
                                                                              string.Format(" where project_id = {0} ", oldProjects["project_id"].ToString()),
                                                                              "order by link_id");

                                if (UserLinks != null)
                                {
                                    foreach (DataRow oldUserLink in UserLinks.Rows)
                                    {
                                        var link6 = new AMBDataSources.AMB6.link();

                                        link6.user_id = A6User.user_id;
                                        link6.project_id = project6.project_id;

                                        //----------------------------

                                        //if (oldUserLink["biolink_id"] == null || string.IsNullOrEmpty(oldUserLink["biolink_id"].ToString()))
                                        //{
                                        //    link6.biolink_id = null;
                                        //}
                                        //else
                                        //{
                                        //    int bid = int.Parse(oldUserLink["biolink_id"].ToString());

                                        //    DataTable parent = AMB4SelectAllFrom("links", 0, 
                                        //       String.Format(" where link_id={0} ", bid.ToString()));
                                        //    if (parent != null)
                                        //    {
                                        //        string strUrl = parent.Rows[0]["url"].ToString();
                                        //        AMBDataSources.AMB6.link LinkParentA6 = AMB6.links.Where(u => u.url == strUrl).FirstOrDefault();
                                        //        link6.biolink_id = LinkParentA6.link_id;
                                        //    }

                                        //}
                                        link6.biolink_id = null;
                                        //----------------------------

                                        link6.domain_id = 0;
                                        link6.type = oldUserLink["type"].ToString();
                                        link6.subtype = oldUserLink["subtype"].ToString();
                                        link6.url = oldUserLink["url"].ToString();
                                        link6.location_url = oldUserLink["location_url"].ToString();
                                        link6.clicks = int.Parse(oldUserLink["clicks"].ToString());
                                        link6.settings = oldUserLink["settings"].ToString();
                                        link6.order = int.Parse(oldUserLink["order"].ToString());
                                        link6.start_date = !DBNull.Value.Equals(oldUserLink["start_date"]) ? DateTime.Parse(oldUserLink["start_date"].ToString()) : (DateTime?)null;
                                        link6.end_date = !DBNull.Value.Equals(oldUserLink["end_date"]) ? DateTime.Parse(oldUserLink["end_date"].ToString()) : (DateTime?)null;
                                        link6.is_enabled = sbyte.Parse(oldUserLink["is_enabled"].ToString());
                                        link6.date = DateTime.Parse(oldUserLink["date"].ToString());

                                        AMB6.links.Add(link6);
                                        AMB6.Entry(link6).State = System.Data.Entity.EntityState.Added;
                                        AMB6.SaveChanges();
                                        AMB6.Entry(link6).State = System.Data.Entity.EntityState.Detached;
                                        Wrt(string.Concat("Projects ", project6.name, " added for ", A6User.email.ToString()));

                                        MapInstance(int.Parse(oldUserLink["link_id"].ToString()),
                                             link6.link_id,
                                             "link");


                                        DataTable UserTrackLinks = AMB4SelectAllFrom("track_links", 0, string.Format(" where link_id = {0} ", oldUserLink["link_id"].ToString()));

                                        if (UserTrackLinks != null)
                                        {

                                            foreach (DataRow oldUserTrackLink in UserTrackLinks.Rows)
                                            {

                                                var track_link6 = new AMBDataSources.AMB6.track_links();

                                                track_link6.user_id = A6User.user_id;
                                                track_link6.project_id = project6.project_id;
                                                track_link6.link_id = link6.link_id;

                                                track_link6.dynamic_id = oldUserTrackLink["dynamic_id"].ToString();
                                                track_link6.ip = oldUserTrackLink["ip"].ToString();

                                                track_link6.country_code = !DBNull.Value.Equals(oldUserTrackLink["country_code"]) ? oldUserTrackLink["country_code"].ToString() : (string)null;
                                                track_link6.os_name = !DBNull.Value.Equals(oldUserTrackLink["os_name"]) ? oldUserTrackLink["os_name"].ToString() : (string)null;
                                                track_link6.browser_name = !DBNull.Value.Equals(oldUserTrackLink["browser_name"]) ? oldUserTrackLink["browser_name"].ToString() : (string)null;
                                                track_link6.referrer = !DBNull.Value.Equals(oldUserTrackLink["referrer"]) ? oldUserTrackLink["referrer"].ToString() : (string)null;
                                                track_link6.device_type = !DBNull.Value.Equals(oldUserTrackLink["device_type"]) ? oldUserTrackLink["device_type"].ToString() : (string)null;
                                                track_link6.browser_language = !DBNull.Value.Equals(oldUserTrackLink["browser_language"]) ? oldUserTrackLink["browser_language"].ToString() : (string)null;

                                                track_link6.count = int.Parse(oldUserTrackLink["count"].ToString());
                                                track_link6.date =  DateTime.Parse(oldUserTrackLink["date"].ToString());
                                                track_link6.last_date = DateTime.Parse(oldUserTrackLink["last_date"].ToString());
                                                
                                                AMB6.track_links.Add(track_link6);
                                                AMB6.Entry(track_link6).State = System.Data.Entity.EntityState.Added;
                                                AMB6.SaveChanges();
                                                AMB6.Entry(track_link6).State = System.Data.Entity.EntityState.Detached;
                                                Wrt(string.Concat("LinkTracks ", track_link6.dynamic_id, " added for ", A6User.email.ToString()));

                                                MapInstance(int.Parse(oldUserTrackLink["id"].ToString()),
                                                     track_link6.id,
                                                     "track_link");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                    }
            }



            }



        }


        public static int GetOldUserID(int NewUserID)
        {

            try
            {
             return int.Parse(AMB6SelectAllFrom("_migmapper",
                                          1,
                                          String.Format(" where newID = {0} and recordtype = 'user'", NewUserID)
                                          ).Rows[0]["oldID"].ToString());
            }
            catch (Exception)
            {
                WrtEr(string.Format("Error in GetOldUserID, NewUserID {0}", NewUserID.ToString()));
                return 0;
                throw;
            }
        }

        public static DataTable GetUserDataFromOldDB(int NewUserID, string oldTableName) 
        {


            try
            {
                var OldUserID = GetOldUserID(NewUserID);

                if (OldUserID == 0)
                    return null;
                
                DataTable thisdata = AMB4SelectAllFrom(oldTableName, 0, String.Format(" where user_id={0}", OldUserID));
                return thisdata;

            }
            catch (Exception ex)
            {
                WrtEr(String.Format("Getting old data from {0} for NewUserID {1} throw error {2}", oldTableName, NewUserID.ToString(), ex.Message));
                throw;
            }
        


            /*
             - Domains
             - UserLogs

             */


        }

        public static void MapInstance(int OldID, int NewID, string Type)
        {

            string insert = String.Format( "INSERT INTO `_migmapper` ( `oldID`,`newID`,`recordtype`) VALUES ({0},{1},'{2}');", OldID, NewID, Type);
            ExecuteNonQuery(insert);
            Wrt(string.Format("Mapping Old:{0} | New:{1} | Type {2}", OldID, NewID, Type));


        }


        public static void RestorAllTables()
        {

            string sqlRestore = System.IO.File.ReadAllText(@"D:\WebProjects\orgbubble.com\CODE\OBSync\AMBMigrater\Scripts\base_script_allmy_bio.sql");

            try
            {
                Wrt("Droping before Restoring");
                DropTables();
                Wrt("All droped!");
                Wrt("Start Restoring");
                ExecuteNonQuery(sqlRestore);
                Wrt("RB Restored");

            }
            catch (Exception ex)
            {
                WrtEr(ex.Message);
                throw;
            }



        }

        public static void DropTables(string connStr ="")
        {

            try
            {

                var strDrop = "SET FOREIGN_KEY_CHECKS = 0; DROP TABLE IF EXISTS `users_logs`; DROP TABLE IF EXISTS `codes`; DROP TABLE IF EXISTS `domains`; DROP TABLE IF EXISTS `links`; DROP TABLE IF EXISTS `pages`; DROP TABLE IF EXISTS `pages_categories`; DROP TABLE IF EXISTS `payments`; DROP TABLE IF EXISTS `plans`; DROP TABLE IF EXISTS `projects`; DROP TABLE IF EXISTS `redeemed_codes`; DROP TABLE IF EXISTS `settings`; DROP TABLE IF EXISTS `taxes`; DROP TABLE IF EXISTS `track_links`; DROP TABLE IF EXISTS `users`;  SET FOREIGN_KEY_CHECKS = 1; TRUNCATE TABLE _migmapper;";

                Wrt("Start DropTables");
                ExecuteNonQuery(strDrop, connStr);
                Wrt("DropTables completed");
                              
            }
            catch (Exception ex)
            {
                WrtEr(ex.Message);
                throw;
            }
            

        }

        public static DataTable AMB4SelectAllFrom(string TableName, int Limit = 0, string where = "", string order="")
        {


            DataTable _dataTable = new DataTable();
            string command = "";
            try
            {

        
                string conString = System.Configuration.ConfigurationManager.ConnectionStrings["AMB4client"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    string strLimit = "";
                    if (Limit > 0)
                    {
                        strLimit = string.Format("LIMIT {0}", Limit.ToString());
                    }

                    using (MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM {0} {2} {1} {3}", TableName, strLimit, where, order), con))
                    {
                        cmd.CommandType = CommandType.Text;
                        command = cmd.CommandText;
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                _dataTable = dt;
                            }
                        }
                        Wrt(string.Format("SQL AMB4: {0} - Records: {1}", cmd.CommandText, _dataTable.Rows.Count.ToString()));
                    }
                }


                return _dataTable;

            }
            catch (Exception ex)
            {
                WrtEr(string.Concat(ex.Message , " Table:" , TableName, " Q: ", command));
                return null;
                throw;
            }
            
        }


        public static DataTable AMB6SelectAllFrom(string TableName, int Limit = 0, string where = "")
        {


            DataTable _dataTable = new DataTable();

            try
            {


                string conString = System.Configuration.ConfigurationManager.ConnectionStrings["AMB6client"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM {0} {2} LIMIT {1}", TableName, Limit, where), con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                _dataTable = dt;
                            }
                        }
                    }
                }


                return _dataTable;

            }
            catch (Exception ex)
            {
                WrtEr(ex.Message);
                return null;
                throw;
            }

        }


        private static void ExecuteNonQuery(string query, string ConnStr = "")
        {

            try
            {

                Wrt("Executing ExecuteNonQuery");
                var connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["AMB6client"].ConnectionString;
                if (!string.IsNullOrEmpty(connectionStr))
                {
                    connectionStr = ConnStr;
                }
                MySql.Data.MySqlClient.MySqlConnection mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionStr);
                
                MySqlCommand myCommand = new MySqlCommand(query, mySqlConnection);
                myCommand.CommandTimeout = 600;
                myCommand.Connection.Open();
                myCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                Wrt("ExecuteNonQuery Commplete");

            }
            catch (Exception ex)
            {
                WrtEr(ex.Message);
                throw;
            }

        }
        
        public static void Wrt(string msg)
        {
            Console.WriteLine(string.Concat(DateTime.Now.ToString(), " INFO ", msg));
            
        }
        
        public static void WrtEr(string msg)
        {
            Console.WriteLine(string.Concat(DateTime.Now.ToString(), " ERRO ", msg));
            
        }





        public static void Restore_dev_allmy_bio()
        {

            var dev_allmy_bio = System.Configuration.ConfigurationManager.ConnectionStrings["AMB4dev_allmy_bio"].ConnectionString;
            var strDrop = "SET FOREIGN_KEY_CHECKS = 0; DROP TABLE IF EXISTS `users_logs`; DROP TABLE IF EXISTS `codes`; DROP TABLE IF EXISTS `domains`; DROP TABLE IF EXISTS `links`; DROP TABLE IF EXISTS `pages`; DROP TABLE IF EXISTS `pages_categories`; DROP TABLE IF EXISTS `payments`; DROP TABLE IF EXISTS `plans`; DROP TABLE IF EXISTS `projects`; DROP TABLE IF EXISTS `redeemed_codes`; DROP TABLE IF EXISTS `settings`; DROP TABLE IF EXISTS `taxes`; DROP TABLE IF EXISTS `track_links`; DROP TABLE IF EXISTS `users`;  SET FOREIGN_KEY_CHECKS = 1;";
            Wrt("droping all from dev_allmy_bio");
            ExecuteNonQuery(strDrop, dev_allmy_bio);
            string sqlRestore = System.IO.File.ReadAllText(@"D:\WebProjects\allmy.bio\CODE\allmy_db_704.sql");
            Wrt("Start Restoring");
            ExecuteNonQuery(sqlRestore, dev_allmy_bio);
            Wrt("RB Restored");


        }


    }
}

using OBSync.Models.OBDataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace OBSync.Models.Helpers
{


    public class CommunicationSubscriptions
    {

        static private OBSyncOLTP OBSyncDB = new OBSyncOLTP();

        //    The intention of this class is to keep our newsletters service 
        //    asd asdas
        //    OBAPIEntitiesTracker: It helps to keep the a track and association of entities accross the multiple services.


        //MailChimp
        //Username: orgbubble
        //Password: M4i1chimP4$$77
        //Get API Keys: https://mailchimp.com/help/about-api-keys/
        //Single method to execute and update all contacts or 2 methods for each service (OB/AMB).
        //Active users. 







        public static bool MarkAsSynced(string EmailAddress, OBAPIEnumEntityType UserType)
        {


            try
            {
                OBAPIEntitiesTracker oMailChimpTracker = new OBAPIEntitiesTracker();
                oMailChimpTracker.OBAPIEntityID = EmailAddress;
                oMailChimpTracker.OBAPIEntityTypeID = (int)UserType;

                OBSyncDB.OBAPIEntitiesTrackers.Add(oMailChimpTracker);

                OBSyncDB.Entry(oMailChimpTracker).State = System.Data.Entity.EntityState.Added;
                OBSyncDB.SaveChanges();
                OBSyncDB.Entry(oMailChimpTracker).State = System.Data.Entity.EntityState.Detached;

                return true;
            }
            catch (Exception)
            {

                return false;
            }

            

        }

        

        //public static bool CheckIFSynced(string EmailAddress, OBAPIEnumEntityType UserType)
        //{




        //}






        }
}
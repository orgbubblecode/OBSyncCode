using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSyncTool.Busines.AMB.Model_
{
    public class User
    {

        public class UserRootObject
        {
            public string status { get; set; }
            public int code { get; set; }
            public string message { get; set; }
            public Document document { get; set; }
        }

        public class Document
        {
            public string pageno { get; set; }
            public string pagesize { get; set; }
            public string total_count { get; set; }
            public Record[] records { get; set; }
        }

        public class Record
        {
            public string user_id { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string name { get; set; }
            public string billing { get; set; }
            public string api_key { get; set; }
            public string token_code { get; set; }
            public object twofa_secret { get; set; }
            public object anti_phishing_code { get; set; }
            public object one_time_login_code { get; set; }
            public string pending_email { get; set; }
            public string email_activation_code { get; set; }
            public string lost_password_code { get; set; }
            public string type { get; set; }
            public string status { get; set; }
            public string is_newsletter_subscribed { get; set; }
            public string has_pending_internal_notifications { get; set; }
            public string plan_id { get; set; }
            public string plan_expiration_date { get; set; }
            public string plan_settings { get; set; }
            public string plan_trial_done { get; set; }
            public string plan_expiry_reminder { get; set; }
            public string payment_subscription_id { get; set; }
            public object payment_processor { get; set; }
            public object payment_total_amount { get; set; }
            public object payment_currency { get; set; }
            public string referral_key { get; set; }
            public object referred_by { get; set; }
            public string referred_by_has_converted { get; set; }
            public string language { get; set; }
            public string timezone { get; set; }
            public object preferences { get; set; }
            public string datetime { get; set; }
            public string ip { get; set; }
            public string continent_code { get; set; }
            public string country { get; set; }
            public string city_name { get; set; }
            public string device_type { get; set; }
            public string browser_language { get; set; }
            public string browser_name { get; set; }
            public string os_name { get; set; }
            public string last_activity { get; set; }
            public string total_logins { get; set; }
            public string user_deletion_reminder { get; set; }
            public string source { get; set; }
            public string aix_transcriptions_current_month { get; set; }
            public string aix_images_current_month { get; set; }
            public string aix_words_current_month { get; set; }
            public string aix_documents_current_month { get; set; }
        }







    }
}

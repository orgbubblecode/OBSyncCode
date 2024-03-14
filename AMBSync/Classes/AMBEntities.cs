using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMBSync.Classes
{
    public class AMBEntities
    {
    }

    public class biolinks_blocks
    {
        public int biolink_block_id { get; set; }
        public int user_id { get; set; }
        public int link_id { get; set; }
        public string type { get; set; }
        public string location_url { get; set; }
        public int clicks { get; set; }
        public string settings { get; set; }
        public int order { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public byte is_enabled { get; set; }
        public DateTime datetime { get;set;}

    
}


    public class codes
    {
        public int code_id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int days { get; set; }
        public string code { get; set; }
        public int discount { get; set; }
        public int quantity { get; set; }
        public int redeemed { get; set; }
        public DateTime datetime { get;set;}
}


    public class _data
    {
        public Int64 datum_id { get; set; }
        public int biolink_block_id { get; set; }
        public int link_id { get; set; }
        public int project_id { get; set; }
        public int user_id { get; set; }
        public string type { get; set; }
        public string data { get; set; }
        public DateTime datetime { get;set;}
    
}

    public class domains
    {
        public int domain_id { get; set; }
        public int user_id { get; set; }
        public string scheme { get; set; }
        public string host { get; set; }
        public string custom_index_url { get; set; }
        public string custom_not_found_url { get; set; }
        public byte type { get; set; }
        public byte is_enabled { get; set; }
        public DateTime datetime { get;set;}
    public DateTime last_datetime { get; set; }
}


    public class links
    {
        public int link_id { get; set; }
        public int project_id { get; set; }
        public int user_id { get; set; }
        public int biolink_id { get; set; }
        public int domain_id { get; set; }
        public string pixels_ids { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
        public string url { get; set; }
        public string location_url { get; set; }
        public int clicks { get; set; }
        public string settings { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public byte is_enabled { get; set; }
        public DateTime datetime { get;set;}
    
}


    public class pages
    {
        public int page_id { get; set; }
        public int pages_category_id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public string type { get; set; }
        public string position { get; set; }
        public int order { get; set; }
        public int total_views { get; set; }
        public DateTime datetime { get;set;}
    public DateTime last_datetime { get; set; }
}


    public class pages_categories
    {
        public int pages_category_id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public int order { get; set; }
    }


    public class payments
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int plan_id { get; set; }
        public float base_amount { get; set; }
        public string processor { get; set; }
        public string type { get; set; }
        public string frequency { get; set; }
        public string code { get; set; }
        public float discount_amount { get; set; }
        public string payment_id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string plan { get; set; }
        public string billing { get; set; }
        public string business { get; set; }
        public string taxes_ids { get; set; }
        public float total_amount { get; set; }
        public string currency { get; set; }
        public string payment_proof { get; set; }
        public byte status { get; set; }
        public DateTime datetime { get;set;}
}


    public class pixels
    {
        public int pixel_id { get; set; }
        public int user_id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string pixel { get; set; }
        public DateTime last_datetime { get; set; }
        public DateTime datetime { get;set;}
}


    public class plans
    {
        public int plan_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float monthly_price { get; set; }
        public float annual_price { get; set; }
        public float lifetime_price { get; set; }
        public int trial_days { get; set; }
        public string settings { get; set; }
        public string taxes_ids { get; set; }
        public string codes_ids { get; set; }
        public string color { get; set; }
        public byte status { get; set; }
        public int order { get; set; }
        public DateTime datetime { get;set;}
}


    public class projects
    {
        public int project_id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public DateTime last_datetime { get; set; }
        public DateTime datetime  { get;set;}
    public string color { get; set; }
}


    public class redeemed_codes
    {
        public int id { get; set; }
        public int code_id { get; set; }
        public int user_id { get; set; }
        public DateTime datetime { get;set;}
}


    public class settings
    {
        public int id { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }


    public class taxes
    {
        public int tax_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int value { get; set; }
        public object value_type { get; set; }
        public object type { get; set; }
        public object billing_type { get; set; }
        public string countries { get; set; }
        public DateTime datetime { get;set;}
}


    public class track_links
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int project_id { get; set; }
        public int link_id { get; set; }
        public int biolink_block_id { get; set; }
        public string country_code { get; set; }
        public string os_name { get; set; }
        public string browser_name { get; set; }
        public string device_type { get; set; }
        public DateTime datetime { get;set;}
    public string browser_language { get; set; }
    public byte is_unique { get; set; }
    public string utm_source { get; set; }
    public string utm_medium { get; set; }
    public string utm_campaign { get; set; }
    public string city_name { get; set; }
    public string referrer_path { get; set; }
    public string referrer_host { get; set; }
    public DateTime KEY_track_links_date_index { get; set; }

    }


    public class users
    {
        public int user_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string api_key { get; set; }
        public string billing { get; set; }
        public string token_code { get; set; }
        public string twofa_secret { get; set; }
        public string one_time_login_code { get; set; }
        public string pending_email { get; set; }
        public string email_activation_code { get; set; }
        public string lost_password_code { get; set; }
        public byte type { get; set; }
        public byte status { get; set; }
        public string plan_id { get; set; }
        public DateTime plan_expiration_date { get; set; }
        public string plan_settings { get; set; }
        public byte plan_trial_done { get; set; }
        public byte plan_expiry_reminder { get; set; }
        public string payment_subscription_id { get; set; }
        public string payment_processor { get; set; }
        public float payment_total_amount { get; set; }
        public string payment_currency { get; set; }
        public string referral_key { get; set; }
        public string referred_by { get; set; }
        public byte referred_by_has_converted { get; set; }
        public DateTime datetime { get;set;}
    public string ip { get; set; }
    public DateTime last_activity { get; set; }
    public string last_user_agent { get; set; }
    public int total_logins { get; set; }
    public string timezone { get; set; }
    public string language { get; set; }
    public string country { get; set; }
}


    public class users_logs
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string type { get; set; }
        public DateTime datetime { get;set;}
    public string ip { get; set; }
    public string device_type { get; set; }
    public string os_name { get; set; }
    public string country_code { get; set; }
}




}

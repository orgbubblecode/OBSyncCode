//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMBMigrater.AMBDataSources.AMB6
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            this.domains = new HashSet<domain>();
            this.links = new HashSet<link>();
            this.payments = new HashSet<payment>();
            this.projects = new HashSet<project>();
            this.redeemed_codes = new HashSet<redeemed_codes>();
            this.track_links = new HashSet<track_links>();
            this.users_logs = new HashSet<users_logs>();
        }
    
        public int user_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string api_key { get; set; }
        public string billing { get; set; }
        public string token_code { get; set; }
        public string twofa_secret { get; set; }
        public string pending_email { get; set; }
        public string email_activation_code { get; set; }
        public string lost_password_code { get; set; }
        public Nullable<long> facebook_id { get; set; }
        public int type { get; set; }
        public int active { get; set; }
        public string plan_id { get; set; }
        public Nullable<System.DateTime> plan_expiration_date { get; set; }
        public string plan_settings { get; set; }
        public Nullable<sbyte> plan_trial_done { get; set; }
        public string payment_subscription_id { get; set; }
        public string language { get; set; }
        public string timezone { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string ip { get; set; }
        public string country { get; set; }
        public Nullable<System.DateTime> last_activity { get; set; }
        public string last_user_agent { get; set; }
        public Nullable<int> total_logins { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<domain> domains { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<link> links { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<payment> payments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project> projects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<redeemed_codes> redeemed_codes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<track_links> track_links { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<users_logs> users_logs { get; set; }
    }
}

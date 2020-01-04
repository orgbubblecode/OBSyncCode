//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OBSync.Models.OBDataSources
{
    using System;
    using System.Collections.Generic;
    
    public partial class account
    {
        public System.Guid id { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> date_entered { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }
        public Nullable<System.Guid> modified_user_id { get; set; }
        public Nullable<System.Guid> created_by { get; set; }
        public string description { get; set; }
        public Nullable<bool> deleted { get; set; }
        public Nullable<System.Guid> assigned_user_id { get; set; }
        public string account_type { get; set; }
        public string industry { get; set; }
        public string annual_revenue { get; set; }
        public string phone_fax { get; set; }
        public string billing_address_street { get; set; }
        public string billing_address_city { get; set; }
        public string billing_address_state { get; set; }
        public string billing_address_postalcode { get; set; }
        public string billing_address_country { get; set; }
        public string rating { get; set; }
        public string phone_office { get; set; }
        public string phone_alternate { get; set; }
        public string website { get; set; }
        public string ownership { get; set; }
        public string employees { get; set; }
        public string ticker_symbol { get; set; }
        public string shipping_address_street { get; set; }
        public string shipping_address_city { get; set; }
        public string shipping_address_state { get; set; }
        public string shipping_address_postalcode { get; set; }
        public string shipping_address_country { get; set; }
        public Nullable<System.Guid> parent_id { get; set; }
        public string sic_code { get; set; }
        public Nullable<System.Guid> campaign_id { get; set; }
    }
}

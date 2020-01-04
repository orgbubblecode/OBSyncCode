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
    
    public partial class aos_products
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
        public string maincode { get; set; }
        public string part_number { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public Nullable<decimal> cost { get; set; }
        public Nullable<decimal> cost_usdollar { get; set; }
        public Nullable<System.Guid> currency_id { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<decimal> price_usdollar { get; set; }
        public string url { get; set; }
        public Nullable<System.Guid> contact_id { get; set; }
        public string product_image { get; set; }
        public Nullable<System.Guid> aos_product_category_id { get; set; }
    }
}

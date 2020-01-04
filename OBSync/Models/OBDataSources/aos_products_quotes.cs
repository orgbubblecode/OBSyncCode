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
    
    public partial class aos_products_quotes
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
        public Nullable<System.Guid> currency_id { get; set; }
        public string part_number { get; set; }
        public string item_description { get; set; }
        public Nullable<int> number { get; set; }
        public Nullable<decimal> product_qty { get; set; }
        public Nullable<decimal> product_cost_price { get; set; }
        public Nullable<decimal> product_cost_price_usdollar { get; set; }
        public Nullable<decimal> product_list_price { get; set; }
        public Nullable<decimal> product_list_price_usdollar { get; set; }
        public Nullable<decimal> product_discount { get; set; }
        public Nullable<decimal> product_discount_usdollar { get; set; }
        public Nullable<decimal> product_discount_amount { get; set; }
        public Nullable<decimal> product_discount_amount_usdollar { get; set; }
        public string discount { get; set; }
        public Nullable<decimal> product_unit_price { get; set; }
        public Nullable<decimal> product_unit_price_usdollar { get; set; }
        public Nullable<decimal> vat_amt { get; set; }
        public Nullable<decimal> vat_amt_usdollar { get; set; }
        public Nullable<decimal> product_total_price { get; set; }
        public Nullable<decimal> product_total_price_usdollar { get; set; }
        public string vat { get; set; }
        public string parent_type { get; set; }
        public Nullable<System.Guid> parent_id { get; set; }
        public Nullable<System.Guid> product_id { get; set; }
        public Nullable<System.Guid> group_id { get; set; }
    }
}

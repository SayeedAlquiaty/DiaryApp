//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiaryApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class schools_tb
    {
        public int school_id { get; set; }
        public string school_name { get; set; }
        public string city_name { get; set; }
        public string province_name { get; set; }
        public string country_name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public System.DateTime date_created { get; set; }
        public Nullable<System.DateTime> date_deleted { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiaryApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class notedata_tb
    {
        public int notedata_id { get; set; }
        public int note_id { get; set; }
        public string notetext { get; set; }
        public byte[] noteimage { get; set; }
        public byte[] notemedia { get; set; }
    
        public virtual note_tb note_tb { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryApplication.Models
{
    public class ClassDTO
    {
        public int class_id { get; set; }
        public int @class { get; set; }
        public string section { get; set; }
        public int school_id { get; set; }
        public System.DateTime date_created { get; set; }
    }
}
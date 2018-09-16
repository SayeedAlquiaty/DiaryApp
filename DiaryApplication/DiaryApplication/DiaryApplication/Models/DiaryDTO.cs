using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryApplication.Models
{
    public class DiaryDTO
    {
        public string DiaryNo { get; set; }
        public int Student_Id { get; set; }
        public int Note_Id { get; set; }
        public System.DateTime Date_Created { get; set; }
        public int School_Id { get; set; }
        public StudentDTO Student { get; set; }
    }
}
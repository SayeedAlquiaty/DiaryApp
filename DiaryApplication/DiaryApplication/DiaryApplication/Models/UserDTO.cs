using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryApplication.Models
{
    public class UserDTO
    {
        public int user_id { get; set; }
        public int school_id { get; set; }
        public string user_name { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string type { get; set; }
        public string phoneno { get; set; }
        public string mobileno { get; set; }
        public string address { get; set; }
        public string relation { get; set; }
        public string remarks { get; set; }
        public System.DateTime date_created { get; set; }
        public IEnumerable<StudentDTO> student_dto { get; set; }
    }
}
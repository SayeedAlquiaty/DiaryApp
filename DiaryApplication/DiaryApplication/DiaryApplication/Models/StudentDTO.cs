using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryApplication.Models
{
    public class StudentDTO
    {
        public int Student_Id { get; set; }
        public int User_Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int RollNo { get; set; }
        public int Class_Id { get; set; }
        public int School_Id { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public System.DateTime Date_Created { get; set; }
        public string Sex { get; set; }
        public DiaryDTO Diary { get; set; }
    }
}
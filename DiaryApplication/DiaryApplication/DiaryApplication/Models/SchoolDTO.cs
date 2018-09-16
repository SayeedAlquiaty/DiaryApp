using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryApplication.Models
{
    public class SchoolDTO
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
        public IEnumerable<ClassDTO> class_dto { get; set; }
        public IEnumerable<UserDTO> user_dto { get; set; }
        public IEnumerable<StudentDTO> student_dto { get; set; }
        public IEnumerable<DiaryDTO> diary_dto { get; set; }
        public IEnumerable<NotesDTO> notes_dto { get; set; }

        //for generating next ID
        public int lastUserId { get; set; }
        public int lastStudentId { get; set; }
    }
}
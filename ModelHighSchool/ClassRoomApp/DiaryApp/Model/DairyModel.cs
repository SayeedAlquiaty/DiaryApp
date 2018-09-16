using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApp.Model
{

    class StudentInfo
    {
        public int SId { get; set; }
        public string SName { get; set; } // FirstName + Surname
    }
    class ClassroomInfo
    {
        public int CId { get; set; }
        public string ClassName { get; set; } //Class grade + section
        public List<StudentInfo> ClassStudents { get; set; } // List of all students in class
    }

    class DairyModel
    {
    }
}

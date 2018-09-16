using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassRoomDB.Tables
{
    public class Classroom_row
    {
        public int Classroom_id { get; set; }
        public string Classroom_year { get; set; }
        public string Classroom_grade { get; set; }
        public string Classroom_section { get; set; }
        public bool Classroom_status { get; set; }
        public string Classroom_remarks { get; set; }
        public string Classroom_date_created { get; set; }
        public string Classroom_date_deleted { get; set; }
    }
    public class ClassroomTB
    {
        public List<Classroom_row> Classrooms { get; set; }
        public List<string> ExecuteSQLStrings { get; set; }

        public void ClassroomQuery()
        {
            string _sqlstring = String.Format("SELECT  * FROM ModelHighSchool.classroom_tb");
            ExecuteSQLStrings.Add(_sqlstring);
        }
        public ClassroomTB()
        {

        }
    }
}

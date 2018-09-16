using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//For table studentdairy_tb
namespace DatabaseTransactions.DatabaseTables
{
    public class StudentDiaryRow
    {
        public int DiaryID { get; set; }
        public int StudenID { get; set; }
        public int TeacherID { get; set; }
        public string DiaryDate { get; set; }
        public string DiaryNotes { get; set; }
        public bool Status { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
    public class StudentDiary
    {
        public List<StudentDiaryRow> StudentDiaryRows { get; set; }
        public List<string> ExecuteSQLStrings { get; set; }

        public void InsertDiaryNotes()
        {
            foreach (StudentDiaryRow sr in StudentDiaryRows)
            {
                string _sqlstring = String.Format
                    ("INSERT INTO studentdiary_tb (student_id,teacher-id,studentdiary_date,studentdiary_notes,studentdiary_date_created)" +
                    "VALUES({0},{1},{2},{3},{5})", sr.StudenID, sr.TeacherID, sr.DiaryDate, sr.DiaryNotes, DateTime.Today.Date.ToString());
                ExecuteSQLStrings.Add(_sqlstring);
            }
            
        }
        public void TeacherUpdateDiary()
        {
            foreach (StudentDiaryRow sr in StudentDiaryRows)
            {
                string _sqlstring = String.Format("UPDATE studentdiary_tb SET");
                ExecuteSQLStrings.Add(_sqlstring);
            }


        }
        public void ParentUpdateDiary()
        {
            foreach (StudentDiaryRow sr in StudentDiaryRows)
            {
                string _sqlstring = String.Format("UPDATE studentdiary_tb SET");
                ExecuteSQLStrings.Add(_sqlstring);
            }


        }
    }
}

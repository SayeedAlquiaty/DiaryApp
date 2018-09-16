using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiaryLib
{
    public class StudentInfo
    {
        public int SId { get; set; }
        public string SName { get; set; } // FirstName + Surname
    }
    public class ClassroomInfo
    {
        public int CId { get; set; }
        public string ClassName { get; set; } //Class grade + section
        public List<StudentInfo> ClassStudents { get; set; } // List of all students in class
    }


    public class ClassRoom
    {
        public int ClassRoomID { get; set; }
        public string ClassRoomGrade { get; set; }
        public string ClassRoomSection { get; set; }
    }

    public class StudentInClassRoom
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; } //Firstname + Surname
    }

    public class TeacherDiary
    {
        public int DiaryID { get; set; }
        public int TeacherID { get; set; }
        public string StudentName { get; set; } //Firstname + Surname
        public bool Status { get; set; }
    }

    public class ParentDiary
    {
        public int DiaryID { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; } //Firstname + Surname
        public bool Status { get; set; } 
    }

    //interface ITeacher
    //{
        
    //    void InsertDiaryNotes();
    //    void selectedStudents();

    //}
    //interface IParent
    //{
    //    void UpdateDiaryStatus();
    //    void selectedDiarys();
    //}
    //public class Diary
    //{

    //    public List<StudentInClassRoom> Students
    //    {
    //        get;
    //        set;
    //    }

    //    public List<ClassRoom> Classrooms
    //    {
    //        get;
    //        set;
    //    }

        
    //}
    //public class DiaryForTeacher: Diary
    //{
    //    public List<StudentDiaryRow> StudentDiaryRows { get; set; }
    //    public List<TeacherDiary> TeacherDiarys { get; set; }
    //    public int TeacherID { get; set; }
    //    public string Notes { get; set; }
    //    public List<StudentInClassRoom> SelectedStudents{ get; set; }
        
    //    public void InsertDiaryNotes()
    //    {
    //        StudentDiary studentDiary = new StudentDiary();
    //        studentDiary.StudentDiaryRows = StudentDiaryRows;
    //        studentDiary.InsertDiaryNotes();
    //    }
    //    public void UpdateDiaryNotes()
    //    {
    //        StudentDiary studentDiary = new StudentDiary();
    //        studentDiary.StudentDiaryRows = StudentDiaryRows;
    //        studentDiary.ParentUpdateDiary();
    //    }
    //    public void selectedStudents()
    //    {
    //        List<StudentDiaryRow> SDiaryRows = new List<StudentDiaryRow>();
    //        foreach ( StudentInClassRoom _student in SelectedStudents)
    //        {
    //            StudentDiaryRow _sdRow = new StudentDiaryRow
    //            {
    //                StudenID = _student.StudentID,
    //                TeacherID = this.TeacherID,
    //                DiaryDate = DateTime.Today.Date.ToString(),
    //                DiaryNotes = Notes,
    //                Status = false
    //            };
    //            SDiaryRows.Add(_sdRow);

    //        }
    //        StudentDiaryRows = SDiaryRows;
 
    //    }
    //    public void selectedDiarys()
    //    {
    //        List<StudentDiaryRow> SDiaryRows = new List<StudentDiaryRow>();
    //        foreach (TeacherDiary _teacherDiary in TeacherDiarys)
    //        {

    //            StudentDiaryRow _sdRow = new StudentDiaryRow
    //            {
    //                DiaryID = _teacherDiary.DiaryID,
    //                StudenID = _teacherDiary.TeacherID,
    //                Status = true
    //            };
    //            SDiaryRows.Add(_sdRow);
    //        }
    //        StudentDiaryRows = SDiaryRows;
    //    }
    //}
    //public class DiaryForParent: Diary
    //{
    //    public List<StudentDiaryRow> StudentDiaryRows { get; set; }
    //    public List<ParentDiary> ParentDiarys { get; set; }
    //    public void UpdateDiaryStatus()
    //    {
    //        StudentDiary studentDiary = new StudentDiary();
    //        studentDiary.StudentDiaryRows = StudentDiaryRows;
    //        studentDiary.ParentUpdateDiary();
    //    }
    //    public void selectedDiarys()
    //    {
    //        List<StudentDiaryRow> SDiaryRows = new List<StudentDiaryRow>();
    //        foreach (ParentDiary _parentDiary in ParentDiarys)
    //        {
                
    //            StudentDiaryRow _sdRow = new StudentDiaryRow
    //            {
    //                DiaryID = _parentDiary.DiaryID,
    //                StudenID = _parentDiary.StudentID,
    //                Status = true
    //            };
    //            SDiaryRows.Add(_sdRow);
    //        }
    //        StudentDiaryRows = SDiaryRows;
    //    }
    //}
}

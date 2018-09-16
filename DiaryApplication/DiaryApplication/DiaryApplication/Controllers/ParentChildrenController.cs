using DiaryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DiaryApplication.Controllers
{
    public class ParentChildrenController : ApiController
    {
#if DEBUG
        LocalDairydbEntities _db;
#else
        DairyDBEntities _db;
#endif
        public ParentChildrenController()
        {

#if DEBUG
            _db = new LocalDairydbEntities();
#else
            _db = new DairyDBEntities();
#endif
        }
        // GET api/parentchildren
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/diary
        public IEnumerable<StudentDTO> GetAllChildren(int _parent_user_id)
        {
            //diary_tb _d;
            var students = from _s in _db.student_tb.Where(s => s.user_id == _parent_user_id)
                           select new StudentDTO
                           {
                               Student_Id = _s.student_id,
                               User_Id = _s.user_id,
                               Firstname = _s.firstname,
                               Surname = _s.surname,
                               RollNo = _s.rollno,
                               Class_Id = _s.class_id,
                               School_Id = _s.school_id,
                               Address = _s.address,
                               Remarks = _s.remarks,
                               Sex = _s.sex,
                               Date_Created = _s.date_created,
                               Diary = new DiaryDTO
                               {
                                   DiaryNo = _s.diary_tb.diaryno,
                                   Student_Id = _s.diary_tb.student_id,
                                   Date_Created = _s.diary_tb.date_created
                               },

                           };






            return students;
        }

        // POST api/parentchildren
        public void Post([FromBody]string value)
        {
        }

        // PUT api/parentchildren/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/parentchildren/5
        public void Delete(int id)
        {
        }
    }
}

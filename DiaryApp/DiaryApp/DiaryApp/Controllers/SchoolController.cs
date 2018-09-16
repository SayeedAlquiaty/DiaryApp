using DiaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DiaryApp.Controllers
{
    public class SchoolController : ApiController
    {
        DairyDBEntities _db;

        SchoolController()
        {
            _db = new DairyDBEntities();
        }

        public IEnumerable<schools_tb> GetAllSchools()
        {
            return _db.schools_tb;
        }
        public IHttpActionResult GetSchool(int id)
        {
            var school = _db.schools_tb.FirstOrDefault((s) => s.school_id == id);
            if (school == null)
            {
                return NotFound();
            }
            return Ok(school);
        }
    }
}

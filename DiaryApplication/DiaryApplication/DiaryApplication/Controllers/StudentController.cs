using DiaryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DiaryApplication.Controllers
{
    public class StudentController : ApiController
    {
#if DEBUG
        LocalDairydbEntities _db;
#else
        DairyDBEntities _db;
#endif
        public StudentController()
        {

#if DEBUG
            _db = new LocalDairydbEntities();
#else
            _db = new DairyDBEntities();
#endif
        }


        // GET api/student
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/student/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/student
        public void Post([FromBody]string value)
        {
        }

        // PUT api/student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/student/5
        public void Delete(int id)
        {
        }
    }
}

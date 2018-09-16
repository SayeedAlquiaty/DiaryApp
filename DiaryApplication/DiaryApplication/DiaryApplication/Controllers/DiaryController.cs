using DiaryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DiaryApplication.Controllers
{
    public class DiaryController : ApiController
    {
#if DEBUG
        LocalDairydbEntities _db;
#else
        DairyDBEntities _db;
#endif
        public DiaryController()
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

        // GET api/diary/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/diary
        public void Post([FromBody]string value)
        {
        }

        // PUT api/diary/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/diary/5
        public void Delete(int id)
        {
        }
    }
}

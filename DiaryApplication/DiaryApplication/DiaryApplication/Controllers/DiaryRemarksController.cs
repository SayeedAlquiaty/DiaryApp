using DiaryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DiaryApplication.Controllers
{
    public class DiaryRemarksController : ApiController
    {
#if DEBUG
        LocalDairydbEntities _db;
#else
        DairyDBEntities _db;
#endif

        DiaryRemarksController()
        {
#if DEBUG
            _db = new LocalDairydbEntities();
#else
            _db = new DairyDBEntities();
#endif
            
            
        }
        // GET api/diaryremarks
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/diaryremarks/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/diaryremarks
        public void Post([FromBody]string value)
        {
        }

        // PUT api/diaryremarks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/diaryremarks/5
        public void Delete(int id)
        {
        }
    }
}

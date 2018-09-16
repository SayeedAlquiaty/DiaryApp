using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DiaryApplication.Models;

namespace DiaryApplication.Controllers
{
    public class UserController : ApiController
    {
#if DEBUG
        LocalDairydbEntities _db;
#else
        DairyDBEntities _db;
#endif

        UserController()
        {
#if DEBUG
            _db = new LocalDairydbEntities();
#else
            _db = new DairyDBEntities();
#endif
            
            
        }
        // GET api/user
        public IEnumerable<UserDTO> GetSchoolAllUsers(int _school_id)
        {
            var users = from _u in _db.user_tb.Where((u) => u.school_id == _school_id)
                        select new UserDTO
                        {
                            user_id = _u.user_id,
                            school_id = _u.school_id,
                            firstname = _u.firstname,
                            surname = _u.surname
                        };
            return users;
        }

        // GET api/user/5
        public UserDTO GetUser(int _school_id, int _user_name, )
        {
            return "value";
        }

        // POST api/user
        public void Post([FromBody]string value)
        {
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}

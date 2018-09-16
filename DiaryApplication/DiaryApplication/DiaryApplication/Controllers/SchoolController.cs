using DiaryApplication.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DiaryApplication.Controllers
{
    public class SchoolController : ApiController
    {
#if DEBUG
        LocalDairydbEntities _db;
#else
        DairyDBEntities _db;
#endif

        SchoolController()
        {
#if DEBUG
            _db = new LocalDairydbEntities();
#else
            _db = new DairyDBEntities();
#endif
            
            
        }

        public IEnumerable<SchoolDTO> GetAllSchools()
        {
            var schools = from s in _db.schools_tb
                          select new SchoolDTO()
                        {
                                school_id = s.school_id,
                                school_name = s.school_name,
                                city_name = s.city_name,
                                province_name = s.province_name,

                                country_name = s.country_name,
                                address = s.address,

                                phone = s.phone,
                                date_created = s.date_created,
                                class_dto = from c in s.class_tb.OrderBy(cl => cl.@class)
                                            select new ClassDTO()
                                            {
                                                class_id = c.class_id,
                                                @class = c.@class,
                                                school_id = c.school_id,
                                                section = c.section,
                                                date_created = c.date_created
                                            }
                                
                        };
            return schools;
        }
        public IHttpActionResult GetSchool(int id)
        {
            var ss = _db.schools_tb.FirstOrDefault((s) => s.school_id == id);

            SchoolDTO school = new SchoolDTO();
            
                school.school_id = ss.school_id;
                school.school_name = ss.school_name;
                school.city_name = ss.city_name;
                school.province_name = ss.province_name;

                school.country_name = ss.country_name;
                school.address = ss.address;

                school.phone = ss.phone;
                school.date_created = ss.date_created;

            
            if (school == null)
            {
                return NotFound();
            }
            return Json(school);
        }

        /*public void PostSchool(JObject s)
        {
            /*var result = _db.schools_tb.Add(s);

            if(result == null){
                return BadRequest();
            }
            //return Ok();
        }*/

        public IHttpActionResult DeleteSchool(int id)
        {
            var result = _db.schools_tb.Remove(_db.schools_tb.FirstOrDefault((s) => s.school_id == id));

            if (result == null)
            {
                return BadRequest();
            }
            return Ok();
        }




    }
}

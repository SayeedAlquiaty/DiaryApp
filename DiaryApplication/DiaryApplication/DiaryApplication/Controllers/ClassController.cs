using DiaryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DiaryApplication.Controllers
{
    public class ClassController : ApiController
    {
#if DEBUG
        LocalDairydbEntities _db;
#else
        DairyDBEntities _db;
#endif

        ClassController()
        {
#if DEBUG
            _db = new LocalDairydbEntities();
#else
            _db = new DairyDBEntities();
#endif
        }

        public IEnumerable<ClassDTO> GetAllClasss()
        {
            var Classs = from c in _db.class_tb
                          select new ClassDTO()
                        {
                            class_id = c.class_id,
                            @class = c.@class,
                            school_id = c.school_id,
                            section = c.section,
                            date_created = c.date_created
                                
                        };
            return Classs;
        }
        public IHttpActionResult GetClass(int id)
        {
            var c = _db.class_tb.FirstOrDefault((s) => s.class_id == id);

            ClassDTO Class = new ClassDTO();
            
                Class.class_id = c.class_id;
                Class.@class = c.@class;
                Class.school_id = c.school_id;
                Class.section = c.section;
                Class.date_created = c.date_created;
                                

            
            if (Class == null)
            {
                return NotFound();
            }
            return Json(Class);
        }

        public IHttpActionResult PostClass(ClassDTO c)
        {
            /*var result = _db.classs_tb.Add(s);

            if(result == null){
                return BadRequest();
            }*/
            return Ok();
        }

        public IHttpActionResult DeleteClass(int id)
        {
            var result = _db.class_tb.Remove(_db.class_tb.FirstOrDefault((s) => s.class_id == id));

            if (result == null)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}

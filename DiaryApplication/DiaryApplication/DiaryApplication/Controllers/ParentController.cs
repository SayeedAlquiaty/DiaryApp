using DiaryApplication.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;

namespace DiaryApplication.Controllers
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Surname { get; set; }
    }
    public class ParentController : ApiController
    {
#if DEBUG
        LocalDairydbEntities _db;
#else
        DairyDBEntities _db;
#endif


        ParentController()
        {
#if DEBUG
            _db = new LocalDairydbEntities();
#else
            _db = new DairyDBEntities();
#endif
        }

        

        // GET api/parent
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/parent/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/parent
        public bool PostParent(JObject result)
        {
            //XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(result.ToString());
            
            List<student_tb> _lstudents_dto = new List<student_tb>();
            int _lschool_id = 0;
            int _lclass_id = 0;
            


            //List of students of user type parent
            foreach(var s in result["students_dto"])
            {
                //parent's child student etials
                student_tb st = new student_tb
                {
                    student_id = (int)s["student_id"],
                    user_id = (int)s["user_id"],
                    school_id = (int)s["school_id"],
                    firstname = (string)s["firstname"],
                    surname = (string)s["surname"],
                    rollno = (int)s["rollno"],
                    class_id = (int)s["class_id"],
                    address = (string)s["address"],
                    sex = (string)s["sex"],
                    remarks = (string)s["remarks"],
                    date_created = DateTime.Now,
                };
                _lschool_id = (int)s["school_id"];
                _lclass_id = (int)s["class_id"];
                _lstudents_dto.Add(st);
                _db.student_tb.Add(st);// Inserting a student 
            }

            
            //parent user details
            user_tb _parent = new user_tb
            {
                user_id = (int)result["user_id"],
                school_id = _lschool_id,
                user_name = (string)result["user_name"],
                password = (string)result["password"],
                firstname = (string)result["firstname"],
                surname = (string)result["surname"],
                type = (string)result["type"],
                phoneno = (string)result["phoneno"],
                mobileno = (string)result["mobileno"],
                address = (string)result["address"],
                relation = (string)result["relation"],
                remarks = (string)result["remarks"],
                date_created = DateTime.Now,
                student_tb = _lstudents_dto

            };

            _db.user_tb.Add(_parent);// Inserting a parent 
            _db.SaveChanges(); //changes are commited to the Database.
            return result != null;

        }

        
        // PUT api/parent/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/parent/5
        public void Delete(int id)
        {
        }
    }
}

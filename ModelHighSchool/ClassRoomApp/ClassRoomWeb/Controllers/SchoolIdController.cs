using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassRoomDB.Tables;

namespace ClassRoomWeb.Controllers
{
    public class SchoolIDController : ApiController
    {
        
        public List<School_row> GetSchools(string _schoolname, string _cityname)
        {
            SchoolTB _schoolTb = new SchoolTB();
            return _schoolTb.GetSchools(_schoolname, _cityname);;
        }
    }
}

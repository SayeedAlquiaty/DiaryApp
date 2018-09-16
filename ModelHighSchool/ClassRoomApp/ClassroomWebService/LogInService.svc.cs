using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ClassRoomDB.Tables;
using System.IO;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace ClassroomWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LogInService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LogInService.svc or LogInService.svc.cs at the Solution Explorer and start debugging.
    public class LogInService : ILogInService
    {
        public string Authenticate(string userid, string mykey)
        {
            string fail = "Fail";
            byte[] salt = new byte[] { 172, 137, 25, 56, 156, 100, 136, 211, 84, 67, 96, 10, 24, 111, 112, 137, 3 };
            int iterations = 1024;
            var rfc2898 = new Rfc2898DeriveBytes("_sOme*ShaREd*SecreT", salt, iterations);
            byte[] key = rfc2898.GetBytes(16);
            String keyB64 = Convert.ToBase64String(key);
            if (mykey == keyB64)
                return keyB64;
            else
                return fail;
        }
        public List<SchoolInfo> GetSchoolsList(string city, string school)
        {
            List<SchoolInfo> _schoolslist = new List<SchoolInfo>();
            SchoolTB _schoolTb = new SchoolTB();
            CitySchoolsInfo_list _cityschoolsinfo = _schoolTb.GetCitySchoolsInfo(city, school);


            StringBuilder sb = new StringBuilder();
            StringWriter stream = new StringWriter(sb);
            XmlSerializer x = new System.Xml.Serialization.XmlSerializer(_cityschoolsinfo.GetType());
            x.Serialize(stream, _cityschoolsinfo);


            foreach (School_Info _temp in _cityschoolsinfo.School_info)
            {
                SchoolInfo _schoolinfo = new SchoolInfo();

                _schoolinfo.ID = _temp.School_id;
                _schoolinfo.Name = _temp.School_name;
                _schoolslist.Add(_schoolinfo);
            }

            return _schoolslist;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ClassRoomDB.Tables;
using System.IO;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace ClassroomWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //public string GetData(string value)
        //{
          //  return string.Format("You entered: {0}", value);
        //}

        public List<string> GetSchools(string city)
        {
            SchoolTB _schoolTb = new SchoolTB();
            CitySchools_list _schools = _schoolTb.GetSchoolsInCity(city);


            StringBuilder sb = new StringBuilder();
            StringWriter stream = new StringWriter(sb);
            XmlSerializer x = new System.Xml.Serialization.XmlSerializer(_schools.GetType());
            x.Serialize(stream, _schools);
            return _schools.School_name;
            //return stream.ToString();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ClassroomWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISchoolService" in both code and config file together.
    [ServiceContract]
    public interface ISchoolService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getschoolslist/city={city},school={school}")]
        List<SchoolInfo> GetSchoolsList(string city, string school="");
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class SchoolInfo
    {
        string _id;
        string _name;

        [DataMember]
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ClassroomWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILogInService" in both code and config file together.
    [ServiceContract]
    public interface ILogInService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "authenticate/userid={userid},mykey={mykey}")]
        string Authenticate(string userid, string mykey);

        /*[OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getschoolslist/city={city},school={school}")]
        List<SchoolInfo> GetSchoolsList(string city, string school = "");*/
    }
    
}

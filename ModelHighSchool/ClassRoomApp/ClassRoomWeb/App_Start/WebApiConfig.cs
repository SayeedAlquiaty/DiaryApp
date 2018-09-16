using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ClassRoomWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "SchoolId",
                routeTemplate: "api/SchoolId/{id}",
                defaults: new { controller = "SchoolId", id = RouteParameter.Optional }
            );
        }
    }
}

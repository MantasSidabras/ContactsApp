using Newtonsoft.Json;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApp
{
    public static class WebApiConfig
    {
        public static void Register(IAppBuilder app, HttpConfiguration config)
        {

            var cors = new EnableCorsAttribute("*", "*", "*") { SupportsCredentials = true }; //cookies from Angular
            // Web API configuration and services

            // Web API routes
            config.EnableCors(cors);
           // config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Formatters.JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Contacts", action = "Get", id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
        }
    }
}

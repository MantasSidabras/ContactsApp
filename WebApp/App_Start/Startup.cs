using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Facebook;
using System.Web.Http;
using WebApp.Message_Managment;
using System.Threading;

[assembly: OwinStartup(typeof(WebApp.App_Start.Startup))]

namespace WebApp.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            Thread.Sleep(5000);


            HttpConfiguration config = GlobalConfiguration.Configuration;

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ExternalCookie,
                ExpireTimeSpan = new TimeSpan(0, 30, 0),
                //LoginPath = new PathString("/Login/Unauthorized")
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            // Mano login info
            app.UseFacebookAuthentication(new FacebookAuthenticationOptions
            {
                AppId = "1376825639104971",
                AppSecret = "396e1f058eff4453b974858285d9a3d0"
            });

            //app.UseFacebookAuthentication(new Microsoft.Owin.Security.Facebook.FacebookAuthenticationOptions
            //{
            //    AppId = "158236271388852",
            //    AppSecret = "a80ee0230cb0366ec1366ec5f0b65401"
            //});
            WebApiConfig.Register(app, config);
        }
    }
}

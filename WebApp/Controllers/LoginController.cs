using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApp.Controllers
{
    
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {

        [Route("Login/Unauthorized")]
        [HttpGet]
        public IHttpActionResult Unauthorized()
        {
            return Ok("Unauthorized!");
        }

        
        [Route("Login/{uri}")]
        [HttpGet]
        public HttpResponseMessage Login(string uri)
        {
            uri = @"http://localhost:" + uri;
            var properties = new AuthenticationProperties() { RedirectUri = uri };
            Request.GetOwinContext().Authentication.Challenge(properties, "Facebook");

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.RequestMessage = Request;
            return response;
        }

    }
}

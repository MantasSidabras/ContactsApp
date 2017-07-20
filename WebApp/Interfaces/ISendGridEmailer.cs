using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WebApp.Interfaces
{
    public interface ISendGridEmailer
    {
        Task<HttpResponseMessage> SendEmail(string clientEmail, string clientSubject, string clientText);
    }
}
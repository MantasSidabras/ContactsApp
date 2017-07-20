using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Configuration;
using WebApp.Interfaces;
using WebApp.Models;
using WebApp.Models.SendGridModels;

namespace WebApp.Message_Managment
{
    public class SendGridEmailer : ISendGridEmailer
    {
        private static readonly HttpClient _client = new HttpClient();
        private string uri = "https://api.sendgrid.com/v3/mail/send";
        private string _authKey;
        
        public SendGridEmailer()
        {
            _authKey = WebConfigurationManager.AppSettings["authKey"];
        }


        public async Task<HttpResponseMessage> SendEmail(string clientEmail, string clientSubject, string clientText)
        {
            var model = new SendGridModel
            {
                personalizations = new List<Personalization>()
                {
                    new Personalization()
                    {
                        to = new List<To>() {
                            new To { email = clientEmail }
                        },
                        subject = clientSubject
                    }
                },
                from = new From()
                {
                    email = "I.Will.Find.You@sender.com"
                },
                content = new List<Models.SendGridModels.Content>()
                {
                    new Models.SendGridModels.Content()
                    {
                        type = "text/plain",
                        value = clientText
                    }
                }
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(model));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authKey);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = content;
            var response = await _client.SendAsync(request);

            return response;
        }
    }
}
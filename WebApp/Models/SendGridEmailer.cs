using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using WebApp.Models.SendGridModels;

namespace WebApp.Models
{
    public class SendGridEmailer
    {
        private static readonly HttpClient _client = new HttpClient();
        private string uri = "https://api.sendgrid.com/v3/mail/send";
        private string _authKey;
        
        public SendGridEmailer(string authKey)
        {
            _authKey = authKey;
        }


        public async Task<HttpResponseMessage> SendEmail(string clientEmail, string clientSubject, string clientText)
        {
            var model = new SendGridModel
            {
                personalizations = new List<SendGridModels.Personalization>()
                {
                    new SendGridModels.Personalization()
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
                content = new List<SendGridModels.Content>()
                {
                    new SendGridModels.Content()
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
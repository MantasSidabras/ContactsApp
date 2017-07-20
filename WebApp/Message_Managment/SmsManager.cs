using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Configuration;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Message_Managment
{
    public class SmsManager : ISmsManager
    {
        private static readonly HttpClient _client = new HttpClient();

        private readonly string _accountReference = "EX0235292";
        private readonly string uri = "https://api.esendex.com/v1.0/messagedispatcher";
        private readonly string _base64Login;

        public SmsManager()
        {
            var username = WebConfigurationManager.AppSettings["esendexUsername"];
            var password = WebConfigurationManager.AppSettings["esendexPassword"];
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(string.Format("{0}:{1}", username, password));
            _base64Login = Convert.ToBase64String(plainTextBytes);

        }

        public async Task<HttpResponseMessage> SendMessage(string phone, string message)
        {
            EsendexModel model = new EsendexModel
            {
                accountreference = _accountReference,
                messages = new EsendexMessage[]
                {
                    new EsendexMessage
                        {
                            to = phone,
                            body = message
                        }
                }
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(model));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _base64Login);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = content;
            var response = await _client.SendAsync(request);
            return response;
        }

    }
}
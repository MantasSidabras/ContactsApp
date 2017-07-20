using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Threading.Tasks;
using WebApp.Models;
using Newtonsoft.Json;

namespace WebApp.Message_Managment
{
    public class SmsManager
    {
        private static readonly HttpClient _client = new HttpClient();

        private readonly string _accountReference = "EX0235292";
        private readonly string uri = "https://api.esendex.com/v1.0/messagedispatcher";
        private readonly string _base64Login;

        public SmsManager(string username, string password)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(string.Format("{0}:{1}", username, password));
            _base64Login = Convert.ToBase64String(plainTextBytes);

        }

        public async Task<HttpResponseMessage> SendMessageEsendex(string phone, string message)
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
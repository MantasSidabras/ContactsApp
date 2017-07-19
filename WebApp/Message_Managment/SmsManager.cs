using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Threading.Tasks;
using RestSharp;

namespace WebApp.Message_Managment
{


    public class SmsManager
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly string _accountReference = "EX0235292";
        private readonly string _phone = "37061148271";
        private readonly string uri = "https://api.esendex.com/v1.0/messagedispatcher";
        private readonly string _base64Login;

        public SmsManager(string username, string password)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(string.Format("{0}:{1}", username, password));
            _base64Login = Convert.ToBase64String(plainTextBytes);

        }


        public void SendMessage(string phone, string message) 
        {

            var client = new RestClient(uri);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", $"Basic { _base64Login }");
            request.AddHeader("accept", "application/json");
            request.AddHeader("context-type", "application/json");
            request.AddParameter("application/json", $"{{\r\n  \"accountreference\":\"{_accountReference}\",\r\n  \"messages\":[{{\r\n    \"to\":\"{ _phone }\",\r\n    \"body\":\"{ message }\"\r\n  }}]\r\n}}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }

    }
}
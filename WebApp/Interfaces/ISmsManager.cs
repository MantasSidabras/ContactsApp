using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Interfaces
{
    public interface ISmsManager
    {
        Task<HttpResponseMessage> SendMessage(string phone, string message);
    }
}
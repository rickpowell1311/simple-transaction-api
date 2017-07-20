using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTransactions.Api.Tests
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string requestUri, T content)
        {
            var contentAsString = JsonConvert.SerializeObject(content);

            return await client.PostAsync(requestUri, new StringContent(contentAsString, Encoding.UTF8, "application/json"));
        }

        public static async Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient client, string requestUri, T content)
        {
            var contentAsString = JsonConvert.SerializeObject(content);

            return await client.PutAsync(requestUri, new StringContent(contentAsString, Encoding.UTF8, "application/json"));
        }

        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var contentAsString = await content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(contentAsString);
        }
    }
}

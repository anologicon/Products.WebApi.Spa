using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Products.WebApi.Entities;

namespace Products.WebApi.Integration
{
    public class SyncApiIntegration
    {
        private HttpClient _client;

        private static readonly string ASYNCSERVER = "http://localhost:6000/api/sync";

        public SyncApiIntegration(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> CreateProductSync(ProductEntity productEntity)
        {
            var response = await Post(productEntity);
            
            return response.IsSuccessStatusCode;
        }

        private Task<HttpResponseMessage> Post<T>(T data)
        {
            var dataString = JsonConvert.SerializeObject(data);
            var content = new StringContent(dataString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return _client.PostAsync(ASYNCSERVER, content);
        }
    }
}
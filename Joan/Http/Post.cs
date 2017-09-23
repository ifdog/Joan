using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Joan.Http
{
    public class Post
    {
        private string _url;
        private HttpClient _httpClient;
        private MediaTypeWithQualityHeaderValue _rpcAccept = MediaTypeWithQualityHeaderValue.Parse("application/json-rpc");

        public Post(string baseurl, int port = 6800)
        {
            _url = $"{baseurl}:{port}";
            _httpClient = new HttpClient(new HttpClientHandler
            {
                UseProxy = false
            });
        }

        public async Task<string> Request(string payload, string path = "jsonrpc")
        {
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json-rpc");
            _httpClient.DefaultRequestHeaders.Accept.Add(_rpcAccept);
            var x = await _httpClient.PostAsync($"{_url}/{path}", content);
            
            return await x.Content.ReadAsStringAsync();
        }

        public async Task<string> Request(object payload, string path = "jsonrpc")
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json-rpc");
            _httpClient.DefaultRequestHeaders.Accept.Add(_rpcAccept);
            var x = await _httpClient.PostAsync($"{_url}/{path}", content);
            return await x.Content.ReadAsStringAsync();
        }

    }
}

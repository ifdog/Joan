using System.Collections.Generic;
using Newtonsoft.Json;

namespace Joan.Json.Request
{
    public class RpcRequest
    {
        [JsonProperty("jsonrpc")]
        public string JsonRpc { get; set; } = "2.0";

        [JsonProperty("id")]
        public string Id { get; set; } = "Joan Application";

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public List<object> Params { get; set; } = new List<object>();
    }
}

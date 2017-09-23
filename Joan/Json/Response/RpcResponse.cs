using Joan.Json.Sub;

namespace Joan.Json.Response
{
    public abstract class RpcResponse
    {
        public string Id { get; set; }

        public string JsonRpc { get; set; }

        public RpcError Error { get; set; }
    }
}

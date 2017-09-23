using Aria2Rpc.Json.Sub;
using RpcError = Joan.Json.Sub.RpcError;

namespace Joan.Json.Response
{
    public abstract class RpcResponse
    {
        public string Id { get; set; }

        public string JsonRpc { get; set; }

        public RpcError Error { get; set; }
    }
}

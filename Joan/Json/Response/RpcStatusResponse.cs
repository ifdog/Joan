using Aria2Rpc.Json.Sub;
using RpcStatus = Joan.Json.Sub.RpcStatus;

namespace Joan.Json.Response
{
    public class RpcStatusResponse:Joan.Json.Response.RpcResponse
    {
        public RpcStatus Result { get; set; }
    }
}

using Aria2Rpc.Json.Sub;
using RpcResult = Joan.Json.Sub.RpcResult;

namespace Joan.Json.Response
{
    public class RpcResultResponse:Joan.Json.Response.RpcResponse
    {
        public RpcResult Result { get; set; }
    }
}

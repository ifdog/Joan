using Aria2Rpc.Json.Response;
using Aria2Rpc.Json.Sub;
using RpcStatus = Joan.Json.Sub.RpcStatus;

namespace Joan.Json.Response
{
    public class RpcMultiStatusResponse:RpcResponse
    { 
        public RpcStatus[] Result { get; set; }
    }
}

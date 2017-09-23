using Joan.Json.Sub;

namespace Joan.Json.Response
{
    public class RpcMultiStatusResponse:RpcResponse
    { 
        public RpcStatus[] Result { get; set; }
    }
}

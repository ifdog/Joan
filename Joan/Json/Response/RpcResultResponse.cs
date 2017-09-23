using Joan.Json.Sub;

namespace Joan.Json.Response
{
    public class RpcResultResponse:Joan.Json.Response.RpcResponse
    {
        public RpcResult Result { get; set; }
    }
}

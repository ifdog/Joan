using Joan.Json.Sub;

namespace Joan.Json.Response
{
    public class RpcStatusResponse:Joan.Json.Response.RpcResponse
    {
        public RpcStatus Result { get; set; }
    }
}

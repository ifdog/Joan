using RpcResponse = Joan.Json.Response.RpcResponse;

namespace Joan.Manage
{
    public class JoanResponse<T> where T:RpcResponse
    {
        public T Aria2Response { get; set; }
        public JoanResponseState State { get; set; }
    }
}

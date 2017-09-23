using Aria2Rpc.Json.Sub;

namespace Joan.Json.Sub
{
    public class RpcFile
    {
        public string Index { get; set; }
        public string Path { get; set; }
        public string Length { get; set; }
        public string CompletedLength { get; set; }
        public string Selected { get; set; }
        public RpcUri[] Uris { get; set; }

    }
}

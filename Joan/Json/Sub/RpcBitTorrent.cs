using Aria2Rpc.Json.Sub;

namespace Joan.Json.Sub
{
    public class RpcBitTorrent
    {
        public string[] AnnounceList { get; set; }
        public string Comment { get; set; }
        public string CreationDate { get; set; }
        public string Mode { get; set; }
        public RpcInfo Info { get; set; }
    }
}

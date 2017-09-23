using Newtonsoft.Json;

namespace Joan.Json.Sub
{
    public class RpcGlobalOptions
    {
        [JsonProperty("min-split-size")]
        public string MinSpiltSize { get; set; }

        [JsonProperty("check-integerity")]
        public bool CheckIntergerity { get; set; }

        [JsonProperty("continue")]
        public bool Continue { get; set; }

        [JsonProperty("all-proxy")]
        public string AllProxy { get; set; }

        [JsonProperty("http-proxy")]
        public string HttpProxy { get; set; }

        [JsonProperty("connect-timeout")]
        public int ConnectionTimeout { get; set; }

        [JsonProperty("lowest-speed-limit")]
        public string LowestSpeedLimit { get; set; }

        [JsonProperty("max-connection-per-server")]
        public int MaxConnectionPerServer { get; set; }

        [JsonProperty("max-file-not-found")]
        public int MaxFileNotFound { get; set; }

        [JsonProperty("max-tries")]
        public int MaxTries { get; set; }

        [JsonProperty("remote-time")]
        public bool RemoteTime { get; set; }

        [JsonProperty("user-agent")]
        public string UserAgent { get; set; }

        [JsonProperty("disk-cache")]
        public string DiskCache { get; set; }

        [JsonProperty("file-allocation")]
        public string FileAllocation { get; set; }

        [JsonProperty("max-overall-download-limit")]
        public string MaxOverallDownloadLimit { get; set; }

        [JsonProperty("save-session-interval")]
        public int SaveSessionInterval { get; set; }

        
    }
}

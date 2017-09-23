using Newtonsoft.Json;

namespace Joan.Json.Sub
{
    public class RpcOptions
    {
        [JsonProperty("all-proxy")]
        public string AllProxy { get; set; } = "";

        [JsonProperty("allow-overwrite")]
        public bool AllowOverWrite { get; set; } = false;

        [JsonProperty("always-resume")]
        public bool AlwaysResume { get; set; } = true;

        [JsonProperty("auto-file-renaming")]
        public bool AutoFileRenaming { get; set; } = true;

        [JsonProperty("bt-enable-lpd")]
        public bool BtEnableLpd { get; set; } = true;

        [JsonProperty("bt-max-peers")]
        public int BtMaxPeers { get; set; } = 55;

        [JsonProperty("bt-request-peer-speed-limit")]
        public string BtRequestPeerSpeedLimit { get; set; } = "50K";

        [JsonProperty("check-integerity")]
        public bool CheckIntergerity { get; set; } = false;

        [JsonProperty("dir")]
        public string Dir { get; set; } = ".";

        [JsonProperty("file-allocation")]
        public string FileAllocation { get; set; } = "falloc";

        [JsonProperty("follow-torrent")]
        public bool FollowTorrent { get; set; } = true;

        [JsonProperty("lowest-speed-limit")]
        public string LowestSpeedLimit { get; set; } = "0";

        [JsonProperty("max-connection-per-server")]
        public int MaxConnectionPerServer { get; set; } = 1;

        [JsonProperty("max-download-limit")]
        public string MaxDownloadLimit { get; set; } = "0";

        [JsonProperty("max-file-not-found")]
        public int MaxFileNotFound { get; set; } = 0;

        [JsonProperty("max-resume-failure-tries")]
        public int MaxResumeFailureTries { get; set; } = 0;

        [JsonProperty("max-tries")]
        public int MaxTries { get; set; } = 5;

        [JsonProperty("max-upload-limit")]
        public string MaxUploadLimit { get; set; } = "0";

        [JsonProperty("min-split-size")]
        public string MinSpiltSize { get; set; } = "20M";

        [JsonProperty("remote-time")]
        public bool RemoteTime { get; set; } = false;

        [JsonProperty("seed-ratio")]
        public double SeedRatio { get; set; } = 1.0;

        [JsonProperty("seed-time")]
        public int SeedTime { get; set; } = 30;

        [JsonProperty("split")]
        public int Split { get; set; } = 5;

        [JsonProperty("continue")]
        public bool Continue { get; set; } = false;

        [JsonProperty("connect-timeout")]
        public int ConnectionTimeout { get; set; } = 60;

        [JsonProperty("user-agent")]
        public string UserAgent { get; set; } = "aria2";
    }
}

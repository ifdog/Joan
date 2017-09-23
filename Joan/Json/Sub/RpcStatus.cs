namespace Joan.Json.Sub
{

    public class RpcStatus
    {

        public string Gid { get; set; }
        public string Status { get; set; }
        public long TotalLength { get; set; }
        public long CompletedLength { get; set; }
        public long UploadLength { get; set; }
        public string Bitfield { get; set; }
        public long DownloadSpeed { get; set; }
        public long UploadSpeed { get; set; }
        public string InfoHash { get; set; }
        public long NumSeeders { get; set; }
        public string Seeder { get; set; }
        public string PieceLength { get; set; }
        public string NumPieces { get; set; }
        public string Connections { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string[] FollowedBy { get; set; }
        public string Following { get; set; }
        public string BelongsTo { get; set; }
        public string Dir { get; set; }
        public Joan.Json.Sub.RpcFile[] Files { get; set; }
        public Joan.Json.Sub.RpcBitTorrent BitTorrent { get; set; }
        public string VerifiedLength { get; set; }
        public string VerifyIntegrityPending { get; set; }
    }
}
using System;
using RpcStatus = Joan.Json.Sub.RpcStatus;

namespace Joan.Manage
{
    public class DownloadStateUpdatedEventArgs:EventArgs
    {
        public string Gid => Status.Gid;
        public RpcStatus Status;
    }
}

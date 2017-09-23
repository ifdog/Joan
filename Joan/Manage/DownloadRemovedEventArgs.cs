using System;

namespace Joan.Manage
{
    public class DownloadRemovedEventArgs:EventArgs
    {
        public string Gid { get; set; }
    }
}

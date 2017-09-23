using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Joan.Manage.Download
{
    public abstract class Download
    {
        public DownloadType Type { get; set; }


        public static UriDownload GetNewUriDownload(IEnumerable<string> uris)
        {
            return new UriDownload
            {
                Type = DownloadType.Uri,
                Uris = uris
            };
        }

        public static UriDownload GetnewUriDownload(string uri)
        {
            return GetNewUriDownload(new[] {uri});
        }

        public static TorrentDownload GetNewTorrentDownload(string torrent)
        {
            return new TorrentDownload
            {
                Type = DownloadType.Torrent,
                Torrent = torrent
            };
        }

        public static async Task<TorrentDownload> GetnewTorrentDownload(FileInfo torrent)
        {
            using (var s = torrent.OpenText())
            {
                return new TorrentDownload
                {
                    Type = DownloadType.Torrent,
                    Torrent = await s.ReadToEndAsync()
                };
            }
        }

        public static MetalinkDownload GetNewMetalinkDownload(string metalink)
        {
            return new MetalinkDownload
            {
                Type = DownloadType.Metalink,
                Metalink = metalink
            };
        }

        public static async Task<MetalinkDownload> GetNewMetalinkDownload(FileInfo metalink)
        {
            using (var s = metalink.OpenText())
            {
                return new MetalinkDownload
                {
                    Type = DownloadType.Metalink,
                    Metalink = await s.ReadToEndAsync()
                };
            }
        }
    }
}

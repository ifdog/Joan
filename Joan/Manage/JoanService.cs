using System;
using System.Threading.Tasks;
using Joan.Json.Response;
using Joan.Manage.Download;

namespace Joan.Manage
{
    public class JoanService
    {
        private Aria2Serivce _aria2Serivce;

        public JoanService(Aria2Serivce aria2Serivce)
        {
            this._aria2Serivce = aria2Serivce;
        }

        public async Task<Download.Download> UpdateStatus(Download.Download download)
        {
            var response = await _aria2Serivce.TellStatus(download.Status.Gid);
            download.Status = response.Result;
            return download;
        }

        public async Task<Download.Download> DownloadAdd(Download.Download download)
        {
            if (download is UriDownload uriDownload)
            {
                var response = await _aria2Serivce.AddUri(uriDownload.Uris);
                uriDownload.Status.Gid= response.Result;
                return uriDownload;
            }

            if (download is TorrentDownload torrentDownload)
            {
                var response = await _aria2Serivce.AddUri(null);
                torrentDownload.Status.Gid = response.Result;
                return torrentDownload;
            }

            if (download is MetalinkDownload metalinkDownload)
            {
                var response = await _aria2Serivce.AddUri(null);
                metalinkDownload.Status.Gid = response.Result;
                return metalinkDownload;
            }
            throw new ArgumentOutOfRangeException();
        }

        public async Task<Download.Download> DownloadRemove(Download.Download download)
        {
            var response = await _aria2Serivce.Remove(download.Status.Gid);
            if (response.Result == "OK")
            {
                return download;
            }
            return null;
        }

        public async Task<Download.Download> DownloadPause(Download.Download download)
        {
            var response = await _aria2Serivce.Pause(download.Status.Gid);
            if (response.Result == "OK")
            {
                return download;
            }
            return null;
        }

        public async Task<Download.Download> DownLoadResume(Download.Download download)
        {
            var response =await _aria2Serivce.Unpause(download.Status.Gid);
            if (response.Result == "OK")
            {
                return download;
            }
            return null;
        }
      
    }
}

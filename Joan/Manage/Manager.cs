using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aria2Rpc;
using Aria2Rpc.Json.Response;
using RpcGidResponse = Joan.Json.Response.RpcGidResponse;

namespace Joan.Manage
{
    public class Manager
    {
        private Aria2Serivce _aria2Serivce;
        private Timer _timer;
        private List<string> _gids;

        public event EventHandler<DownloadStateUpdatedEventArgs> DownloadStateUpdated;
        public event EventHandler<DownloadAddedEventArgs> DownloadAdded;
        public event EventHandler<DownloadRemovedEventArgs> DownloadRemoved; 

        public Manager(Aria2Serivce aria2Serivce)
        {
            this._aria2Serivce = aria2Serivce;
            _timer = new Timer(StatusUpdate,null, Timeout.Infinite, Timeout.Infinite);
            _gids = new List<string>();
        }

        private void StatusUpdate(object state)
        {
            _gids.ForEach(async i =>
            {
                var response = await _aria2Serivce.TellStatus(i);

                DownloadStateUpdated?.Invoke(this,new DownloadStateUpdatedEventArgs
                {
                    Status = response.Result
                });
            });
        }

        public async Task<JoanResponse<RpcGidResponse>> DownloadAdd(Download download)
        {
            var uriDownload = download as UriDownload;
            if (uriDownload != null)
            {
                var response = await _aria2Serivce.AddUri(uriDownload.Uris);
                uriDownload.Gid = response.Result;
                
                DownloadAdded?.Invoke(this,new DownloadAddedEventArgs()
                {
                    Gid = uriDownload.Gid
                });
                return new JoanResponse<RpcGidResponse>
                {
                    Aria2Response = response,
                    State = JoanResponseState.JoanAccepted
                };
            }

            var torrentDownload = download as TorrentDownload;
            if (torrentDownload != null)
            {
                var response = await _aria2Serivce.AddUri(null);
                torrentDownload.Gid = response.Result;
               
                DownloadAdded?.Invoke(this, new DownloadAddedEventArgs()
                {
                    Gid = torrentDownload.Gid
                });
                return new JoanResponse<RpcGidResponse>
                {
                    Aria2Response = response,
                    State = JoanResponseState.JoanAccepted
                };
            }

            var metaLinkDownload = download as MetaLinkDownload;
            if (metaLinkDownload != null)
            {
                var response = await _aria2Serivce.AddUri(null);
                metaLinkDownload.Gid = response.Result;
             
                DownloadAdded?.Invoke(this, new DownloadAddedEventArgs()
                {
                    Gid = metaLinkDownload.Gid
                });
                return new JoanResponse<RpcGidResponse>
                {
                    Aria2Response = response,
                    State = JoanResponseState.JoanAccepted
                };
            }

            return new JoanResponse<RpcGidResponse>
            {
                Aria2Response = null,
                State = JoanResponseState.JoanRefused
            };
        }

        public void Start()
        {
            _aria2Serivce.StartService();
            _timer.Change(1000, 1000);
        }

        public void Stop()
        {
            _aria2Serivce.StopService();
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            
        }

        public async Task<JoanResponse<RpcGidResponse>> DownloadRemove(Download download)
        {
            var response = await _aria2Serivce.Remove(download.Gid);
            if (response.Result == "OK")
            {
                _gids.Remove(download.Gid);
                DownloadRemoved?.Invoke(this,new DownloadRemovedEventArgs
                {
                    Gid = download.Gid
                });
            }
            return new JoanResponse<RpcGidResponse>
            {
                Aria2Response = response
            };
        }

        public async Task<JoanResponse<RpcGidResponse>> DownloadPause(Download download)
        {
            return new JoanResponse<RpcGidResponse>
            {
                Aria2Response = await _aria2Serivce.Pause(download.Gid)
            };
        }

        public async Task<JoanResponse<RpcGidResponse>> DownLoadResume(Download download)
        {
            return new JoanResponse<RpcGidResponse>
            {
                Aria2Response = await _aria2Serivce.Unpause(download.Gid)
            };
        }
      
    }
}

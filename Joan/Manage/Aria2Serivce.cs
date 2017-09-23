using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Aria2Exe = Joan.Execute.Aria2Exe;
using Post = Joan.Http.Post;
using RpcGidResponse = Joan.Json.Response.RpcGidResponse;
using RpcMultiStatusResponse = Joan.Json.Response.RpcMultiStatusResponse;
using RpcOptions = Joan.Json.Sub.RpcOptions;
using RpcRequest = Joan.Json.Request.RpcRequest;
using RpcResultResponse = Joan.Json.Response.RpcResultResponse;
using RpcStatusResponse = Joan.Json.Response.RpcStatusResponse;

namespace Joan.Manage
{
    public class Aria2Serivce
    {

        private Post _post;
        private string _token;
        private Aria2Exe _exe;

        public Aria2Serivce(string aria2ExePath = "aria2c.exe", string baseUrl = "http://localhost", int port = 6800, string token = "ifdog",bool builtinExe = true, bool debug =false)
        {
            _token = $"token:{token}";
            _post = new Post(baseUrl, port);
            _exe = new Aria2Exe(aria2ExePath, token, port, debug);
        }

        public async Task<RpcGidResponse> AddUri(IEnumerable<string> uris, RpcOptions options = null, int position = int.MaxValue)
        {
            var model = new RpcRequest {Method = "aria2.addUri"};
            if(_token!=null) model.Params.Add(_token);
            model.Params.Add(uris);
            if (options != null) model.Params.Add(options);
            if (position != int.MaxValue) model.Params.Add(position);

            var requestModel = JsonConvert.SerializeObject(model);
            var req = await _post.Request(requestModel);
            return JsonConvert.DeserializeObject<RpcGidResponse>(req);
        }

        public async Task<RpcGidResponse> Pause(string gid)
        {
            var model = new RpcRequest { Method = "aria2.pause" };
            if (_token != null) model.Params.Add(_token);
            model.Params.Add(gid);

            var requestModel = JsonConvert.SerializeObject(model);
            var req = await _post.Request(requestModel);
            return JsonConvert.DeserializeObject<RpcGidResponse>(req);
        }

        public async Task<RpcGidResponse> Unpause(string gid)
        {
            var model = new RpcRequest { Method = "aria2.unpause" };
            if (_token != null) model.Params.Add(_token);
            model.Params.Add(gid);

            var requestModel = JsonConvert.SerializeObject(model);
            var req = await _post.Request(requestModel);
            return JsonConvert.DeserializeObject<RpcGidResponse>(req);
        }

        public async Task<RpcGidResponse> Remove(string gid)
        {
            var model = new RpcRequest {Method = "aria2.remove"};
            if (_token != null) model.Params.Add(_token);
            model.Params.Add(gid);

            var requestModel = JsonConvert.SerializeObject(model);
            var req = await _post.Request(requestModel);
            return JsonConvert.DeserializeObject<RpcGidResponse>(req);
        }

        public async Task<RpcStatusResponse> TellStatus(string gid, string[] keys = null)
        {
            var model = new RpcRequest {Method = "aria2.tellStatus"};
            if (_token != null) model.Params.Add(_token);
            model.Params.Add(gid);
            if (keys != null) model.Params.Add(keys);

            var requestModel = JsonConvert.SerializeObject(model);
            var req = await _post.Request(requestModel);
            return JsonConvert.DeserializeObject<RpcStatusResponse>(req);
        }

        public async Task<RpcMultiStatusResponse> TellActive(string[] keys = null)
        {
            var model = new RpcRequest {Method = "aria2.tellActive"};
            if (_token != null) model.Params.Add(_token);
            if (keys != null) model.Params.Add(keys);

            var requestModel = JsonConvert.SerializeObject(model);
            var req = await _post.Request(requestModel);
            return JsonConvert.DeserializeObject<RpcMultiStatusResponse>(req);
        }

        public async Task<RpcMultiStatusResponse> TellWaiting(int offset, int num, string[] keys = null)
        {
            var model = new RpcRequest { Method = "aria2.tellWaiting" };
            if (_token != null) model.Params.Add(_token);
            model.Params.Add(offset);
            model.Params.Add(num);
            if (keys != null) model.Params.Add(keys);

            var requestModel = JsonConvert.SerializeObject(model);
            var req = await _post.Request(requestModel);
            return JsonConvert.DeserializeObject<RpcMultiStatusResponse>(req);
        }
        public async Task<RpcMultiStatusResponse> TellStopped(int offset, int num, string[] keys = null)
        {
            var model = new RpcRequest { Method = "aria2.tellStopped" };
            if (_token != null) model.Params.Add(_token);
            model.Params.Add(offset);
            model.Params.Add(num);
            if (keys != null) model.Params.Add(keys);

            var requestModel = JsonConvert.SerializeObject(model);
            var req = await _post.Request(requestModel);
            return JsonConvert.DeserializeObject<RpcMultiStatusResponse>(req);
        }

        public async Task<RpcResultResponse> ShutDown()
        {
            var model = new RpcRequest { Method = "aria2.shutdown" };
            if (_token != null) model.Params.Add(_token);

            var requestModel = JsonConvert.SerializeObject(model);
            var req =  await _post.Request(requestModel);
            return JsonConvert.DeserializeObject<RpcResultResponse>(req);
        }

        public async Task<RpcResultResponse> ForceShutDown()
        {
            var model = new RpcRequest { Method = "aria2.forceShutdown" };
            if (_token != null) model.Params.Add(_token);

            var requestModel = JsonConvert.SerializeObject(model);
            var req = await _post.Request(requestModel);
            return JsonConvert.DeserializeObject<RpcResultResponse>(req);
        }


    }
}

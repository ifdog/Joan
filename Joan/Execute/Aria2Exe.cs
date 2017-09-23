using System;
using System.Collections.Generic;
using System.Diagnostics;
using Joan.Misc;

namespace Joan.Execute
{
    public class Aria2Exe
    {
        public readonly string Aria2ExePath;
        public readonly string Token;
        public readonly int Port;
        public readonly bool Debug;
        public readonly bool MonoPoly;
        public readonly List<string> StartUpArguments = new List<string>(new []{ "--enable-rpc=true","-D" });

        public event DataReceivedEventHandler OutputDataRecived;
        public event DataReceivedEventHandler ErrorDataRecived;

        private Process _aria2Process;



        public Aria2Exe(string aria2ExePath = "aria2c.exe", string token = null, int port = 6800, bool debug = false, bool monoPoly = true, string[] additionalArguments = null)
        {
            Aria2ExePath = aria2ExePath;

            Token = token;
            if (Token != null) StartUpArguments.Add($"--rpc-secret={Token}");

            Port = port;
            if (Port != 6800 && 1024 < Port && Port < 65535) StartUpArguments.Add($"--rpc-listen-port={Port}");

            Debug = debug;
            MonoPoly = monoPoly;
            additionalArguments?.ForEach(StartUpArguments.Add);

            _aria2Process = new Process
            {
                StartInfo =
                {
                    FileName = Aria2ExePath,
                    Arguments = string.Join(" ", StartUpArguments),
                    UseShellExecute = Debug,
                    CreateNoWindow = true
                }
            };
            _aria2Process.OutputDataReceived += _aria2Process_OutputDataReceived;
            _aria2Process.ErrorDataReceived += _aria2Process_ErrorDataReceived;
            _aria2Process.Exited += _aria2Process_Exited;
        }

        private void _aria2Process_Exited(object sender, EventArgs e)
        {
            _aria2Process.Close();
            _aria2Process = null;
        }

        private void _aria2Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            ErrorDataRecived?.Invoke(this,e);
        }

        private void _aria2Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            OutputDataRecived?.Invoke(this,e);
        }

        public void Start()
        {
            if (_aria2Process == null) return;
            if (MonoPoly) KillAll();
            _aria2Process.Start();
        }

        public void Kill()
        {
            if (MonoPoly)
            {
                KillAll();
            }
            else
            {
                _aria2Process.Kill();
            }
        }

        private static void KillAll() => Process.GetProcessesByName("aria2c").ForEach(i => i.Kill());

    }
}

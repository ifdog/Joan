using System;
using ReactiveUI;

namespace Joan.Manage
{
    public class DownloadItemControlVm:ReactiveObject
    {


        public string Gid { get; set; }

        private double _progress;
        public double Progress => _progress;

        private string _status;
        public string Status
        {
            get => _status;
            set => this.RaiseAndSetIfChanged(ref _status,value);
        }

        private long _totalLength;
        public long TotalLength
        {
            get => _totalLength;
            set => this.RaiseAndSetIfChanged(ref _totalLength, value);
        }

        private long _completeLength;
        public long CompletedLength
        {
            get => _completeLength;
            set
            {
                this.RaiseAndSetIfChanged(ref _completeLength, value);
                _progress = Convert.ToDouble(value) / Convert.ToDouble(TotalLength)*300.0;
                this.RaisePropertyChanged(nameof(Progress));
            }

        
        }
    

        private long _uploadLength;
        public long UploadLength
        {
            get => _uploadLength;
            set => this.RaiseAndSetIfChanged(ref _uploadLength, value);
        }

        private long _downloadSpeed;
        public long DownloadSpeed
        {
            get => _downloadSpeed;
            set => this.RaiseAndSetIfChanged(ref _downloadSpeed, value);
        }

        private long _uploadSpeed;
        public long UploadSpeed
        {
            get => _uploadSpeed;
            set => this.RaiseAndSetIfChanged(ref _uploadSpeed, value);
        }

    }
}

using System;
using System.Linq;
using Joan.Manage;
using ReactiveUI;

namespace Joan.Presentation
{
    public class MainWindowVm:ReactiveObject
    {
        private JoanService _joanService;
        public ReactiveList<DownloadItemControlVm> Downloads { get; set; }
        public DownloadItemControlVm SelectedControlVm { get; set; }

        public ReactiveCommand NewCommand { get; private set; }
        public ReactiveCommand PauseCommand { get; private set; }
        public ReactiveCommand ResumeCommand { get; private set; }
        public ReactiveCommand DeleteCommand { get; private set; }
        public ReactiveCommand SettingCommand { get; private set; }
        public ReactiveCommand DetailCommand { get; private set; }

        public MainWindowVm(JoanService joanService, Func<NewDownloadWindow> newDownload)
        {
            Downloads = new ReactiveList<DownloadItemControlVm>()
            {
               // ChangeTrackingEnabled = true
            };
            _joanService = joanService;
            NewCommand = ReactiveCommand.Create(() => newDownload().ShowDialog());
            PauseCommand = ReactiveCommand.Create(() => _joanService.DownloadPause());


            _joanService.DownloadAdded += _manager_DownloadAdded;
            _joanService.DownloadRemoved += _manager_DownloadRemoved;
            _joanService.DownloadStateUpdated += _manager_DownloadStateUpdated;


        }

        private void _manager_DownloadStateUpdated(object sender, DownloadUpdatedEventArgs e)
        {
            var d = Downloads.First(i => i.Gid == e.Gid);
            d.Status = e.Status.Status;
            d.CompletedLength = e.Status.CompletedLength;
            d.TotalLength = e.Status.TotalLength;
            d.UploadLength = e.Status.UploadLength;
            d.DownloadSpeed = e.Status.DownloadSpeed;
            d.UploadSpeed = e.Status.UploadSpeed;
            
        }

        private void _manager_DownloadRemoved(object sender, DownloadRemovedEventArgs e)
        {
            Downloads.Remove(Downloads.First(i => i.Gid == e.Gid));
        }

        private void _manager_DownloadAdded(object sender, DownloadAddedEventArgs e)
        {
            Downloads.Add(new DownloadItemControlVm
            {
                Gid = e.Gid
            });
        }
    }
}

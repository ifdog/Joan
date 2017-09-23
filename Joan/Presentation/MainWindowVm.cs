using System;
using System.Linq;
using Joan.Manage;
using ReactiveUI;

namespace Joan.Presentation
{
    public class MainWindowVm:ReactiveObject
    {
        private Manager _manager;
        public ReactiveList<DownloadItemControlVm> Downloads { get; set; }
        public DownloadItemControlVm SelectedControlVm { get; set; }

        public ReactiveCommand NewCommand { get; private set; }
        public ReactiveCommand PauseCommand { get; private set; }
        public ReactiveCommand ResumeCommand { get; private set; }
        public ReactiveCommand DeleteCommand { get; private set; }
        public ReactiveCommand SettingCommand { get; private set; }
        public ReactiveCommand DetailCommand { get; private set; }

        public MainWindowVm(Manager manager, Func<NewDownloadWindow> newDownload)
        {
            Downloads = new ReactiveList<DownloadItemControlVm>()
            {
               // ChangeTrackingEnabled = true
            };
            _manager = manager;
            NewCommand = ReactiveCommand.Create(() => newDownload().ShowDialog());
            PauseCommand = ReactiveCommand.Create(() => _manager.DownloadPause());


            _manager.DownloadAdded += _manager_DownloadAdded;
            _manager.DownloadRemoved += _manager_DownloadRemoved;
            _manager.DownloadStateUpdated += _manager_DownloadStateUpdated;


        }

        private void _manager_DownloadStateUpdated(object sender, DownloadStateUpdatedEventArgs e)
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

using System;
using System.Collections.Generic;
using System.Linq;
using Joan.Manage;
using ReactiveUI;

namespace Joan.Presentation
{
    public class JoanMainWindowVm:ReactiveObject
    {
        private JoanService _joanService;
        public ReactiveList<DownloadItemVm> Downloads { get; set; }
        public List<DownloadItemVm> SelectedDownloads { get; set; }

        public ReactiveCommand NewCommand { get; private set; }
        public ReactiveCommand PauseCommand { get; private set; }
        public ReactiveCommand ResumeCommand { get; private set; }
        public ReactiveCommand DeleteCommand { get; private set; }
        public ReactiveCommand SettingCommand { get; private set; }
        public ReactiveCommand DetailCommand { get; private set; }

        public JoanMainWindowVm(JoanService joanService, Func<NewDownloadWindow> newDownload)
        {
            Downloads = new ReactiveList<DownloadItemVm>();
            SelectedDownloads = new List<DownloadItemVm>();
            _joanService = joanService;
            NewCommand = ReactiveCommand.Create(() => newDownload().ShowDialog());
            //PauseCommand = ReactiveCommand.Create(() => _joanService.DownloadPause());




        }

        

    }
}

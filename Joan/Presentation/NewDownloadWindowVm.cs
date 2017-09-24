using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Joan.Manage;
using Joan.Manage.Download;
using Joan.Misc;
using Joan.Properties;
using Microsoft.Win32;
using ReactiveUI;

namespace Joan.Presentation
{
    public class NewDownloadWindowVm:ReactiveObject,IRequestViewClose
    {
        private string _linkText;
        private JoanService _joanService;

        public event EventHandler RequestViewClose;
        public string LinkText
        {
            get => _linkText;
            set => this.RaiseAndSetIfChanged(ref _linkText, value);
        }
        public ReactiveCommand OkCommand { get; private set; }
        public ReactiveCommand AddFileCommand { get; private set; }
        public List<string> x;

        
        public NewDownloadWindowVm(JoanService joanService)
        {
            _joanService = joanService;
            var canOk = true;
            OkCommand = ReactiveCommand.CreateFromTask(OkAction);
            AddFileCommand = ReactiveCommand.Create(AddFileAction);
        }

        private async Task OkAction()
        {
            var torrent = new Regex(Resources.TorrentRegExp, RegexOptions.IgnoreCase);
            var webLink = new Regex(Resources.WebLinkRegExp, RegexOptions.IgnoreCase);
            var metalink = new Regex(Resources.MetaLinkRegExp, RegexOptions.IgnoreCase);
            var items = LinkText.Split('\n').Select(i => i.Trim()).ToArray();

            items.Where(i => webLink.IsMatch(i))
                .ForEach(async i => await _joanService.AddNew(Download.GetnewUriDownload(i)));
            items.Where(i => torrent.IsMatch(i))
                .ForEach(async i => await _joanService.AddNew(Download.GetnewUriDownload(i)));
            items.Where(i => metalink.IsMatch(i))
                .ForEach(async i => await _joanService.AddNew(Download.GetnewUriDownload(i)));
            RequestViewClose?.Invoke(this,null);
        }

        private void AddFileAction()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                DefaultExt = ".Torrent",
                Filter =
                    "Torrnet Files (*.torrent)|*.torrent|Metalink Files (*.metalink)|*.metalink|text Files (*.txt)|*.txt",
                Multiselect = true,
                CheckFileExists = true,
                InitialDirectory = Environment.SpecialFolder.DesktopDirectory.ToString(),
                Title = @"Select Seed Files"
            };

            var showDialog = dialog.ShowDialog();
            if (showDialog != null && showDialog.Value)
            {
                LinkText += string.Join(Environment.NewLine, dialog.FileNames);
            }
        }

        
    }


}

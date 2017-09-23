namespace Joan.Presentation
{
    /// <summary>
    /// Interaction logic for NewDownloadWindow.xaml
    /// </summary>
    public partial class NewDownloadWindow 
    {
        private NewDownloadWindowVm _newDownloadWindowVm;
        public NewDownloadWindow(NewDownloadWindowVm newDownloadWindowVm)
        {
            _newDownloadWindowVm = newDownloadWindowVm;
            DataContext = _newDownloadWindowVm;
            InitializeComponent();
        }
    }
}

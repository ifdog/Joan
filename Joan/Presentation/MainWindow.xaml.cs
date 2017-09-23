using System.Windows;

namespace Joan.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVm viewModel;
        public MainWindow(MainWindowVm viewModel)
        {
            this.viewModel = viewModel;
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Joan.Execute;

namespace Joan.Presentation
{
    /// <summary>
    /// Interaction logic for JoanMainWindow.xaml
    /// </summary>
    public partial class JoanMainWindow : Window
    {
        private JoanMainWindowVm _joanMainWindowVm;
        
        public JoanMainWindow(JoanMainWindowVm joanMainWindowVm, Func<Aria2Exe> aria2exe)
        {
            _joanMainWindowVm = joanMainWindowVm;
            this.DataContext = _joanMainWindowVm;
            InitializeComponent();
            aria2exe().Start();
        }
    }
}

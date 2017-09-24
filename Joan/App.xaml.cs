using System.Windows;
using Autofac;
using Joan.Execute;
using Joan.Manage;
using Joan.Presentation;
using Aria2Serivce = Joan.Manage.Aria2Serivce;

namespace Joan
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ContainerBuilder _builder;
        private JoanService _joanService;
        public IContainer Container { get; private set; }

        public App()
        {
            _builder = new ContainerBuilder();
            _builder.RegisterType<Aria2Serivce>().AsSelf().SingleInstance();
            _builder.RegisterType<JoanService>().AsSelf().SingleInstance();
            _builder.RegisterType<Aria2Exe>().AsSelf().SingleInstance();
            _builder.RegisterType<Presentation.JoanMainWindow>().AsSelf();
            _builder.RegisterType<JoanMainWindowVm>().AsSelf();
            _builder.RegisterType<Presentation.NewDownloadWindow>().AsSelf();
            _builder.RegisterType<NewDownloadWindowVm>().AsSelf();


            Container = _builder.Build();

            _joanService = Container.Resolve<JoanService>();
            Container.Resolve<Presentation.JoanMainWindow>().Show();
          // Container.Resolve<Presentation.MainWindow>().Show();
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            
        }

        protected override void OnExit(ExitEventArgs e)
        {
        }

        
    }
}

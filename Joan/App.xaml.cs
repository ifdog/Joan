using System.Windows;
using Autofac;
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
        private Manager _manager;
        public IContainer Container { get; private set; }

        public App()
        {
            _builder = new ContainerBuilder();
            _builder.RegisterType<Aria2Serivce>().AsSelf().SingleInstance();
            _builder.RegisterType<Manager>().AsSelf().SingleInstance();

            _builder.RegisterType<Presentation.MainWindow>().AsSelf();
            _builder.RegisterType<MainWindowVm>().AsSelf();
            _builder.RegisterType<Presentation.NewDownloadWindow>().AsSelf();
            _builder.RegisterType<NewDownloadWindowVm>().AsSelf();


            Container = _builder.Build();

            _manager = Container.Resolve<Manager>();
           Container.Resolve<Presentation.MainWindow>().Show();
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            
            _manager.Start();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            //_manager.Stop();
        }

        
    }
}

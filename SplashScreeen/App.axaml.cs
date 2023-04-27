using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SplashScreeen.ViewModels;
using SplashScreeen.Views;
using System.Threading.Tasks;

namespace SplashScreeen
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override async void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var splashWindow = new Splash();
                var splashViewModel = new SplashViewModel();

                splashWindow.DataContext = splashViewModel;
                desktop.MainWindow = splashWindow;

                try
                {
                    splashViewModel.StartUpMessage = "Application load resources...";
                    await Task.Delay(1000, cancellationToken: splashViewModel.CancellationToken);

                    splashViewModel.StartUpMessage = "Get data from Online...";
                    await Task.Delay(5000, cancellationToken: splashViewModel.CancellationToken);

                    splashViewModel.StartUpMessage = "Opening...";
                    await Task.Delay(1000, cancellationToken: splashViewModel.CancellationToken);
                }
                catch(TaskCanceledException)
                {
                    splashWindow.Close();
                    return;
                }

                var mainWindow = new MainWindow();
                
                desktop.MainWindow = mainWindow;

                mainWindow.Show();

                splashWindow.Close();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
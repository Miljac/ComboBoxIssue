using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Logging;
using Avalonia.Markup.Xaml;

using ComboBoxIssue.ViewModels;
using ComboBoxIssue.Views;
using ReactiveUI;
using Splat.ModeDetection;
using Splat;
using System;
using Avalonia.ReactiveUI;
using System.Runtime;

namespace ComboBoxIssue;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public App()
    {
        ModeDetector.OverrideModeDetector(Mode.Run);
        RxApp.MainThreadScheduler = AvaloniaScheduler.Instance;
        RegisterReactiveServices();
    }

    private void RegisterReactiveServices()
    {
        Locator.CurrentMutable.RegisterLazySingleton(() => new MainWindow(), typeof(IViewFor<MainViewModel>));
        Locator.CurrentMutable.RegisterLazySingleton(() => new MainViewModel());
        Locator.CurrentMutable.Register(() => new UserView(), typeof(IViewFor<User>));
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var mainViewModel = Locator.Current.GetService<MainViewModel>();
                var mainWindow = (MainWindow)Locator.Current.GetService<IViewFor<MainViewModel>>();
                mainWindow.ViewModel = mainViewModel;
                desktop.ShutdownMode = Avalonia.Controls.ShutdownMode.OnMainWindowClose;
                desktop.MainWindow = mainWindow;
            }

            base.OnFrameworkInitializationCompleted();

        //if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        //{
        //    desktop.MainWindow = new MainWindow
        //    {
        //        DataContext = new MainViewModel()
        //    };
        //}
        //else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        //{
        //    singleViewPlatform.MainView = new MainView
        //    {
        //        DataContext = new MainViewModel()
        //    };
        //}

        //base.OnFrameworkInitializationCompleted();
    }
}

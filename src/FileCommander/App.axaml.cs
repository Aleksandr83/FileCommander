using System;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using FileCommander.ViewModels;
using FileCommander.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Regions;
using System.Linq;
using Prism.Modularity;

namespace FileCommander
{
    public class App : PrismApplication
    {
        public static bool IsSingleViewLifetime =>
            Environment.GetCommandLineArgs()
                .Any(a => a == "--fbdev" || a == "--drm");

        public static AppBuilder BuildAvaloniaApp() =>
            AppBuilder
                .Configure<App>()
                .UsePlatformDetect();

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            MyApp.FileCommander.App.Init();
            base.Initialize();
        }

        protected override IAvaloniaObject CreateShell()
        {
            //if (IsSingleViewLifetime)
            //    return Container.Resolve<MainControl>(); // For Linux Framebuffer or DRM
            //else
                return Container.Resolve<MainWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            // Register modules
            //moduleCatalog.AddModule<Module1.Module>();         
        }

        /// <summary>Called after <seealso cref="Initialize"/>.</summary>
        protected override void OnInitialized()
        {
        // Register initial Views to Region.
        var regionManager = Container.Resolve<IRegionManager>();       
        //regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(DashboardView));
        //regionManager.RegisterViewWithRegion(RegionNames.SidebarRegion, typeof(SidebarView));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register Services
            //containerRegistry.Register<IRestService, RestService>();

            // Views - Generic
            containerRegistry.Register<MainWindow>();

            // Views - Region Navigation           
            //containerRegistry.RegisterForNavigation<DashboardView, DashboardViewModel>();
            //containerRegistry.RegisterForNavigation<SettingsView,  SettingsViewModel>();
            //containerRegistry.RegisterForNavigation<SidebarView,   SidebarViewModel>();
        }
    }

    // public partial class App : Application
    // {
    //     public override void Initialize()
    //     {
    //         AvaloniaXamlLoader.Load(this);
    //         MyApp.FileCommander.App.Init();
    //     }

    //     public override void OnFrameworkInitializationCompleted()
    //     {
    //         if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    //         {
    //             desktop.MainWindow = new MainWindow
    //             {
    //                 DataContext = new MainWindowViewModel(),
    //             };
    //         }

    //         base.OnFrameworkInitializationCompleted();
    //     }
    // }
}
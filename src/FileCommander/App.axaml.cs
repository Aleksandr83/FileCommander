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

namespace FileCommander;

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

    protected override AvaloniaObject CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        // Register modules           
    }

    /// <summary>Called after <seealso cref="Initialize"/>.</summary>
    protected override void OnInitialized()
    {    
        var regionManager = Container.Resolve<IRegionManager>();      
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {       
        containerRegistry.Register<MainWindow>();        
    }
}

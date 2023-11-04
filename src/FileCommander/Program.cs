using Avalonia;
using Avalonia.ReactiveUI;
using Avalonia.Dialogs;
using System;
using System.Globalization;
using System.Threading;
using System.Linq;

namespace FileCommander;


public static class Program
{
    static int Main(string[] args)
    {
        double GetScaling()
        {
            var idx = Array.IndexOf(args, "--scaling");
            if (idx != 0 && args.Length > idx + 1 &&
                double.TryParse(args[idx + 1], NumberStyles.Any, CultureInfo.InvariantCulture, out var scaling))
                return scaling;
            return 1;
        }

        var builder = BuildAvaloniaApp();
        //InitializeLogging();
        
        //if (args.Contains("--fbdev"))
        //{
        //    SilenceConsole();
        //    return builder.StartLinuxFbDev(args, scaling: GetScaling());
        //}
        //else if (args.Contains("--drm"))
        //{
        //    SilenceConsole();
        //    return builder.StartLinuxDrm(args, scaling: GetScaling());
        //}
        //else
            return builder.StartWithClassicDesktopLifetime(args);
    }

    static void SilenceConsole()
    {
        new Thread(() =>
        {
            Console.CursorVisible = false;
            while (true)
                Console.ReadKey(true);
        })
        { IsBackground = true }.Start();
    }

    public static AppBuilder BuildAvaloniaApp() =>
    AppBuilder.Configure<App>()
        .UsePlatformDetect()
        .With(new X11PlatformOptions
        {
            EnableMultiTouch = true,
            UseDBusMenu = true
        })
        .With(new Win32PlatformOptions
        {
            EnableMultitouch = true,
            AllowEglInitialization = true
        })
        .UseSkia()
        .UseReactiveUI()
        .UseManagedSystemDialogs();
}


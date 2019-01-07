using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using OxyPlot.Avalonia;
using Serilog;


namespace AvaloniaSimpleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            OxyPlotModule.EnsureLoaded();
           // InitializeLogging();
            BuildAvaloniaApp().Start<MainWindow>();
        }

        private static void InitializeLogging()
        {
#if DEBUG
            SerilogLogger.Initialize(new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Trace(outputTemplate: "{Area}: {Message}")
                .CreateLogger());
#endif

        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .BeforeStarting(_ => OxyPlotModule.Initialize())
                .LogToDebug();
    }
}

using Serilog.Events;
using Serilog;
using System.Runtime.InteropServices;

namespace ShoppingAPI.Middleware
{
    public class SerilogConfig
    {
    
public static Serilog.ILogger AddSerilogConfiguration()

        {

            string logFileName = "./serilogs/webapi-.txt";

            Serilog.ILogger logger = new LoggerConfiguration()

                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)

                .MinimumLevel.Is(LogEventLevel.Warning)

                .WriteTo.Console()

                .WriteTo.File(

                    path: logFileName,

                    retainedFileCountLimit: 7,

                    shared: true,

                    rollingInterval: RollingInterval.Day,

                    rollOnFileSizeLimit: true,

                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {StatusCode}] [{SourceContext}] {Message:lj} {NewLine} {Exception}")

                .Enrich.FromLogContext()

                .CreateLogger();

            return logger;

        }
    }
}

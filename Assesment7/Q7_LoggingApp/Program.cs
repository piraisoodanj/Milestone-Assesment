using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Q7_LoggingApp
{
    internal class Program
    {
        //Log file path
        private static readonly string logFilePath = "Logs/myapp.log";

        static void Main(string[] args)
        {
            //Set up dependency injection and logging
            var serviceProvider = new ServiceCollection()
                .AddLogging(configure => configure.AddConsole())
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();

            //Ensure log directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

            //Log messages
            LogManager logManager = new LogManager();
            logManager.LogMessages(logger, logFilePath);
        }
    }
}
using log4net.Config;
using log4net;

namespace Part8_LoggingUsingLog4net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoggingManager loggingManager = new LoggingManager();

            //Configure log4net
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            Console.WriteLine("Configured log4net");

            //Ensure log directory exists
            Directory.CreateDirectory("Logs");
            Console.WriteLine("Created log folder");

            //Log messages
            loggingManager.LogMessages();

            //Read log file data
            loggingManager.ReadLogFile();
        }
    }
}
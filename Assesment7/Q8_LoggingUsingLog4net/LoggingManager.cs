using log4net;
using log4net.Config;

namespace Part8_LoggingUsingLog4net
{
    public class LoggingManager
    {
        //Create a logger for this class
        ILog logger = LogManager.GetLogger(typeof(Program));

        //Log file path
        private readonly string filePath = "Logs/application.log";

        //Fuction to log messages
        public void LogMessages()
        {
            try
            {
                logger.Info("Application started");
                logger.Warn("Low disk space");
                logger.Error("An error occurred during processing");
                logger.Info("Application end");

                //Re-configure to release the current log file.
                ConfigureLogger("log4net1.config");
                Console.WriteLine("Logs added");
            }
            catch (Exception ex)
            {
                logger.Error("An exception occurred during logging", ex);
            }
        }

        //Function to read log file data
        public void ReadLogFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var logContents = File.ReadAllLines(filePath);
                    Console.WriteLine("Reading log file");
                    Console.WriteLine("Log File Contents:");
                    foreach (var line in logContents)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("Log file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading log file: {ex.Message}");
            }
        }

        private void ConfigureLogger(string filePath)
        {
            //Re-Configure log4net for reading log
            XmlConfigurator.Configure(new FileInfo(filePath));
        }
    }
}

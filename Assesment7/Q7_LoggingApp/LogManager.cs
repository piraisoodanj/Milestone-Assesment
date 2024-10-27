using Microsoft.Extensions.Logging;

namespace Q7_LoggingApp
{
    class LogManager
    {
        private static string logFilePath="";

        public void LogMessages(ILogger<Program> logger, string _logFilePath)
        {
            try
            {
                logFilePath = _logFilePath;
                LogToFile("Application started");
                logger.LogInformation("Application started");

                //Simulating some operations
                LogToFile("Performing operation...");
                logger.LogInformation("Performing operation...");

                //Simulating an operation delay
                Thread.Sleep(2000); //2 second

                LogToFile("Application ended");
                logger.LogInformation("Application ended");
            }
            catch (Exception ex)
            {
                //Handle logging errors
                logger.LogError(ex, "An error occurred while logging:");
            }
            finally
            {
                //Validate log file contents (optional)
                ValidateLogFile(logFilePath);
            }
        }

        //Function to write into log file
        private void LogToFile(string message)
        {
            try
            {
                var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }

        //Function to read data from the Log file
        private void ValidateLogFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var logContents = File.ReadAllLines(filePath);
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
    }
}

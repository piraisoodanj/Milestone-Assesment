using System;
using System.Diagnostics;

namespace Part4PythonInDotNET
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the Python script and arguments
            string pythonScript = "sum_python.py"; 
            int num1 = 5;
            int num2 = 10;

            // Invoke the Python script
            string result = RunPythonScript(pythonScript, num1, num2);

            // Output the result
            if (result != null)
            {
                Console.WriteLine("The sum is: " + result);
            }
        }

        static string RunPythonScript(string scriptPath, int arg1, int arg2)
        {
            try
            {
                // Initialize the process to run Python
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "python", // Ensure that 'python' is in the system PATH or provide full path
                    Arguments = $"{scriptPath} {arg1} {arg2}",
                    RedirectStandardOutput = true, // Redirect the output so we can capture it
                    RedirectStandardError = true,  // Capture any error messages
                    UseShellExecute = false, // Required for redirection
                    CreateNoWindow = true    // Prevents a console window from popping up
                };

                // Start the process
                using (Process process = Process.Start(psi))
                {
                    // Read the output from the script
                    string output = process.StandardOutput.ReadToEnd();
                    string errors = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    // Handle errors
                    if (process.ExitCode != 0)
                    {
                        Console.WriteLine("Error during script execution: " + errors);
                        return null;
                    }

                    return output.Trim(); // Return the trimmed output
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }
    }
}

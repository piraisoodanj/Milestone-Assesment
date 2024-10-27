namespace Q4_OutlookEmailSender
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Mail parameters
            string recipient = "U77606@ust.com";
            string subject = "Monthly Report";
            string body = "Please find the attached report.";
            string attachmentPath = AppDomain.CurrentDomain.BaseDirectory + "Report.pdf";

            OutlookEmailSender outlookEmailSender = new OutlookEmailSender();

            try
            {
                //send mail
                outlookEmailSender.SendEmail(recipient, subject, body, attachmentPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
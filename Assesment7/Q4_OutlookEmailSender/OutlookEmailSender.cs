using Microsoft.Office.Interop.Outlook;

namespace Q4_OutlookEmailSender
{
    public class OutlookEmailSender
    {
        public void SendEmail(string recipient, string subject, string body, string attachmentPath)
        {
            //Validate email address
            if (!IsValidEmail(recipient))
            {
                throw new ArgumentException("Invalid email address.");
            }

            //Create Outlook application and mail item
            Application outlookApp = new Application();
            MailItem mailItem = (MailItem)outlookApp.CreateItem(OlItemType.olMailItem);

            //Set mail item properties
            mailItem.To = recipient;
            mailItem.Subject = subject;
            mailItem.Body = body;

            //Attach the file
            if (!string.IsNullOrEmpty(attachmentPath))
            {
                try
                {
                    mailItem.Attachments.Add(attachmentPath, OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception("Could not attach the file: " + ex.Message);
                }
            }

            //Send the email
            mailItem.Send();
            Console.WriteLine($"Email sent successfully to {recipient}.");
        }

        //Function to validate email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

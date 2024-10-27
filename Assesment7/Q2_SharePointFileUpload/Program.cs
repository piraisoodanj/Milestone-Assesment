namespace Q2_SharePointFileUpload
{
    internal class Program
    {
        //Configuration for SharePoint site URL and document library name
        private static string siteUrl = "https://sample_sangeeth-tenant.sharepoint.com/sites"; 
        private static string libraryName = "NewSite";

        //Azure AD application credentials
        private static string clientId = "gH5kL9mN3-qR7sT4-vU2wX6yZ1-aB8cE0";
        private static string clientSecret = "9R&fZ3p*L$2xQ!kA";

        static void Main(string[] args)
        {
            //Specify the file path of the document to upload
            string filePath = @"C:\UploadFiles\Q2.docx";

            //Create an instance of SharePointOperations
            SharePointOperations operations = new SharePointOperations(siteUrl, libraryName, clientId, clientSecret);

            try
            {
                //Attempt to upload the file
                operations.UploadFile(filePath);
            }
            catch (Exception ex)
            {
                //Catch any unexpected errors and display a message
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
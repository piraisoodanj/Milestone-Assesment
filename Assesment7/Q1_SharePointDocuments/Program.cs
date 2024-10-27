namespace Q1_SharePointDocuments
{
    internal class Program
    {
        //Configuration for SharePoint site URL and document library name
        private static string siteUrl = "https://sample_sangeeth-tenant.sharepoint.com/sites";
        private static string libraryName = "NewSite";

        static void Main(string[] args)
        {
            try
            {
                //Retrieve and print the list of documents from the SharePoint library
                var documentList = SharepointManager.GetDocumentsFromLibrary(siteUrl, libraryName);
                SharepointManager.PrintDocumentList(documentList);
            }
            catch (Exception ex)
            {
                //Catch any unexpected exceptions
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
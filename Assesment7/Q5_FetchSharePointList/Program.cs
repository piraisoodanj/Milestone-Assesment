namespace Q5_FetchSharePointList
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Define the SharePoint site URL and the name of the list
            string siteUrl = "https://sample_sangeeth-tenant.sharepoint.com/sitesNew";
            string listName = "TasksList";

            // Create an instance of SharePointClient
            var client = new SharePointClient(siteUrl);

            try
            {
                // Authenticate to SharePoint
                await client.AuthenticateAsync();
                // Retrieve and display items from the specified list
                await client.GetListItemsAsync(listName);
            }
            catch (HttpRequestException httpEx)
            {
                // Handle specific HTTP errors
                Console.WriteLine($"HTTP Request Error: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                // Handle any other general errors
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Optional: Cleanup resources if necessary
                client.Dispose();
            }
        }
    }
}
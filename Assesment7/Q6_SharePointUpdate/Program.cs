namespace Q6_SharePointUpdate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get user input for SharePoint site URL and list details
            Console.Write("Enter SharePoint Site URL: ");
            string siteUrl = Console.ReadLine();

            Console.Write("Enter List Name: ");
            string listName = Console.ReadLine();

            Console.Write("Enter Item ID: ");
            string itemId = Console.ReadLine();

            Console.Write("Enter Updated Title: ");
            string updatedTitle = Console.ReadLine();

            // Create an instance of SharePointUpdater
            SharePointUpdater updater = new SharePointUpdater();

            // Call the update method
            updater.UpdateListItemAsync(siteUrl, listName, itemId, updatedTitle);
        }
    }
}
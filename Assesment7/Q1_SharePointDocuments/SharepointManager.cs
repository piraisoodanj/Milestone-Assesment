using Microsoft.Identity.Client;
using Microsoft.SharePoint.Client;

namespace Q1_SharePointDocuments
{
    static class SharepointManager
    {
       
        private static string clientId = "gH5kL9mN3-qR7sT4-vU2wX6yZ1-aB8cE0";
        private static string clientSecret = "9R&fZ3p*L$2xQ!kA";


       
        public static List<string> GetDocumentsFromLibrary(string siteUrl, string libraryName)
        {
            List<string> documentNames = new List<string>();

            try
            {
                //Authenticate using Client ID and Secret
                var app = ConfidentialClientApplicationBuilder.Create(clientId)
                    .WithClientSecret(clientSecret)
                    .WithAuthority(new Uri("https://login.microsoftonline.com/b8f9e1d2-a7c3-9f4g-8h2k-jq5z7x1l3m8p"))
                    .Build();

                //Acquire an authentication token for accessing the SharePoint site
                var authResult = app.AcquireTokenForClient(new[] { $"{siteUrl}/.default" }).ExecuteAsync().Result;

                //Create a SharePoint ClientContext for the site
                using (ClientContext context = new ClientContext(siteUrl))
                {
                    //Add the authentication token to the request headers
                    context.ExecutingWebRequest += (s, e) =>
                    {
                        e.WebRequestExecutor.RequestHeaders["Authorization"] = "Bearer " + authResult.AccessToken;
                    };

                    //Get the document library by its name
                    List library = context.Web.Lists.GetByTitle(libraryName);
                    CamlQuery query = CamlQuery.CreateAllItemsQuery(); //Create a query to retrieve all items
                    ListItemCollection items = library.GetItems(query);
                    context.Load(items); //Load the items into the context
                    context.ExecuteQuery(); //Execute the query against SharePoint

                    //Retrieve the names of the documents and add them to the list
                    documentNames = items.Select(item => item["FileLeafRef"].ToString()).ToList();
                }
            }
            catch (Exception ex)
            {
                //Handle general exceptions related to document retrieval
                Console.WriteLine("An error occurred while retrieving documents: " + ex.Message);
            }
            return documentNames; //Return the list of document names
        }

       
        public static void PrintDocumentList(List<string> documents)
        {
            //Check if the document list is empty and inform the user
            if (documents.Count == 0)
            {
                Console.WriteLine("No documents found in the specified library.");
                return;
            }

            //Print the list of documents in a formatted manner
            Console.WriteLine("Document List:");
            foreach (var document in documents)
            {
                Console.WriteLine($"- {document}"); //Print each document name
            }
        }
    }
}

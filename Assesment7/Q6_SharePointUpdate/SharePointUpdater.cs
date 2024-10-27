using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Net.Http.Headers;

namespace Q6_SharePointUpdate
{
    public class SharePointUpdater
    {
        private const string clientId = "gH5kL9mN3-qR7sT4-vU2wX6yZ1-aB8cE0";
        private const string clientSecret = "9R&fZ3p*L$2xQ!kA";
        private const string tenantId = "b8f9e1d2-a7c3-9f4g-8h2k-jq5z7x1l3m8p";
        private static readonly string[] scopes = new[] { "https://graph.microsoft.com/.default" };

        public async Task UpdateListItemAsync(string siteUrl, string listName, string itemId, string updatedTitle)
        {
            // Authenticate and get Graph service client
            GraphServiceClient graphClient = GetAuthenticatedGraphClient();

            try
            {
                // Get the SharePoint site ID from the URL
                var site = await graphClient.Sites.GetByPath(siteUrl, tenantId).Request().GetAsync();

                // Create the dictionary for updated fields
                var updatedFields = new Dictionary<string, object>
                {
                    { "Title", updatedTitle } // Update the Title field
                };

                // Update the list item
                await graphClient.Sites[site.Id].Lists[listName].Items[itemId].Fields.Request().UpdateAsync(new FieldValueSet
                {
                    AdditionalData = updatedFields
                });

                // Output the result
                Console.WriteLine($"Item updated successfully: Task ID {itemId}");
            }
            catch (ServiceException ex)
            {
                // Handle potential errors
                Console.WriteLine($"Error updating item: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        // Method to authenticate and get the GraphServiceClient
        private GraphServiceClient GetAuthenticatedGraphClient()
        {
            IConfidentialClientApplication confidentialClient = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}"))
                .Build();

            // Acquire a token to authenticate
            AuthenticationResult authResult = confidentialClient.AcquireTokenForClient(scopes).ExecuteAsync().Result;

            // Create the GraphServiceClient with the authentication provider
            GraphServiceClient graphClient = new GraphServiceClient(new DelegateAuthenticationProvider((requestMessage) =>
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
                return Task.CompletedTask;
            }));

            return graphClient;
        }
    }
}

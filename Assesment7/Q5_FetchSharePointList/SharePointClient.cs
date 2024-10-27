using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace Q5_FetchSharePointList
{
    public class SharePointClient : IDisposable
    {
        private readonly string _siteUrl;
        private readonly HttpClient _httpClient;
        private string _accessToken;

        public SharePointClient(string siteUrl)
        {
            _siteUrl = siteUrl;
            _httpClient = new HttpClient();
        }

        public async Task AuthenticateAsync()
        {
            //Define your Azure AD application credentials
            var clientId = "gH5kL9mN3-qR7sT4-vU2wX6yZ1-aB8cE0"; //Client ID
            var clientSecret = "9R&fZ3p*L$2xQ!kA"; //Client Secret
            var tenantId = "b8f9e1d2-a7c3-9f4g-8h2k-jq5z7x1l3m8p"; //Tenant ID
            var authority = $"https://login.microsoftonline.com/{tenantId}";

            try
            {
                //Create a confidential client application
                IConfidentialClientApplication app = ConfidentialClientApplicationBuilder
                    .Create(clientId)
                    .WithClientSecret(clientSecret)
                    .WithAuthority(new Uri(authority))
                    .Build();

                //Define the required scopes
                string[] scopes = new[] { $"{_siteUrl}/.default" };

                //Acquire an access token for the client
                AuthenticationResult result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
                _accessToken = result.AccessToken;

                //Set the Authorization header for the HttpClient
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            }
            catch (MsalException msalEx)
            {
                //Handle specific authentication errors
                Console.WriteLine($"Authentication Error: {msalEx.Message}");
                throw; //Rethrow to handle at a higher level
            }
            catch (Exception ex)
            {
                //Handle any other exceptions during authentication
                Console.WriteLine($"An error occurred during authentication: {ex.Message}");
                throw; //Rethrow to handle at a higher level
            }
        }

        public async Task GetListItemsAsync(string listName)
        {
            try
            {
                //Construct the request URL for the SharePoint list items
                var requestUrl = $"{_siteUrl}/_api/web/lists/getbytitle('{listName}')/items";

                //Send the GET request to retrieve list items
                var response = await _httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode(); //Throw an exception if the response is not successful

                //Read and parse the JSON response
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var items = JObject.Parse(jsonResponse)["value"];

                //Display the items in the console
                Console.WriteLine($"{listName} List:");
                foreach (var item in items)
                {
                    Console.WriteLine($"- {item["Title"]}: {item["Description"]}");
                }
            }
            catch (HttpRequestException httpEx)
            {
                //Handle specific HTTP errors
                Console.WriteLine($"HTTP Request Error: {httpEx.Message}");
                throw; //Rethrow to handle at a higher level
            }
            catch (Exception ex)
            {
                //Handle any other exceptions during data retrieval
                Console.WriteLine($"An error occurred while retrieving list items: {ex.Message}");
                throw; //Rethrow to handle at a higher level
            }
        }

        public void Dispose()
        {
            //Dispose of the HttpClient when done
            _httpClient.Dispose();
        }
    }
}

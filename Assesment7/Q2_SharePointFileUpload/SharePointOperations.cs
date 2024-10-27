using Microsoft.Identity.Client;
using Microsoft.SharePoint.Client;
using File = System.IO.File;

namespace Q2_SharePointFileUpload
{
    public class SharePointOperations
    {
        private string siteUrl;
        private string libraryName;
        private string clientId;
        private string clientSecret;

        //Constructor to initialize SharePoint configurations
        public SharePointOperations(string siteUrl, string libraryName, string clientId, string clientSecret)
        {
            this.siteUrl = siteUrl;
            this.libraryName = libraryName;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }

        
        public void UploadFile(string filePath)
        {
            //Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found: " + filePath);
                return;
            }

            try
            {
                //Authenticate using Client ID and Secret
                var app = ConfidentialClientApplicationBuilder.Create(clientId)
                    .WithClientSecret(clientSecret)
                    .WithAuthority(new Uri("https://login.microsoftonline.com/b8f9e1d2-a7c3-9f4g-8h2k-jq5z7x1l3m8p")) //tenant ID
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

                    //Get the target document library
                    List library = context.Web.Lists.GetByTitle(libraryName);

                    //Create a FileCreationInformation object to specify the file upload parameters
                    FileCreationInformation newFile = new FileCreationInformation
                    {
                        ContentStream = new FileStream(filePath, FileMode.Open), //Open the file stream
                        Url = Path.GetFileName(filePath), //Set the name for the file in SharePoint
                        Overwrite = true //Allow overwriting of the file if it exists
                    };

                    //Upload the file to the library
                    Microsoft.SharePoint.Client.File uploadFile = library.RootFolder.Files.Add(newFile);
                    context.Load(uploadFile); //Load the file object to get its properties
                    context.ExecuteQuery(); //Execute the query to perform the upload

                    //Notify the user of the successful upload
                    Console.WriteLine($"File uploaded successfully: {uploadFile.Name}");
                }
            }
            catch (Exception ex)
            {
                //Handle general exceptions related to file upload
                Console.WriteLine("An error occurred while uploading the file: " + ex.Message);
            }
        }
    }
}

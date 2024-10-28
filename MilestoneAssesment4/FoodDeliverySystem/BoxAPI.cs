using Box.V2.Config;
using Box.V2.JWTAuth;
using Box.V2.Models;
using System.Net.Http.Headers;
namespace FoodDeliveryManagement
{
    class BoxAPI
    {
        private static readonly HttpClient client = new HttpClient();

        //Box API endpoint for uploading files
        private static string uploadUrl = "https://upload.box.com/api/2.0/files/content";

        //The access token obtained from Box Developer Console
        private static string developerToken = "******GNiuEZh5PZn2sJ6y2V6kqmKwzcDN";

        public async Task<string> UploadFileToBox(string fileName)
        {
            try
            {
                string clientId = "*****pryp7oed24pzh0eu6chfxftn3nbs";
                string clientSecret = "**naSXpxPHr86kLL7E7mvBUKpNorki7";
                var boxConfig = new BoxConfig(clientId, clientSecret, new Uri("http://localhost"));
                var boxJWTAuth = new BoxJWTAuth(boxConfig);
                var boxClient = boxJWTAuth.AdminClient(developerToken);
                using (var stream = new FileStream(fileName, FileMode.Open))
                {
                    var fileRequest = new BoxFileRequest
                    {
                        Name = Path.GetFileName(fileName),
                        Parent = new BoxRequestEntity { Id = "0", Type = BoxType.file },
                    };

                    var uplaodedFile = await boxClient.FilesManager.UploadAsync(fileRequest, stream);
                    return "file uploaded - FileId: " + uplaodedFile.Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return "file failed to upload";
            }
        }

        public async Task<string> DownloadFileFromBox(string fileID)
        {
            try
            {
                string clientId = "3k7cpryp7oed24pzh0eu6chf********";
                string clientSecret = "cRpnaSXpxPHr86kLL7E7mvBUKp***";
                var boxConfig = new BoxConfig(clientId, clientSecret, new Uri("http://localhost"));
                var boxJWTAuth = new BoxJWTAuth(boxConfig);
                var boxClient = boxJWTAuth.AdminClient(developerToken);

                BoxFile file = await boxClient.FilesManager.GetInformationAsync(id: fileID);
                Stream fileContents = await boxClient.FilesManager.DownloadAsync(id: fileID);


                //Specify the local path where you want to save the downloaded file
                string localPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                localPath = Path.GetDirectoryName(localPath);
                string subPath = localPath + @"\Downloads";

                try
                {
                    if (!Directory.Exists(subPath))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(subPath);
                    }
                }
                catch (IOException ioex)
                {
                    Console.WriteLine(ioex.Message);
                }

            

                using (var fileStream = File.Create(subPath + @"\" + file.Name))
                {
                    fileContents.CopyTo(fileStream);

                }
                return "file downloaded to the location\n" + subPath + @"\" + file.Name;
            }
            catch (Exception)
            {
                return "file failed to upload";
            }

        }

        public static async Task UploadFileToBox1(string filePath, string fileName, string folderId = "0")
        {
            var reader = new StreamReader("config.json");
            var json = reader.ReadToEnd();
            var config = BoxConfig.CreateFromJsonString(json);
            var sdk = new BoxJWTAuth(config);
            var token = await sdk.AdminTokenAsync();
            var boxClient = sdk.AdminClient(token);

            //Create multipart form data
            var form = new MultipartFormDataContent();

            //Add file data
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "file",
                    FileName = fileName
                };
                form.Add(fileContent);
            }

            //Add parent folder ID
            form.Add(new StringContent(folderId), "parent_id");

            //Set the authorization header
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", developerToken);

            //Send the POST request
            var response = await client.PostAsync(uploadUrl, form);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"File uploaded successfully: {fileName}");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error uploading file: " + error);
            }
        }
    }
}

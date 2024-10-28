using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FoodDeliveryManagement
{
    public class ServiceNowApi
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<ServiceNowIncident>> GetIncidentData()
        {
            var serviceNowInstance = "https://dev201893.service-now.com";
            var user = "admin";
            var password = "pass";

            // Set up basic authentication
            var authToken = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{user}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

            // API Endpoint to fetch incidents related to restaurant services (custom query)
            var url = $"{serviceNowInstance}/api/now/table/incident?sysparm_query=short_descriptionLIrestaurant";

            // Send GET request to ServiceNow API
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                // Read the response content as JSON
                var responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize JSON response to a list of ServiceNowIncident objects
                var incidents = JsonConvert.DeserializeObject<ServiceNowResponse>(responseBody);
                return incidents.Result;
            }
            else
            {
                Console.WriteLine("Error fetching data from ServiceNow.");
                return null;
            }
        }
    }
}

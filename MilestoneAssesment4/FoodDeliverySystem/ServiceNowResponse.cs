using Newtonsoft.Json;

namespace FoodDeliveryManagement
{
    public class ServiceNowResponse
    {
        [JsonProperty("result")]
        public List<ServiceNowIncident> Result { get; set; }
    }
}

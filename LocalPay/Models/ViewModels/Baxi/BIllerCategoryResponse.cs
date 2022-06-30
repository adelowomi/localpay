using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class BillerCategoryResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("service_type")]
        public string ServiceType { get; set; }
    }
}
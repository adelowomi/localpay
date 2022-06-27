using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class BIllerCategoryResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("service_type")]
        public string ServiceType { get; set; }
    }
}
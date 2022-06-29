using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class BillerResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("serviceId")]
        public string ServiceId { get; set; }

        [JsonProperty("serviceCode")]
        public string ServiceCode { get; set; }

        [JsonProperty("serviceCategory")]
        public string ServiceCategory { get; set; }

        [JsonProperty("serviceType")]
        public string ServiceType { get; set; }

        [JsonProperty("serviceName")]
        public string ServiceName { get; set; }

        [JsonProperty("serviceDescription")]
        public string ServiceDescription { get; set; }

        [JsonProperty("serviceHandler")]
        public string ServiceHandler { get; set; }

        [JsonProperty("serviceProvider")]
        public string ServiceProvider { get; set; }

        [JsonProperty("serviceEnabled")]
        public string ServiceEnabled { get; set; }

        [JsonProperty("serviceStatus")]
        public string ServiceStatus { get; set; }

        [JsonProperty("deployed")]
        public string Deployed { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}
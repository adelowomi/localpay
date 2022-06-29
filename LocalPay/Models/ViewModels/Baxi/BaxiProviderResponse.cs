using System.Collections.Generic;
using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class BaxiProviderResponse
    {
        [JsonProperty("service_type")]
        public string ServiceType { get; set; }

        [JsonProperty("shortname")]
        public string Shortname { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("plans")]
        public List<string> Plans { get; set; }
    }
}
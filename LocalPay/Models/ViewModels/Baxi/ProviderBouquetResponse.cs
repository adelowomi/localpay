using Newtonsoft.Json;
using System.Collections.Generic;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class ProviderBouquetResponse
    {
        [JsonProperty("availablePricingOptions")]
        public List<AvailablePricingOptionResponse> AvailablePricingOptions { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}

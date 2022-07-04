using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class ProviderResponse
    {
       
        [JsonProperty("service_type")]
        public string ServiceType { get; set; }

        [JsonProperty("shortname")]
        public string Shortname { get; set; }

        [JsonProperty("biller_id")]
        public int BillerId { get; set; }

        [JsonProperty("product_id")]
        public int ProductId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
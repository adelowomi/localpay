using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class ProviderBundleResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("allowance")]
        public string Allowance { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("validity")]
        public string Validity { get; set; }

        [JsonProperty("datacode")]
        public int Datacode { get; set; }
    }
}

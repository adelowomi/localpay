using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class EpinBundleResponse
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}

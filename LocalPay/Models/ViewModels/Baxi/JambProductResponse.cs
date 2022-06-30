using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class JambProductResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("product_code")]
        public string ProductCode { get; set; }
    }
}

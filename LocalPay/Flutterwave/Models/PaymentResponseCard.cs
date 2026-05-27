using Newtonsoft.Json;

namespace LocalPay.Flutterwave.Models
{
    public class PaymentResponseCard
    {
        [JsonProperty("first_6digits")]
        public string? First6Digits { get; set; }

        [JsonProperty("last_4digits")]
        public string? Last4Digits { get; set; }

        [JsonProperty("issuer")]
        public string? Issuer { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }

        [JsonProperty("expiry")]
        public string? Expiry { get; set; }
    }
}

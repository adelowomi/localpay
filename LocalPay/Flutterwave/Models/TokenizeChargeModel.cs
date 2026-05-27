using Newtonsoft.Json;

namespace LocalPay.Flutterwave.Models
{
    public class TokenizeChargeModel
    {
        [JsonProperty("token")]
        public string Token { get; set; } = string.Empty;

        [JsonProperty("currency")]
        public string Currency { get; set; } = "NGN";

        [JsonProperty("country")]
        public string Country { get; set; } = "NG";

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? FirstName { get; set; }

        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? LastName { get; set; }

        [JsonProperty("ip", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ip { get; set; }

        [JsonProperty("narration", NullValueHandling = NullValueHandling.Ignore)]
        public string? Narration { get; set; }

        [JsonProperty("tx_ref")]
        public string TxRef { get; set; } = string.Empty;
    }
}

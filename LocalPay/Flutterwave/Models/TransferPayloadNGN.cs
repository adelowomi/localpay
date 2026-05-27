using Newtonsoft.Json;

namespace LocalPay.Flutterwave.Models
{
    public class TransferPayloadNGN
    {
        [JsonProperty("account_bank")]
        public string AccountBank { get; set; } = string.Empty;

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; } = string.Empty;

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("narration", NullValueHandling = NullValueHandling.Ignore)]
        public string? Narration { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; } = "NGN";

        [JsonProperty("reference")]
        public string Reference { get; set; } = string.Empty;

        [JsonProperty("callback_url", NullValueHandling = NullValueHandling.Ignore)]
        public string? CallbackUrl { get; set; }

        [JsonProperty("debit_currency")]
        public string DebitCurrency { get; set; } = "NGN";
    }
}

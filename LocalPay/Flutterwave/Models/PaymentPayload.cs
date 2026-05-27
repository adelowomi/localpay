using Newtonsoft.Json;

namespace LocalPay.Flutterwave.Models
{
    public class PaymentPayload
    {
        [JsonProperty("tx_ref")]
        public string TxRef { get; set; } = string.Empty;

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; } = "NGN";

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; } = string.Empty;

        [JsonProperty("payment_options", NullValueHandling = NullValueHandling.Ignore)]
        public string? PaymentOptions { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; } = new Customer();

        [JsonProperty("customizations", NullValueHandling = NullValueHandling.Ignore)]
        public Customization? Customizations { get; set; }
    }
}

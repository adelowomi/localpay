using Newtonsoft.Json;

namespace LocalPay.Flutterwave.Models
{
    public class RefundPayload
    {
        /// <summary>
        /// Optional partial-refund amount. Omit to refund the full transaction.
        /// </summary>
        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Amount { get; set; }

        [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
        public string? Comments { get; set; }
    }
}

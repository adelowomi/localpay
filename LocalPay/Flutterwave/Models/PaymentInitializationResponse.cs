using Newtonsoft.Json;

namespace LocalPay.Flutterwave.Models
{
    public class PaymentInitializationResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("data")]
        public PaymentInitializationResponseData? Data { get; set; }
    }

    public class PaymentInitializationResponseData
    {
        [JsonProperty("link")]
        public string Link { get; set; } = string.Empty;
    }
}

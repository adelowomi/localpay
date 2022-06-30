using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class AirtimeResponse
    {
        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("transactionStatus")]
        public string TransactionStatus { get; set; }

        [JsonProperty("transactionReference")]
        public int TransactionReference { get; set; }

        [JsonProperty("transactionMessage")]
        public string TransactionMessage { get; set; }
    }
}

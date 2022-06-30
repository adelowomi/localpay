using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class AccountRawOutputResponse
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("outstandingAmount")]
        public int OutstandingAmount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("minimumAmount")]
        public int MinimumAmount { get; set; }

        [JsonProperty("customerAccountType")]
        public string CustomerAccountType { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("customerDtNumber")]
        public string CustomerDtNumber { get; set; }
    }
}

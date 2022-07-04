using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class AccountRawOutputResponse
    {
       [JsonProperty("canVend")]
        public bool CanVend { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("meterNumber")]
        public string MeterNumber { get; set; }

        [JsonProperty("minimumAmount")]
        public object MinimumAmount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("customerAccountType")]
        public string CustomerAccountType { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("customerDtNumber")]
        public string CustomerDtNumber { get; set; }

        [JsonProperty("debtAmount")]
        public object DebtAmount { get; set; }
    }
}

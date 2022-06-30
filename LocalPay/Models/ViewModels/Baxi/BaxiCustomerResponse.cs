using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class BaxiCustomerResponse<T>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("outstandingBalance")]
        public int OutstandingBalance { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("minimumAmount")]
        public int MinimumAmount { get; set; }

        [JsonProperty("rawOutput")]
        public T RawOutput { get; set; }

    }
}

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
        public object OutstandingBalance { get; set; }

        [JsonProperty("dueDate")]
        public  object DueDate { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("minimumAmount")]
        public string MinimumAmount { get; set; }

        [JsonProperty("rawOutput")]
        public T RawOutput { get; set; }
        
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

    }
}

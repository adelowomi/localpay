using Newtonsoft.Json;
using System;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class RawOutputResponse
    {
        [JsonProperty("accountStatus")]
        public string AccountStatus { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("customerType")]
        public string CustomerType { get; set; }

        [JsonProperty("invoicePeriod")]
        public int InvoicePeriod { get; set; }

        [JsonProperty("dueDate")]
        public DateTime DueDate { get; set; }

        [JsonProperty("customerNumber")]
        public int CustomerNumber { get; set; }
    }
}
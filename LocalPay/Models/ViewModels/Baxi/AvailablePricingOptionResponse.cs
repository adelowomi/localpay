using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class AvailablePricingOptionResponse
    {
        [JsonProperty("monthsPaidFor")]
        public int MonthsPaidFor { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("invoicePeriod")]
        public int InvoicePeriod { get; set; }
    }
}
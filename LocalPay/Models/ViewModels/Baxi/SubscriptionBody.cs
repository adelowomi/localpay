using System;
using System.Text.Json.Serialization;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class SubscriptionBody :BaxiBody
    {
        [JsonPropertyName("isBoxOffice")]
        public bool IsBoxOffice { get; set; }

        [JsonPropertyName("total_amount")]
        public string TotalAmount { get; set; }

        [JsonPropertyName("product_monthsPaidFor")]
        public string ProductMonthsPaidFor { get; set; }

        [JsonPropertyName("product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName("smartcard_number")]
        public string SmartcardNumber { get; set; }


    }
}

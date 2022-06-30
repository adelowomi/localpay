using System.Text.Json.Serialization;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class CableSubscriptionBody :BaxiBody
    {
        [JsonPropertyName("total_amount")]
        public string TotalAmount { get; set; }

        [JsonPropertyName("addon_monthsPaidFor")]
        public string AddonMonthsPaidFor { get; set; }

        [JsonPropertyName("addon_code")]
        public string AddonCode { get; set; }

        [JsonPropertyName("product_monthsPaidFor")]
        public string ProductMonthsPaidFor { get; set; }

        [JsonPropertyName("product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName("smartcard_number")]
        public string SmartcardNumber { get; set; }


    }
}

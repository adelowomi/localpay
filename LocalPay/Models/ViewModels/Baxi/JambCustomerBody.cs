using System.Text.Json.Serialization;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class JambCustomerBody : ProviderBundleBody
    {
        [JsonPropertyName("product_code")]
        public string ProductCode { get; set; }
    }
}

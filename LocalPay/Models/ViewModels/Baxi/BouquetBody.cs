using System.Text.Json.Serialization;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class BouquetBody
    {
        [JsonPropertyName("product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName("service_type")]
        public string ServiceType { get; set; }
    }
}

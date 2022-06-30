using System.Text.Json.Serialization;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class ProviderBundleBody
    {
        [JsonPropertyName("service_type")]
        public string ServiceType { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }
    }
}

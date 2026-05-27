using Newtonsoft.Json;

namespace LocalPay.Flutterwave.Models
{
    public class Customer
    {
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("phonenumber")]
        public string? PhoneNumber { get; set; }
    }
}

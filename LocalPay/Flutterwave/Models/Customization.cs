using Newtonsoft.Json;

namespace LocalPay.Flutterwave.Models
{
    public class Customization
    {
        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("logo")]
        public string? Logo { get; set; }
    }
}

using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class JambProviderResponse
    {
        [JsonProperty("baxiReference")]
        public int BaxiReference { get; set; }

        [JsonProperty("provider_status")]
        public string ProviderStatus { get; set; }

        [JsonProperty("provider_status_code")]
        public object ProviderStatusCode { get; set; }

        [JsonProperty("provider_message")]
        public object ProviderMessage { get; set; }

        [JsonProperty("provider_reference")]
        public object ProviderReference { get; set; }

        [JsonProperty("token_pin")]
        public string TokenPin { get; set; }

        [JsonProperty("provider_data")]
        public ProviderDataResponse ProviderData { get; set; }
    }
}
